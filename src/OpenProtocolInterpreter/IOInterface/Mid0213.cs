using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Status externally monitored inputs unsubscribe
    /// <para>Unsubscribe for the <see cref="Mid0211"/> Status externally monitored inputs.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, 
    ///             Status externally monitored inputs subscription does not exist
    /// </para>
    /// </summary>
    public class Mid0213 : Mid, IIOInterface, IIntegrator, IUnsubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 213;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.STATUS_EXTERNAL_MONITORED_INPUTS_SUBSCRIPTION_DOESNT_EXISTS };

        public Mid0213() : base(MID, DEFAULT_REVISION) { }

        public Mid0213(Header header) : base(header)
        {
        }
    }
}
