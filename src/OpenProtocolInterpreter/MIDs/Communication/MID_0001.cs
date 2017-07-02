namespace OpenProtocolInterpreter.MIDs.Communication
{
    /// <summary>
    /// MID: Application Communication start
    /// Description:
    ///     This message enables the communication. The controller does not respond to any other command
    ///     before this
    /// Message sent by: Integrator
    /// Answer: MID 0002 Communication start acknowledge or MID 0004 Command error, 
    ///         Client already connected or MID revision unsupported
    /// </summary>
    public class MID_0001 : MID, ICommunication
    {
        private const int length = 20;
        public const int MID = 1;
        private const int lastRevision = 5;

        public MID_0001() : base(length, MID, lastRevision) { }

        public MID_0001(int revision) : base(length, MID, revision) { }

        internal MID_0001(IMID nextTemplate) : base(length, MID, lastRevision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0001)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
