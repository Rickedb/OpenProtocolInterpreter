using OpenProtocolInterpreter.Converters;
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
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<long> _longConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<decimal> _decimalConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        private readonly IValueConverter<StrategyOptions> _strategyOptionsConverter;
        private readonly IValueConverter<TighteningErrorStatus> _tighteningErrorStatusConverter;
        private readonly IValueConverter<TighteningErrorStatus2> _tighteningErrorStatus2Converter;
        private readonly IValueConverter<IEnumerable<StageResult>> _stageResultListConverter;
        public const int MID = 61;

        public int CellId
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.CellId).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.CellId).SetValue(_intConverter.Convert, value);
        }
        public int ChannelId
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.ChannelId).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.ChannelId).SetValue(_intConverter.Convert, value);
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
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.JobId).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.JobId).SetValue(_intConverter.Convert, value);
        }
        public int ParameterSetId
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.ParameterSetId).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.ParameterSetId).SetValue(_intConverter.Convert, value);
        }
        public int BatchSize
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchSize).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchSize).SetValue(_intConverter.Convert, value);
        }
        public int BatchCounter
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchCounter).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchCounter).SetValue(_intConverter.Convert, value);
        }
        public bool TighteningStatus
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningStatus).GetValue(_boolConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningStatus).SetValue(_boolConverter.Convert, value);
        }
        public TighteningValueStatus TorqueStatus
        {
            get => (TighteningValueStatus)GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueStatus).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus AngleStatus
        {
            get => (TighteningValueStatus)GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleStatus).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public decimal TorqueMinLimit
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueMinLimit).GetValue(_decimalConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueMinLimit).SetValue(_decimalConverter.Convert, value);
        }
        public decimal TorqueMaxLimit
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueMaxLimit).GetValue(_decimalConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueMaxLimit).SetValue(_decimalConverter.Convert, value);
        }
        public decimal TorqueFinalTarget
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueFinalTarget).GetValue(_decimalConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TorqueFinalTarget).SetValue(_decimalConverter.Convert, value);
        }
        public decimal Torque
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.Torque).GetValue(_decimalConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.Torque).SetValue(_decimalConverter.Convert, value);
        }
        public int AngleMinLimit
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleMinLimit).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleMinLimit).SetValue(_intConverter.Convert, value);
        }
        public int AngleMaxLimit
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleMaxLimit).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleMaxLimit).SetValue(_intConverter.Convert, value);
        }
        public int AngleFinalTarget
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleFinalTarget).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.AngleFinalTarget).SetValue(_intConverter.Convert, value);
        }
        public int Angle
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.Angle).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.Angle).SetValue(_intConverter.Convert, value);
        }
        public DateTime Timestamp
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.Timestamp).GetValue(_dateConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.Timestamp).SetValue(_dateConverter.Convert, value);
        }
        public DateTime LastChangeInParameterSet
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.LastChangeInParameterSet).GetValue(_dateConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.LastChangeInParameterSet).SetValue(_dateConverter.Convert, value);
        }
        public BatchStatus BatchStatus
        {
            get => (BatchStatus)GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchStatus).GetValue(_intConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.BatchStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public long TighteningId
        {
            get => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningId).GetValue(_longConverter.Convert);
            set => GetField(GetCurrentRevisionIndex(), (int)DataFields.TighteningId).SetValue(_longConverter.Convert, value);
        }
        //Rev 2 Addition
        public Strategy Strategy
        {
            get => (Strategy)GetField(2, (int)DataFields.Strategy).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.Strategy).SetValue(_intConverter.Convert, (int)value);
        }
        public StrategyOptions StrategyOptions { get; set; }
        public TighteningValueStatus RundownAngleStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.RundownAngleStatus).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.RundownAngleStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus CurrentMonitoringStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.CurrentMonitoringStatus).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.CurrentMonitoringStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus SelftapStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.SelftapStatus).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.SelftapStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus PrevailTorqueMonitoringStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.PrevailTorqueMonitoringStatus).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.PrevailTorqueMonitoringStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus PrevailTorqueCompensateStatus
        {
            get => (TighteningValueStatus)GetField(2, (int)DataFields.PrevailTorqueCompensateStatus).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.PrevailTorqueCompensateStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningErrorStatus TighteningErrorStatus { get; set; }
        public int RundownAngleMin
        {
            get => GetField(2, (int)DataFields.RundownAngleMin).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.RundownAngleMin).SetValue(_intConverter.Convert, value);
        }
        public int RundownAngleMax
        {
            get => GetField(2, (int)DataFields.RundownAngleMax).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.RundownAngleMax).SetValue(_intConverter.Convert, value);
        }
        public int RundownAngle
        {
            get => GetField(2, (int)DataFields.RundownAngle).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.RundownAngle).SetValue(_intConverter.Convert, value);
        }
        public int CurrentMonitoringMin
        {
            get => GetField(2, (int)DataFields.CurrentMonitoringMin).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.CurrentMonitoringMin).SetValue(_intConverter.Convert, value);
        }
        public int CurrentMonitoringMax
        {
            get => GetField(2, (int)DataFields.CurrentMonitoringMax).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.CurrentMonitoringMax).SetValue(_intConverter.Convert, value);
        }
        public int CurrentMonitoringValue
        {
            get => GetField(2, (int)DataFields.CurrentMonitoringValue).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.CurrentMonitoringValue).SetValue(_intConverter.Convert, value);
        }
        public decimal SelftapMin
        {
            get => GetField(2, (int)DataFields.SelftapMin).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.SelftapMin).SetValue(_decimalConverter.Convert, value);
        }
        public decimal SelftapMax
        {
            get => GetField(2, (int)DataFields.SelftapMax).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.SelftapMax).SetValue(_decimalConverter.Convert, value);
        }
        public decimal SelftapTorque
        {
            get => GetField(2, (int)DataFields.SelftapTorque).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.SelftapTorque).SetValue(_decimalConverter.Convert, value);
        }
        public decimal PrevailTorqueMonitoringMin
        {
            get => GetField(2, (int)DataFields.PrevailTorqueMonitoringMin).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.PrevailTorqueMonitoringMin).SetValue(_decimalConverter.Convert, value);
        }
        public decimal PrevailTorqueMonitoringMax
        {
            get => GetField(2, (int)DataFields.PrevailTorqueMonitoringMax).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.PrevailTorqueMonitoringMax).SetValue(_decimalConverter.Convert, value);
        }
        public decimal PrevailTorque
        {
            get => GetField(2, (int)DataFields.PrevailTorque).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.PrevailTorque).SetValue(_decimalConverter.Convert, value);
        }
        public int JobSequenceNumber
        {
            get => GetField(2, (int)DataFields.JobSequenceNumber).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.JobSequenceNumber).SetValue(_intConverter.Convert, value);
        }
        public int SyncTighteningId
        {
            get => GetField(2, (int)DataFields.SyncTighteningId).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.SyncTighteningId).SetValue(_intConverter.Convert, value);
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
            get => (TorqueValuesUnit)GetField(3, (int)DataFields.TorqueValuesUnit).GetValue(_intConverter.Convert);
            set => GetField(3, (int)DataFields.TorqueValuesUnit).SetValue(_intConverter.Convert, (int)value);
        }
        public ResultType ResultType
        {
            get => (ResultType)GetField(3, (int)DataFields.ResultType).GetValue(_intConverter.Convert);
            set => GetField(3, (int)DataFields.ResultType).SetValue(_intConverter.Convert, (int)value);
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
            get => GetField(6, (int)DataFields.PrevailTorqueCompensateValue).GetValue(_decimalConverter.Convert);
            set => GetField(6, (int)DataFields.PrevailTorqueCompensateValue).SetValue(_decimalConverter.Convert, value);
        }
        public TighteningErrorStatus2 TighteningErrorStatus2 { get; set; }
        //Rev 7 addition
        public decimal CompensatedAngle
        {
            get => GetField(7, (int)DataFields.CompensatedAngle).GetValue(_decimalConverter.Convert);
            set => GetField(7, (int)DataFields.CompensatedAngle).SetValue(_decimalConverter.Convert, value);
        }
        public decimal FinalAngleDecimal
        {
            get => GetField(7, (int)DataFields.FinalAngleDecimal).GetValue(_decimalConverter.Convert);
            set => GetField(7, (int)DataFields.FinalAngleDecimal).SetValue(_decimalConverter.Convert, value);
        }
        //Rev 8 addition
        public decimal StartFinalAngle
        {
            get => GetField(8, (int)DataFields.StartFinalAngle).GetValue(_decimalConverter.Convert);
            set => GetField(8, (int)DataFields.StartFinalAngle).SetValue(_decimalConverter.Convert, value);
        }
        public PostViewTorque PostViewTorqueActivated
        {
            get => (PostViewTorque)GetField(8, (int)DataFields.PostViewTorqueActivated).GetValue(_intConverter.Convert);
            set => GetField(8, (int)DataFields.PostViewTorqueActivated).SetValue(_intConverter.Convert, (int)value);
        }
        public decimal PostViewTorqueHigh
        {
            get => GetField(8, (int)DataFields.PostViewTorqueHigh).GetValue(_decimalConverter.Convert);
            set => GetField(8, (int)DataFields.PostViewTorqueHigh).SetValue(_decimalConverter.Convert, value);
        }
        public decimal PostViewTorqueLow
        {
            get => GetField(8, (int)DataFields.PostViewTorqueLow).GetValue(_decimalConverter.Convert);
            set => GetField(8, (int)DataFields.PostViewTorqueLow).SetValue(_decimalConverter.Convert, value);
        }
        //Rev 998 addition
        public int NumberOfStagesInMultistage
        {
            get => GetField(998, (int)DataFields.NumberOfStagesInMultistage).GetValue(_intConverter.Convert);
            set => GetField(998, (int)DataFields.NumberOfStagesInMultistage).SetValue(_intConverter.Convert, value);
        }
        public int NumberOfStageResults
        {
            get => GetField(998, (int)DataFields.NumberOfStageResults).GetValue(_intConverter.Convert);
            set => GetField(998, (int)DataFields.NumberOfStageResults).SetValue(_intConverter.Convert, value);
        }
        public List<StageResult> StageResults { get; set; }

        public Mid0061() : this(DEFAULT_REVISION)
        {

        }

        public Mid0061(Header header) : base(header)
        {
            var byteArrayConverter = new ByteArrayConverter();
            _intConverter = new Int32Converter();
            _longConverter = new Int64Converter();
            _boolConverter = new BoolConverter();
            _decimalConverter = new DecimalTrucatedConverter(2);
            _dateConverter = new DateConverter();
            _strategyOptionsConverter = new StrategyOptionsConverter(byteArrayConverter, _intConverter);
            _tighteningErrorStatusConverter = new TighteningErrorStatusConverter(byteArrayConverter, _longConverter);
            _tighteningErrorStatus2Converter = new TighteningErrorStatus2Converter(byteArrayConverter, _longConverter);
            _stageResultListConverter = new StageResultListConverter(_intConverter, _decimalConverter);
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
                GetField(2, (int)DataFields.StrategyOptions).SetValue(_strategyOptionsConverter.Convert, StrategyOptions);
                GetField(2, (int)DataFields.TighteningErrorStatus).SetValue(_tighteningErrorStatusConverter.Convert, TighteningErrorStatus);

                if (Header.Revision > 5)
                {
                    GetField(6, (int)DataFields.TighteningErrorStatus2).SetValue(_tighteningErrorStatus2Converter.Convert, TighteningErrorStatus2);
                }

                if (Header.Revision == 998)
                {
                    NumberOfStageResults = StageResults.Count;
                    var stageResultField = GetField(998, (int)DataFields.StageResult);
                    stageResultField.Size = StageResults.Count * 11;
                    stageResultField.SetValue(_stageResultListConverter.Convert(StageResults));
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
                    StageResults = _stageResultListConverter.Convert(stageResultField.Value).ToList();
                }

                for (int i = 2; i <= processUntil; i++)
                    ProcessDataFields(RevisionsByFields[i], package);

                var strategyOptionsField = GetField(2, (int)DataFields.StrategyOptions);
                StrategyOptions = _strategyOptionsConverter.Convert(strategyOptionsField.Value);

                var tighteningErrorStatusField = GetField(2, (int)DataFields.TighteningErrorStatus);
                TighteningErrorStatus = _tighteningErrorStatusConverter.Convert(tighteningErrorStatusField.Value);

                if (Header.Revision > 5)
                {
                    var tighteningErrorStatus2Field = GetField(6, (int)DataFields.TighteningErrorStatus2);
                    TighteningErrorStatus2 = _tighteningErrorStatus2Converter.Convert(tighteningErrorStatus2Field.Value);
                }
            }
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
