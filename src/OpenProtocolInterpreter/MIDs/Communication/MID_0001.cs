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
    public class MID_0001 : MID
    {
        private const int length = 20;
        private const int mid = 1;
        private const int revision = 1;

        public MID_0001() : base(length, mid, revision) { }

        internal MID_0001(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0001)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }
    }
}
