using System.Collections.Generic;

namespace OpenProtocolInterpreter.RexrothJob
{
    /// <summary>
    /// Rexroth job result unsubscribe
    /// <para>Cancel the subscription for job result notifications.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error
    /// </para>
    /// </summary>
    public class Mid0557 : Mid, IRexrothJob, IIntegrator, IUnsubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 557;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.SubscriptionDoesntExists };

        public Mid0557() : this(DEFAULT_REVISION) { }

        public Mid0557(Header header) : base(header) { }

        public Mid0557(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }
    }
}
