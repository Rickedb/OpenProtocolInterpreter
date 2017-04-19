using System;

namespace OpenProtocolInterpreter.MIDs.Job.Advanced
{
    /// <summary>
    /// MID: Abort Job
    /// Description: Abort the current running job if there is one.
    /// Message sent by: Integrator
    /// Answer: MID 0005
    /// </summary>
    public class MID_0127 : MID, IAdvancedJob
    {
        private const int length = 20;
        private const int mid = 127;
        private const int revision = 1;

        public MID_0127() : base(length, mid, revision)
        {

        }

        internal MID_0127(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0127)base.processPackage(package);

            throw new NotImplementedException("MID not implemented or doesn't exists!");
        }

        protected override void registerDatafields() { }
    }
}
