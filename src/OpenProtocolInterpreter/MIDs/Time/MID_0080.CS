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
        private const int mid = 80;
        private const int revision = 1;

        public MID_0080() : base(length, mid, revision)
        {

        }

        public MID_0080(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }
    }
}
