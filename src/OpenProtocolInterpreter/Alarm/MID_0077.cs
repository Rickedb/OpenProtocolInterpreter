namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// MID: Alarm status acknowledge
    /// Description: 
    ///      Acknowledgement of MID 0076 Alarm Status.
    /// Message sent by: Integrator
    /// Answer : None
    /// </summary>
    public class MID_0077 : Mid, IAlarm
    {
        public const int MID = 77;
        private const int length = 20;
        private const int revision = 1;

        public MID_0077() : base(length, MID, revision)
        {

        }

        internal MID_0077(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return base.ProcessPackage(package);

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
