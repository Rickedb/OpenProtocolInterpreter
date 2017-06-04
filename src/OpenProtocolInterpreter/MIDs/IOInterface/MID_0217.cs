using System;

namespace OpenProtocolInterpreter.MIDs.IOInterface
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
        private const int length = 24;
        private const int revision = 1;

        public Relay.RelayNumbers RelayNumber { get; set; }
        public bool RelayStatus { get; set; }

        public MID_0217() : base(length, MID, revision) { }

        internal MID_0217(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            string pkg = base.buildHeader();
            pkg += ((int)this.RelayNumber).ToString().PadLeft(base.RegisteredDataFields[(int)DataFields.RELAY_NUMBER].Size, '0');
            pkg += Convert.ToInt32(this.RelayStatus).ToString();
            return pkg;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processHeader(package);
                var relay = new Relay().getRelay(package.Substring(20));
                this.RelayNumber = relay.Number;
                this.RelayStatus = relay.Status;
                return this;
            }


            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.RELAY_NUMBER, 20, 3));
            this.RegisteredDataFields.Add(new DataField((int)DataFields.RELAY_STATUS, 23, 1));
        }

        public enum DataFields
        {
            RELAY_NUMBER,
            RELAY_STATUS
        }
    }
}

