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
    public class Mid0050 : Mid, IVin, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 50;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.VINInputSourceNotGranted };

        public string VinNumber
        {
            get => GetField(1, (int)DataFields.VinNumber).Value;
            set => GetField(1, (int)DataFields.VinNumber).SetValue(value);
        }

        public Mid0050() : base(MID, DEFAULT_REVISION) { }

        public Mid0050(Header header) : base(header)
        {
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.VinNumber).Size = VinNumber.Length;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            GetField(1, (int)DataFields.VinNumber).Size = Header.Length - 20;
            ProcessDataFields(package);
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.VinNumber, 20, 0, false), //dynamic
                            }
                }
            };
        }

        protected enum DataFields
        {
            VinNumber
        }
    }
}
