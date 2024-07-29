﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Abstract class which every Mid should inherit, containing all of default data, such as <see cref="Header"/> data and methods.
    /// </summary>
    public abstract class Mid
    {
        protected const int DEFAULT_REVISION = 1;

        protected Dictionary<int, List<DataField>> RevisionsByFields { get; }
        public Header Header { get; set; }

        public Mid(Header header)
        {
            Header = header;
            RevisionsByFields = new SafeAccessRevisionsFields(RegisterDatafields());
        }

        public Mid(int mid, int revision, bool noAckFlag = false) : this(new Header()
        {
            Mid = mid,
            Revision = revision,
            NoAckFlag = noAckFlag
        })
        {

        }

        protected virtual byte[] BuildRawHeader() => ToBytes(BuildHeader());

        protected virtual string BuildHeader()
        {
            if (RevisionsByFields.Any())
            {
                Header.Length = 20;
                for (int i = 1; i <= (Header.Revision > 0 ? Header.Revision : 1); i++)
                {
                    if (RevisionsByFields.TryGetValue(i, out var dataFields))
                    {
                        foreach (var dataField in dataFields)
                            Header.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
                    }
                }
            }
            return Header.ToString();
        }

        public virtual string Pack()
        {
            var header = BuildHeader();
            if (!RevisionsByFields.Any())
                return header;

            var builder = new StringBuilder(header);
            builder.Append(PackDataFields());
            return builder.ToString();
        }

        public virtual byte[] PackBytes() => Encoding.ASCII.GetBytes(Pack());

        internal string PackDataFields()
        {
            var builder = new StringBuilder();
            int prefixIndex = 1;
            var revision = (Header.Revision > 0 ? Header.Revision : 1);
            for (int i = 1; i <= revision; i++)
            {
                builder.Append(Pack(i, ref prefixIndex));
            }

            return builder.ToString();
        }

        protected virtual string Pack(int revision, ref int prefixIndex)
        {
            if (!RevisionsByFields.TryGetValue(revision, out var dataFields))
            {
                return string.Empty;
            }

            return Pack(dataFields, ref prefixIndex);
        }

        protected virtual string Pack(List<DataField> dataFields, ref int prefixIndex)
        {
            var builder = new StringBuilder();
            foreach (var dataField in dataFields)
            {
                if (dataField.HasPrefix)
                {
                    builder.Append(prefixIndex.ToString("D2"));
                    prefixIndex++;
                }

                builder.Append(dataField.Value);
            }

            return builder.ToString();
        }

        protected virtual Dictionary<int, List<DataField>> RegisterDatafields() => new();

        protected virtual Header ProcessHeader(string package)
        {
            if (package.Length < 20)
            {
                package = package.PadRight(20, ' ');
            }

            static bool IsNotEmptyOrZero(string package, out int value)
            {
                value = 0;
                return !string.IsNullOrWhiteSpace(package) && int.TryParse(package, out value) && value > 0;
            }

            var header = new Header
            {
                Length = int.Parse(package.Substring(0, 4)),
                Mid = int.Parse(package.Substring(4, 4)),
                Revision = IsNotEmptyOrZero(package.Substring(8, 3), out var revision) ? revision : 1,
                NoAckFlag = !string.IsNullOrWhiteSpace(package.Substring(11, 1)),
                StationId = int.TryParse(package.Substring(12, 2), out var stationId) ? stationId : 1,
                SpindleId = int.TryParse(package.Substring(14, 2), out var spindleId) ? spindleId : 1,
                SequenceNumber = IsNotEmptyOrZero(package.Substring(16, 2), out var sequenceNumber) ? sequenceNumber : default(int?),
                NumberOfMessages = IsNotEmptyOrZero(package.Substring(18, 1), out var numberOfMessages) ? numberOfMessages : default(int?),
                MessageNumber = IsNotEmptyOrZero(package.Substring(19, 1), out var messageNumber) ? messageNumber : default(int?)
            };

            return header;
        }

        public virtual Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            ProcessDataFields(package);
            return this;
        }

        public virtual Mid Parse(byte[] package)
        {
            var pack = ToAscii(package);
            return Parse(pack);
        }

        protected virtual void ProcessDataFields(string package)
        {
            if (!RevisionsByFields.Any())
                return;

            int revision = Header.Revision > 0 ? Header.Revision : 1;
            for (int i = 1; i <= revision; i++)
            {
                ProcessDataFields(i, package);
            }
        }

        protected virtual void ProcessDataFields(int revision, string package)
        {
            if (RevisionsByFields.TryGetValue(revision, out var fields))
            {
                ProcessDataFields(fields, package);
            }
        }

        protected virtual void ProcessDataFields(List<DataField> dataFields, string package)
        {
            foreach (var dataField in dataFields)
                dataField.Value = GetValue(dataField, package);
        }

        protected string GetValue(DataField field, string package)
        {
            try
            {
                return field.HasPrefix ? package.Substring(2 + field.Index, field.Size) : package.Substring(field.Index, field.Size);
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }

        protected byte[] GetValue(DataField field, byte[] package)
        {
            try
            {
                byte[] bytes = new byte[field.Size];
                var index = field.HasPrefix ? 2 + field.Index : field.Index;
                int j = 0;
                for (int i = index; i < index + field.Size; i++)
                {
                    bytes[j] = package[i];
                    j++;
                }

                return bytes;
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }

        protected DataField GetField(int revision, int field)
        {
            if (!RevisionsByFields.TryGetValue(revision, out var fields))
            {
                return DataField.Default;
            }

            return fields.FirstOrDefault(x => x.Field == field) ?? DataField.Default;
        }

        protected DataField GetField<TEnum>(int revision, TEnum field) where TEnum : struct, Enum
            => GetField(revision, field.GetHashCode());

        protected static string ToAscii(byte[] bytes) => Encoding.ASCII.GetString(bytes);

        protected static byte[] ToBytes(string value) => Encoding.ASCII.GetBytes(value);

    }
}
