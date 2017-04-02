using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MIDs
{
    public abstract class MID : IMID
    {
        public MID(Header header)
        {
            this.HeaderData = header;
            this.RegisteredDataFields = new List<DataField>();
        }

        public MID(int length, int mid, int revision, int? noAckFlag = null, int? spindleID = null, int? stationID = null)
        {
            this.HeaderData = new Header()
            {
                Length = length,
                Mid = mid,
                Revision = revision,
                NoAckFlag = noAckFlag,
                SpindleID = spindleID,
                StationID = stationID
            };
            this.RegisteredDataFields = new List<DataField>();
        }

        public List<DataField> RegisteredDataFields { get; set; }

        public Header HeaderData { get; set; }

        protected bool isCorrectType(int mid) { return (mid == this.HeaderData.Mid); }

        protected bool isCorrectType(string package)
        {
            int mid;
            if (int.TryParse(package.Substring(4, 4), out mid))
                return (mid == this.HeaderData.Mid);

            return false;
        }

        protected string buildHeader() { return this.HeaderData.ToString(); }

        public virtual string buildPackage()
        {
            string package = this.buildHeader();

            if (this.RegisteredDataFields.Count == 0)
                return package;

            for (int i = 1; i < this.RegisteredDataFields.Count + 1; i++)
                package += i.ToString().PadLeft(2, '0') + RegisteredDataFields[i - 1].getPaddedLeftValue();

            return package;
        }


        protected Header processHeader(string package)
        {
            Header header = new Header();

            header.Length = Convert.ToInt32(package.Substring(0, 4));
            header.Mid = Convert.ToInt32(package.Substring(4, 4));
            header.Revision = (!string.IsNullOrEmpty(package.Substring(11, 1))) ? Convert.ToInt32(package.Substring(8, 3)) : 1;
            header.NoAckFlag = (!string.IsNullOrEmpty(package.Substring(11, 1))) ? (int?)Convert.ToInt32(package.Substring(11, 1)) : null;
            header.StationID = (!string.IsNullOrEmpty(package.Substring(12, 2))) ? (int?)Convert.ToInt32(package.Substring(12, 2)) : null;
            header.SpindleID = (!string.IsNullOrEmpty(package.Substring(14, 2))) ? (int?)Convert.ToInt32(package.Substring(14, 2)) : null;

            return header;
        }

        public virtual MID processPackage(string package)
        {
            this.HeaderData = this.processHeader(package);
            this.processDataFields(package);
            return this;
        }

        protected void processDataFields(string package)
        {
            foreach (var dataField in this.RegisteredDataFields)
                dataField.Value = package.Substring(2 + dataField.Index, dataField.Size);
        }

        

        public struct Header
        {
            public int Length { get; set; }
            public int Mid { get; set; }
            public int Revision { get; set; }
            public int? NoAckFlag { get; set; }
            public int? SpindleID { get; set; }
            public int? StationID { get; set; }

            public override string ToString()
            {
                string header = string.Empty;
                header += this.Length.ToString().PadLeft(4, '0');
                header += this.Mid.ToString().PadLeft(4, '0');
                header += this.Revision.ToString().PadLeft(3, '0');
                header += this.NoAckFlag.ToString().PadLeft(1, ' ');
                header += this.StationID.ToString().PadLeft(2, '0');
                header += this.SpindleID.ToString().PadLeft(2, '0');
                header += "   "; //"Used as" (doesn't matter for UMI)
                return header;
            }
        }
    }
}
