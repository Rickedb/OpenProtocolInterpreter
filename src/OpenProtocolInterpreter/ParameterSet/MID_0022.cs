using System;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Lock at batch done upload
    /// Description: 
    ///     This message gives the relay status for Lock at batch done.
    /// Message sent by: Controller
    /// Answer: MID 0023 Lock at batch done upload Ack
    /// </summary>
    public class MID_0022 : MID, IParameterSet
    {
        private const int length = 21;
        public const int MID = 22;
        private const int revision = 1;

        public bool RelayStatus { get; set; }

        public MID_0022() : base(length, MID, revision) { }

        public MID_0022(bool relayStatus) : base(length, MID, revision)
        {
            this.RelayStatus = relayStatus;
        }

        internal MID_0022(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            string package = base.BuildPackage();
            package += Convert.ToInt32(this.RelayStatus).ToString();
            return package;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                this.HeaderData = base.ProcessHeader(package);

                this.RelayStatus = Convert.ToBoolean(Convert.ToInt32(package.Substring(this.RegisteredDataFields[(int)DataFields.RELAY_STATUS].Index,
                                                                        this.RegisteredDataFields[(int)DataFields.RELAY_STATUS].Size)));
                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() 
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.RELAY_STATUS, 20, 1));
        }

        public enum DataFields
        {
            RELAY_STATUS
        }
    }
}
