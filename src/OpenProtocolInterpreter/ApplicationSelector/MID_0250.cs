namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// MID: Selector socket info subscribe
    /// Description:
    ///     Subscribe for the socket information of all socket selectors (connected to the controller).
    ///     After subscription, every time a socket is lifted or put back, MID 0251 is sent to the subscriber 
    ///     with the device ID of the selector and the current status of each one of the sockets, lifted or not.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, The selector socket info subscription already exists
    /// </summary>
    public class MID_0250 : MID, IApplicationSelector
    {
        private const int length = 20;
        public const int MID = 250;
        private const int revision = 1;

        public MID_0250() : base(length, MID, revision) { }

        internal MID_0250(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
                return (MID_0250)base.ProcessPackage(package);

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields() { }
    }
}
