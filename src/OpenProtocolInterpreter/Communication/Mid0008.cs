using System;
using System.Collections.Generic;
using System.Runtime.Versioning;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// Application data message subscription
    /// <para>
    ///     Start a subscription of data. This message is used for ALL subscription handling.
    ///     When used it substitutes the use of all MID special subscription messages.
    /// </para>
    /// <para>
    ///     NOTE! The Header Revision field is the revision of the MID 0008 itself NOT the revision of the data
    ///     MID that is wanted to be subscribed for.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Mid0005"/> Command accepted with the MID subscribed for or <see cref="Mid0004"/> Command error,
    ///         MID revision unsupported or Invalid data code and the MID subscribed for
    /// </para>
    /// </summary>
    public class Mid0008 : Mid, ICommunication, IIntegrator
    {
        public const int MID = 8;

        [Int32DataFieldDefinition(id: 0, revision: 1, Size = 4, HasPrefix = false)]
        public int SubscriptionMid { get; set; }
        [Int32DataFieldDefinition(id: 1, revision: 1, Size = 3, HasPrefix = false)]
        public int WantedRevision { get; set; }
        [Int32DataFieldDefinition(id: 2, revision: 1, Size = 2, HasPrefix = false)]
        public int ExtraDataLength { get; set; }
        [StringDataFieldDefinition(id: 3, revision: 1, Size = 0, HasPrefix = false)]
        public string ExtraData { get; set; }

        public Mid0008() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0008(Header header) : base(header)
        {
        }

        public override string Pack()
        {
            ExtraDataLength = ExtraData?.Length ?? 0;
            HandleExtraDataFieldSize();
            return base.Pack();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            base.ProcessDataField(dataField, package);
            if (dataField.Field == 2)
            {
                HandleExtraDataFieldSize();
            }
        }

        private void HandleExtraDataFieldSize()
        {
            GetField(revision: 1, field: 3).Size = ExtraDataLength;
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            SubscriptionMid,
            WantedRevision,
            ExtraDataLength,
            ExtraData
        }
    }
}
