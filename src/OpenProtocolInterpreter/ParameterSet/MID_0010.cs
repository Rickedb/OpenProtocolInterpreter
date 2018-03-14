namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Parameter set ID upload request
    /// Description: 
    ///     A request to get the valid parameter set IDs from the controller.
    /// Message sent by: Integrator
    /// Answer: MID 0011 Parameter set ID upload reply
    /// </summary>
    public class MID_0010 : MID, IParameterSet
    {
        private const int LENGTH = 20;
        public const int MID = 10;
        private const int LAST_REVISION = 3;

        public MID_0010(int revision = LAST_REVISION) : base(LENGTH, MID, revision) { }

        internal MID_0010(IMID nextTemplate) : base(LENGTH, MID, LAST_REVISION)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0010)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() {  }
    }
}
