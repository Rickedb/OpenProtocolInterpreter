namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// Selector socket info subscribe
    /// <para>
    ///     Subscribe for the socket information of all socket selectors (connected to the controller).
    ///     After subscription, every time a socket is lifted or put back, <see cref="Mid0251"/> is sent to the subscriber 
    ///     with the device ID of the selector and the current status of each one of the sockets, lifted or not.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, The selector socket info subscription already exists</para>
    /// </summary>
    public class Mid0250 : Mid, IApplicationSelector, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 250;

        public Mid0250() : this(0)
        {

        }

        public Mid0250(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) { }
    }
}
