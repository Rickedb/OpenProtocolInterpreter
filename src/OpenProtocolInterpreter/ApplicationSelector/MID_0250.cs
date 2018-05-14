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
    public class MID_0250 : Mid, IApplicationSelector
    {
        private const int LAST_REVISION = 1;
        public const int MID = 250;

        public MID_0250(int? noAckFlag = 1) : base(MID, LAST_REVISION, noAckFlag) { }

        internal MID_0250(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
