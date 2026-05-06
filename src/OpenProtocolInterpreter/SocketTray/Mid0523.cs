using System.Collections.Generic;

namespace OpenProtocolInterpreter.SocketTray
{
    /// <summary>
    /// Socket tray change unsubscribe
    /// <para>Cancel the subscription for socket tray change notifications.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error
    /// </para>
    /// </summary>
    public class Mid0523 : Mid, ISocketTray, IIntegrator, IUnsubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 523;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.SubscriptionDoesntExists };

        public Mid0523() : this(DEFAULT_REVISION) { }

        public Mid0523(Header header) : base(header) { }

        public Mid0523(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }
    }
}
