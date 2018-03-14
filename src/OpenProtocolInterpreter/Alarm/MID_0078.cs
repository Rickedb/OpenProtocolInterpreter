namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// MID: Acknowledge alarm remotely on controller
    /// Description: 
    ///      The integrator can remotely acknowledge the current alarm on the controller by sending MID 0078. 
    ///      If no alarm is currently active when the controller receives the command, the command will be rejected.
    /// Message sent by: Integrator
    /// Answer : MID 0005 Command accepted or MID 0004 Command error, No alarm present or Invalid data
    /// </summary>
    public class MID_0078 : MID, IAlarm
    {
        public const int MID = 78;
        private const int length = 20;
        private const int revision = 1;

        public MID_0078() : base(length, MID, revision)
        {

        }

        internal MID_0078(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
