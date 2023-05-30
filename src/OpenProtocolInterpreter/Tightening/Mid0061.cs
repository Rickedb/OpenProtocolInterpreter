using System;
using System.Collections.Generic;
using System.Linq;

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
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.CellId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.CellId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int ChannelId
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.ChannelId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.ChannelId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string TorqueControllerName
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueControllerName).Value;
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueControllerName).SetValue(value);
        }
        public string VinNumber
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.VinNumber).Value;
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.VinNumber).SetValue(value);
        }
        public int JobId
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.JobId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.JobId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int ParameterSetId
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.ParameterSetId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.ParameterSetId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int BatchSize
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchSize).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchSize).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int BatchCounter
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchCounter).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchCounter).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool TighteningStatus
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public TighteningValueStatus TorqueStatus
        {
            get => (TighteningValueStatus)GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public TighteningValueStatus AngleStatus
        {
            get => (TighteningValueStatus)GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public decimal TorqueMinLimit
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueMinLimit).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueMinLimit).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal TorqueMaxLimit
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueMaxLimit).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueMaxLimit).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal TorqueFinalTarget
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueFinalTarget).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueFinalTarget).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal Torque
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.Torque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.Torque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int AngleMinLimit
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleMinLimit).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleMinLimit).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int AngleMaxLimit
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleMaxLimit).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleMaxLimit).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int AngleFinalTarget
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleFinalTarget).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleFinalTarget).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int Angle
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.Angle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.Angle).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime Timestamp
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.Timestamp).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.Timestamp).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime LastChangeInParameterSet
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.LastChangeInParameterSet).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.LastChangeInParameterSet).SetValue(OpenProtocolConvert.ToString, value);
        }
        public BatchStatus BatchStatus
        {
            get => (BatchStatus)GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public long TighteningId
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningId).GetValue(OpenProtocolConvert.ToInt64);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningId).SetValue(OpenProtocolConvert.ToString, value);
        }
        //Rev 2 Addition
        public Strategy Strategy
        {
            get => (Strategy)GetField(2, (int)DataFields.Strategy).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.Strategy).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public StrategyOptions StrategyOptions { get; set; }
        public TighteningValueStatus RundownAngleStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.RundownAngleStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.RundownAngleStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public TighteningValueStatus CurrentMonitoringStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.CurrentMonitoringStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.CurrentMonitoringStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public TighteningValueStatus SelftapStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.SelftapStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.SelftapStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public TighteningValueStatus PrevailTorqueMonitoringStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.PrevailTorqueMonitoringStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.PrevailTorqueMonitoringStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public TighteningValueStatus PrevailTorqueCompensateStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.PrevailTorqueCompensateStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.PrevailTorqueCompensateStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public TighteningErrorStatus TighteningErrorStatus { get; set; }
        public int RundownAngleMin
        {
            get => GetField(2, (int)DataFields.RundownAngleMin).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.RundownAngleMin).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int RundownAngleMax
        {
            get => GetField(2, (int)DataFields.RundownAngleMax).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.RundownAngleMax).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int RundownAngle
        {
            get => GetField(2, (int)DataFields.RundownAngle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.RundownAngle).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int CurrentMonitoringMin
        {
            get => GetField(2, (int)DataFields.CurrentMonitoringMin).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.CurrentMonitoringMin).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int CurrentMonitoringMax
        {
            get => GetField(2, (int)DataFields.CurrentMonitoringMax).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.CurrentMonitoringMax).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int CurrentMonitoringValue
        {
            get => GetField(2, (int)DataFields.CurrentMonitoringValue).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.CurrentMonitoringValue).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal SelftapMin
        {
            get => GetField(2, (int)DataFields.SelftapMin).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.SelftapMin).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal SelftapMax
        {
            get => GetField(2, (int)DataFields.SelftapMax).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.SelftapMax).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal SelftapTorque
        {
            get => GetField(2, (int)DataFields.SelftapTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.SelftapTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal PrevailTorqueMonitoringMin
        {
            get => GetField(2, (int)DataFields.PrevailTorqueMonitoringMin).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.PrevailTorqueMonitoringMin).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal PrevailTorqueMonitoringMax
        {
            get => GetField(2, (int)DataFields.PrevailTorqueMonitoringMax).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.PrevailTorqueMonitoringMax).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal PrevailTorque
        {
            get => GetField(2, (int)DataFields.PrevailTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.PrevailTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int JobSequenceNumber
        {
            get => GetField(2, (int)DataFields.JobSequenceNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.JobSequenceNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int SyncTighteningId
        {
            get => GetField(2, (int)DataFields.SyncTighteningId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.SyncTighteningId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string ToolSerialNumber
        {
            get => GetField(2, (int)DataFields.ToolSerialNumber).Value;
            set => GetField(2, (int)DataFields.ToolSerialNumber).SetValue(value);
        }
        //Rev 3 Addition
        public string ParameterSetName
        {
            get => GetField(3, (int)DataFields.ParameterSetName).Value;
            set => GetField(3, (int)DataFields.ParameterSetName).SetValue(value);
        }
        public TorqueValuesUnit TorqueValuesUnit
        {
            get => (TorqueValuesUnit)GetField(3, (int)DataFields.TorqueValuesUnit).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(3, (int)DataFields.TorqueValuesUnit).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public ResultType ResultType
        {
            get => (ResultType)GetField(3, (int)DataFields.ResultType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(3, (int)DataFields.ResultType).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        //Rev 4 addition
        public string IdentifierResultPart2
        {
            get => GetField(4, (int)DataFields.IdentifierResultPart2).Value;
            set => GetField(4, (int)DataFields.IdentifierResultPart2).SetValue(value);
        }
        public string IdentifierResultPart3
        {
            get => GetField(4, (int)DataFields.IdentifierResultPart3).Value;
            set => GetField(4, (int)DataFields.IdentifierResultPart3).SetValue(value);
        }
        public string IdentifierResultPart4
        {
            get => GetField(4, (int)DataFields.IdentifierResultPart4).Value;
            set => GetField(4, (int)DataFields.IdentifierResultPart4).SetValue(value);
        }
        //Rev 5 addition
        public string CustomerTighteningErrorCode
        {
            get => GetField(5, (int)DataFields.CustomerTighteningErrorCode).Value;
            set => GetField(5, (int)DataFields.CustomerTighteningErrorCode).SetValue(value);
        }
        //Rev 6 Addition
        public decimal PrevailTorqueCompensateValue
        {
            get => GetField(6, (int)DataFields.PrevailTorqueCompensateValue).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(6, (int)DataFields.PrevailTorqueCompensateValue).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public TighteningErrorStatus2 TighteningErrorStatus2 { get; set; }
        //Rev 7 addition
        public decimal CompensatedAngle
        {
            get => GetField(7, (int)DataFields.CompensatedAngle).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(7, (int)DataFields.CompensatedAngle).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal FinalAngleDecimal
        {
            get => GetField(7, (int)DataFields.FinalAngleDecimal).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(7, (int)DataFields.FinalAngleDecimal).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        //Rev 8 addition
        public decimal StartFinalAngle
        {
            get => GetField(8, (int)DataFields.StartFinalAngle).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(8, (int)DataFields.StartFinalAngle).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public PostViewTorque PostViewTorqueActivated
        {
            get => (PostViewTorque)GetField(8, (int)DataFields.PostViewTorqueActivated).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(8, (int)DataFields.PostViewTorqueActivated).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public decimal PostViewTorqueHigh
        {
            get => GetField(8, (int)DataFields.PostViewTorqueHigh).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(8, (int)DataFields.PostViewTorqueHigh).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal PostViewTorqueLow
        {
            get => GetField(8, (int)DataFields.PostViewTorqueLow).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(8, (int)DataFields.PostViewTorqueLow).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        //Rev 998 addition
        public int NumberOfStagesInMultistage
        {
            get => GetField(998, (int)DataFields.NumberOfStagesInMultistage).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(998, (int)DataFields.NumberOfStagesInMultistage).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int NumberOfStageResults
        {
            get => GetField(998, (int)DataFields.NumberOfStageResults).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(998, (int)DataFields.NumberOfStageResults).SetValue(OpenProtocolConvert.ToString, value);
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
                        GetField(998, (int)DataFields.StageResult).Size = StageResults.Count * 11;
                        foreach (var dataField in RevisionsByFields[998])
                            Header.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
                    }
                }
            }
            return Header.ToString();
        }

        public override string Pack()
        {
            string package = string.Empty;
            int prefixIndex = 1;
            if (Header.Revision > 1 && Header.Revision != 999)
            {
                GetField(2, (int)DataFields.StrategyOptions).SetValue(StrategyOptions.Pack());
                GetField(2, (int)DataFields.TighteningErrorStatus).SetValue(TighteningErrorStatus.Pack());

                if (Header.Revision > 5)
                {
                    GetField(6, (int)DataFields.TighteningErrorStatus2).SetValue(TighteningErrorStatus2.Pack());
                }

                if (Header.Revision == 998)
                {
                    NumberOfStageResults = StageResults.Count;
                    var stageResultField = GetField(998, (int)DataFields.StageResult);
                    stageResultField.Size = StageResults.Count * 11;
                    stageResultField.SetValue(PackStageResults());
                }

                package = BuildHeader();
                int processUntil = Header.Revision != 998 ? Header.Revision : 6;
                for (int i = 2; i <= processUntil; i++)
                {
                    package += Pack(RevisionsByFields[i], ref prefixIndex);
                }

                if (Header.Revision == 998)
                {
                    package += Pack(RevisionsByFields[998], ref prefixIndex);
                }
            }
            else
            {
                package = BuildHeader();
                package += Pack(RevisionsByFields[Header.Revision], ref prefixIndex);
            }

            return package;
        }

        protected override void ProcessDataFields(string package)
        {
            if (Header.Revision == 1 || Header.Revision == 999)
            {
                ProcessDataFields(RevisionsByFields[Header.Revision], package);
            }
            else
            {
                int processUntil = Header.Revision;
                if (Header.Revision == 998)
                {
                    processUntil = 6;
                    var stageResultField = GetField(998, (int)DataFields.StageResult);
                    stageResultField.Size = Header.Length - stageResultField.Index - 2;
                    ProcessDataFields(RevisionsByFields[998], package);
                    StageResults = StageResult.ParseAll(stageResultField.Value).ToList();
                }

                for (int i = 2; i <= processUntil; i++)
                    ProcessDataFields(RevisionsByFields[i], package);

                var strategyOptionsField = GetField(2, (int)DataFields.StrategyOptions);
                StrategyOptions = StrategyOptions.Parse(strategyOptionsField.Value);

                var tighteningErrorStatusField = GetField(2, (int)DataFields.TighteningErrorStatus);
                TighteningErrorStatus = TighteningErrorStatus.Parse(tighteningErrorStatusField.Value);

                if (Header.Revision > 5)
                {
                    var tighteningErrorStatus2Field = GetField(6, (int)DataFields.TighteningErrorStatus2);
                    TighteningErrorStatus2 = TighteningErrorStatus2.Parse(tighteningErrorStatus2Field.Value);
                }
            }
        }

        protected virtual string PackStageResults()
        {
            string pack = string.Empty;
            foreach (var v in StageResults)
            {
                pack += v.Pack();
            }

            return pack;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            //opted to work with a different approuch (since it would need to modify too much fields)
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.CellId, 20, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ChannelId, 26, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TorqueControllerName, 30, 25, ' '),
                                new DataField((int)DataFields.VinNumber, 57, 25, ' '),
                                new DataField((int)DataFields.JobId, 84, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ParameterSetId, 88, 3, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.BatchSize, 93, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.BatchCounter, 99, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TighteningStatus, 105, 1),
                                new DataField((int)DataFields.TorqueStatus, 108, 1),
                                new DataField((int)DataFields.AngleStatus, 111, 1),
                                new DataField((int)DataFields.TorqueMinLimit, 114, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TorqueMaxLimit, 122, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TorqueFinalTarget, 130, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.Torque, 138, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.AngleMinLimit, 146, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.AngleMaxLimit, 153, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.AngleFinalTarget, 160, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.Angle, 167, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.Timestamp, 174, 19),
                                new DataField((int)DataFields.LastChangeInParameterSet, 195, 19),
                                new DataField((int)DataFields.BatchStatus, 216, 1),
                                new DataField((int)DataFields.TighteningId, 219, 10, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                },
                {
                    2, new List<DataField>()
                            {
                                new DataField((int)DataFields.CellId, 20, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ChannelId, 26, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TorqueControllerName, 30, 25, ' '),
                                new DataField((int)DataFields.VinNumber, 57, 25, ' '),
                                new DataField((int)DataFields.JobId, 84, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ParameterSetId, 90, 3, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.Strategy, 95, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.StrategyOptions, 99, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.BatchSize, 106, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.BatchCounter, 112, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TighteningStatus, 118, 1),
                                new DataField((int)DataFields.BatchStatus, 121, 1),
                                new DataField((int)DataFields.TorqueStatus, 124, 1),
                                new DataField((int)DataFields.AngleStatus, 127, 1),
                                new DataField((int)DataFields.RundownAngleStatus, 130, 1),
                                new DataField((int)DataFields.CurrentMonitoringStatus, 133, 1),
                                new DataField((int)DataFields.SelftapStatus, 136, 1),
                                new DataField((int)DataFields.PrevailTorqueMonitoringStatus, 139, 1),
                                new DataField((int)DataFields.PrevailTorqueCompensateStatus, 142, 1),
                                new DataField((int)DataFields.TighteningErrorStatus, 145, 10, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TorqueMinLimit, 157, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TorqueMaxLimit, 165, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TorqueFinalTarget, 173, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.Torque, 181, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.AngleMinLimit, 189, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.AngleMaxLimit, 196, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.AngleFinalTarget, 203, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.Angle, 210, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.RundownAngleMin, 217, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.RundownAngleMax, 224, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.RundownAngle, 231, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.CurrentMonitoringMin, 238, 3, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.CurrentMonitoringMax, 243, 3, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.CurrentMonitoringValue, 248, 3, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.SelftapMin, 253, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.SelftapMax, 261, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.SelftapTorque, 269, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.PrevailTorqueMonitoringMin, 277, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.PrevailTorqueMonitoringMax, 285, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.PrevailTorque, 293, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TighteningId, 301, 10, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.JobSequenceNumber, 313, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.SyncTighteningId, 320, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ToolSerialNumber, 327, 14, ' '),
                                new DataField((int)DataFields.Timestamp, 343, 19),
                                new DataField((int)DataFields.LastChangeInParameterSet, 364, 19)
                            }
                },
                {
                    3, new List<DataField>()
                            {
                                new DataField((int)DataFields.ParameterSetName, 385, 25, ' '),
                                new DataField((int)DataFields.TorqueValuesUnit, 412, 1),
                                new DataField((int)DataFields.ResultType, 415, 2, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                },
                {
                    4, new List<DataField>()
                            {
                                new DataField((int)DataFields.IdentifierResultPart2, 419, 25, ' '),
                                new DataField((int)DataFields.IdentifierResultPart3, 446, 25, ' '),
                                new DataField((int)DataFields.IdentifierResultPart4, 473, 25, ' ')
                            }
                },
                {
                    5, new List<DataField>()
                            {
                                new DataField((int)DataFields.CustomerTighteningErrorCode, 500, 4, ' '),
                            }
                },
                {
                    6, new List<DataField>()
                            {
                                new DataField((int)DataFields.PrevailTorqueCompensateValue, 506, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TighteningErrorStatus2, 514, 10, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                },
                {
                    7, new List<DataField>()
                            {
                                new DataField((int)DataFields.CompensatedAngle, 526, 7, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.FinalAngleDecimal, 535, 7, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                },
                {
                    8, new List<DataField>()
                            {
                                new DataField((int)DataFields.StartFinalAngle, 544, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.PostViewTorqueActivated, 552, 1),
                                new DataField((int)DataFields.PostViewTorqueHigh, 555, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.PostViewTorqueLow, 563, 6, '0', DataField.PaddingOrientations.LeftPadded),
                            }
                },
                {
                    998, new List<DataField>()
                            {
                                new DataField((int)DataFields.NumberOfStagesInMultistage, 526, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.NumberOfStageResults, 530, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.StageResult, 534, 11)
                            }
                },
                {
                    999, new List<DataField>()
                            {
                                new DataField((int)DataFields.VinNumber, 20, 25, ' ', hasPrefix: false),
                                new DataField((int)DataFields.JobId, 45, 2, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.ParameterSetId, 47, 3, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.BatchSize, 50, 4, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.BatchCounter, 54, 4, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.BatchStatus, 58, 1, false),
                                new DataField((int)DataFields.TighteningStatus, 59, 1, false),
                                new DataField((int)DataFields.TorqueStatus, 60, 1, false),
                                new DataField((int)DataFields.AngleStatus, 61, 1, false),
                                new DataField((int)DataFields.Torque, 62, 6, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.Angle, 68, 5, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.Timestamp, 73, 19, false),
                                new DataField((int)DataFields.LastChangeInParameterSet, 92, 19, false),
                                new DataField((int)DataFields.TighteningId, 111, 10, '0', DataField.PaddingOrientations.LeftPadded, false)
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
            //Rev 998 (Go over 7)
            NumberOfStagesInMultistage,
            NumberOfStageResults,
            StageResult
            //Rev 999 => all registered
        }
    }
}
