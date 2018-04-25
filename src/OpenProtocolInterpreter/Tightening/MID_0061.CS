using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// MID: Last tightening result data
    /// Description: Upload the last tightening result.
    /// Message sent by: Controller
    /// Answer: MID 0062 Last tightening result data acknowledge
    /// </summary>
    public class MID_0061 : MID, ITightening
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<long> _longConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<decimal> _decimalConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        private const int LAST_REVISION = 7;
        public const int MID = 61;

        public int CellId
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.CELL_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.CELL_ID].SetValue(_intConverter.Convert, value);
        }
        public int ChannelId
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.CHANNEL_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.CHANNEL_ID].SetValue(_intConverter.Convert, value);
        }
        public string TorqueControllerName
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TORQUE_CONTROLLER_NAME].Value;
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TORQUE_CONTROLLER_NAME].SetValue(value);
        }
        public string VinNumber
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.VIN_NUMBER].Value;
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.VIN_NUMBER].SetValue(value);
        }
        public int JobId
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.JOB_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.JOB_ID].SetValue(_intConverter.Convert, value);
        }
        public int ParameterSetId
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.PARAMETER_SET_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.PARAMETER_SET_ID].SetValue(_intConverter.Convert, value);
        }
        public int BatchSize
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.BATCH_SIZE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.BATCH_SIZE].SetValue(_intConverter.Convert, value);
        }
        public int BatchCounter
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.BATCH_COUNTER].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.BATCH_COUNTER].SetValue(_intConverter.Convert, value);
        }
        public bool TighteningStatus
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TIGHTENING_STATUS].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TIGHTENING_STATUS].SetValue(_boolConverter.Convert, value);
        }
        public TighteningValueStatus TorqueStatus
        {
            get => (TighteningValueStatus)RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TORQUE_STATUS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TORQUE_STATUS].SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus AngleStatus
        {
            get => (TighteningValueStatus)RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.ANGLE_STATUS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.ANGLE_STATUS].SetValue(_intConverter.Convert, (int)value);
        }
        public decimal TorqueMinLimit
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TORQUE_MIN_LIMIT].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TORQUE_MIN_LIMIT].SetValue(_decimalConverter.Convert, value);
        }
        public decimal TorqueMaxLimit
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TORQUE_MAX_LIMIT].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TORQUE_MAX_LIMIT].SetValue(_decimalConverter.Convert, value);
        }
        public decimal TorqueFinalTarget
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TORQUE_FINAL_TARGET].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TORQUE_FINAL_TARGET].SetValue(_decimalConverter.Convert, value);
        }
        public decimal Torque
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TORQUE].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TORQUE].SetValue(_decimalConverter.Convert, value);
        }
        public int AngleMinLimit
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.ANGLE_MIN_LIMIT].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.ANGLE_MIN_LIMIT].SetValue(_intConverter.Convert, value);
        }
        public int AngleMaxLimit
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.ANGLE_MAX_LIMIT].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.ANGLE_MAX_LIMIT].SetValue(_intConverter.Convert, value);
        }
        public int AngleFinalTarget
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.ANGLE_FINAL_TARGET].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.ANGLE_FINAL_TARGET].SetValue(_intConverter.Convert, value);
        }
        public int Angle
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.ANGLE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.ANGLE].SetValue(_intConverter.Convert, value);
        }
        public DateTime TimeStamp
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TIMESTAMP].GetValue(_dateConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TIMESTAMP].SetValue(_dateConverter.Convert, value);
        }
        public DateTime LastChangeInParameterSet
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.LAST_CHANGE_IN_PARAMETER_SET].GetValue(_dateConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.LAST_CHANGE_IN_PARAMETER_SET].SetValue(_dateConverter.Convert, value);
        }
        public BatchStatus BatchStatus
        {
            get => (BatchStatus)RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.BATCH_STATUS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.BATCH_STATUS].SetValue(_intConverter.Convert, (int)value);
        }
        public long TighteningId
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TIGHTENING_ID].GetValue(_longConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TIGHTENING_ID].SetValue(_longConverter.Convert, value);
        }
        //Rev 2 Addition
        public Strategy Strategy
        {
            get => (Strategy)RevisionsByFields[2][(int)DataFields.STRATEGY].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.STRATEGY].SetValue(_intConverter.Convert, (int)value);
        }
        /// <summary>
        /// Still can't use because it has to work with BYTE ARRAY!!!
        /// </summary>
        public string StrategyOptions
        {
            get => RevisionsByFields[2][(int)DataFields.STRATEGY_OPTIONS].Value;
            set => RevisionsByFields[2][(int)DataFields.STRATEGY_OPTIONS].SetValue(value);
        }
        public TighteningValueStatus RundownAngleStatus
        {
            get => (TighteningValueStatus)RevisionsByFields[2][(int)DataFields.RUNDOWN_ANGLE_STATUS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.RUNDOWN_ANGLE_STATUS].SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus CurrentMonitoringStatus
        {
            get => (TighteningValueStatus)RevisionsByFields[2][(int)DataFields.CURRENT_MONITORING_STATUS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.CURRENT_MONITORING_STATUS].SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus SelftapStatus
        {
            get => (TighteningValueStatus)RevisionsByFields[2][(int)DataFields.SELFTAP_STATUS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.SELFTAP_STATUS].SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus PrevailTorqueMonitoringStatus
        {
            get => (TighteningValueStatus)RevisionsByFields[2][(int)DataFields.PREVAIL_TORQUE_MONITORING_STATUS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.PREVAIL_TORQUE_MONITORING_STATUS].SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus PrevailTorqueCompensateStatus
        {
            get => (TighteningValueStatus)RevisionsByFields[2][(int)DataFields.PREVAIL_TORQUE_COMPENSATE_STATUS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.PREVAIL_TORQUE_COMPENSATE_STATUS].SetValue(_intConverter.Convert, (int)value);
        }
        /// <summary>
        /// Still can't use because it has to work with BYTE ARRAY!!!
        /// </summary>
        public string TighteningErrorStatus
        {
            get => RevisionsByFields[2][(int)DataFields.TIGHTENING_ERROR_STATUS].Value;
            set => RevisionsByFields[2][(int)DataFields.TIGHTENING_ERROR_STATUS].SetValue(value);
        }
        public int RundownAngleMin
        {
            get => RevisionsByFields[2][(int)DataFields.RUNDOWN_ANGLE_MIN].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.RUNDOWN_ANGLE_MIN].SetValue(_intConverter.Convert, value);
        }
        public int RundownAngleMax
        {
            get => RevisionsByFields[2][(int)DataFields.RUNDOWN_ANGLE_MAX].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.RUNDOWN_ANGLE_MAX].SetValue(_intConverter.Convert, value);
        }
        public int RundownAngle
        {
            get => RevisionsByFields[2][(int)DataFields.RUNDOWN_ANGLE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.RUNDOWN_ANGLE].SetValue(_intConverter.Convert, value);
        }
        public int CurrentMonitoringMin
        {
            get => RevisionsByFields[2][(int)DataFields.CURRENT_MONITORING_MIN].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.CURRENT_MONITORING_MIN].SetValue(_intConverter.Convert, value);
        }
        public int CurrentMonitoringMax
        {
            get => RevisionsByFields[2][(int)DataFields.CURRENT_MONITORING_MAX].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.CURRENT_MONITORING_MAX].SetValue(_intConverter.Convert, value);
        }
        public decimal SelftapMin
        {
            get => RevisionsByFields[2][(int)DataFields.SELFTAP_MIN].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.SELFTAP_MIN].SetValue(_decimalConverter.Convert, value);
        }
        public decimal SelftapTorque
        {
            get => RevisionsByFields[2][(int)DataFields.SELFTAP_TORQUE].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.SELFTAP_TORQUE].SetValue(_decimalConverter.Convert, value);
        }
        public decimal PrevailTorqueMonitoringMin
        {
            get => RevisionsByFields[2][(int)DataFields.PREVAIL_TORQUE_MONITORING_MIN].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.PREVAIL_TORQUE_MONITORING_MIN].SetValue(_decimalConverter.Convert, value);
        }
        public decimal PrevailTorqueMonitoringMax
        {
            get => RevisionsByFields[2][(int)DataFields.PREVAIL_TORQUE_MONITORING_MAX].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.PREVAIL_TORQUE_MONITORING_MAX].SetValue(_decimalConverter.Convert, value);
        }
        public decimal PrevailTorque
        {
            get => RevisionsByFields[2][(int)DataFields.PREVAIL_TORQUE].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.PREVAIL_TORQUE].SetValue(_decimalConverter.Convert, value);
        }
        public int JobSequenceNumber
        {
            get => RevisionsByFields[2][(int)DataFields.JOB_SEQUENCE_NUMBER].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.JOB_SEQUENCE_NUMBER].SetValue(_intConverter.Convert, value);
        }
        public int SyncTighteningId
        {
            get => RevisionsByFields[2][(int)DataFields.SYNC_TIGHTENING_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.SYNC_TIGHTENING_ID].SetValue(_intConverter.Convert, value);
        }
        public string ToolSerialNumber
        {
            get => RevisionsByFields[2][(int)DataFields.TOOL_SERIAL_NUMBER].Value;
            set => RevisionsByFields[2][(int)DataFields.TOOL_SERIAL_NUMBER].SetValue(value);
        }
        //Rev 3 Addition
        public string ParameterSetName
        {
            get => RevisionsByFields[3][(int)DataFields.PARAMETER_SET_NAME].Value;
            set => RevisionsByFields[3][(int)DataFields.PARAMETER_SET_NAME].SetValue(value);
        }
        public TorqueValuesUnit TorqueValuesUnit
        {
            get => (TorqueValuesUnit)RevisionsByFields[3][(int)DataFields.TORQUE_VALUES_UNIT].GetValue(_intConverter.Convert);
            set => RevisionsByFields[3][(int)DataFields.TORQUE_VALUES_UNIT].SetValue(_intConverter.Convert, (int)value);
        }
        public ResultType ResultType
        {
            get => (ResultType)RevisionsByFields[3][(int)DataFields.RESULT_TYPE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[3][(int)DataFields.RESULT_TYPE].SetValue(_intConverter.Convert, (int)value);
        }
        //Rev 4 addition
        public string IdentifierResultPart2
        {
            get => RevisionsByFields[4][(int)DataFields.IDENTIFIER_RESULT_PART_2].Value;
            set => RevisionsByFields[4][(int)DataFields.IDENTIFIER_RESULT_PART_2].SetValue(value);
        }
        public string IdentifierResultPart3
        {
            get => RevisionsByFields[4][(int)DataFields.IDENTIFIER_RESULT_PART_3].Value;
            set => RevisionsByFields[4][(int)DataFields.IDENTIFIER_RESULT_PART_3].SetValue(value);
        }
        public string IdentifierResultPart4
        {
            get => RevisionsByFields[4][(int)DataFields.IDENTIFIER_RESULT_PART_4].Value;
            set => RevisionsByFields[4][(int)DataFields.IDENTIFIER_RESULT_PART_4].SetValue(value);
        }
        //Rev 5 addition
        public string CustomerTighteningErrorCode
        {
            get => RevisionsByFields[5][(int)DataFields.CUSTOMER_TIGHTENING_ERROR_CODE].Value;
            set => RevisionsByFields[5][(int)DataFields.CUSTOMER_TIGHTENING_ERROR_CODE].SetValue(value);
        }
        //Rev 6 Addition
        public decimal PrevailTorqueCompensateValue
        {
            get => RevisionsByFields[6][(int)DataFields.PREVAIL_TORQUE_COMPENSATE_VALUE].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[6][(int)DataFields.PREVAIL_TORQUE_COMPENSATE_VALUE].SetValue(_decimalConverter.Convert, value);
        }
        /// <summary>
        /// Still can't use because it has to work with BYTE ARRAY!!!
        /// </summary>
        public string TighteningErrorStatus2
        {
            get => RevisionsByFields[6][(int)DataFields.TIGHTENING_ERROR_STATUS_2].Value;
            set => RevisionsByFields[6][(int)DataFields.TIGHTENING_ERROR_STATUS_2].SetValue(value);
        }
        //Rev 7 addition
        public decimal CompensatedAngle
        {
            get => RevisionsByFields[7][(int)DataFields.COMPENSATED_ANGLE].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[7][(int)DataFields.COMPENSATED_ANGLE].SetValue(_decimalConverter.Convert, value);
        }
        public decimal FinalAngleDecimal
        {
            get => RevisionsByFields[7][(int)DataFields.FINAL_ANGLE_DECIMAL].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[7][(int)DataFields.FINAL_ANGLE_DECIMAL].SetValue(_decimalConverter.Convert, value);
        }
        //Rev 998 addition
        public int NumberOfStagesInMultistage
        {
            get => RevisionsByFields[998][(int)DataFields.NUMBER_OF_STAGES_IN_MULTISTAGE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[998][(int)DataFields.NUMBER_OF_STAGES_IN_MULTISTAGE].SetValue(_intConverter.Convert, value);
        }
        public int NumberOfStageResults
        {
            get => RevisionsByFields[998][(int)DataFields.NUMBER_OF_STAGE_RESULTS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[998][(int)DataFields.NUMBER_OF_STAGE_RESULTS].SetValue(_intConverter.Convert, value);
        }
        public string StageResult
        {
            get => RevisionsByFields[998][(int)DataFields.STAGE_RESULT].Value;
            set => RevisionsByFields[998][(int)DataFields.STAGE_RESULT].SetValue(value);
        }

        public MID_0061(int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            _longConverter = new Int64Converter();
            _boolConverter = new BoolConverter();
            _decimalConverter = new DecimalTrucatedConverter(2);
            _dateConverter = new DateConverter();
        }

        internal MID_0061(IMID nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string BuildPackage()
        {
            string package = BuildHeader();
            if (HeaderData.Revision == 1)
            {
                package += BuildDataFieldsPackage(1, RevisionsByFields[1]);
            }
            else if (HeaderData.Revision == 999)
            {
                package += BuildDataFieldsPackage(1, RevisionsByFields[999]);
            }
            else if (HeaderData.Revision > 2)
            {
                int? processUntil = HeaderData.Revision;
                bool mid998 = HeaderData.Revision == 998;
                if (mid998)
                    processUntil = 6;

                int prefixIndex = 1;
                for (int i = 2; i <= processUntil; i++)
                {
                    package += BuildDataFieldsPackage(prefixIndex, RevisionsByFields[i]);
                    prefixIndex += RevisionsByFields[i].Count(x => x.HasPrefix);
                }
            }

            return package;
        }

        protected override void ProcessDataFields(string package)
        {
            if (HeaderData.Revision == 1)
            {
                ProcessDataFields(package, RevisionsByFields[1]);
            }
            else if (HeaderData.Revision == 999)
            {
                ProcessDataFields(package, RevisionsByFields[999]);
            }
            else if (HeaderData.Revision > 2)
            {
                int? processUntil = HeaderData.Revision;
                if (HeaderData.Revision == 998)
                {
                    processUntil = 6;
                    ProcessDataFields(package, RevisionsByFields[998]);
                }

                for (int i = 2; i <= processUntil; i++)
                    ProcessDataFields(package, RevisionsByFields[i]);
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
                                new DataField((int)DataFields.CELL_ID, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.CHANNEL_ID, 26, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_CONTROLLER_NAME, 30, 25, ' '),
                                new DataField((int)DataFields.VIN_NUMBER, 57, 25, ' '),
                                new DataField((int)DataFields.JOB_ID, 84, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.PARAMETER_SET_ID, 88, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.BATCH_SIZE, 93, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.BATCH_COUNTER, 99, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TIGHTENING_STATUS, 105, 1),
                                new DataField((int)DataFields.TORQUE_STATUS, 108, 1),
                                new DataField((int)DataFields.ANGLE_STATUS, 111, 1),
                                new DataField((int)DataFields.TORQUE_MIN_LIMIT, 114, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_MAX_LIMIT, 122, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_FINAL_TARGET, 130, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE, 138, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE_MIN_LIMIT, 146, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE_MAX_LIMIT, 153, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE_FINAL_TARGET, 160, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE, 167, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TIMESTAMP, 174, 19),
                                new DataField((int)DataFields.LAST_CHANGE_IN_PARAMETER_SET, 195, 19),
                                new DataField((int)DataFields.BATCH_STATUS, 216, 1),
                                new DataField((int)DataFields.TIGHTENING_ID, 219, 10, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                },
                {
                    2, new List<DataField>()
                            {
                                new DataField((int)DataFields.CELL_ID, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.CHANNEL_ID, 26, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_CONTROLLER_NAME, 30, 25, ' '),
                                new DataField((int)DataFields.VIN_NUMBER, 57, 25, ' '),
                                new DataField((int)DataFields.JOB_ID, 84, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.PARAMETER_SET_ID, 90, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.STRATEGY, 95, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.STRATEGY_OPTIONS, 99, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.BATCH_SIZE, 106, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.BATCH_COUNTER, 112, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TIGHTENING_STATUS, 118, 1),
                                new DataField((int)DataFields.BATCH_STATUS, 121, 1),
                                new DataField((int)DataFields.TORQUE_STATUS, 124, 1),
                                new DataField((int)DataFields.ANGLE_STATUS, 127, 1),
                                new DataField((int)DataFields.RUNDOWN_ANGLE_STATUS, 130, 1),
                                new DataField((int)DataFields.CURRENT_MONITORING_STATUS, 133, 1),
                                new DataField((int)DataFields.SELFTAP_STATUS, 136, 1),
                                new DataField((int)DataFields.PREVAIL_TORQUE_MONITORING_STATUS, 139, 1),
                                new DataField((int)DataFields.PREVAIL_TORQUE_COMPENSATE_STATUS, 142, 1),
                                new DataField((int)DataFields.TIGHTENING_ERROR_STATUS, 145, 10),
                                new DataField((int)DataFields.TORQUE_MIN_LIMIT, 157, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_MAX_LIMIT, 165, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_FINAL_TARGET, 173, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE, 181, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE_MIN_LIMIT, 189, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE_MAX_LIMIT, 196, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE_FINAL_TARGET, 203, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE, 210, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.RUNDOWN_ANGLE_MIN, 217, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.RUNDOWN_ANGLE_MAX, 224, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.RUNDOWN_ANGLE, 231, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.CURRENT_MONITORING_MIN, 238, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.CURRENT_MONITORING_MAX, 243, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.CURRENT_MONITORING_VALUE, 248, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.SELFTAP_MIN, 253, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.SELFTAP_MAX, 261, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.SELFTAP_TORQUE, 269, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.PREVAIL_TORQUE_MONITORING_MIN, 277, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.PREVAIL_TORQUE_MONITORING_MAX, 285, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.PREVAIL_TORQUE, 293, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TIGHTENING_ID, 301, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.JOB_SEQUENCE_NUMBER, 313, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.SYNC_TIGHTENING_ID, 320, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TOOL_SERIAL_NUMBER, 327, 14, ' '),
                                new DataField((int)DataFields.TIMESTAMP, 343, 19),
                                new DataField((int)DataFields.LAST_CHANGE_IN_PARAMETER_SET, 364, 19)
                            }
                },
                {
                    3, new List<DataField>()
                            {
                                new DataField((int)DataFields.PARAMETER_SET_NAME, 385, 25, ' '),
                                new DataField((int)DataFields.TORQUE_VALUES_UNIT, 412, 1),
                                new DataField((int)DataFields.RESULT_TYPE, 415, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                },
                {
                    4, new List<DataField>()
                            {
                                new DataField((int)DataFields.IDENTIFIER_RESULT_PART_2, 419, 25, ' '),
                                new DataField((int)DataFields.IDENTIFIER_RESULT_PART_3, 446, 25, ' '),
                                new DataField((int)DataFields.IDENTIFIER_RESULT_PART_4, 473, 25, ' ')
                            }
                },
                {
                    5, new List<DataField>()
                            {
                                new DataField((int)DataFields.CUSTOMER_TIGHTENING_ERROR_CODE, 500, 4, ' '),
                            }
                },
                {
                    6, new List<DataField>()
                            {
                                new DataField((int)DataFields.PREVAIL_TORQUE_COMPENSATE_VALUE, 506, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TIGHTENING_ERROR_STATUS_2, 514, 10, ' ')
                            }
                },
                {
                    7, new List<DataField>()
                            {
                                new DataField((int)DataFields.COMPENSATED_ANGLE, 526, 7, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.FINAL_ANGLE_DECIMAL, 535, 8, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                },
                {
                    998, new List<DataField>()
                            {
                                new DataField((int)DataFields.NUMBER_OF_STAGES_IN_MULTISTAGE, 526, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.NUMBER_OF_STAGE_RESULTS, 530, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.STAGE_RESULT, 534, 11)
                            }
                },
                {
                    999, new List<DataField>()
                            {
                                new DataField((int)DataFields.VIN_NUMBER, 20, 25, ' ', hasPrefix: false),
                                new DataField((int)DataFields.JOB_ID, 45, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.PARAMETER_SET_ID, 47, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.BATCH_SIZE, 50, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.BATCH_COUNTER, 54, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.BATCH_STATUS, 58, 1, false),
                                new DataField((int)DataFields.TIGHTENING_STATUS, 59, 1, false),
                                new DataField((int)DataFields.TORQUE_STATUS, 60, 1, false),
                                new DataField((int)DataFields.ANGLE_STATUS, 61, 1, false),
                                new DataField((int)DataFields.TORQUE, 62, 6, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.ANGLE, 68, 5, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.TIMESTAMP, 73, 19, false),
                                new DataField((int)DataFields.LAST_CHANGE_IN_PARAMETER_SET, 92, 19,false),
                                new DataField((int)DataFields.TIGHTENING_ID, 112, 10, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
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
            if (HeaderData.Revision == 999)
                return 999;

            if (HeaderData.Revision > 1)
                return 2;
            return 1;
        }

        private void ProcessDataFields(string package, List<DataField> fields)
        {
            foreach (var dataField in fields)
                try
                {
                    if (dataField.HasPrefix)
                        dataField.Value = package.Substring(2 + dataField.Index, dataField.Size);
                    else
                        dataField.Value = package.Substring(dataField.Index, dataField.Size);
                }
                catch (ArgumentOutOfRangeException)
                {
                    //null value
                }
        }

        private string BuildDataFieldsPackage(int prefixIndex, List<DataField> fields)
        {
            string package = string.Empty;
            foreach (var dataField in fields)
                if (dataField.HasPrefix)
                {
                    package += prefixIndex.ToString().PadLeft(2, '0') + dataField.Value;
                    prefixIndex++;
                }
                else
                    package += dataField.Value;

            return package;
        }

        public enum DataFields
        {
            CELL_ID,
            CHANNEL_ID,
            TORQUE_CONTROLLER_NAME,
            VIN_NUMBER,
            JOB_ID,
            PARAMETER_SET_ID,
            BATCH_SIZE,
            BATCH_COUNTER,
            TIGHTENING_STATUS,
            TORQUE_STATUS,
            ANGLE_STATUS,
            TORQUE_MIN_LIMIT,
            TORQUE_MAX_LIMIT,
            TORQUE_FINAL_TARGET,
            TORQUE,
            ANGLE_MIN_LIMIT,
            ANGLE_MAX_LIMIT,
            ANGLE_FINAL_TARGET,
            ANGLE,
            TIMESTAMP,
            LAST_CHANGE_IN_PARAMETER_SET,
            BATCH_STATUS,
            TIGHTENING_ID,
            //Rev 2
            STRATEGY,
            STRATEGY_OPTIONS,
            RUNDOWN_ANGLE_STATUS,
            CURRENT_MONITORING_STATUS,
            SELFTAP_STATUS,
            PREVAIL_TORQUE_MONITORING_STATUS,
            PREVAIL_TORQUE_COMPENSATE_STATUS,
            TIGHTENING_ERROR_STATUS,
            RUNDOWN_ANGLE_MIN,
            RUNDOWN_ANGLE_MAX,
            RUNDOWN_ANGLE,
            CURRENT_MONITORING_MIN,
            CURRENT_MONITORING_MAX,
            CURRENT_MONITORING_VALUE,
            SELFTAP_MIN,
            SELFTAP_MAX,
            SELFTAP_TORQUE,
            PREVAIL_TORQUE_MONITORING_MIN,
            PREVAIL_TORQUE_MONITORING_MAX,
            PREVAIL_TORQUE,
            JOB_SEQUENCE_NUMBER,
            SYNC_TIGHTENING_ID,
            TOOL_SERIAL_NUMBER,
            //Rev 3
            PARAMETER_SET_NAME,
            TORQUE_VALUES_UNIT,
            RESULT_TYPE,
            //Rev 4
            IDENTIFIER_RESULT_PART_2,
            IDENTIFIER_RESULT_PART_3,
            IDENTIFIER_RESULT_PART_4,
            //Rev 5
            CUSTOMER_TIGHTENING_ERROR_CODE,
            //Rev 6
            PREVAIL_TORQUE_COMPENSATE_VALUE,
            TIGHTENING_ERROR_STATUS_2,
            //Rev 7
            COMPENSATED_ANGLE,
            FINAL_ANGLE_DECIMAL,
            //Rev 998 (Go over 7)
            NUMBER_OF_STAGES_IN_MULTISTAGE,
            NUMBER_OF_STAGE_RESULTS,
            STAGE_RESULT,
            //Rev 999 => all registered
        }
    }
}
