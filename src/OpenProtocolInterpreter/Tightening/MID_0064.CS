using System;
namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// MID: Old tightening result upload request
    /// Description: This message is a request to upload a particular tightening result from the controller. The requested
    ///              result is specified by its unique ID(tightening ID). This message is useful after a failure of the
    ///              network in order to retrieve the missing result during the communication interruption.The integrator
    ///              can see the missing results by always comparing the last tightening IDs of the two last received
    ///              tightenings packets (parameter 23 in the result message).
    ///              Requesting tightening ID zero is the same as requesting the latest tightening performed.
    /// Message sent by: Integrator
    /// Answer: MID 0065 Old tightening result upload reply 
    ///         or MID 0004 Command error, Tightening ID requested not found,
    ///         or MID revision not supported
    /// </summary>
    public class MID_0064 : MID, ITightening
    {
        private const int length = 30;
        public const int MID = 64;
        private const int revision = 1;
        
        public int TighteningID { get; set; }

        public MID_0064() : base(length, MID, revision) { }

        public MID_0064(int tighteningId) : base(length, MID, revision)
        {
            this.TighteningID = tighteningId;
        }

        internal MID_0064(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage() { return base.BuildHeader() + this.TighteningID.ToString().PadRight(10, ' '); }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                this.HeaderData = this.ProcessHeader(package);
                var dataField = base.RegisteredDataFields[(int)DataFields.TIGHTENING_ID];
                this.TighteningID = Convert.ToInt32(package.Substring(dataField.Index, dataField.Size));
                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.TIGHTENING_ID, 20, 10));
        }

        public enum DataFields
        {
            TIGHTENING_ID
        }
    }
}
