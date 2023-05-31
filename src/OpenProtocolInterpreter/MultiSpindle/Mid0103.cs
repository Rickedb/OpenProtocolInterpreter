using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Multi-spindle result unsubscribe
    /// <para>Reset the subscription for the multi spindle result.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    /// Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    /// <see cref="Communication.Mid0004"/> Command error, Multi spindle result subscription does not exist
    /// </para>
    /// </summary>
    public class Mid0103 : Mid, IMultiSpindle, IIntegrator, IUnsubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 103;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.MultiSpindleResultSubscriptionDoesntExists };

        public Mid0103() : base(MID, DEFAULT_REVISION) { }

        public Mid0103(Header header) : base(header)
        {
        }
    }
}
