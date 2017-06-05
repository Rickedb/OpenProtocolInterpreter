namespace OpenProtocolInterpreter.MIDs.ApplicationController
{
    /// <summary>
    /// MID: Controller reboot request 
    /// Description:
    ///     This message causes the controller to reboot after it has accepted the command.
    ///     Warning 1: this MID requires programming control (see 4.4 Programming control).
    ///     Warning 2: the connection will be lost and will need to be reestablished after controller reboot!
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Programming control not granted
    /// </summary>
    public class MID_0270 : MID
    {
        private const int length = 20;
        public const int MID = 270;
        private const int revision = 1;

        public MID_0270() : base(length, MID, revision) { }

        internal MID_0270(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0270)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
