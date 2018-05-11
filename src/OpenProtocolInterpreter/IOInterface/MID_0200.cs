namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Set externally controlled relays
    /// Description: 
    ///     By using this message the integrator can control 10 relays (externally control relays). The station can
    ///     set, reset the relays or make them flashing.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0200 : Mid, IIOInterface
    {
        private const int length = 30;
        public const int MID = 200;
        private const int revision = 1;

        public RelayStatuses StatusRelayOne { get; set; }
        public RelayStatuses StatusRelayTwo { get; set; }
        public RelayStatuses StatusRelayThree { get; set; }
        public RelayStatuses StatusRelayFour { get; set; }
        public RelayStatuses StatusRelayFive { get; set; }
        public RelayStatuses StatusRelaySix { get; set; }
        public RelayStatuses StatusRelaySeven { get; set; }
        public RelayStatuses StatusRelayEight { get; set; }
        public RelayStatuses StatusRelayNine { get; set; }
        public RelayStatuses StatusRelayTen { get; set; }

        public MID_0200() : base(length, MID, revision)
        {

        }

        internal MID_0200(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            string package = base.BuildHeader();
            package += $"{(int)StatusRelayOne}{(int)StatusRelayTwo}{(int)StatusRelayThree}{(int)StatusRelayFour}{(int)StatusRelayFive}";
            package += $"{(int)StatusRelaySix}{(int)StatusRelaySeven}{(int)StatusRelayEight}{(int)StatusRelayNine}{(int)StatusRelayTen}";
            return package;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.HeaderData = base.ProcessHeader(package);

                foreach (var field in base.RegisteredDataFields)
                    field.Value = package.Substring(field.Index, field.Size);

                StatusRelayOne = (RelayStatuses)base.RegisteredDataFields[(int)DataFields.STATUS_RELAY_1].ToInt32();
                StatusRelayTwo = (RelayStatuses)base.RegisteredDataFields[(int)DataFields.STATUS_RELAY_2].ToInt32();
                StatusRelayThree = (RelayStatuses)base.RegisteredDataFields[(int)DataFields.STATUS_RELAY_3].ToInt32();
                StatusRelayFour = (RelayStatuses)base.RegisteredDataFields[(int)DataFields.STATUS_RELAY_4].ToInt32();
                StatusRelayFive = (RelayStatuses)base.RegisteredDataFields[(int)DataFields.STATUS_RELAY_5].ToInt32();
                StatusRelaySix = (RelayStatuses)base.RegisteredDataFields[(int)DataFields.STATUS_RELAY_6].ToInt32();
                StatusRelaySeven = (RelayStatuses)base.RegisteredDataFields[(int)DataFields.STATUS_RELAY_7].ToInt32();
                StatusRelayEight = (RelayStatuses)base.RegisteredDataFields[(int)DataFields.STATUS_RELAY_8].ToInt32();
                StatusRelayNine = (RelayStatuses)base.RegisteredDataFields[(int)DataFields.STATUS_RELAY_9].ToInt32();
                StatusRelayTen = (RelayStatuses)base.RegisteredDataFields[(int)DataFields.STATUS_RELAY_10].ToInt32();

                return this;
            }

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.AddRange(
                new DataField[]
                {
                    new DataField((int)DataFields.STATUS_RELAY_1, 20, 1),
                    new DataField((int)DataFields.STATUS_RELAY_2, 21, 1),
                    new DataField((int)DataFields.STATUS_RELAY_3, 22, 1),
                    new DataField((int)DataFields.STATUS_RELAY_4, 23, 1),
                    new DataField((int)DataFields.STATUS_RELAY_5, 24, 1),
                    new DataField((int)DataFields.STATUS_RELAY_6, 25, 1),
                    new DataField((int)DataFields.STATUS_RELAY_7, 26, 1),
                    new DataField((int)DataFields.STATUS_RELAY_8, 27, 1),
                    new DataField((int)DataFields.STATUS_RELAY_9, 28, 1),
                    new DataField((int)DataFields.STATUS_RELAY_10, 29, 1)
                });
        }

        public enum RelayStatuses
        {
            OFF = 0,
            ON = 1,
            FLASHING = 2,
            KEEP_CURRENT_STATUS = 3
        }

        public enum DataFields
        {
            STATUS_RELAY_1,
            STATUS_RELAY_2,
            STATUS_RELAY_3,
            STATUS_RELAY_4,
            STATUS_RELAY_5,
            STATUS_RELAY_6,
            STATUS_RELAY_7,
            STATUS_RELAY_8,
            STATUS_RELAY_9,
            STATUS_RELAY_10
        }
    }
}
