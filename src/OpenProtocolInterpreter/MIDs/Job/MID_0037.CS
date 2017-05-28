using System;

namespace OpenProtocolInterpreter.MIDs.Job
{
    /// <summary>
    /// MID: Job info unsubscribe
    /// Description: Reset the subscription for a Job info message.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Job info subscription does not exist
    /// </summary>
    public class MID_0037 : MID, IJob
    {
        private const int length = 20;
        public const int MID = 37;
        private const int revision = 1;
        
        public MID_0037() : base(length, MID, revision) { }

        internal MID_0037(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0037)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
