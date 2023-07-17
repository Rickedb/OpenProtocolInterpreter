using System.Collections.Generic;

namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// Selector socket info unsubscribe
    /// <para>Unsubscribe for the selector socket info. The subscription is reset for all selector devices.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, The selector socket info subscription does not exist</para>
    /// </summary>
    public class Mid0253 : Mid, IApplicationSelector, IIntegrator, IUnsubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 253;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.SelectorSocketInfoSubscriptionDoesntExists };

        public Mid0253() : base(MID, DEFAULT_REVISION) { }

        public Mid0253(Header header) : base(header)
        {

        }
    }
}
