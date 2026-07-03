using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// Application Communication negative acknowledge
    /// <para>
    ///     This message is used by the controller when a request, command or subscription for any reason has
    ///     not been performed.
    ///     The data field contains the message ID of the message request that failed as well as an error code.
    ///     It can also be used by the integrator to acknowledge received subscribed data/events upload and will
    ///     then do all the special subscription data acknowledges obsolete.
    /// </para>
    /// <para>
    ///     When using the communication acknowledgement of MID 0007 and <see cref="Mid0006"/> together with sequence
    ///     numbering this is an application level message only.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0004 : Mid, ICommunication, IController
    {
        public const int MID = 4;

        [Int32DataFieldDefinition(field: 0, revision: 1, Size = 4, HasPrefix = false)]
        public int FailedMid { get; set; }

        [Int32DataFieldDefinition(field: 1, revision: 1, Size = 2, HasPrefix = false)]
        public Error ErrorCode { get; set; }

        public Mid0004() : this(DEFAULT_REVISION)
        {

        }

        public Mid0004(Header header) : base(header)
        {
        }

        public Mid0004(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }

        public override string Pack()
        {
            HandleRevision();
            return base.Pack();
        }

        protected override void ProcessDataFields(ReadOnlySpan<char> package)
        {
            HandleRevision();
            base.ProcessDataFields(package);
        }

        private void HandleRevision()
            => GetField(revision: 1, field: 1).Size = Header.Revision > 1 ? 3 : 2;

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            Mid,
            ErrorCode
        }
    }
}
