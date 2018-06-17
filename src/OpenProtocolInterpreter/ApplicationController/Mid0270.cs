namespace OpenProtocolInterpreter.ApplicationController
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
    public class Mid0270 : Mid
    {
        private const int LAST_REVISION = 1;
        public const int MID = 270;

        public Mid0270() : base(MID, LAST_REVISION) { }

        internal Mid0270(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        
    }
}
