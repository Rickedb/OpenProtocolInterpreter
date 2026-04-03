using System;
using System.Collections.Generic;
using System.Linq;
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
                Header.Length = Header.DefaultSize;
                for (int i = 1; i <= Header.StandardizedRevision; i++)
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
            int prefixIndex = 1;
            var revision = Header.StandardizedRevision;
            for (int i = 1; i <= revision; i++)
            {
                builder.Append(Pack(i, ref prefixIndex));
            }

            return builder.ToString();
        }

        public virtual byte[] PackBytes() => Encoding.ASCII.GetBytes(Pack());

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

        protected virtual Dictionary<int, List<DataField>> RegisterDatafields() => [];

        protected virtual Header ProcessHeader(string package)
            => ProcessHeader(package.AsSpan());

        protected virtual Header ProcessHeader(ReadOnlySpan<char> package)
        {
            if (package.Length < 20)
            {
                Span<char> buffer = stackalloc char[20];
                package.CopyTo(buffer);
                buffer.Slice(package.Length).Fill(' ');
                return ParseHeader(buffer);
            }

            return ParseHeader(package);
        }

        public virtual Mid Parse(string package)
            => Parse(package.AsSpan());

        public virtual Mid Parse(ReadOnlySpan<char> package)
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

        protected virtual void ProcessDataFields(ReadOnlySpan<char> package)
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
            => ProcessDataFields(revision, package.AsSpan());

        protected virtual void ProcessDataFields(int revision, ReadOnlySpan<char> package)
        {
            if (RevisionsByFields.TryGetValue(revision, out var fields))
            {
                ProcessDataFields(fields, package);
            }
        }

        protected virtual void ProcessDataFields(List<DataField> dataFields, string package)
            => ProcessDataFields(dataFields, package.AsSpan());

        protected virtual void ProcessDataFields(List<DataField> dataFields, ReadOnlySpan<char> package)
        {
            foreach (var dataField in dataFields)
                dataField.SetValue(GetValue(dataField, package));
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

        protected ReadOnlySpan<char> GetValue(DataField field, ReadOnlySpan<char> package)
        {
            try
            {
                return field.HasPrefix ? package.Slice(2 + field.Index, field.Size) : package.Slice(field.Index, field.Size);
            }
            catch (ArgumentOutOfRangeException)
            {
                return ReadOnlySpan<char>.Empty;
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
        protected static Span<byte> ToBytesSpan(string value) => ToBytes(value.AsSpan());
        protected static Span<byte> ToBytes(ReadOnlySpan<char> value)
        {
            var buffer = new byte[value.Length];
#if NETSTANDARD2_0
            Encoding.ASCII.GetBytes(value.ToString(), 0, value.Length, buffer, 0);
#else
            Encoding.ASCII.GetBytes(value, buffer);
#endif
            return buffer;
        }

        private Header ParseHeader(ReadOnlySpan<char> package)
        {
#if NETSTANDARD2_0
            static bool IsNotEmptyOrZero(ReadOnlySpan<char> package, out int value)
            {
                value = 0;
                return !package.IsWhiteSpace() && int.TryParse(package.ToString(), out value) && value > 0;
            }
            static int ParseInt(ReadOnlySpan<char> span) => int.Parse(span.ToString());
            static bool TryParseInt(ReadOnlySpan<char> span, out int value) => int.TryParse(span.ToString(), out value);
#else
            static bool IsNotEmptyOrZero(ReadOnlySpan<char> package, out int value)
            {
                value = 0;
                return !package.IsWhiteSpace() && int.TryParse(package, out value) && value > 0;
            }
            static int ParseInt(ReadOnlySpan<char> span) => int.Parse(span);
            static bool TryParseInt(ReadOnlySpan<char> span, out int value) => int.TryParse(span, out value);
#endif

            return new Header
            {
                Length = ParseInt(package.Slice(0, 4)),
                Mid = ParseInt(package.Slice(4, 4)),
                Revision = IsNotEmptyOrZero(package.Slice(8, 3), out var revision) ? revision : 1,
                NoAckFlag = !package.Slice(11, 1).IsWhiteSpace(),
                StationId = TryParseInt(package.Slice(12, 2), out var stationId) ? stationId : 1,
                SpindleId = TryParseInt(package.Slice(14, 2), out var spindleId) ? spindleId : 1,
                SequenceNumber = IsNotEmptyOrZero(package.Slice(16, 2), out var sequenceNumber) ? sequenceNumber : default(int?),
                NumberOfMessages = IsNotEmptyOrZero(package.Slice(18, 1), out var numberOfMessages) ? numberOfMessages : default(int?),
                MessageNumber = IsNotEmptyOrZero(package.Slice(19, 1), out var messageNumber) ? messageNumber : default(int?)
            };
        }
    }
}
