namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job line control started
    /// Description: This message tells the integrator that Job Line control start has been set in the controller.
    /// Message sent by: Controller
    /// Answer: MID 0125 Job line control info acknowledged
    /// </summary>
    public class MID_0121 : Mid, IAdvancedJob
    {
        private const int length = 20;
        public const int MID = 121;
        private const int revision = 1;

        public MID_0121() : base(length, MID, revision) { }

        internal MID_0121(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0121)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}
