using System.Collections.Generic;

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
    public class Mid0250 : Mid, IApplicationSelector, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        private const int LAST_REVISION = 1;
        public const int MID = 250;

        public IEnumerable<Error> PossibleErrors => new Error[] { Error.SELECTOR_SOCKET_INFO_SUBSCRIPTION_ALREADY_EXISTS };

        public Mid0250() : this(false)
        {

        }

        public Mid0250(bool noAckFlag = false) : base(MID, LAST_REVISION, noAckFlag) { }

        public Mid0250(Header header) : base(header)
        {

        }
    }
}
