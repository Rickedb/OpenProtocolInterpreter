using System.Collections.Generic;

namespace OpenProtocolInterpreter.Hvo
{
    /// <summary>
    /// HVO signal change unsubscribe
    /// <para>Cancel the subscription for HVO signal change notifications.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error
    /// </para>
    /// </summary>
    public class Mid0513 : Mid, IHvo, IIntegrator, IUnsubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 513;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.SubscriptionDoesntExists };

        public Mid0513() : this(DEFAULT_REVISION) { }

        public Mid0513(Header header) : base(header) { }

        public Mid0513(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }
    }
}
