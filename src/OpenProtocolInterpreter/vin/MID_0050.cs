using System.Collections.Generic;

namespace OpenProtocolInterpreter.Vin
{
    /// <summary>
    /// MID: Vehicle ID Number download request
    /// Description: 
    ///     This message is replaced by MID 0150. MID 0050 is still supported.
    ///     Used by the integrator to send a VIN number to the controller.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, VIN input source not granted
    /// </summary>
    public class MID_0050 : Mid, IVin
    {
        private const int LAST_REVISION = 1;
        public const int MID = 50;

        public string VinNumber
        {
            get => RevisionsByFields[1][(int)DataFields.VIN_NUMBER].Value;
            set => RevisionsByFields[1][(int)DataFields.VIN_NUMBER].SetValue(value);
        }

        public MID_0050() : base(MID, LAST_REVISION) { }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="vinNumber">Dynamic with max 25 ASCII characters.</param>
        public MID_0050(string vinNumber) : this()
        {
            VinNumber = vinNumber;
        }

        internal MID_0050(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string Pack()
        {
            RevisionsByFields[1][(int)DataFields.VIN_NUMBER].Size = VinNumber.Length + 20;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);
                RevisionsByFields[1][(int)DataFields.VIN_NUMBER].Size = HeaderData.Length - 20;
                ProcessDataFields(package);
                return this;
            }

            return NextTemplate.Parse(package);
        }

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out string error)
        {
            error = string.Empty;
            if (VinNumber.Length > 25)
                error = new System.ArgumentOutOfRangeException(nameof(VinNumber), "Max of 25 characters").Message;
            return !string.IsNullOrEmpty(error);
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.VIN_NUMBER, 20, 0, false), //dynamic
                            }
                }
            };
        }

        public enum DataFields
        {
            VIN_NUMBER
        }
    }
}
