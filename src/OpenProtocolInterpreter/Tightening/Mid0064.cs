using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Old tightening result upload request
    /// <para>
    ///     This message is a request to upload a particular tightening result from the controller. The requested
    ///     result is specified by its unique ID(tightening ID). This message is useful after a failure of the
    ///     network in order to retrieve the missing result during the communication interruption.The integrator
    ///     can see the missing results by always comparing the last tightening IDs of the two last received
    ///     tightenings packets (parameter 23 in the result message).
    /// </para>
    /// <para>
    ///     Requesting tightening ID zero is the same as requesting the latest tightening performed.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Mid0065"/> Old tightening result upload reply or
    ///             <see cref="Communication.Mid0004"/> Command error, Tightening ID requested not found, or
    ///             MID revision not supported
    /// </para>
    /// </summary>
    public class Mid0064 : Mid, ITightening, IIntegrator, IAnswerableBy<Mid0065>, IDeclinableCommand
    {
        public const int MID = 64;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.TighteningIdRequestNotFound, Error.MidRevisionUnsupported };

        [Int64DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 10, HasPrefix = false)]
        public long TighteningId { get; set; }

        [BooleanDataFieldDefinition(revision: 10, field: 2, Index = 30, Size = 1, HasPrefix = false)]
        public bool OfflineResult { get; set; }

        public Mid0064() : this(DEFAULT_REVISION)
        {

        }

        public Mid0064(Header header) : base(header)
        {

        }

        public Mid0064(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        override public string Pack()
        {
            return base.Pack();
        }
    }
}
