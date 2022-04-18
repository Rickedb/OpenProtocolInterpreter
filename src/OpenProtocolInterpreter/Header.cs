namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Represents a Mid header
    /// </summary>
    public sealed class Header
    {
        public int Length { get; internal set; }
        public int Mid { get; internal set; }
        public int Revision { get; internal set; }
        public bool NoAckFlag { get; set; }
        public int? StationID { get; set; }
        public int? SpindleID { get; set; }
        public int? SequenceNumber { get; set; }
        public int? NumberOfMessages { get; set; }
        public int? MessageNumber { get; set; }

        public override string ToString()
        {
            string header = Length.ToString().PadLeft(4, '0');
            header += Mid.ToString().PadLeft(4, '0');
            header += (Revision > 0) ? Revision.ToString().PadLeft(3, '0') : "   ";
            header += NoAckFlag ? "0" : " ";
            header += (StationID != null) ? StationID.ToString().PadLeft(2, '0') : string.Empty.PadLeft(2, ' ');
            header += (SpindleID != null) ? SpindleID.ToString().PadLeft(2, '0') : string.Empty.PadLeft(2, ' ');
            header += (SequenceNumber != null) ? SequenceNumber.ToString().PadLeft(2, '0') : string.Empty.PadLeft(2, ' ');
            header += NumberOfMessages.ToString().PadLeft(1, ' ');
            header += MessageNumber.ToString().PadLeft(1, ' ');
            return header;
        }
    }
}
