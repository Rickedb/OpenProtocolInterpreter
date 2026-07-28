using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Last tightening result data
    /// <para>Upload the last tightening result.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0062"/> Last tightening result data acknowledge</para>
    /// </summary>
    public class Mid0061 : Mid, ITightening, IController, IAcknowledgeable<Mid0062>
    {
        public const int MID = 61;

        [Int32DataFieldDefinition(field: 1, revision: 1, Index = 20, Size = 4)]
        [Int32DataFieldDefinition(field: 1, revision: 2, Index = 20, Size = 4)]
        public int CellId { get; set; }

        [Int32DataFieldDefinition(field: 2, revision: 1, Index = 26, Size = 2)]
        [Int32DataFieldDefinition(field: 2, revision: 2, Index = 26, Size = 2)]
        public int ChannelId { get; set; }

        [StringDataFieldDefinition(field: 3, revision: 1, Index = 30, Size = 25)]
        [StringDataFieldDefinition(field: 3, revision: 2, Index = 30, Size = 25)]
        public string TorqueControllerName { get; set; }

        [StringDataFieldDefinition(field: 4, revision: 1, Index = 57, Size = 25)]
        [StringDataFieldDefinition(field: 4, revision: 2, Index = 57, Size = 25)]
        [StringDataFieldDefinition(field: 1, revision: 999, Index = 20, Size = 25, HasPrefix = false)]
        public string VinNumber { get; set; }

        [Int32DataFieldDefinition(field: 5, revision: 1, Index = 84, Size = 2)]
        [Int32DataFieldDefinition(field: 5, revision: 2, Index = 84, Size = 4)]
        [Int32DataFieldDefinition(field: 2, revision: 999, Index = 45, Size = 2, HasPrefix = false)]
        public int JobId { get; set; }

        [Int32DataFieldDefinition(field: 6, revision: 1, Index = 88, Size = 3)]
        [Int32DataFieldDefinition(field: 6, revision: 2, Index = 90, Size = 3)]
        [Int32DataFieldDefinition(field: 3, revision: 999, Index = 47, Size = 3, HasPrefix = false)]
        public int ParameterSetId { get; set; }

        [Int32DataFieldDefinition(field: 7, revision: 1, Index = 93, Size = 4)]
        [Int32DataFieldDefinition(field: 9, revision: 2, Index = 106, Size = 4)]
        [Int32DataFieldDefinition(field: 4, revision: 999, Index = 50, Size = 4, HasPrefix = false)]
        public int BatchSize { get; set; }

        [Int32DataFieldDefinition(field: 8, revision: 1, Index = 99, Size = 4)]
        [Int32DataFieldDefinition(field: 10, revision: 2, Index = 112, Size = 4)]
        [Int32DataFieldDefinition(field: 5, revision: 999, Index = 54, Size = 4, HasPrefix = false)]
        public int BatchCounter { get; set; }

        [BooleanDataFieldDefinition(field: 9, revision: 1, Index = 105)]
        [BooleanDataFieldDefinition(field: 11, revision: 2, Index = 118)]
        [BooleanDataFieldDefinition(field: 7, revision: 999, Index = 59, HasPrefix = false)]
        public bool TighteningStatus { get; set; }

        [Int32DataFieldDefinition(field: 10, revision: 1, Index = 108, Size = 1)]
        [Int32DataFieldDefinition(field: 13, revision: 2, Index = 124, Size = 1)]
        [Int32DataFieldDefinition(field: 8, revision: 999, Index = 60, Size = 1, HasPrefix = false)]
        public TighteningValueStatus TorqueStatus { get; set; }

        [Int32DataFieldDefinition(field: 11, revision: 1, Index = 111, Size = 1)]
        [Int32DataFieldDefinition(field: 14, revision: 2, Index = 127, Size = 1)]
        [Int32DataFieldDefinition(field: 9, revision: 999, Index = 61, Size = 1, HasPrefix = false)]
        public TighteningValueStatus AngleStatus { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 12, revision: 1, Index = 114, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(field: 21, revision: 2, Index = 157, Size = 6)]
        public decimal TorqueMinLimit { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 13, revision: 1, Index = 122, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(field: 22, revision: 2, Index = 165, Size = 6)]
        public decimal TorqueMaxLimit { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 14, revision: 1, Index = 130, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(field: 23, revision: 2, Index = 173, Size = 6)]
        public decimal TorqueFinalTarget { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 15, revision: 1, Index = 138, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(field: 24, revision: 2, Index = 181, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(field: 10, revision: 999, Index = 62, Size = 6, HasPrefix = false)]
        public decimal Torque { get; set; }

        [Int32DataFieldDefinition(field: 16, revision: 1, Index = 146, Size = 5)]
        [Int32DataFieldDefinition(field: 25, revision: 2, Index = 189, Size = 5)]
        public int AngleMinLimit { get; set; }

        [Int32DataFieldDefinition(field: 17, revision: 1, Index = 153, Size = 5)]
        [Int32DataFieldDefinition(field: 26, revision: 2, Index = 196, Size = 5)]
        public int AngleMaxLimit { get; set; }

        [Int32DataFieldDefinition(field: 18, revision: 1, Index = 160, Size = 5)]
        [Int32DataFieldDefinition(field: 27, revision: 2, Index = 203, Size = 5)]
        public int AngleFinalTarget { get; set; }

        [Int32DataFieldDefinition(field: 19, revision: 1, Index = 167, Size = 5)]
        [Int32DataFieldDefinition(field: 28, revision: 2, Index = 210, Size = 5)]
        [Int32DataFieldDefinition(field: 11, revision: 999, Index = 68, Size = 5, HasPrefix = false)]
        public int Angle { get; set; }

        [TimestampDataFieldDefinition(field: 20, revision: 1, Index = 174)]
        [TimestampDataFieldDefinition(field: 45, revision: 2, Index = 343)]
        [TimestampDataFieldDefinition(field: 12, revision: 999, Index = 73, HasPrefix = false)]
        public DateTime Timestamp { get; set; }

        [TimestampDataFieldDefinition(field: 21, revision: 1, Index = 195)]
        [TimestampDataFieldDefinition(field: 46, revision: 2, Index = 364)]
        [TimestampDataFieldDefinition(field: 13, revision: 999, Index = 92, HasPrefix = false)]
        public DateTime LastChangeInParameterSet { get; set; }

        [Int32DataFieldDefinition(field: 22, revision: 1, Index = 216, Size = 1)]
        [Int32DataFieldDefinition(field: 12, revision: 2, Index = 121, Size = 1)]
        [Int32DataFieldDefinition(field: 6, revision: 999, Index = 58, Size = 1, HasPrefix = false)]
        public BatchStatus BatchStatus { get; set; }

        [Int64DataFieldDefinition(field: 23, revision: 1, Index = 219, Size = 10)]
        [Int64DataFieldDefinition(field: 41, revision: 2, Index = 301, Size = 10)]
        [Int64DataFieldDefinition(field: 14, revision: 999, Index = 111, Size = 10, HasPrefix = false)]
        public long TighteningId { get; set; }

        //Rev 2
        [Int32DataFieldDefinition(field: 7, revision: 2, Index = 95, Size = 2)]
        public Strategy Strategy { get; set; }

        [StrategyOptionsDefinition(field: 8, revision: 2, Index = 99, Size = 5, PaddingChar = '0', PaddingOrientation = PaddingOrientation.LeftPadded)]
        public StrategyOptions StrategyOptions { get; set; }

        [Int32DataFieldDefinition(field: 15, revision: 2, Index = 130, Size = 1)]
        public TighteningValueStatus RundownAngleStatus { get; set; }

        [Int32DataFieldDefinition(field: 16, revision: 2, Index = 133, Size = 1)]
        public TighteningValueStatus CurrentMonitoringStatus { get; set; }

        [Int32DataFieldDefinition(field: 17, revision: 2, Index = 136, Size = 1)]
        public TighteningValueStatus SelftapStatus { get; set; }

        [Int32DataFieldDefinition(field: 18, revision: 2, Index = 139, Size = 1)]
        public TighteningValueStatus PrevailTorqueMonitoringStatus { get; set; }


        [Int32DataFieldDefinition(field: 19, revision: 2, Index = 142, Size = 1)]
        public TighteningValueStatus PrevailTorqueCompensateStatus { get; set; }

        [TighteningErrorStatusDefinition(field: 20, revision: 2, Index = 145, Size = 10, PaddingChar = '0', PaddingOrientation = PaddingOrientation.LeftPadded)]
        public TighteningErrorStatus TighteningErrorStatus { get; set; }

        [Int32DataFieldDefinition(field: 29, revision: 2, Index = 217, Size = 5)]
        public int RundownAngleMin { get; set; }

        [Int32DataFieldDefinition(field: 30, revision: 2, Index = 224, Size = 5)]
        public int RundownAngleMax { get; set; }

        [Int32DataFieldDefinition(field: 31, revision: 2, Index = 231, Size = 5)]
        public int RundownAngle { get; set; }

        [Int32DataFieldDefinition(field: 32, revision: 2, Index = 238, Size = 3)]
        public int CurrentMonitoringMin { get; set; }

        [Int32DataFieldDefinition(field: 33, revision: 2, Index = 243, Size = 3)]
        public int CurrentMonitoringMax { get; set; }

        [Int32DataFieldDefinition(field: 34, revision: 2, Index = 248, Size = 3)]
        public int CurrentMonitoringValue { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 35, revision: 2, Index = 253, Size = 6)]
        public decimal SelftapMin { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 36, revision: 2, Index = 261, Size = 6)]
        public decimal SelftapMax { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 37, revision: 2, Index = 269, Size = 6)]
        public decimal SelftapTorque { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 38, revision: 2, Index = 277, Size = 6)]
        public decimal PrevailTorqueMonitoringMin { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 39, revision: 2, Index = 285, Size = 6)]
        public decimal PrevailTorqueMonitoringMax { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 40, revision: 2, Index = 293, Size = 6)]
        public decimal PrevailTorque { get; set; }

        [Int32DataFieldDefinition(field: 42, revision: 2, Index = 313, Size = 5)]
        public int JobSequenceNumber { get; set; }

        [Int32DataFieldDefinition(field: 43, revision: 2, Index = 320, Size = 5)]
        public int SyncTighteningId { get; set; }

        [StringDataFieldDefinition(field: 44, revision: 2, Index = 327, Size = 14)]
        public string ToolSerialNumber { get; set; }

        //Rev 3 Addition
        [StringDataFieldDefinition(field: 47, revision: 3, Index = 385, Size = 25)]
        public string ParameterSetName { get; set; }

        [Int32DataFieldDefinition(field: 48, revision: 3, Index = 412, Size = 1)]
        public TorqueValuesUnit TorqueValuesUnit { get; set; }

        [Int32DataFieldDefinition(field: 49, revision: 3, Index = 415, Size = 2)]
        public ResultType ResultType { get; set; }

        //Rev 4 addition
        [StringDataFieldDefinition(field: 50, revision: 4, Index = 419, Size = 25)]
        public string IdentifierResultPart2 { get; set; }

        [StringDataFieldDefinition(field: 51, revision: 4, Index = 446, Size = 25)]
        public string IdentifierResultPart3 { get; set; }

        [StringDataFieldDefinition(field: 52, revision: 4, Index = 473, Size = 25)]
        public string IdentifierResultPart4 { get; set; }

        //Rev 5 addition
        [StringDataFieldDefinition(field: 53, revision: 5, Index = 500, Size = 4)]
        public string CustomerTighteningErrorCode { get; set; }

        //Rev 6 Addition
        [TruncatedDecimalDataFieldDefinition(field: 54, revision: 6, Index = 506, Size = 6)]
        public decimal PrevailTorqueCompensateValue { get; set; }

        [TighteningErrorStatus2Definition(field: 55, revision: 6, Index = 514, Size = 10, PaddingChar = '0', PaddingOrientation = PaddingOrientation.LeftPadded)]
        public TighteningErrorStatus2 TighteningErrorStatus2 { get; set; }

        //Rev 7 addition
        [TruncatedDecimalDataFieldDefinition(field: 56, revision: 7, Index = 526, Size = 7)]
        public decimal CompensatedAngle { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 57, revision: 7, Index = 535, Size = 7)]
        public decimal FinalAngleDecimal { get; set; }

        //Rev 8 addition
        [TruncatedDecimalDataFieldDefinition(field: 58, revision: 8, Index = 544, Size = 6)]
        public decimal StartFinalAngle { get; set; }

        [Int32DataFieldDefinition(field: 59, revision: 8, Index = 552, Size = 1)]
        public PostViewTorque PostViewTorqueActivated { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 60, revision: 8, Index = 555, Size = 6)]
        public decimal PostViewTorqueHigh { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 61, revision: 8, Index = 563, Size = 6)]
        public decimal PostViewTorqueLow { get; set; }

        //Rev 9 addition
        [TruncatedDecimalDataFieldDefinition(field: 62, revision: 9, Index = 571, Size = 5)]
        public decimal CurrentMonitoringAmpere { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 63, revision: 9, Index = 578, Size = 5)]
        public decimal CurrentMonitoringAmpereMin { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 64, revision: 9, Index = 585, Size = 5)]
        public decimal CurrentMonitoringAmpereMax { get; set; }

        //Rev 10 addition
        [Int32DataFieldDefinition(field: 65, revision: 10, Index = 592, Size = 5)]
        public int AngleNumeratorScaleFactor { get; set; }

        [Int32DataFieldDefinition(field: 66, revision: 10, Index = 599, Size = 5)]
        public int AngleDenominatorScaleFactor { get; set; }

        [Int32DataFieldDefinition(field: 67, revision: 10, Index = 606, Size = 1)]
        public TighteningValueStatus OverallAngleStatus { get; set; }

        [Int32DataFieldDefinition(field: 68, revision: 10, Index = 609, Size = 5)]
        public int OverallAngleMin { get; set; }

        [Int32DataFieldDefinition(field: 69, revision: 10, Index = 616, Size = 5)]
        public int OverallAngleMax { get; set; }

        [Int32DataFieldDefinition(field: 70, revision: 10, Index = 623, Size = 5)]
        public int OverallAngle { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 71, revision: 10, Index = 630, Size = 6)]
        public decimal PeakTorque { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 72, revision: 10, Index = 638, Size = 6)]
        public decimal ResidualBreakawayTorque { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 73, revision: 10, Index = 646, Size = 6)]
        public decimal StartRundownAngle { get; set; }

        [TruncatedDecimalDataFieldDefinition(field: 74, revision: 10, Index = 654, Size = 6)]
        public decimal RundownAngleComplete { get; set; }

        //Rev 11
        [TruncatedDecimalDataFieldDefinition(field: 75, revision: 11, Index = 662, Size = 6)]
        public decimal ClickTorque { get; set; }

        [Int32DataFieldDefinition(field: 76, revision: 11, Index = 670, Size = 5)]
        public int ClickAngle { get; set; }

        //Rev 12
        [Int32DataFieldDefinition(field: 77, revision: 12, Index = 677, Size = 4)]
        public int SelectedIdentifierNumber { get; set; }

        [StringDataFieldDefinition(field: 78, revision: 12, Index = 683, Size = 25)]
        public string JointId { get; set; }

        //Rev 998 addition
        [Int32DataFieldDefinition(field: 56, revision: 998, Index = 526, Size = 2)]
        public int NumberOfStagesInMultistage { get; set; }

        [Int32DataFieldDefinition(field: 57, revision: 998, Index = 530, Size = 2)]
        public int NumberOfStageResults { get; set; }

        [StageResultCollectionDefinition(field: 58, revision: 998, Index = 534, Size = 0)]
        public List<StageResult> StageResults { get; set; }

        public Mid0061() : this(DEFAULT_REVISION)
        {

        }

        public Mid0061(Header header) : base(header)
        {
        }

        public Mid0061(int revision) : this(new Header()
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
            ProcessDataFields(fields, package);
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (Header.StandardizedRevision == 998 && dataField.Field == 58)
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
            if (currentRevision == 999)
            {
                fromRevision = toRevision = 999;
            }
            else if (currentRevision > 1)
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
            CellId,
            ChannelId,
            TorqueControllerName,
            VinNumber,
            JobId,
            ParameterSetId,
            BatchSize,
            BatchCounter,
            TighteningStatus,
            TorqueStatus,
            AngleStatus,
            TorqueMinLimit,
            TorqueMaxLimit,
            TorqueFinalTarget,
            Torque,
            AngleMinLimit,
            AngleMaxLimit,
            AngleFinalTarget,
            Angle,
            Timestamp,
            LastChangeInParameterSet,
            BatchStatus,
            TighteningId,
            //Rev 2
            Strategy,
            StrategyOptions,
            RundownAngleStatus,
            CurrentMonitoringStatus,
            SelftapStatus,
            PrevailTorqueMonitoringStatus,
            PrevailTorqueCompensateStatus,
            TighteningErrorStatus,
            RundownAngleMin,
            RundownAngleMax,
            RundownAngle,
            CurrentMonitoringMin,
            CurrentMonitoringMax,
            CurrentMonitoringValue,
            SelftapMin,
            SelftapMax,
            SelftapTorque,
            PrevailTorqueMonitoringMin,
            PrevailTorqueMonitoringMax,
            PrevailTorque,
            JobSequenceNumber,
            SyncTighteningId,
            ToolSerialNumber,
            //Rev 3
            ParameterSetName,
            TorqueValuesUnit,
            ResultType,
            //Rev 4
            IdentifierResultPart2,
            IdentifierResultPart3,
            IdentifierResultPart4,
            //Rev 5
            CustomerTighteningErrorCode,
            //Rev 6
            PrevailTorqueCompensateValue,
            TighteningErrorStatus2,
            //Rev 7
            CompensatedAngle,
            FinalAngleDecimal,
            //Rev 8
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
            //Rev 999 => all registered
        }
    }
}
