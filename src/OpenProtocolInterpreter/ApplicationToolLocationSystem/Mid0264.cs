using System.Collections.Generic;

namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// Tool tag ID unsubscribe
    /// <para>Used by the integrator to send a Tool tag ID unsubscription to the controller.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Tool tag ID subscription does not exist or MID revision unsupported.</para>
    /// </summary>
    public class Mid0264 : Mid, IApplicationToolLocationSystem, IIntegrator, IUnsubscription, IAcceptableCommand, IDeclinableCommand
    {
        private const int LAST_REVISION = 1;
        public const int MID = 264;

        public IEnumerable<Error> PossibleErrors => new Error[]
        {
            Error.TOOL_TAG_ID_UNKNOWN,
            Error.SUBSCRIPTION_DOESNT_EXISTS,
            Error.MID_REVISION_UNSUPPORTED
        };

        public Mid0264() : base(MID, LAST_REVISION) { }

        public Mid0264(Header header) : base(header)
        {

        }
    }
}
