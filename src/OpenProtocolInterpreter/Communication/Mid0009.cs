using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// Application Data Message unsubscribe
    /// <para>
    ///     Unsubscribe the data. This message is used for ALL unsubscribe.
    ///     When used it substitutes the use of all MID special subscription messages.
    /// </para>
    /// <para>
    ///     NOTE! The Header Revision field is the revision of the MID 0009 itself NOT the revision of the data
    ///     MID that is wanted to be subscribed for.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    /// Answer: <see cref="Mid0005"/> Command accepted with the MID subscribed for or <see cref="Mid0004"/> Command error,
    ///         MID revision unsupported or Invalid data code and the MID subscribed for
    /// </para>
    /// </summary>
    public class Mid0009 : Mid, ICommunication, IIntegrator
    {
        public const int MID = 9;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 4, HasPrefix = false)]
        public int UnsubscriptionMid { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 24, Size = 3, HasPrefix = false)]
        public int ExtraDataRevision { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 3, Index = 27, Size = 2, HasPrefix = false)]
        public int ExtraDataLength { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 4, Index = 29, Size = 0, HasPrefix = false)]
        public string ExtraData { get; set; }

        public Mid0009() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0009(Header header) : base(header)
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
            if (dataField.Field == 3)
            {
                HandleExtraDataFieldSize();
            }
        }

        private void HandleExtraDataFieldSize()
        {
            GetField(nameof(ExtraData)).Size = ExtraDataLength;
        }
    }
}
