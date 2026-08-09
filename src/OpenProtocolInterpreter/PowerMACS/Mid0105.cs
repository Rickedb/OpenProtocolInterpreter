using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// Last PowerMACS tightening result data subscribe
    /// <para>
    ///    Set the subscription for the rundowns result. The result of this command will be the transmission of
    ///    the rundown result after the tightening is performed(push function).
    /// </para>
    /// <para>
    ///    This telegram is also used for a PowerMACS 4000 system running a press instead of a spindle.A
    ///    press system only supports revision 4 and higher of the telegram and will answer with <see cref="Communication.Mid0004"/>,
    ///    MID revision unsupported if a subscription is made with a lower revision.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///         <see cref="Communication.Mid0004"/> Command error, Subscription already exists or MID revision unsupported
    /// </para>
    /// </summary>
    public class Mid0105 : Mid, IPowerMACS, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 105;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.SubscriptionAlreadyExists, Error.MidRevisionUnsupported };

        [Int64DataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 10, HasPrefix = false)]
        public long DataNumberSystem { get; set; }
        [BooleanDataFieldDefinition(revision: 3, field: 2, Index = 30, HasPrefix = false)]
        public bool SendOnlyNewData { get; set; }

        public Mid0105() : this(DEFAULT_REVISION)
        {

        }

        public Mid0105(Header header) : base(header)
        {
        }

        public Mid0105(bool noAckFlag = false) : this(DEFAULT_REVISION, noAckFlag)
        {

        }

        public Mid0105(int revision, bool noAckFlag = false) : this(new Header()
        {
            Mid = MID,
            Revision = revision,
            NoAckFlag = noAckFlag
        })
        {
        }
    }
}
