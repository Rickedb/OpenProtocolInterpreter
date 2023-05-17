using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Last tightening result data subscribe
    /// <para>
    ///     Set the subscription for the result tightenings. The result of this command will be the transmission of
    ///     the tightening result after the tightening is performed(push function). The MID revision in the header
    ///     is used to subscribe to different revisions of <see cref="Mid0061"/> Last tightening result data upload reply.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///             <see cref="Communication.Mid0004"/> Command error, Last tightening subscription already exists or MID revision not supported
    /// </para>
    /// </summary>
    public class Mid0060 : Mid, ITightening, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 60;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.LastTighteningResultSubscriptionAlreadyExists, Error.MidRevisionUnsupported };

        public Mid0060() : this(DEFAULT_REVISION)
        {

        }

        public Mid0060(int revision, bool noAckFlag = false) : base(MID, revision, noAckFlag)
        {

        }

        public Mid0060(Header header) : base(header)
        {
        }
    }
}
