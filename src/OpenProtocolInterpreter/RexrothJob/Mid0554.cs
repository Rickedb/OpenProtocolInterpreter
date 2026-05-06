using System.Collections.Generic;

namespace OpenProtocolInterpreter.RexrothJob
{
    /// <summary>
    /// Rexroth job result subscribe
    /// <para>
    ///     Subscribe to job result notifications. After subscription, the controller sends
    ///     <see cref="Mid0555"/> on each job result.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error
    /// </para>
    /// </summary>
    public class Mid0554 : Mid, IRexrothJob, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 554;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.SubscriptionAlreadyExists };

        public Mid0554() : this(DEFAULT_REVISION) { }

        public Mid0554(Header header) : base(header) { }

        public Mid0554(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }
    }
}
