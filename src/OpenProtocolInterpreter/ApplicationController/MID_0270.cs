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
    public class MID_0270 : Mid
    {
        private const int LAST_REVISION = 1;
        public const int MID = 270;

        public MID_0270() : base(MID, LAST_REVISION) { }

        internal MID_0270(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        
    }
}
