using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Multi-spindle result subscribe
    /// <para>
    ///     A subscription for the multi-spindle status. For Power Focus, the subscription must
    ///     be addressed to a sync Master.
    /// </para>
    /// <para>
    ///     This telegram is also used for a PowerMACS 4000 system
    ///     running a press instead of a spindle. A press system only supports revision 4 and higher
    ///     of the telegram and will answer with <see cref="Communication.Mid0004"/>, MID revision unsupported if a subscription
    ///     is made with a lower revision.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error, Controller is not a sync master/station controller,
    ///     Multi-spindle result subscription already exists or MID revision unsupported
    /// </para>
    /// </summary>
    public class Mid0100 : Mid, IMultiSpindle, IIntegrator, ISubscription, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 100;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[]
        {
            Error.ControllerIsNotASyncMasterOrStationController,
            Error.MultiSpindleResultSubscriptionAlreadyExists,
            Error.MidRevisionUnsupported
        };

        [Int64DataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 10, HasPrefix = false)]
        public long DataNumberSystem { get; set; }

        [BooleanDataFieldDefinition(revision: 3, field: 2, Index = 30, HasPrefix = false)]
        public bool SendOnlyNewData { get; set; }

        public Mid0100() : this(DEFAULT_REVISION)
        {

        }

        public Mid0100(Header header) : base(header)
        {
        }

        public Mid0100(bool noAckFlag = false) : this(DEFAULT_REVISION, noAckFlag)
        {

        }

        public Mid0100(int revision, bool noAckFlag = false) : this(new Header()
        {
            Mid = MID,
            Revision = revision,
            NoAckFlag = noAckFlag
        })
        {
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            DataNumberSystem,
            SendOnlyNewData
        }
    }
}
