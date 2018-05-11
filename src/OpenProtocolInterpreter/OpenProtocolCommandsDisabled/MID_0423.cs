namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// MID: Open Protocol commands disabled unsubscribe
    /// Description: 
    ///     Reset the subscription for the Open Protocol commands disabled digital input.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, Open Protocol commands disabled
    ///         subscription does not exist
    /// </summary>
    public class MID_0423 : Mid, IOpenProtocolCommandsDisabled
    {
        private const int length = 20;
        public const int MID = 423;
        private const int revision = 1;

        public MID_0423() : base(length, MID, revision) { }

        internal MID_0423(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0423)base.Parse(package);

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields() { }
    }
}
