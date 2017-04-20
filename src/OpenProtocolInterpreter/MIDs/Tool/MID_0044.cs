namespace OpenProtocolInterpreter.MIDs.Tool
{
    /// <summary>
    /// MID: Disconnect tool request
    /// Description: 
    ///     This command is sent by the integrator in order to request the possibility to disconnect the tool from
    ///     the controller.The command is rejected if the tool is currently used.
    ///     When the command is accepted the operator can disconnect the tool and replace it (hot swap).
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Tool currently in use
    /// </summary>
    public class MID_0044 : MID, ITool
    {
        private const int length = 20;
        public const int MID = 44;
        private const int revision = 1;

        public MID_0044() : base(length, MID, revision)
        {

        }

        internal MID_0044(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
