namespace OpenProtocolInterpreter.MIDs.Time
{
    /// <summary>
    /// MID: Read time upload request
    /// Description: 
    ///     Read time request.
    /// 
    /// Message sent by: Integrator
    /// Answer: MID 0081 Read time upload reply
    /// </summary>
    public class MID_0080 : MID, ITime
    {
        private const int length = 20;
        public const int MID = 80;
        private const int revision = 1;

        public MID_0080() : base(length, MID, revision)
        {

        }

        internal MID_0080(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0080)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
