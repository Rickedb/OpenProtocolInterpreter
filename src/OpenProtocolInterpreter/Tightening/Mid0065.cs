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

        [Int64DataFieldDefinition(field: 1, revision: 1, Index = 20, Size = 10)]
        [Int64DataFieldDefinition(field: 1, revision: 2, Index = 20, Size = 10)]
        public long TighteningId { get; set; }

        [StringDataFieldDefinition(field: 2, revision: 1, Index = 32, Size = 25)]
        [StringDataFieldDefinition(field: 2, revision: 2, Index = 32, Size = 25)]
        public string VinNumber { get; set; }

        [Int32DataFieldDefinition(field: 3, revision: 1, Index = 59, Size = 3)]
        [Int32DataFieldDefinition(field: 4, revision: 2, Index = 65, Size = 3)]
        public int ParameterSetId { get; set; }

        [Int32DataFieldDefinition(field: 4, revision: 1, Index = 64, Size = 4)]
        [Int32DataFieldDefinition(field: 8, revision: 2, Index = 87, Size = 4)]
        public int BatchCounter { get; set; }

        [BooleanDataFieldDefinition(field: 5, revision: 1, Index = 70, Size = 1)]
        [BooleanDataFieldDefinition(field: 9, revision: 2, Index = 93, Size = 1)]
        public bool TighteningStatus { get; set; }

        [Int32DataFieldDefinition(field: 6, revision: 1, Index = 73, Size = 1)]
        [Int32DataFieldDefinition(field: 11, revision: 2, Index = 99, Size = 1)]
        public TighteningValueStatus TorqueStatus { get; set; }

        [Int32DataFieldDefinition(field: 7, revision: 1, Index = 76, Size = 1)]
        [Int32DataFieldDefinition(field: 12, revision: 2, Index = 102, Size = 1)]
        public TighteningValueStatus AngleStatus { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 8, revision: 1, Index = 79, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(field: 19, revision: 2, Index = 132, Size = 6)]
        public decimal Torque { get; set; }

        [Int32DataFieldDefinition(field: 9, revision: 1, Index = 87, Size = 5)]
        [Int32DataFieldDefinition(field: 20, revision: 2, Index = 140, Size = 5)]
        public int Angle { get; set; }

        [TimestampDataFieldDefinition(field: 10, revision: 1, Index = 94, Size = 19)]
        [TimestampDataFieldDefinition(field: 28, revision: 2, Index = 205, Size = 19)]
        public DateTime Timestamp { get; set; }

        [Int32DataFieldDefinition(field: 11, revision: 1, Index = 115, Size = 1)]
        [Int32DataFieldDefinition(field: 10, revision: 2, Index = 96, Size = 1)]
        public BatchStatus BatchStatus { get; set; }

        //Rev 2
        [Int32DataFieldDefinition(field: 3, revision: 2, Index = 59, Size = 4)]
        public int JobId { get; set; }

        [Int32DataFieldDefinition(field: 5, revision: 2, Index = 70, Size = 2)]
        public Strategy Strategy { get; set; }

        [StrategyOptionsDefinition(field: 6, revision: 2, Index = 74, Size = 5, PaddingChar = '0', PaddingOrientation = PaddingOrientation.LeftPadded)]
        public StrategyOptions StrategyOptions { get; set; }

        [Int32DataFieldDefinition(field: 7, revision: 2, Index = 81, Size = 4)]
        public int BatchSize { get; set; }

        [Int32DataFieldDefinition(field: 13, revision: 2, Index = 105, Size = 1)]
        public TighteningValueStatus RundownAngleStatus { get; set; }

        [Int32DataFieldDefinition(field: 14, revision: 2, Index = 108, Size = 1)]
        public TighteningValueStatus CurrentMonitoringStatus { get; set; }

        [Int32DataFieldDefinition(field: 15, revision: 2, Index = 111, Size = 1)]
        public TighteningValueStatus SelftapStatus { get; set; }

        [Int32DataFieldDefinition(field: 16, revision: 2, Index = 114, Size = 1)]
        public TighteningValueStatus PrevailTorqueMonitoringStatus { get; set; }

        [Int32DataFieldDefinition(field: 17, revision: 2, Index = 117, Size = 1)]
        public TighteningValueStatus PrevailTorqueCompensateStatus { get; set; }

        [TighteningErrorStatusDefinition(field: 18, revision: 2, Index = 120, Size = 10, PaddingChar = '0', PaddingOrientation = PaddingOrientation.LeftPadded)]
        public TighteningErrorStatus TighteningErrorStatus { get; set; }

        [Int32DataFieldDefinition(field: 21, revision: 2, Index = 147, Size = 5)]
        public int RundownAngle { get; set; }

        [Int32DataFieldDefinition(field: 22, revision: 2, Index = 154, Size = 3)]
        public int CurrentMonitoringValue { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 23, revision: 2, Index = 159, Size = 6)]
        public decimal SelftapTorque { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 24, revision: 2, Index = 167, Size = 6)]
        public decimal PrevailTorque { get; set; }

        [Int32DataFieldDefinition(field: 25, revision: 2, Index = 175, Size = 5)]
        public int JobSequenceNumber { get; set; }

        [Int32DataFieldDefinition(field: 26, revision: 2, Index = 182, Size = 5)]
        public int SyncTighteningId { get; set; }

        [StringDataFieldDefinition(field: 27, revision: 2, Index = 189, Size = 14)]
        public string ToolSerialNumber { get; set; }

        //Rev 3
        [Int32DataFieldDefinition(field: 29, revision: 3, Index = 226, Size = 1)]
        public TorqueValuesUnit TorqueValuesUnit { get; set; }

        [Int32DataFieldDefinition(field: 30, revision: 3, Index = 229, Size = 2)]
        public ResultType ResultType { get; set; }


        //Rev 4
        [StringDataFieldDefinition(field: 31, revision: 4, Index = 233, Size = 25)]
        public string IdentifierResultPart2 { get; set; }

        [StringDataFieldDefinition(field: 32, revision: 4, Index = 260, Size = 25)]
        public string IdentifierResultPart3 { get; set; }

        [StringDataFieldDefinition(field: 33, revision: 4, Index = 287, Size = 25)]
        public string IdentifierResultPart4 { get; set; }

        //Rev 5
        [StringDataFieldDefinition(field: 34, revision: 5, Index = 314, Size = 4)]
        public string CustomerTighteningErrorCode { get; set; }

        //Rev 6
        [TruncatedDecimalDataFieldDefinition(field: 35, revision: 6, Index = 320, Size = 6)]
        public decimal PrevailTorqueCompensateValue { get; set; }

        [TighteningErrorStatus2Definition(field: 36, revision: 6, Index = 328, Size = 10, PaddingChar = '0', PaddingOrientation = PaddingOrientation.LeftPadded)]
        public TighteningErrorStatus2 TighteningErrorStatus2 { get; set; }

        //Rev 7
        [Int64DataFieldDefinition(field: 37, revision: 7, Index = 340, Size = 10)]
        public long StationId { get; set; }

        [StringDataFieldDefinition(field: 38, revision: 7, Index = 352, Size = 25)]
        public string StationName { get; set; }

        //Rev 8
        [TruncatedDecimalDataFieldDefinition(field: 39, revision: 8, Index = 379, Size = 6)]
        public decimal StartFinalAngle { get; set; }

        [Int32DataFieldDefinition(field: 40, revision: 8, Index = 387, Size = 1)]
        public PostViewTorque PostViewTorqueActivated { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 41, revision: 8, Index = 390, Size = 6)]
        public decimal PostViewTorqueHigh { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 42, revision: 8, Index = 398, Size = 6)]
        public decimal PostViewTorqueLow { get; set; }

        //Rev 9
        [TruncatedDecimalDataFieldDefinition(field: 43, revision: 9, Index = 406, Size = 5)]
        public decimal CurrentMonitoringAmpere { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 44, revision: 9, Index = 413, Size = 5)]
        public decimal CurrentMonitoringAmpereMin { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 45, revision: 9, Index = 420, Size = 5)]
        public decimal CurrentMonitoringAmpereMax { get; set; }

        //Rev 10 addition
        [Int32DataFieldDefinition(field: 46, revision: 10, Index = 427, Size = 5)]
        public int AngleNumeratorScaleFactor { get; set; }

        [Int32DataFieldDefinition(field: 47, revision: 10, Index = 434, Size = 5)]
        public int AngleDenominatorScaleFactor { get; set; }

        [Int32DataFieldDefinition(field: 48, revision: 10, Index = 441, Size = 1)]
        public TighteningValueStatus OverallAngleStatus { get; set; }

        [Int32DataFieldDefinition(field: 49, revision: 10, Index = 444, Size = 5)]
        public int OverallAngleMin { get; set; }

        [Int32DataFieldDefinition(field: 50, revision: 10, Index = 451, Size = 5)]
        public int OverallAngleMax { get; set; }

        [Int32DataFieldDefinition(field: 51, revision: 10, Index = 458, Size = 5)]
        public int OverallAngle { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 52, revision: 10, Index = 465, Size = 6)]
        public decimal PeakTorque { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 53, revision: 10, Index = 473, Size = 6)]
        public decimal ResidualBreakawayTorque { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 54, revision: 10, Index = 481, Size = 6)]
        public decimal StartRundownAngle { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 55, revision: 10, Index = 489, Size = 6)]
        public decimal RundownAngleComplete { get; set; }

        //Rev 11
        [TruncatedDecimalDataFieldDefinition(field: 56, revision: 11, Index = 497, Size = 6)]
        public decimal ClickTorque { get; set; }

        [Int32DataFieldDefinition(field: 57, revision: 11, Index = 505, Size = 5)]
        public int ClickAngle { get; set; }

        //Rev 12
        [Int32DataFieldDefinition(field: 58, revision: 12, Index = 512, Size = 4)]
        public int SelectedIdentifierNumber { get; set; }

        [StringDataFieldDefinition(field: 59, revision: 12, Index = 518, Size = 25)]
        public string JointId { get; set; }

        //Rev 998 addition
        [Int32DataFieldDefinition(field: 37, revision: 998, Index = 340, Size = 2)]
        public int NumberOfStagesInMultistage { get; set; }

        [Int32DataFieldDefinition(field: 38, revision: 998, Index = 344, Size = 2)]
        public int NumberOfStageResults { get; set; }

        [StageResultCollectionDefinition(field: 39, revision: 998, Index = 348, Size = 0)]
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

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            TighteningId,
            VinNumber,
            ParameterSetId,
            BatchCounter,
            TighteningStatus,
            TorqueStatus,
            AngleStatus,
            Torque,
            Angle,
            Timestamp,
            BatchStatus,
            //Rev 2 Additions
            JobId,
            Strategy,
            StrategyOptions,
            BatchSize,
            RundownAngleStatus,
            CurrentMonitoringStatus,
            SelftapStatus,
            PrevailTorqueMonitoringStatus,
            PrevaiTorqueMonitoringStatus,
            TighteningErrorStatus,
            RundownAngle,
            CurrentMonitoringValue,
            SelftapTorque,
            PrevailTorque,
            JobSequenceNumber,
            SyncTighteningId,
            ToolSerialNumber,
            //Rev 3 Additions
            TorqueValuesUnit,
            ResultType,
            //Rev 4 Additions
            IdentifierResulPart2,
            IdentifierResulPart3,
            IdentifierResulPart4,
            //Rev 5 Additions
            CustomerTighteningErrorCode,
            //Rev 6 Additions
            PrevailTorqueCompensateValue,
            TighteningErrorStatus2,
            //Rev 7 Additions
            StationId,
            StationName,
            //Rev 8 Additions
            StartFinalAngle,
            PostViewTorqueActivated,
            PostViewTorqueHigh,
            PostViewTorqueLow,
            //Rev 9
            CurrentMonitoringAmp,
            CurrentMonitoringAmpMin,
            CurrentMonitoringAmpMax,
            //Rev 10
            AngleNumeratorScaleFactor,
            AngleDenominatorScaleFactor,
            OverallAngleStatus,
            OverallAngleMin,
            OverallAngleMax,
            OverallAngle,
            PeakTorque,
            ResidualBreakawayTorque,
            StartRundownAngle,
            RundownAngleComplete,
            //Rev 11
            ClickTorque,
            ClickAngle,
            //Rev 12
            SelectedIdentifierNumber,
            JointId,
            //Rev 998 (Go over rev 7)
            NumberOfStagesInMultistage,
            NumberOfStageResults,
            StageResult
        }
    }
}
