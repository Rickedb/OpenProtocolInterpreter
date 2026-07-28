using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Multi-spindle result
    /// <para>
    ///     The multi-spindle result is sent after each sync tightening and if it is subscribed. The multiple results
    ///     contain the common status of the multiple as well as the individual tightening result(torque and angle)
    ///     of each spindle.
    /// </para>
    /// <para>
    ///     This telegram is also used for PowerMACS systems running a Press.The layout of the telegram is
    ///     exactly the same but some of the fields have slightly different definitions.The fields for Torque are
    ///     used for Force values and the fields for Angle are used for Stroke values. A press system always uses
    ///     revision 4 or higher of the telegram.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0102"/> Multi-spindle result acknowledge</para>
    /// </summary>
    public class Mid0101 : Mid, IMultiSpindle, IController, IAcknowledgeable<Mid0102>
    {
        public const int MID = 101;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 2)]
        public int NumberOfSpindlesOrPresses { get; set; }
        [StringDataFieldDefinition(revision: 1, field: 2, Index = 24, Size = 25)]
        public string VinNumber { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 3, Index = 51, Size = 2)]
        public int JobId { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 4, Index = 55, Size = 3)]
        public int ParameterSetId { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 5, Index = 60, Size = 4)]
        public int BatchSize { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 6, Index = 66, Size = 4)]
        public int BatchCounter { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 7, Index = 72, Size = 1)]
        public BatchStatus BatchStatus { get; set; }
        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 8, Index = 75, Size = 6)]
        public decimal TorqueOrForceMinLimit { get; set; }
        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 9, Index = 83, Size = 6)]
        public decimal TorqueOrForceMaxLimit { get; set; }
        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 10, Index = 91, Size = 6)]
        public decimal TorqueOrForceFinalTarget { get; set; }
        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 11, Index = 99, Size = 5)]
        public decimal AngleOrStrokeMinLimit { get; set; }
        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 12, Index = 106, Size = 5)]
        public decimal AngleOrStrokeMaxLimit { get; set; }
        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 13, Index = 113, Size = 5)]
        public decimal FinalAngleOrStrokeTarget { get; set; }
        [TimestampDataFieldDefinition(revision: 1, field: 14, Index = 120)]
        public DateTime LastChangeInParameterSet { get; set; }
        [TimestampDataFieldDefinition(revision: 1, field: 15, Index = 141)]
        public DateTime TimeStamp { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 16, Index = 162, Size = 5)]
        public int SyncTighteningId { get; set; }
        [BooleanDataFieldDefinition(revision: 1, field: 17, Index = 169)]
        public bool SyncOverallStatus { get; set; }
        [SpindleOrPressStatusCollectionDefinition(revision: 1, field: 18, Index = 172)]
        public List<SpindleOrPressStatus> SpindlesOrPressesStatus { get; set; }
        [Int32DataFieldDefinition(revision: 4, field: 19, Index = 0, Size = 3)]
        public SystemSubType SystemSubType { get; set; }
        [Int32DataFieldDefinition(revision: 5, field: 20, Index = 0, Size = 5)]
        public int JobSequenceNumber { get; set; }

        public Mid0101() : this(DEFAULT_REVISION)
        {

        }

        public Mid0101(Header header) : base(header)
        {

        }

        public Mid0101(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        public override string Pack()
        {
            NumberOfSpindlesOrPresses = SpindlesOrPressesStatus?.Count ?? 0; //Enforce the number of spindles to match the list count
            var spindlesOrPressesStatusField = GetField(revision: 1, field: 18);
            spindlesOrPressesStatusField.Size = NumberOfSpindlesOrPresses * SpindleOrPressStatus.DefaultSize;
            if (Header.Revision > 3)
            {
                var systemSubTypeField = GetField(revision: 4, field: 19);
                systemSubTypeField.Index = spindlesOrPressesStatusField.Index + spindlesOrPressesStatusField.TotalSize;
                if (Header.Revision > 4)
                {
                    GetField(revision: 5, field: 20).Index = systemSubTypeField.Index + systemSubTypeField.TotalSize;
                }
            }
            return base.Pack();
        }


        protected override void ProcessDataFields(ReadOnlySpan<char> package)
        {
            foreach (var field in DataFieldsByRevision())
            {
                ProcessDataField(field, package);
            }
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 18)
            {
                dataField.Size = NumberOfSpindlesOrPresses * SpindleOrPressStatus.DefaultSize;
            }
            base.ProcessDataField(dataField, package);
        }

        private IEnumerable<DataField> DataFieldsByRevision()
        {
            var previousField = default(DataField);
            foreach (var fields in RevisionsByFields)
            {
                foreach (var dataField in fields.Value)
                {
                    if (previousField != null && dataField.Index == 0)
                    {
                        dataField.Index = previousField.Index + previousField.TotalSize;
                    }

                    previousField = dataField;
                    yield return dataField;
                }
            }
        }
    }
}
