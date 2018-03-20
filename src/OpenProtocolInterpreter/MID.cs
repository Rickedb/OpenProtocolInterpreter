using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter
{
    public abstract class MID : IMID
    {
        protected IMID NextTemplate;

        public Dictionary<int, List<DataField>> RevisionsByFields { get; set; }
        public Header HeaderData { get; set; }

        public MID(Header header)
        {
            HeaderData = header;
            RevisionsByFields = new Dictionary<int, List<DataField>>();
            RegisterDatafields();
        }

        //public MID(int length, int MID, int? revision, int? noAckFlag = null, int? spindleID = null, int? stationID = null, IEnumerable<DataField> usedAs = null)
        //{
        //    HeaderData = new Header()
        //    {
        //        Length = length,
        //        Mid = MID,
        //        Revision = revision,
        //        NoAckFlag = noAckFlag,
        //        SpindleID = spindleID,
        //        StationID = stationID,
        //        UsedAs = usedAs
        //    };
        //    RevisionsByFields = new Dictionary<int, List<DataField>>();
        //    RegisterDatafields();
        //}

        public MID(int MID, int revision, int? noAckFlag = null, int? spindleID = null, int? stationID = null, IEnumerable<DataField> usedAs = null)
        {
            HeaderData = new Header()
            {
                Length = 20,
                Mid = MID,
                Revision = revision,
                NoAckFlag = noAckFlag,
                SpindleID = spindleID,
                StationID = stationID,
                UsedAs = usedAs
            };
            RevisionsByFields = new Dictionary<int, List<DataField>>();
            RegisterDatafields();
        }

        protected bool IsCorrectType(string package)
        {
            if (int.TryParse(package.Substring(4, 4), out int mid))
                return (mid == HeaderData.Mid);

            return false;
        }

        protected virtual string BuildHeader() { return HeaderData.ToString(); }

        public virtual string BuildPackage()
        {
            if (!RevisionsByFields.Any())
                return BuildHeader();

            string package = string.Empty;
            for (int i = 1; i <= HeaderData.Revision; i++)
                foreach (var dataField in RevisionsByFields[i])
                {
                    package += i.ToString().PadLeft(2, '0') + dataField.Value;
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
                Revision = (package.Length >= 11 && !string.IsNullOrWhiteSpace(package.Substring(8, 3))) ? (int?)Convert.ToInt32(package.Substring(8, 3)) : null,
                NoAckFlag = (package.Length >= 12 && !string.IsNullOrWhiteSpace(package.Substring(11, 1))) ? (int?)Convert.ToInt32(package.Substring(11, 1)) : null,
                StationID = (package.Length >= 14 && !string.IsNullOrWhiteSpace(package.Substring(12, 2))) ? (int?)Convert.ToInt32(package.Substring(12, 2)) : null,
                SpindleID = (package.Length >= 16 && !string.IsNullOrWhiteSpace(package.Substring(14, 2))) ? (int?)Convert.ToInt32(package.Substring(14, 2)) : null
            };

            return header;
        }

        public virtual MID ProcessPackage(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);
                ProcessDataFields(package);
                return this;
            }

            return NextTemplate.ProcessPackage(package);
        }

        protected void ProcessDataFields(string package)
        {
            if (!RevisionsByFields.Any())
                return;

            for (int i = 1; i <= HeaderData.Revision; i++)
            {
                foreach (var dataField in RevisionsByFields[i])
                    try
                    {
                        if (dataField.HasPrefix)
                            dataField.Value = package.Substring(2 + dataField.Index, dataField.Size);
                        else
                            dataField.Value = package.Substring(dataField.Index, dataField.Size);
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        //null value
                    }
            }
        }

        public class Header
        {
            public int Length { get; set; }
            public int Mid { get; set; }
            public int? Revision { get; set; }
            public int? NoAckFlag { get; set; }
            public int? SpindleID { get; set; }
            public int? StationID { get; set; }
            public IEnumerable<DataField> UsedAs { get; set; }

            public override string ToString()
            {
                string header = string.Empty;
                header += Length.ToString().PadLeft(4, '0');
                header += Mid.ToString().PadLeft(4, '0');
                header += (Revision != null) ? Revision.ToString().PadLeft(3, '0') : Revision.ToString().PadLeft(3, ' ');
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

        internal void SetNextTemplate(MID mid) => NextTemplate = mid;
    }
}
