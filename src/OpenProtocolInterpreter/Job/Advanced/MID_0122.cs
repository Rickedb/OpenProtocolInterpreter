namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job line control alert 1
    /// Description: This message tells the integrator that, for example, 
    /// a car has reached 80% of the station and that the
    /// Job line control alert 1 is set in the controller.
    /// Only available when a job has been selected.
    /// Message sent by: Controller
    /// Answer: MID 0125 Job line control info acknowledged
    /// </summary>
    public class MID_0122 : Mid, IAdvancedJob
    {
        private const int length = 20;
        public const int MID = 122;
        private const int revision = 1;

        public MID_0122() : base(length, MID, revision) { }

        internal MID_0122(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0122)base.ProcessPackage(package);

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
