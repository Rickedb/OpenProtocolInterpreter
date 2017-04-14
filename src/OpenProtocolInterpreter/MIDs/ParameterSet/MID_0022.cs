using System;

namespace OpenProtocolInterpreter.MIDs.ParameterSet
{
    /// <summary>
    /// MID: Lock at batch done upload
    /// Description: 
    ///     This message gives the relay status for Lock at batch done.
    /// Message sent by: Controller
    /// Answer: MID 0023 Lock at batch done upload Ack
    /// </summary>
    public class MID_0022 : MID
    {
        private const int length = 21;
        private const int mid = 22;
        private const int revision = 1;

        public bool RelayStatus { get; set; }

        public MID_0022() : base(length, mid, revision) { }

        public MID_0022(bool relayStatus) : base(length, mid, revision)
        {
            this.RelayStatus = relayStatus;
        }

        internal MID_0022(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            string package = base.buildPackage();
            package += Convert.ToInt32(this.RelayStatus).ToString();
            return package;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                this.HeaderData = base.processHeader(package);

                this.RelayStatus = Convert.ToBoolean(Convert.ToInt32(package.Substring(this.RegisteredDataFields[(int)DataFields.RELAY_STATUS].Index,
                                                                        this.RegisteredDataFields[(int)DataFields.RELAY_STATUS].Size)));
                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        private void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.RELAY_STATUS, 20, 1));
        }

        public enum DataFields
        {
            RELAY_STATUS
        }
    }
}
