using System.Collections.Generic;

namespace OpenProtocolInterpreter.SocketTray
{
    /// <summary>
    /// Socket tray change subscribe
    /// <para>
    ///     Subscribe to socket tray/chamber change notifications.
    ///     After subscription, the controller sends socket tray state changes.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error
    /// </para>
    /// </summary>
    public class Mid0520 : Mid, ISocketTray, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 520;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.SubscriptionAlreadyExists };

        public Mid0520() : this(DEFAULT_REVISION) { }

        public Mid0520(Header header) : base(header) { }

        public Mid0520(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }
    }
}
