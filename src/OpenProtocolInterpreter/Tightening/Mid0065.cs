using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Old tightening result upload reply
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0065 : Mid, ITightening, IController
    {
        public const int MID = 65;

        [Int64DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 10)]
        [Int64DataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 10)]
        public long TighteningId { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 2, Index = 32, Size = 25)]
        [StringDataFieldDefinition(revision: 2, field: 2, Index = 32, Size = 25)]
        public string VinNumber { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 3, Index = 59, Size = 3)]
        [Int32DataFieldDefinition(revision: 2, field: 4, Index = 65, Size = 3)]
        public int ParameterSetId { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 4, Index = 64, Size = 4)]
        [Int32DataFieldDefinition(revision: 2, field: 8, Index = 87, Size = 4)]
        public int BatchCounter { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 5, Index = 70, Size = 1)]
        [BooleanDataFieldDefinition(revision: 2, field: 9, Index = 93, Size = 1)]
        public bool TighteningStatus { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 6, Index = 73, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 11, Index = 99, Size = 1)]
        public TighteningValueStatus TorqueStatus { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 7, Index = 76, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 12, Index = 102, Size = 1)]
        public TighteningValueStatus AngleStatus { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 8, Index = 79, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 19, Index = 132, Size = 6)]
        public decimal Torque { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 9, Index = 87, Size = 5)]
        [Int32DataFieldDefinition(revision: 2, field: 20, Index = 140, Size = 5)]
        public int Angle { get; set; }

        [TimestampDataFieldDefinition(revision: 1, field: 10, Index = 94, Size = 19)]
        [TimestampDataFieldDefinition(revision: 2, field: 28, Index = 205, Size = 19)]
        public DateTime Timestamp { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 11, Index = 115, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 10, Index = 96, Size = 1)]
        public BatchStatus BatchStatus { get; set; }

        //Rev 2
        [Int32DataFieldDefinition(revision: 2, field: 3, Index = 59, Size = 4)]
        public int JobId { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 5, Index = 70, Size = 2)]
        public Strategy Strategy { get; set; }

        [StrategyOptionsDefinition(revision: 2, field: 6, Index = 74, Size = 5, PaddingChar = '0', PaddingOrientation = PaddingOrientation.LeftPadded)]
        public StrategyOptions StrategyOptions { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 7, Index = 81, Size = 4)]
        public int BatchSize { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 13, Index = 105, Size = 1)]
        public TighteningValueStatus RundownAngleStatus { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 14, Index = 108, Size = 1)]
        public TighteningValueStatus CurrentMonitoringStatus { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 15, Index = 111, Size = 1)]
        public TighteningValueStatus SelftapStatus { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 16, Index = 114, Size = 1)]
        public TighteningValueStatus PrevailTorqueMonitoringStatus { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 17, Index = 117, Size = 1)]
        public TighteningValueStatus PrevailTorqueCompensateStatus { get; set; }

        [TighteningErrorStatusDefinition(revision: 2, field: 18, Index = 120, Size = 10, PaddingChar = '0', PaddingOrientation = PaddingOrientation.LeftPadded)]
        public TighteningErrorStatus TighteningErrorStatus { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 21, Index = 147, Size = 5)]
        public int RundownAngle { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 22, Index = 154, Size = 3)]
        public int CurrentMonitoringValue { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 23, Index = 159, Size = 6)]
        public decimal SelftapTorque { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 24, Index = 167, Size = 6)]
        public decimal PrevailTorque { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 25, Index = 175, Size = 5)]
        public int JobSequenceNumber { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 26, Index = 182, Size = 5)]
        public int SyncTighteningId { get; set; }

        [StringDataFieldDefinition(revision: 2, field: 27, Index = 189, Size = 14)]
        public string ToolSerialNumber { get; set; }

        //Rev 3
        [Int32DataFieldDefinition(revision: 3, field: 29, Index = 226, Size = 1)]
        public TorqueValuesUnit TorqueValuesUnit { get; set; }

        [Int32DataFieldDefinition(revision: 3, field: 30, Index = 229, Size = 2)]
        public ResultType ResultType { get; set; }


        //Rev 4
        [StringDataFieldDefinition(revision: 4, field: 31, Index = 233, Size = 25)]
        public string IdentifierResultPart2 { get; set; }

        [StringDataFieldDefinition(revision: 4, field: 32, Index = 260, Size = 25)]
        public string IdentifierResultPart3 { get; set; }

        [StringDataFieldDefinition(revision: 4, field: 33, Index = 287, Size = 25)]
        public string IdentifierResultPart4 { get; set; }

        //Rev 5
        [StringDataFieldDefinition(revision: 5, field: 34, Index = 314, Size = 4)]
        public string CustomerTighteningErrorCode { get; set; }

        //Rev 6
        [TruncatedDecimalDataFieldDefinition(revision: 6, field: 35, Index = 320, Size = 6)]
        public decimal PrevailTorqueCompensateValue { get; set; }

        [TighteningErrorStatus2Definition(revision: 6, field: 36, Index = 328, Size = 10, PaddingChar = '0', PaddingOrientation = PaddingOrientation.LeftPadded)]
        public TighteningErrorStatus2 TighteningErrorStatus2 { get; set; }

        //Rev 7
        [Int64DataFieldDefinition(revision: 7, field: 37, Index = 340, Size = 10)]
        public long StationId { get; set; }

        [StringDataFieldDefinition(revision: 7, field: 38, Index = 352, Size = 25)]
        public string StationName { get; set; }

        //Rev 8
        [TruncatedDecimalDataFieldDefinition(revision: 8, field: 39, Index = 379, Size = 6)]
        public decimal StartFinalAngle { get; set; }

        [Int32DataFieldDefinition(revision: 8, field: 40, Index = 387, Size = 1)]
        public PostViewTorque PostViewTorqueActivated { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 8, field: 41, Index = 390, Size = 6)]
        public decimal PostViewTorqueHigh { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 8, field: 42, Index = 398, Size = 6)]
        public decimal PostViewTorqueLow { get; set; }

        //Rev 9
        [TruncatedDecimalDataFieldDefinition(revision: 9, field: 43, Index = 406, Size = 5)]
        public decimal CurrentMonitoringAmpere { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 9, field: 44, Index = 413, Size = 5)]
        public decimal CurrentMonitoringAmpereMin { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 9, field: 45, Index = 420, Size = 5)]
        public decimal CurrentMonitoringAmpereMax { get; set; }

        //Rev 10 addition
        [Int32DataFieldDefinition(revision: 10, field: 46, Index = 427, Size = 5)]
        public int AngleNumeratorScaleFactor { get; set; }

        [Int32DataFieldDefinition(revision: 10, field: 47, Index = 434, Size = 5)]
        public int AngleDenominatorScaleFactor { get; set; }

        [Int32DataFieldDefinition(revision: 10, field: 48, Index = 441, Size = 1)]
        public TighteningValueStatus OverallAngleStatus { get; set; }

        [Int32DataFieldDefinition(revision: 10, field: 49, Index = 444, Size = 5)]
        public int OverallAngleMin { get; set; }

        [Int32DataFieldDefinition(revision: 10, field: 50, Index = 451, Size = 5)]
        public int OverallAngleMax { get; set; }

        [Int32DataFieldDefinition(revision: 10, field: 51, Index = 458, Size = 5)]
        public int OverallAngle { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 10, field: 52, Index = 465, Size = 6)]
        public decimal PeakTorque { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 10, field: 53, Index = 473, Size = 6)]
        public decimal ResidualBreakawayTorque { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 10, field: 54, Index = 481, Size = 6)]
        public decimal StartRundownAngle { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 10, field: 55, Index = 489, Size = 6)]
        public decimal RundownAngleComplete { get; set; }

        //Rev 11
        [TruncatedDecimalDataFieldDefinition(revision: 11, field: 56, Index = 497, Size = 6)]
        public decimal ClickTorque { get; set; }

        [Int32DataFieldDefinition(revision: 11, field: 57, Index = 505, Size = 5)]
        public int ClickAngle { get; set; }

        //Rev 12
        [Int32DataFieldDefinition(revision: 12, field: 58, Index = 512, Size = 4)]
        public int SelectedIdentifierNumber { get; set; }

        [StringDataFieldDefinition(revision: 12, field: 59, Index = 518, Size = 25)]
        public string JointId { get; set; }

        //Rev 998 addition
        [Int32DataFieldDefinition(revision: 998, field: 37, Index = 340, Size = 2)]
        public int NumberOfStagesInMultistage { get; set; }

        [Int32DataFieldDefinition(revision: 998, field: 38, Index = 344, Size = 2)]
        public int NumberOfStageResults { get; set; }

        [StageResultCollectionDefinition(revision: 998, field: 39, Index = 348, Size = 0)]
        public List<StageResult> StageResults { get; set; }

        public Mid0065() : this(DEFAULT_REVISION)
        {

        }

        public Mid0065(Header header) : base(header)
        {

        }

        public Mid0065(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        protected override string BuildHeader()
        {
            if (RevisionsByFields.Any())
            {
                Header.Length = Header.DefaultSize;
                if (Header.Revision == 998)
                {
                    var stageResultField = GetField(nameof(StageResults));
                    stageResultField.Size = StageResults.Count * 11;
                }

                var fields = DataFieldsByRevision();
                Header.Length += fields.Sum(x => x.TotalSize);
            }
            return Header.ToString();
        }

        public override string Pack()
        {
            var builder = new StringBuilder();
            var fields = DataFieldsByRevision().OrderBy(f => f.Index).ToList();
            builder.Append(BuildHeader());
            builder.Append(Pack(fields));

            return builder.ToString();
        }

        protected override void ProcessDataFields(ReadOnlySpan<char> package)
        {
            var fields = DataFieldsByRevision().OrderBy(f => f.Index).ToList();
            base.ProcessDataFields(fields, package);
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (Header.StandardizedRevision == 998 && dataField.Field == 39)
            {
                dataField.Size = NumberOfStageResults * 11;
            }
            base.ProcessDataField(dataField, package);
        }


        private IEnumerable<DataField> DataFieldsByRevision()
        {
            var currentRevision = Header.StandardizedRevision;
            var fromRevision = Header.StandardizedRevision;
            var toRevision = Header.StandardizedRevision;
            if (currentRevision > 1)
            {
                fromRevision = 2;
                toRevision = Header.StandardizedRevision != 998 ? Header.StandardizedRevision : 6;
            }

            for (int i = fromRevision; i <= toRevision; i++)
            {
                foreach (var dataField in RevisionsByFields[i])
                    yield return dataField;
            }

            if (currentRevision == 998)
            {
                foreach (var dataField in RevisionsByFields[998])
                    yield return dataField;
            }
        }
    }
}
