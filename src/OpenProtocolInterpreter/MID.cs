using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter
{
    public abstract class Mid : IMid
    {
        public Dictionary<int, List<DataField>> RevisionsByFields { get; set; }
        public Header HeaderData { get; set; }

        public Mid(Header header)
        {
            HeaderData = header;
            RevisionsByFields = CachedFields.GetRegisteredFields(header.Mid, RegisterDatafields);
        }

        public Mid(int mid, int revision, int? noAckFlag = null, int? spindleID = null, int? stationID = null, IEnumerable<DataField> usedAs = null)
        {
            HeaderData = new Header()
            {
                Length = 20,
                Mid = mid,
                Revision = revision,
                NoAckFlag = noAckFlag,
                SpindleID = spindleID,
                StationID = stationID,
                UsedAs = usedAs
            };
            RevisionsByFields = CachedFields.GetRegisteredFields(mid, RegisterDatafields);
        }

        protected virtual byte[] BuildRawHeader() => ToBytes(BuildHeader());

        protected virtual string BuildHeader()
        {
            if (RevisionsByFields.Any())
            {
                HeaderData.Length = 20;
                for (int i = 1; i <= (HeaderData.Revision > 0 ? HeaderData.Revision : 1); i++)
                    foreach (var dataField in RevisionsByFields[i])
                        HeaderData.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
            }
            return HeaderData.ToString();
        }

        public virtual string Pack()
        {
            if (!RevisionsByFields.Any())
                return BuildHeader();

            string package = BuildHeader();
            int prefixIndex = 1;
            for (int i = 1; i <= (HeaderData.Revision > 0 ? HeaderData.Revision : 1); i++)
                package += Pack(RevisionsByFields[i], ref prefixIndex);

            return package;
        }

        public virtual byte[] PackBytes() => Encoding.ASCII.GetBytes(Pack());

        protected virtual string Pack(List<DataField> dataFields, ref int prefixIndex)
        {
            string package = string.Empty;
            foreach (var dataField in dataFields)
            {
                if (dataField.HasPrefix)
                {
                    package += prefixIndex.ToString().PadLeft(2, '0') + dataField.Value;
                    prefixIndex++;
                }
                else
                    package += dataField.Value;
            }

            return package;
        }

        protected virtual Dictionary<int, List<DataField>> RegisterDatafields() => new Dictionary<int, List<DataField>>();

        protected virtual Header ProcessHeader(string package)
        {
            Header header = new Header
            {
                Length = Convert.ToInt32(package.Substring(0, 4)),
                Mid = Convert.ToInt32(package.Substring(4, 4)),
                Revision = (package.Length >= 11 && !string.IsNullOrWhiteSpace(package.Substring(8, 3))) ? Convert.ToInt32(package.Substring(8, 3)) : 0,
                NoAckFlag = (package.Length >= 12 && !string.IsNullOrWhiteSpace(package.Substring(11, 1))) ? (int?)Convert.ToInt32(package.Substring(11, 1)) : null,
                StationID = (package.Length >= 14 && !string.IsNullOrWhiteSpace(package.Substring(12, 2))) ? (int?)Convert.ToInt32(package.Substring(12, 2)) : null,
                SpindleID = (package.Length >= 16 && !string.IsNullOrWhiteSpace(package.Substring(14, 2))) ? (int?)Convert.ToInt32(package.Substring(14, 2)) : null
            };

            return header;
        }

        public virtual Mid Parse(string package)
        {
            HeaderData = ProcessHeader(package);
            ProcessDataFields(package);
            return this;
        }

        public virtual Mid Parse(byte[] package)
        {
            var pack = ToAscii(package); //Mostly ASCII encoding
            return Parse(pack);
        }

        protected virtual void ProcessDataFields(string package)
        {
            if (!RevisionsByFields.Any())
                return;

            int revision = HeaderData.Revision > 0 ? HeaderData.Revision : 1;
            for (int i = 1; i <= revision; i++)
                ProcessDataFields(RevisionsByFields[i], package);
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

        protected DataField GetField(int revision, int field) => RevisionsByFields[revision].FirstOrDefault(x => x.Field == field);

        protected string ToAscii(byte[] bytes) => Encoding.ASCII.GetString(bytes);

        protected byte[] ToBytes(string value) => Encoding.ASCII.GetBytes(value);

        public class Header
        {
            public int Length { get; internal set; }
            public int Mid { get; internal set; }
            public int Revision { get; internal set; }
            public int? NoAckFlag { get; set; }
            public int? SpindleID { get; set; }
            public int? StationID { get; set; }
            public IEnumerable<DataField> UsedAs { get; set; }

            public override string ToString()
            {
                string header = string.Empty;
                header += Length.ToString().PadLeft(4, '0');
                header += Mid.ToString().PadLeft(4, '0');
                header += (Revision > 0) ? Revision.ToString().PadLeft(3, '0') : string.Empty.PadLeft(3, ' ');
                header += NoAckFlag.ToString().PadLeft(1, ' ');
                header += (StationID != null) ? StationID.ToString().PadLeft(2, '0') : StationID.ToString().PadLeft(2, ' ');
                header += (SpindleID != null) ? SpindleID.ToString().PadLeft(2, '0') : SpindleID.ToString().PadLeft(2, ' ');
                string usedAs = "    ";
                if (UsedAs != null)
                {
                    usedAs = string.Empty;
                    foreach (DataField field in UsedAs)
                        usedAs += field.Value.ToString();
                }
                header += usedAs;
                return header;
            }
        }
    }
}
