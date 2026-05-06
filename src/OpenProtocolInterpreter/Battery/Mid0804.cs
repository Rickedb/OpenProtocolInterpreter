using System.Collections.Generic;

namespace OpenProtocolInterpreter.Battery
{
    /// <summary>
    /// Cancel battery level changes subscription
    /// <para>Cancel the subscription for battery level change notifications.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error, subscription does not exist
    /// </para>
    /// </summary>
    public class Mid0804 : Mid, IBattery, IIntegrator, IUnsubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 804;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.SubscriptionDoesntExists };

        public Mid0804() : this(DEFAULT_REVISION) { }

        public Mid0804(Header header) : base(header) { }

        public Mid0804(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }
    }
}
