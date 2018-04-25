using System;

namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Abort Job
    /// Description: Abort the current running job if there is one.
    /// Message sent by: Integrator
    /// Answer: MID 0005
    /// </summary>
    public class MID_0127 : Mid, IAdvancedJob
    {
        private const int length = 20;
        public const int MID = 127;
        private const int revision = 1;

        public MID_0127() : base(length, MID, revision)
        {

        }

        internal MID_0127(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0127)base.ProcessPackage(package);

            throw new NotImplementedException("MID not implemented or doesn't exists!");
        }

        protected override void RegisterDatafields() { }
    }
}
