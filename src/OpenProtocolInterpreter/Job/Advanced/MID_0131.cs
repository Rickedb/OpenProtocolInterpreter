﻿namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Set Job line control start
    /// Description: The integrator can set the line control start in the controller with this message.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0131 : Mid, IAdvancedJob
    {
        private const int length = 20;
        public const int MID = 131;
        private const int revision = 1;

        public MID_0131() : base(length, MID, revision) { }

        internal MID_0131(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0131)base.ProcessPackage(package);

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}