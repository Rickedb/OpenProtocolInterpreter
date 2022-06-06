using System.Collections.Generic;

namespace OpenProtocolInterpreter.Vin
{
    /// <summary>
    /// Vehicle ID Number download request
    /// <para>
    ///     This message is replaced by <see cref="MultipleIdentifiers.Mid0150"/>. <see cref="Mid0050"/> is still supported.
    /// </para>
    /// <para>Used by the integrator to send a VIN number to the controller.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///             <see cref="Communication.Mid0004"/> Command error, VIN input source not granted
    /// </para>
    /// </summary>
    public class Mid0050 : Mid, IVin, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 50;

        public string VinNumber
        {
            get => GetField(1, (int)DataFields.VIN_NUMBER).Value;
            set => GetField(1, (int)DataFields.VIN_NUMBER).SetValue(value);
        }

        public Mid0050() : base(MID, LAST_REVISION) { }

        public Mid0050(Header header) : base(header)
        {
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="vinNumber">Dynamic with max 25 ASCII characters.</param>
        public Mid0050(string vinNumber) : this()
        {
            VinNumber = vinNumber;
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.VIN_NUMBER).Size = VinNumber.Length;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            GetField(1, (int)DataFields.VIN_NUMBER).Size = Header.Length - 20;
            ProcessDataFields(package);
            return this;
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
