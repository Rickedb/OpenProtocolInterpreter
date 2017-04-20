namespace OpenProtocolInterpreter.MIDs.VIN
{
    /// <summary>
    /// MID: Vehicle ID Number subscribe
    /// Description: 
    ///     This message is used by the integrator to set a subscription for the current identifiers of the tightening
    ///     result.
    ///     The tightening result can be stamped with up to four identifiers:
    ///         - VIN number
    ///         - Identifier result part 2
    ///         - Identifier result part 3
    ///         - Identifier result part 4
    ///     The identifiers are received by the controller from several input sources, for example serial, Ethernet,
    ///     or field bus.
    ///     In revision 1 of the MID 0052 Vehicle ID Number, only the VIN number is transmitted.In revision 2, all
    ///     four possible identifiers are transmitted.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, VIN subscription already exists
    /// </summary>
    public class MID_0051 : MID, IVIN
    {
        private const int length = 20;
        private const int mid = 51;
        private const int revision = 1;

        public MID_0051() : base(length, mid, revision)
        {

        }

        internal MID_0051(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
