using System.Collections.Generic;

namespace OpenProtocolInterpreter.Wifi
{
    /// <summary>
    /// Cancel reception quality change subscription
    /// <para>Cancel the subscription for reception quality change notifications.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error, subscription does not exist
    /// </para>
    /// </summary>
    public class Mid0809 : Mid, IWifi, IIntegrator, IUnsubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 809;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.SubscriptionDoesntExists };

        public Mid0809() : this(DEFAULT_REVISION) { }

        public Mid0809(Header header) : base(header) { }

        public Mid0809(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }
    }
}
