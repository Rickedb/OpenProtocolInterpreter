using System;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Relay function
    /// Description: 
    ///     Upload of one specific relay function status, see Table 101.
    ///     For tracking event functions, MID 0217 Relay function, is sent each time the relay status is changed. For
    ///     relay functions which are not tracking events, the upload is sent only when the relay is set high, i.e. the
    ///     data field “Relay function status” will always be 1 for such functions.
    /// Message sent by: Controller
    /// Answer: MID 0218 Relay function acknowledge
    /// </summary>
    public class MID_0217 : MID, IIOInterface
    {
        public const int MID = 217;
        private const int length = 28;
        private const int revision = 1;

        public Relay.RelayNumbers RelayNumber { get; set; }
        public bool RelayStatus { get; set; }

        public MID_0217() : base(length, MID, revision) { }

        internal MID_0217(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            string pkg = base.BuildHeader();
            pkg += "01" + ((int)this.RelayNumber).ToString().PadLeft(base.RegisteredDataFields[(int)DataFields.RELAY_NUMBER].Size, '0');
            pkg += "02" + Convert.ToInt32(this.RelayStatus).ToString();
            return pkg;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.ProcessPackage(package);
                this.RelayNumber =(Relay.RelayNumbers) base.RegisteredDataFields[(int)DataFields.RELAY_NUMBER].ToInt32();
                this.RelayStatus = base.RegisteredDataFields[(int)DataFields.RELAY_STATUS].ToBoolean();
                return this;
            }


            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.RELAY_NUMBER, 20, 3));
            this.RegisteredDataFields.Add(new DataField((int)DataFields.RELAY_STATUS, 25, 1));
        }

        public enum DataFields
        {
            RELAY_NUMBER,
            RELAY_STATUS
        }
    }
}

