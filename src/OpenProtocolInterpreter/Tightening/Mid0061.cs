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

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 4)]
        [Int32DataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 4)]
        public int CellId { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 26, Size = 2)]
        [Int32DataFieldDefinition(revision: 2, field: 2, Index = 26, Size = 2)]
        public int ChannelId { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 3, Index = 30, Size = 25)]
        [StringDataFieldDefinition(revision: 2, field: 3, Index = 30, Size = 25)]
        public string TorqueControllerName { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 4, Index = 57, Size = 25)]
        [StringDataFieldDefinition(revision: 2, field: 4, Index = 57, Size = 25)]
        [StringDataFieldDefinition(revision: 999, field: 1, Index = 20, Size = 25, HasPrefix = false)]
        public string VinNumber { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 5, Index = 84, Size = 2)]
        [Int32DataFieldDefinition(revision: 2, field: 5, Index = 84, Size = 4)]
        [Int32DataFieldDefinition(revision: 999, field: 2, Index = 45, Size = 2, HasPrefix = false)]
        public int JobId { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 6, Index = 88, Size = 3)]
        [Int32DataFieldDefinition(revision: 2, field: 6, Index = 90, Size = 3)]
        [Int32DataFieldDefinition(revision: 999, field: 3, Index = 47, Size = 3, HasPrefix = false)]
        public int ParameterSetId { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 7, Index = 93, Size = 4)]
        [Int32DataFieldDefinition(revision: 2, field: 9, Index = 106, Size = 4)]
        [Int32DataFieldDefinition(revision: 999, field: 4, Index = 50, Size = 4, HasPrefix = false)]
        public int BatchSize { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 8, Index = 99, Size = 4)]
        [Int32DataFieldDefinition(revision: 2, field: 10, Index = 112, Size = 4)]
        [Int32DataFieldDefinition(revision: 999, field: 5, Index = 54, Size = 4, HasPrefix = false)]
        public int BatchCounter { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 9, Index = 105)]
        [BooleanDataFieldDefinition(revision: 2, field: 11, Index = 118)]
        [BooleanDataFieldDefinition(revision: 999, field: 7, Index = 59, HasPrefix = false)]
        public bool TighteningStatus { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 10, Index = 108, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 13, Index = 124, Size = 1)]
        [Int32DataFieldDefinition(revision: 999, field: 8, Index = 60, Size = 1, HasPrefix = false)]
        public TighteningValueStatus TorqueStatus { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 11, Index = 111, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 14, Index = 127, Size = 1)]
        [Int32DataFieldDefinition(revision: 999, field: 9, Index = 61, Size = 1, HasPrefix = false)]
        public TighteningValueStatus AngleStatus { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 12, Index = 114, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 21, Index = 157, Size = 6)]
        public decimal TorqueMinLimit { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 13, Index = 122, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 22, Index = 165, Size = 6)]
        public decimal TorqueMaxLimit { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 14, Index = 130, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 23, Index = 173, Size = 6)]
        public decimal TorqueFinalTarget { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 15, Index = 138, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 24, Index = 181, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(revision: 999, field: 10, Index = 62, Size = 6, HasPrefix = false)]
        public decimal Torque { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 16, Index = 146, Size = 5)]
        [Int32DataFieldDefinition(revision: 2, field: 25, Index = 189, Size = 5)]
        public int AngleMinLimit { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 17, Index = 153, Size = 5)]
        [Int32DataFieldDefinition(revision: 2, field: 26, Index = 196, Size = 5)]
        public int AngleMaxLimit { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 18, Index = 160, Size = 5)]
        [Int32DataFieldDefinition(revision: 2, field: 27, Index = 203, Size = 5)]
        public int AngleFinalTarget { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 19, Index = 167, Size = 5)]
        [Int32DataFieldDefinition(revision: 2, field: 28, Index = 210, Size = 5)]
        [Int32DataFieldDefinition(revision: 999, field: 11, Index = 68, Size = 5, HasPrefix = false)]
        public int Angle { get; set; }

        [TimestampDataFieldDefinition(revision: 1, field: 20, Index = 174)]
        [TimestampDataFieldDefinition(revision: 2, field: 45, Index = 343)]
        [TimestampDataFieldDefinition(revision: 999, field: 12, Index = 73, HasPrefix = false)]
        public DateTime Timestamp { get; set; }

        [TimestampDataFieldDefinition(revision: 1, field: 21, Index = 195)]
        [TimestampDataFieldDefinition(revision: 2, field: 46, Index = 364)]
        [TimestampDataFieldDefinition(revision: 999, field: 13, Index = 92, HasPrefix = false)]
        public DateTime LastChangeInParameterSet { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 22, Index = 216, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 12, Index = 121, Size = 1)]
        [Int32DataFieldDefinition(revision: 999, field: 6, Index = 58, Size = 1, HasPrefix = false)]
        public BatchStatus BatchStatus { get; set; }

        [Int64DataFieldDefinition(revision: 1, field: 23, Index = 219, Size = 10)]
        [Int64DataFieldDefinition(revision: 2, field: 41, Index = 301, Size = 10)]
        [Int64DataFieldDefinition(revision: 999, field: 14, Index = 111, Size = 10, HasPrefix = false)]
        public long TighteningId { get; set; }

        //Rev 2
        [Int32DataFieldDefinition(revision: 2, field: 7, Index = 95, Size = 2)]
        public Strategy Strategy { get; set; }

        [StrategyOptionsDefinition(revision: 2, field: 8, Index = 99, Size = 5, PaddingChar = '0', PaddingOrientation = PaddingOrientation.LeftPadded)]
        public StrategyOptions StrategyOptions { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 15, Index = 130, Size = 1)]
        public TighteningValueStatus RundownAngleStatus { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 16, Index = 133, Size = 1)]
        public TighteningValueStatus CurrentMonitoringStatus { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 17, Index = 136, Size = 1)]
        public TighteningValueStatus SelftapStatus { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 18, Index = 139, Size = 1)]
        public TighteningValueStatus PrevailTorqueMonitoringStatus { get; set; }


        [Int32DataFieldDefinition(revision: 2, field: 19, Index = 142, Size = 1)]
        public TighteningValueStatus PrevailTorqueCompensateStatus { get; set; }

        [TighteningErrorStatusDefinition(revision: 2, field: 20, Index = 145, Size = 10, PaddingChar = '0', PaddingOrientation = PaddingOrientation.LeftPadded)]
        public TighteningErrorStatus TighteningErrorStatus { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 29, Index = 217, Size = 5)]
        public int RundownAngleMin { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 30, Index = 224, Size = 5)]
        public int RundownAngleMax { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 31, Index = 231, Size = 5)]
        public int RundownAngle { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 32, Index = 238, Size = 3)]
        public int CurrentMonitoringMin { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 33, Index = 243, Size = 3)]
        public int CurrentMonitoringMax { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 34, Index = 248, Size = 3)]
        public int CurrentMonitoringValue { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 35, Index = 253, Size = 6)]
        public decimal SelftapMin { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 36, Index = 261, Size = 6)]
        public decimal SelftapMax { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 37, Index = 269, Size = 6)]
        public decimal SelftapTorque { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 38, Index = 277, Size = 6)]
        public decimal PrevailTorqueMonitoringMin { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 39, Index = 285, Size = 6)]
        public decimal PrevailTorqueMonitoringMax { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 40, Index = 293, Size = 6)]
        public decimal PrevailTorque { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 42, Index = 313, Size = 5)]
        public int JobSequenceNumber { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 43, Index = 320, Size = 5)]
        public int SyncTighteningId { get; set; }

        [StringDataFieldDefinition(revision: 2, field: 44, Index = 327, Size = 14)]
        public string ToolSerialNumber { get; set; }

        //Rev 3 Addition
        [StringDataFieldDefinition(revision: 3, field: 47, Index = 385, Size = 25)]
        public string ParameterSetName { get; set; }

        [Int32DataFieldDefinition(revision: 3, field: 48, Index = 412, Size = 1)]
        public TorqueValuesUnit TorqueValuesUnit { get; set; }

        [Int32DataFieldDefinition(revision: 3, field: 49, Index = 415, Size = 2)]
        public ResultType ResultType { get; set; }

        //Rev 4 addition
        [StringDataFieldDefinition(revision: 4, field: 50, Index = 419, Size = 25)]
        public string IdentifierResultPart2 { get; set; }

        [StringDataFieldDefinition(revision: 4, field: 51, Index = 446, Size = 25)]
        public string IdentifierResultPart3 { get; set; }

        [StringDataFieldDefinition(revision: 4, field: 52, Index = 473, Size = 25)]
        public string IdentifierResultPart4 { get; set; }

        //Rev 5 addition
        [StringDataFieldDefinition(revision: 5, field: 53, Index = 500, Size = 4)]
        public string CustomerTighteningErrorCode { get; set; }

        //Rev 6 Addition
        [TruncatedDecimalDataFieldDefinition(revision: 6, field: 54, Index = 506, Size = 6)]
        public decimal PrevailTorqueCompensateValue { get; set; }

        [TighteningErrorStatus2Definition(revision: 6, field: 55, Index = 514, Size = 10, PaddingChar = '0', PaddingOrientation = PaddingOrientation.LeftPadded)]
        public TighteningErrorStatus2 TighteningErrorStatus2 { get; set; }

        //Rev 7 addition
        [TruncatedDecimalDataFieldDefinition(revision: 7, field: 56, Index = 526, Size = 7)]
        public decimal CompensatedAngle { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 7, field: 57, Index = 535, Size = 7)]
        public decimal FinalAngleDecimal { get; set; }

        //Rev 8 addition
        [TruncatedDecimalDataFieldDefinition(revision: 8, field: 58, Index = 544, Size = 6)]
        public decimal StartFinalAngle { get; set; }

        [Int32DataFieldDefinition(revision: 8, field: 59, Index = 552, Size = 1)]
        public PostViewTorque PostViewTorqueActivated { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 8, field: 60, Index = 555, Size = 6)]
        public decimal PostViewTorqueHigh { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 8, field: 61, Index = 563, Size = 6)]
        public decimal PostViewTorqueLow { get; set; }

        //Rev 9 addition
        [TruncatedDecimalDataFieldDefinition(revision: 9, field: 62, Index = 571, Size = 5)]
        public decimal CurrentMonitoringAmpere { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 9, field: 63, Index = 578, Size = 5)]
        public decimal CurrentMonitoringAmpereMin { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 9, field: 64, Index = 585, Size = 5)]
        public decimal CurrentMonitoringAmpereMax { get; set; }

        //Rev 10 addition
        [Int32DataFieldDefinition(revision: 10, field: 65, Index = 592, Size = 5)]
        public int AngleNumeratorScaleFactor { get; set; }

        [Int32DataFieldDefinition(revision: 10, field: 66, Index = 599, Size = 5)]
        public int AngleDenominatorScaleFactor { get; set; }

        [Int32DataFieldDefinition(revision: 10, field: 67, Index = 606, Size = 1)]
        public TighteningValueStatus OverallAngleStatus { get; set; }

        [Int32DataFieldDefinition(revision: 10, field: 68, Index = 609, Size = 5)]
        public int OverallAngleMin { get; set; }

        [Int32DataFieldDefinition(revision: 10, field: 69, Index = 616, Size = 5)]
        public int OverallAngleMax { get; set; }

        [Int32DataFieldDefinition(revision: 10, field: 70, Index = 623, Size = 5)]
        public int OverallAngle { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 10, field: 71, Index = 630, Size = 6)]
        public decimal PeakTorque { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 10, field: 72, Index = 638, Size = 6)]
        public decimal ResidualBreakawayTorque { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 10, field: 73, Index = 646, Size = 6)]
        public decimal StartRundownAngle { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 10, field: 74, Index = 654, Size = 6)]
        public decimal RundownAngleComplete { get; set; }

        //Rev 11
        [TruncatedDecimalDataFieldDefinition(revision: 11, field: 75, Index = 662, Size = 6)]
        public decimal ClickTorque { get; set; }

        [Int32DataFieldDefinition(revision: 11, field: 76, Index = 670, Size = 5)]
        public int ClickAngle { get; set; }

        //Rev 12
        [Int32DataFieldDefinition(revision: 12, field: 77, Index = 677, Size = 4)]
        public int SelectedIdentifierNumber { get; set; }

        [StringDataFieldDefinition(revision: 12, field: 78, Index = 683, Size = 25)]
        public string JointId { get; set; }

        //Rev 998 addition
        [Int32DataFieldDefinition(revision: 998, field: 56, Index = 526, Size = 2)]
        public int NumberOfStagesInMultistage { get; set; }

        [Int32DataFieldDefinition(revision: 998, field: 57, Index = 530, Size = 2)]
        public int NumberOfStageResults { get; set; }

        [StageResultCollectionDefinition(revision: 998, field: 58, Index = 534, Size = 0)]
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
    }
}
