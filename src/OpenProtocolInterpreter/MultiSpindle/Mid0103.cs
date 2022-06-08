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
        private const int LAST_REVISION = 1;
        public const int MID = 103;

        public IEnumerable<Error> PossibleErrors => new Error[] { Error.MULTI_SPINDLE_RESULT_SUBSCRIPTION_DOESNT_EXISTS };

        public Mid0103() : base(MID, LAST_REVISION) { }

        public Mid0103(Header header) : base(header)
        {
        }
    }
}
