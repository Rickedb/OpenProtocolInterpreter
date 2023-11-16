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

        public int CellId
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.CellId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.CellId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int ChannelId
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.ChannelId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.ChannelId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string TorqueControllerName
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.TorqueControllerName).Value;
            set => GetField(GetCurrentRevisionIndex(), DataFields.TorqueControllerName).SetValue(value);
        }
        public string VinNumber
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.VinNumber).Value;
            set => GetField(GetCurrentRevisionIndex(), DataFields.VinNumber).SetValue(value);
        }
        public int JobId
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.JobId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.JobId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int ParameterSetId
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.ParameterSetId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.ParameterSetId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int BatchSize
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.BatchSize).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.BatchSize).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int BatchCounter
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.BatchCounter).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.BatchCounter).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool TighteningStatus
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.TighteningStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(GetCurrentRevisionIndex(), DataFields.TighteningStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus TorqueStatus
        {
            get => (TighteningValueStatus)GetField(GetCurrentRevisionIndex(), DataFields.TorqueStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.TorqueStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus AngleStatus
        {
            get => (TighteningValueStatus)GetField(GetCurrentRevisionIndex(), DataFields.AngleStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.AngleStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal TorqueMinLimit
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.TorqueMinLimit).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(GetCurrentRevisionIndex(), DataFields.TorqueMinLimit).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal TorqueMaxLimit
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.TorqueMaxLimit).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(GetCurrentRevisionIndex(), DataFields.TorqueMaxLimit).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal TorqueFinalTarget
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.TorqueFinalTarget).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(GetCurrentRevisionIndex(), DataFields.TorqueFinalTarget).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal Torque
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.Torque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(GetCurrentRevisionIndex(), DataFields.Torque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int AngleMinLimit
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.AngleMinLimit).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.AngleMinLimit).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int AngleMaxLimit
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.AngleMaxLimit).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.AngleMaxLimit).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int AngleFinalTarget
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.AngleFinalTarget).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.AngleFinalTarget).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int Angle
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.Angle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.Angle).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime Timestamp
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.Timestamp).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(GetCurrentRevisionIndex(), DataFields.Timestamp).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime LastChangeInParameterSet
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.LastChangeInParameterSet).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(GetCurrentRevisionIndex(), DataFields.LastChangeInParameterSet).SetValue(OpenProtocolConvert.ToString, value);
        }
        public BatchStatus BatchStatus
        {
            get => (BatchStatus)GetField(GetCurrentRevisionIndex(), DataFields.BatchStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), DataFields.BatchStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public long TighteningId
        {
            get => GetField(GetCurrentRevisionIndex(), DataFields.TighteningId).GetValue(OpenProtocolConvert.ToInt64);
            set => GetField(GetCurrentRevisionIndex(), DataFields.TighteningId).SetValue(OpenProtocolConvert.ToString, value);
        }
        //Rev 2 Addition
        public Strategy Strategy
        {
            get => (Strategy)GetField(2, DataFields.Strategy).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.Strategy).SetValue(OpenProtocolConvert.ToString, value);
        }
        public StrategyOptions StrategyOptions { get; set; }
        public TighteningValueStatus RundownAngleStatus
        {
            get => (TighteningValueStatus)GetField(2, DataFields.RundownAngleStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.RundownAngleStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus CurrentMonitoringStatus
        {
            get => (TighteningValueStatus)GetField(2, DataFields.CurrentMonitoringStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.CurrentMonitoringStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus SelftapStatus
        {
            get => (TighteningValueStatus)GetField(2, DataFields.SelftapStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.SelftapStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus PrevailTorqueMonitoringStatus
        {
            get => (TighteningValueStatus)GetField(2, DataFields.PrevailTorqueMonitoringStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.PrevailTorqueMonitoringStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus PrevailTorqueCompensateStatus
        {
            get => (TighteningValueStatus)GetField(2, DataFields.PrevailTorqueCompensateStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.PrevailTorqueCompensateStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningErrorStatus TighteningErrorStatus { get; set; }
        public int RundownAngleMin
        {
            get => GetField(2, DataFields.RundownAngleMin).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.RundownAngleMin).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int RundownAngleMax
        {
            get => GetField(2, DataFields.RundownAngleMax).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.RundownAngleMax).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int RundownAngle
        {
            get => GetField(2, DataFields.RundownAngle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.RundownAngle).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int CurrentMonitoringMin
        {
            get => GetField(2, DataFields.CurrentMonitoringMin).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.CurrentMonitoringMin).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int CurrentMonitoringMax
        {
            get => GetField(2, DataFields.CurrentMonitoringMax).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.CurrentMonitoringMax).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int CurrentMonitoringValue
        {
            get => GetField(2, DataFields.CurrentMonitoringValue).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.CurrentMonitoringValue).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal SelftapMin
        {
            get => GetField(2, DataFields.SelftapMin).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, DataFields.SelftapMin).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal SelftapMax
        {
            get => GetField(2, DataFields.SelftapMax).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, DataFields.SelftapMax).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal SelftapTorque
        {
            get => GetField(2, DataFields.SelftapTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, DataFields.SelftapTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal PrevailTorqueMonitoringMin
        {
            get => GetField(2, DataFields.PrevailTorqueMonitoringMin).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, DataFields.PrevailTorqueMonitoringMin).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal PrevailTorqueMonitoringMax
        {
            get => GetField(2, DataFields.PrevailTorqueMonitoringMax).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, DataFields.PrevailTorqueMonitoringMax).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal PrevailTorque
        {
            get => GetField(2, DataFields.PrevailTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, DataFields.PrevailTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int JobSequenceNumber
        {
            get => GetField(2, DataFields.JobSequenceNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.JobSequenceNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int SyncTighteningId
        {
            get => GetField(2, DataFields.SyncTighteningId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.SyncTighteningId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string ToolSerialNumber
        {
            get => GetField(2, DataFields.ToolSerialNumber).Value;
            set => GetField(2, DataFields.ToolSerialNumber).SetValue(value);
        }
        //Rev 3 Addition
        public string ParameterSetName
        {
            get => GetField(3, DataFields.ParameterSetName).Value;
            set => GetField(3, DataFields.ParameterSetName).SetValue(value);
        }
        public TorqueValuesUnit TorqueValuesUnit
        {
            get => (TorqueValuesUnit)GetField(3, DataFields.TorqueValuesUnit).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(3, DataFields.TorqueValuesUnit).SetValue(OpenProtocolConvert.ToString, value);
        }
        public ResultType ResultType
        {
            get => (ResultType)GetField(3, DataFields.ResultType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(3, DataFields.ResultType).SetValue(OpenProtocolConvert.ToString, value);
        }
        //Rev 4 addition
        public string IdentifierResultPart2
        {
            get => GetField(4, DataFields.IdentifierResultPart2).Value;
            set => GetField(4, DataFields.IdentifierResultPart2).SetValue(value);
        }
        public string IdentifierResultPart3
        {
            get => GetField(4, DataFields.IdentifierResultPart3).Value;
            set => GetField(4, DataFields.IdentifierResultPart3).SetValue(value);
        }
        public string IdentifierResultPart4
        {
            get => GetField(4, DataFields.IdentifierResultPart4).Value;
            set => GetField(4, DataFields.IdentifierResultPart4).SetValue(value);
        }
        //Rev 5 addition
        public string CustomerTighteningErrorCode
        {
            get => GetField(5, DataFields.CustomerTighteningErrorCode).Value;
            set => GetField(5, DataFields.CustomerTighteningErrorCode).SetValue(value);
        }
        //Rev 6 Addition
        public decimal PrevailTorqueCompensateValue
        {
            get => GetField(6, DataFields.PrevailTorqueCompensateValue).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(6, DataFields.PrevailTorqueCompensateValue).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public TighteningErrorStatus2 TighteningErrorStatus2 { get; set; }
        //Rev 7 addition
        public decimal CompensatedAngle
        {
            get => GetField(7, DataFields.CompensatedAngle).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(7, DataFields.CompensatedAngle).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal FinalAngleDecimal
        {
            get => GetField(7, DataFields.FinalAngleDecimal).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(7, DataFields.FinalAngleDecimal).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        //Rev 8 addition
        public decimal StartFinalAngle
        {
            get => GetField(8, DataFields.StartFinalAngle).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(8, DataFields.StartFinalAngle).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public PostViewTorque PostViewTorqueActivated
        {
            get => (PostViewTorque)GetField(8, DataFields.PostViewTorqueActivated).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(8, DataFields.PostViewTorqueActivated).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal PostViewTorqueHigh
        {
            get => GetField(8, DataFields.PostViewTorqueHigh).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(8, DataFields.PostViewTorqueHigh).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal PostViewTorqueLow
        {
            get => GetField(8, DataFields.PostViewTorqueLow).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(8, DataFields.PostViewTorqueLow).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        //Rev 9 addition
        public decimal CurrentMonitoringAmpere
        {
            get => GetField(9, DataFields.CurrentMonitoringAmp).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(9, DataFields.CurrentMonitoringAmp).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal CurrentMonitoringAmpereMin
        {
            get => GetField(9, DataFields.CurrentMonitoringAmpMin).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(9, DataFields.CurrentMonitoringAmpMin).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal CurrentMonitoringAmpereMax
        {
            get => GetField(9, DataFields.CurrentMonitoringAmpMax).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(9, DataFields.CurrentMonitoringAmpMax).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        //Rev 10 addition
        public int AngleNumeratorScaleFactor
        {
            get => GetField(10, DataFields.AngleNumeratorScaleFactor).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, DataFields.AngleNumeratorScaleFactor).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int AngleDenominatorScaleFactor
        {
            get => GetField(10, DataFields.AngleDenominatorScaleFactor).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, DataFields.AngleDenominatorScaleFactor).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus OverallAngleStatus
        {
            get => (TighteningValueStatus)GetField(10, DataFields.OverallAngleStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, DataFields.OverallAngleStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int OverallAngleMin
        {
            get => GetField(10, DataFields.OverallAngleMin).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, DataFields.OverallAngleMin).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int OverallAngleMax
        {
            get => GetField(10, DataFields.OverallAngleMax).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, DataFields.OverallAngleMax).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int OverallAngle
        {
            get => GetField(10, DataFields.OverallAngle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(10, DataFields.OverallAngle).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal PeakTorque
        {
            get => GetField(10, DataFields.PeakTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(10, DataFields.PeakTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal ResidualBreakawayTorque
        {
            get => GetField(10, DataFields.ResidualBreakawayTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(10, DataFields.ResidualBreakawayTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal StartRundownAngle
        {
            get => GetField(10, DataFields.StartRundownAngle).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(10, DataFields.StartRundownAngle).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal RundownAngleComplete
        {
            get => GetField(10, DataFields.RundownAngleComplete).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(10, DataFields.RundownAngleComplete).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        //Rev 11
        public decimal ClickTorque
        {
            get => GetField(11, DataFields.ClickTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(11, DataFields.ClickTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int ClickAngle
        {
            get => GetField(11, DataFields.ClickAngle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(11, DataFields.ClickAngle).SetValue(OpenProtocolConvert.ToString, value);
        }
        //Rev 998 addition 
        public int NumberOfStagesInMultistage
        {
            get => GetField(998, DataFields.NumberOfStagesInMultistage).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(998, DataFields.NumberOfStagesInMultistage).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int NumberOfStageResults
        {
            get => GetField(998, DataFields.NumberOfStageResults).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(998, DataFields.NumberOfStageResults).SetValue(OpenProtocolConvert.ToString, value);
        }
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
                Header.Length = 20;
                Header.Revision = Header.Revision > 0 ? Header.Revision : 1;
                if (Header.Revision == 1 || Header.Revision == 999)
                {
                    foreach (var dataField in RevisionsByFields[Header.Revision])
                        Header.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
                }
                else
                {
                    int processUntil = Header.Revision != 998 ? Header.Revision : 6;

                    for (int i = 2; i <= processUntil; i++)
                        foreach (var dataField in RevisionsByFields[i])
                            Header.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;

                    if (Header.Revision == 998)
                    {
                        GetField(998, DataFields.StageResult).Size = StageResults.Count * 11;
                        foreach (var dataField in RevisionsByFields[998])
                            Header.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
                    }
                }
            }
            return Header.ToString();
        }

        public override string Pack()
        {
            var builder = new StringBuilder();
            int prefixIndex = 1;
            if (Header.Revision > 1 && Header.Revision != 999)
            {
                GetField(2, DataFields.StrategyOptions).SetValue(StrategyOptions.Pack());
                GetField(2, DataFields.TighteningErrorStatus).SetValue(TighteningErrorStatus.Pack());

                if (Header.Revision > 5)
                {
                    GetField(6, DataFields.TighteningErrorStatus2).SetValue(TighteningErrorStatus2.Pack());
                }

                if (Header.Revision == 998)
                {
                    NumberOfStageResults = StageResults.Count;
                    var stageResultField = GetField(998, DataFields.StageResult);
                    stageResultField.Size = StageResults.Count * 11;
                    stageResultField.SetValue(PackStageResults());
                }

                builder.Append(BuildHeader());
                int processUntilRevision = Header.Revision != 998 ? Header.Revision : 6;
                for (int revision = 2; revision <= processUntilRevision; revision++)
                {
                    builder.Append(Pack(revision, ref prefixIndex));
                }

                if (Header.Revision == 998)
                {
                    builder.Append(Pack(998, ref prefixIndex));
                }
            }
            else
            {
                builder.Append(BuildHeader());
                builder.Append(Pack(Header.Revision, ref prefixIndex));
            }

            return builder.ToString();
        }

        protected override void ProcessDataFields(string package)
        {
            if (Header.Revision == 1 || Header.Revision == 999)
            {
                ProcessDataFields(Header.Revision, package);
            }
            else
            {
                int processUntilRevision = Header.Revision;
                if (Header.Revision == 998)
                {
                    processUntilRevision = 6;
                    var stageResultField = GetField(998, DataFields.StageResult);
                    stageResultField.Size = Header.Length - stageResultField.Index - 2;
                    ProcessDataFields(998, package);
                    StageResults = StageResult.ParseAll(stageResultField.Value).ToList();
                }

                for (int revision = 2; revision <= processUntilRevision; revision++)
                    ProcessDataFields(revision, package);

                var strategyOptionsField = GetField(2, DataFields.StrategyOptions);
                StrategyOptions = StrategyOptions.Parse(strategyOptionsField.Value);

                var tighteningErrorStatusField = GetField(2, DataFields.TighteningErrorStatus);
                TighteningErrorStatus = TighteningErrorStatus.Parse(tighteningErrorStatusField.Value);

                if (Header.Revision > 5)
                {
                    var tighteningErrorStatus2Field = GetField(6, DataFields.TighteningErrorStatus2);
                    TighteningErrorStatus2 = TighteningErrorStatus2.Parse(tighteningErrorStatus2Field.Value);
                }
            }
        }

        protected virtual string PackStageResults()
        {
            var builder = new StringBuilder();
            foreach (var v in StageResults)
            {
                builder.Append(v.Pack());
            }

            return builder.ToString();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            //opted to work with a different approuch (since it would need to modify too much fields)
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Number(DataFields.CellId, 20, 4),
                                DataField.Number(DataFields.ChannelId, 26, 2),
                                DataField.String(DataFields.TorqueControllerName, 30, 25),
                                DataField.String(DataFields.VinNumber, 57, 25),
                                DataField.Number(DataFields.JobId, 84, 2),
                                DataField.Number(DataFields.ParameterSetId, 88, 3),
                                DataField.Number(DataFields.BatchSize, 93, 4),
                                DataField.Number(DataFields.BatchCounter, 99, 4),
                                DataField.Number(DataFields.TighteningStatus, 105, 1),
                                DataField.Number(DataFields.TorqueStatus, 108, 1),
                                DataField.Number(DataFields.AngleStatus, 111, 1),
                                DataField.Number(DataFields.TorqueMinLimit, 114, 6),
                                DataField.Number(DataFields.TorqueMaxLimit, 122, 6),
                                DataField.Number(DataFields.TorqueFinalTarget, 130, 6),
                                DataField.Number(DataFields.Torque, 138, 6),
                                DataField.Number(DataFields.AngleMinLimit, 146, 5),
                                DataField.Number(DataFields.AngleMaxLimit, 153, 5),
                                DataField.Number(DataFields.AngleFinalTarget, 160, 5),
                                DataField.Number(DataFields.Angle, 167, 5),
                                DataField.Timestamp(DataFields.Timestamp, 174),
                                DataField.Timestamp(DataFields.LastChangeInParameterSet, 195),
                                DataField.Number(DataFields.BatchStatus, 216, 1),
                                DataField.Number(DataFields.TighteningId, 219, 10)
                            }
                },
                {
                    2, new List<DataField>()
                            {
                                DataField.Number(DataFields.CellId, 20, 4),
                                DataField.Number(DataFields.ChannelId, 26, 2),
                                DataField.String(DataFields.TorqueControllerName, 30, 25),
                                DataField.String(DataFields.VinNumber, 57, 25),
                                DataField.Number(DataFields.JobId, 84, 4),
                                DataField.Number(DataFields.ParameterSetId, 90, 3),
                                DataField.Number(DataFields.Strategy, 95, 2),
                                new(DataFields.StrategyOptions, 99, 5, '0', PaddingOrientation.LeftPadded),
                                DataField.Number(DataFields.BatchSize, 106, 4),
                                DataField.Number(DataFields.BatchCounter, 112, 4),
                                DataField.Number(DataFields.TighteningStatus, 118, 1),
                                DataField.Number(DataFields.BatchStatus, 121, 1),
                                DataField.Number(DataFields.TorqueStatus, 124, 1),
                                DataField.Number(DataFields.AngleStatus, 127, 1),
                                DataField.Number(DataFields.RundownAngleStatus, 130, 1),
                                DataField.Number(DataFields.CurrentMonitoringStatus, 133, 1),
                                DataField.Number(DataFields.SelftapStatus, 136, 1),
                                DataField.Number(DataFields.PrevailTorqueMonitoringStatus, 139, 1),
                                DataField.Number(DataFields.PrevailTorqueCompensateStatus, 142, 1),
                                new(DataFields.TighteningErrorStatus, 145, 10, '0', PaddingOrientation.LeftPadded),
                                DataField.Number(DataFields.TorqueMinLimit, 157, 6),
                                DataField.Number(DataFields.TorqueMaxLimit, 165, 6),
                                DataField.Number(DataFields.TorqueFinalTarget, 173, 6),
                                DataField.Number(DataFields.Torque, 181, 6),
                                DataField.Number(DataFields.AngleMinLimit, 189, 5),
                                DataField.Number(DataFields.AngleMaxLimit, 196, 5),
                                DataField.Number(DataFields.AngleFinalTarget, 203, 5),
                                DataField.Number(DataFields.Angle, 210, 5),
                                DataField.Number(DataFields.RundownAngleMin, 217, 5),
                                DataField.Number(DataFields.RundownAngleMax, 224, 5),
                                DataField.Number(DataFields.RundownAngle, 231, 5),
                                DataField.Number(DataFields.CurrentMonitoringMin, 238, 3),
                                DataField.Number(DataFields.CurrentMonitoringMax, 243, 3),
                                DataField.Number(DataFields.CurrentMonitoringValue, 248, 3),
                                DataField.Number(DataFields.SelftapMin, 253, 6),
                                DataField.Number(DataFields.SelftapMax, 261, 6  ),
                                DataField.Number(DataFields.SelftapTorque, 269, 6),
                                DataField.Number(DataFields.PrevailTorqueMonitoringMin, 277, 6),
                                DataField.Number(DataFields.PrevailTorqueMonitoringMax, 285, 6),
                                DataField.Number(DataFields.PrevailTorque, 293, 6),
                                DataField.Number(DataFields.TighteningId, 301, 10),
                                DataField.Number(DataFields.JobSequenceNumber, 313, 5),
                                DataField.Number(DataFields.SyncTighteningId, 320, 5),
                                DataField.String(DataFields.ToolSerialNumber, 327, 14),
                                DataField.Timestamp(DataFields.Timestamp, 343),
                                DataField.Timestamp(DataFields.LastChangeInParameterSet, 364)
                            }
                },
                {
                    3, new List<DataField>()
                            {
                                DataField.String(DataFields.ParameterSetName, 385, 25),
                                DataField.Number(DataFields.TorqueValuesUnit, 412, 1),
                                DataField.Number(DataFields.ResultType, 415, 2)
                            }
                },
                {
                    4, new List<DataField>()
                            {
                                DataField.String(DataFields.IdentifierResultPart2, 419, 25),
                                DataField.String(DataFields.IdentifierResultPart3, 446, 25),
                                DataField.String(DataFields.IdentifierResultPart4, 473, 25)
                            }
                },
                {
                    5, new List<DataField>()
                            {
                                DataField.String(DataFields.CustomerTighteningErrorCode, 500, 4)
                            }
                },
                {
                    6, new List<DataField>()
                            {
                                DataField.Number(DataFields.PrevailTorqueCompensateValue, 506, 6),
                                new(DataFields.TighteningErrorStatus2, 514, 10, '0', PaddingOrientation.LeftPadded)
                            }
                },
                {
                    7, new List<DataField>()
                            {
                                DataField.Number(DataFields.CompensatedAngle, 526, 7),
                                DataField.Number(DataFields.FinalAngleDecimal, 535, 7)
                            }
                },
                {
                    8, new List<DataField>()
                            {
                                DataField.Number(DataFields.StartFinalAngle, 544, 6),
                                DataField.Number(DataFields.PostViewTorqueActivated, 552, 1),
                                DataField.Number(DataFields.PostViewTorqueHigh, 555, 6),
                                DataField.Number(DataFields.PostViewTorqueLow, 563, 6)
                            }
                },
                {
                    9, new List<DataField>()
                            {
                                DataField.Number(DataFields.CurrentMonitoringAmp, 571, 5),
                                DataField.Number(DataFields.CurrentMonitoringAmpMin, 578, 5),
                                DataField.Number(DataFields.CurrentMonitoringAmpMax, 585, 5)
                            }
                },
                {
                    10, new List<DataField>()
                            {
                                DataField.Number(DataFields.AngleNumeratorScaleFactor, 592, 5),
                                DataField.Number(DataFields.AngleDenominatorScaleFactor, 599, 5),
                                DataField.Number(DataFields.OverallAngleStatus, 606, 1),
                                DataField.Number(DataFields.OverallAngleMin, 609, 5),
                                DataField.Number(DataFields.OverallAngleMax, 616, 5),
                                DataField.Number(DataFields.OverallAngle, 623, 5),
                                DataField.Number(DataFields.PeakTorque, 630, 6),
                                DataField.Number(DataFields.ResidualBreakawayTorque, 638, 6),
                                DataField.Number(DataFields.StartRundownAngle, 646, 6),
                                DataField.Number(DataFields.RundownAngleComplete, 654, 6)
                            }
                },
                {
                    11, new List<DataField>()
                            {
                                DataField.Number(DataFields.ClickTorque, 662, 6),
                                DataField.Number(DataFields.ClickAngle, 670, 5),
                            }
                },
                {
                    998, new List<DataField>()
                            {
                                DataField.Number(DataFields.NumberOfStagesInMultistage, 526, 2),
                                DataField.Number(DataFields.NumberOfStageResults, 530, 2),
                                new(DataFields.StageResult, 534, 11)
                            }
                },
                {
                    999, new List<DataField>()
                            {
                                DataField.String(DataFields.VinNumber, 20, 25, false),
                                DataField.Number(DataFields.JobId, 45, 2, false),
                                DataField.Number(DataFields.ParameterSetId, 47, 3, false),
                                DataField.Number(DataFields.BatchSize, 50, 4, false),
                                DataField.Number(DataFields.BatchCounter, 54, 4, false),
                                DataField.Number(DataFields.BatchStatus, 58, 1, false),
                                DataField.Number(DataFields.TighteningStatus, 59, 1, false),
                                DataField.Number(DataFields.TorqueStatus, 60, 1, false),
                                DataField.Number(DataFields.AngleStatus, 61, 1, false),
                                DataField.Number(DataFields.Torque, 62, 6, false),
                                DataField.Number(DataFields.Angle, 68, 5, false),
                                DataField.Timestamp(DataFields.Timestamp, 73, false),
                                DataField.Timestamp(DataFields.LastChangeInParameterSet, 92, false),
                                DataField.Number(DataFields.TighteningId, 111, 10, false)
                            }
                }
            };
        }

        /// <summary>
        /// Obtain which revision we will work with for shared properties
        /// (since rev 1, 2 and 999 are way too different, they are processed in different datafields)
        /// </summary>
        /// <returns>Datafield Revision Index</returns>
        private int GetCurrentRevisionIndex()
        {
            if (Header.Revision == 999)
                return 999;

            if (Header.Revision > 1)
                return 2;

            return 1;
        }

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
            //Rev 998 (Go over rev 7)
            NumberOfStagesInMultistage,
            NumberOfStageResults,
            StageResult
            //Rev 999 => all registered
        }
    }
}
