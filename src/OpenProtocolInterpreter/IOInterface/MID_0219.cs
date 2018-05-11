using System;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Relay function unsubscribe
    /// Description: 
    ///     Unsubscribe for a single relay function. The data field consists of three ASCII digits,
    ///     the relay number, which corresponds to the specific relay function. The relay numbers can be 
    ///     found in Table 101.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, The relay function subscription does not exist
    /// </summary>
    public class MID_0219 : Mid, IIOInterface
    {
        public const int MID = 219;
        private const int length = 23;
        private const int revision = 1;

        public Relay.RelayNumbers RelayNumber { get; set; }

        public MID_0219() : base(length, MID, revision) { }

        internal MID_0219(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            return base.BuildHeader() + ((int)RelayNumber).ToString().PadLeft(base.RegisteredDataFields[(int)DataFields.RELAY_NUMBER].Size, '0');
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.ProcessHeader(package);
                var dataField = base.RegisteredDataFields[(int)DataFields.RELAY_NUMBER];
                RelayNumber = (Relay.RelayNumbers)Convert.ToInt32(package.Substring(dataField.Index, dataField.Size));
                return this;
            }


            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.RELAY_NUMBER, 20, 3));
        }

        public enum DataFields
        {
            RELAY_NUMBER
        }
    }
}
