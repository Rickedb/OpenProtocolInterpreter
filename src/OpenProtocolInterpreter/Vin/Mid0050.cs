using System;
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

        [StringDataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 25, HasPrefix = false)]
        public string VinNumber { get; set; }

        public Mid0050() : base(MID, DEFAULT_REVISION) { }

        public Mid0050(Header header) : base(header)
        {
        }

        public override string Pack()
        {
            GetField(nameof(VinNumber)).Size = VinNumber.Length;
            return base.Pack();
        }

        public override Mid Parse(ReadOnlySpan<char> package)
        {
            Header = ProcessHeader(package);
            GetField(nameof(VinNumber)).Size = Header.Length - 20;
            ProcessDataFields(package);
            return this;
        }
    }
}
