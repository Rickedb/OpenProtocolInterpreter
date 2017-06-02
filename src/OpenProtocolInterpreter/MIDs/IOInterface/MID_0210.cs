namespace OpenProtocolInterpreter.MIDs.IOInterface
{
    /// <summary>
    /// MID: Status externally monitored inputs subscribe
    /// Description: 
    ///     By using this message the integrator can set a subscription to monitor the status 
    ///     for the eight externally monitored digital inputs. After the subscription the station 
    ///     will directly receive a status message and then every time the status of at least one of 
    ///     the inputs has changed.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    /// MID 0004 Command error, 
    /// Status externally monitored inputs subscription already exists or 
    /// MID 0211 Status externally monitored inputs.
    /// </summary>
    public class MID_0210 : MID, IIOInterface
    {
        public const int MID = 210;
        private const int length = 20;
        private const int revision = 1;

        public MID_0210() : base(length, MID, revision) { }

        internal MID_0210(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0210)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
