using System;
using System.Collections.Generic;
using System.Text;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Multi-spindle status
    /// <para>
    ///      The multi-spindle status is sent after each sync tightening. The multiple status contains the common
    ///      status of the multiple as well as the individual status of each spindle.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0092"/> Multi-spindle status acknowledge</para>
    /// </summary>
    public class Mid0091 : Mid, IMultiSpindle, IController, IAcknowledgeable<Mid0092>
    {
        public const int MID = 91;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 2)]
        public int NumberOfSpindles { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 24, Size = 5)]
        public int SyncTighteningId { get; set; }
        [TimestampDataFieldDefinition(revision: 1, field: 3, Index = 31)]
        public DateTime Time { get; set; }
        [BooleanDataFieldDefinition(revision: 1, field: 4, Index = 52)]
        public bool SyncOverallStatus { get; set; }
        [SpindleStatusCollectionDefinition(revision: 1, field: 5, Index = 55, Size = 5)]
        public List<SpindleStatus> SpindlesStatus { get; set; }

        public Mid0091() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0091(Header header) : base(header)
        {
            SpindlesStatus ??= [];
        }


        public override string Pack()
        {
            NumberOfSpindles = SpindlesStatus?.Count ?? 0; //Enforce the number of spindles to match the list count
            GetField(nameof(SpindlesStatus)).Size = NumberOfSpindles * SpindleStatus.DefaultSize;
            return base.Pack();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 5)
            {
                dataField.Size = NumberOfSpindles * SpindleStatus.DefaultSize;
            }
            base.ProcessDataField(dataField, package);
        }
    }
}
