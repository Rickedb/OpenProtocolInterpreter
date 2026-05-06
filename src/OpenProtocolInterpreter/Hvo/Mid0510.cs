using System.Collections.Generic;

namespace OpenProtocolInterpreter.Hvo
{
    /// <summary>
    /// HVO signal change subscribe
    /// <para>
    ///     Subscribe to HVO (Hand-guided Visual Output) button change notifications.
    ///     After subscription, the controller sends MID 0511 on each HVO state change.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error
    /// </para>
    /// </summary>
    public class Mid0510 : Mid, IHvo, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 510;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.SubscriptionAlreadyExists };

        public Mid0510() : this(DEFAULT_REVISION) { }

        public Mid0510(Header header) : base(header) { }

        public Mid0510(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }
    }
}
