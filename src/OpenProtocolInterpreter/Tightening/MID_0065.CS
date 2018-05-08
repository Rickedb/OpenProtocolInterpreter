using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// MID: Old tightening result upload reply
    /// Description: Old tightening upload.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0065 : Mid, ITightening
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<long> _longConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<decimal> _decimalConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        private readonly IValueConverter<StrategyOptions> _strategyOptionsConverter;
        private readonly IValueConverter<TighteningErrorStatus> _tighteningErrorStatusConverter;
        private readonly IValueConverter<TighteningErrorStatus2> _tighteningErrorStatus2Converter;
        public const int MID = 65;
        private const int LAST_REVISION = 6;

        public long TighteningId
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TIGHTENING_ID].GetValue(_longConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TIGHTENING_ID].SetValue(_longConverter.Convert, value);
        }
        public string VinNumber
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.VIN_NUMBER].Value;
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.VIN_NUMBER].SetValue(value);
        }
        public int ParameterSetId
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.PARAMETER_SET_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.PARAMETER_SET_ID].SetValue(_intConverter.Convert, value);
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
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.BATCH_COUNTER].SetValue(_intConverter.Convert, (int)value);
        }
        public TighteningValueStatus AngleStatus
        {
            get => (TighteningValueStatus)RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.ANGLE_STATUS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.BATCH_COUNTER].SetValue(_intConverter.Convert, (int)value);
        }
        public decimal Torque
        {
            get => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TORQUE].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.TORQUE].SetValue(_decimalConverter.Convert, value);
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
        public BatchStatus BatchStatus
        {
            get => (BatchStatus)RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.BATCH_STATUS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[GetCurrentRevisionIndex()][(int)DataFields.BATCH_STATUS].SetValue(_intConverter.Convert, (int)value);
        }
        //Rev 2
        public int JobId
        {
            get => RevisionsByFields[2][(int)DataFields.TIGHTENING_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.TIGHTENING_ID].SetValue(_intConverter.Convert, value);
        }
        public Strategy Strategy
        {
            get => (Strategy)RevisionsByFields[2][(int)DataFields.TIGHTENING_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.TIGHTENING_ID].SetValue(_intConverter.Convert, (int)value);
        }
        public StrategyOptions StrategyOptions
        {
            get => RevisionsByFields[2][(int)DataFields.STRATEGY_OPTIONS].GetValue(_strategyOptionsConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.STRATEGY_OPTIONS].SetValue(_strategyOptionsConverter.Convert, value);
        }
        public int BatchSize
        {
            get => RevisionsByFields[2][(int)DataFields.TIGHTENING_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.TIGHTENING_ID].SetValue(_intConverter.Convert, value);
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
        public TighteningErrorStatus TighteningErrorStatus
        {
            get => RevisionsByFields[2][(int)DataFields.TIGHTENING_ERROR_STATUS].GetValue(_tighteningErrorStatusConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.TIGHTENING_ERROR_STATUS].SetValue(_tighteningErrorStatusConverter.Convert, value);
        }
        public int RundownAngle
        {
            get => RevisionsByFields[2][(int)DataFields.RUNDOWN_ANGLE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.RUNDOWN_ANGLE].SetValue(_intConverter.Convert, value);
        }
        public int CurrentMonitoringValue
        {
            get => RevisionsByFields[2][(int)DataFields.CURRENT_MONITORING_VALUE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.CURRENT_MONITORING_VALUE].SetValue(_intConverter.Convert, value);
        }
        public decimal SelftapTorque
        {
            get => RevisionsByFields[2][(int)DataFields.SELFTAP_TORQUE].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.SELFTAP_TORQUE].SetValue(_decimalConverter.Convert, value);
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
        //Rev 3
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
        //Rev 4
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
        //Rev 5
        public decimal PrevailTorqueCompensateValue
        {
            get => RevisionsByFields[5][(int)DataFields.PREVAIL_TORQUE_COMPENSATE_VALUE].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[5][(int)DataFields.PREVAIL_TORQUE_COMPENSATE_VALUE].SetValue(_decimalConverter.Convert, value);
        }
        public TighteningErrorStatus2 TighteningErrorStatus2
        {
            get => RevisionsByFields[5][(int)DataFields.TIGHTENING_ERROR_STATUS_2].GetValue(_tighteningErrorStatus2Converter.Convert);
            set => RevisionsByFields[5][(int)DataFields.TIGHTENING_ERROR_STATUS_2].SetValue(_tighteningErrorStatus2Converter.Convert, value);
        }

        public MID_0065(int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            _longConverter = new Int64Converter();
            _boolConverter = new BoolConverter();
            _decimalConverter = new DecimalTrucatedConverter(2);
            _dateConverter = new DateConverter();
            _strategyOptionsConverter = new StrategyOptionsConverter();
            _tighteningErrorStatusConverter = new TighteningErrorStatusConverter();
            _tighteningErrorStatus2Converter = new TighteningErrorStatus2Converter();
        }

        internal MID_0065(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override Mid ProcessPackage(string package)
        {
            if (IsCorrectType(package))
            {
                base.ProcessPackage(package);


                return this;
            }

            if (NextTemplate == null)
                throw new NotImplementedException("MID not implemented or doesn't exists");


            return NextTemplate.ProcessPackage(package);
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            //opted to work with a different approuch (since it would need to modify too much fields)
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.TIGHTENING_ID, 20, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.VIN_NUMBER, 32, 25, ' '),
                                new DataField((int)DataFields.PARAMETER_SET_ID, 59, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.BATCH_COUNTER, 64, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TIGHTENING_STATUS, 70, 1),
                                new DataField((int)DataFields.TORQUE_STATUS, 73, 1),
                                new DataField((int)DataFields.ANGLE_STATUS, 76, 1),
                                new DataField((int)DataFields.TORQUE, 79, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE, 87, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TIMESTAMP, 94, 19),
                                new DataField((int)DataFields.BATCH_STATUS, 115, 1)
                            }
                },
                {
                    2, new List<DataField>()
                            {
                                new DataField((int)DataFields.TIGHTENING_ID, 20, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.VIN_NUMBER, 32, 25, ' '),
                                new DataField((int)DataFields.JOB_ID, 59, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.PARAMETER_SET_ID, 65, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.STRATEGY, 70, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.STRATEGY_OPTIONS, 74, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.BATCH_SIZE, 81, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.BATCH_COUNTER, 87, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TIGHTENING_STATUS, 93, 1),
                                new DataField((int)DataFields.BATCH_STATUS, 96, 1),
                                new DataField((int)DataFields.TORQUE_STATUS, 99, 1),
                                new DataField((int)DataFields.ANGLE_STATUS, 102, 1),
                                new DataField((int)DataFields.RUNDOWN_ANGLE_STATUS, 105, 1),
                                new DataField((int)DataFields.CURRENT_MONITORING_STATUS, 108, 1),
                                new DataField((int)DataFields.SELFTAP_STATUS, 111, 1),
                                new DataField((int)DataFields.PREVAIL_TORQUE_MONITORING_STATUS, 114, 1),
                                new DataField((int)DataFields.PREVAIL_TORQUE_COMPENSATE_STATUS, 117, 1),
                                new DataField((int)DataFields.TIGHTENING_ERROR_STATUS, 120, 10),
                                new DataField((int)DataFields.TORQUE, 132, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE, 140, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.RUNDOWN_ANGLE, 147, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.CURRENT_MONITORING_VALUE, 154, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.SELFTAP_TORQUE, 159, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.PREVAIL_TORQUE, 167, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.JOB_SEQUENCE_NUMBER, 175, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.SYNC_TIGHTENING_ID, 182, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TOOL_SERIAL_NUMBER, 189, 14, ' '),
                                new DataField((int)DataFields.TIMESTAMP, 205, 19),
                            }
                },
                {
                    3, new List<DataField>()
                            {
                                new DataField((int)DataFields.TORQUE_VALUES_UNIT, 226, 1),
                                new DataField((int)DataFields.RESULT_TYPE, 229, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                },
                {
                    4, new List<DataField>()
                            {
                                new DataField((int)DataFields.IDENTIFIER_RESULT_PART_2, 233, 25, ' '),
                                new DataField((int)DataFields.IDENTIFIER_RESULT_PART_3, 260, 25, ' '),
                                new DataField((int)DataFields.IDENTIFIER_RESULT_PART_4, 287, 25, ' ')
                            }
                },
                {
                    5, new List<DataField>()
                            {
                                new DataField((int)DataFields.CUSTOMER_TIGHTENING_ERROR_CODE, 314, 4, ' '),
                            }
                },
                {
                    6, new List<DataField>()
                            {
                                new DataField((int)DataFields.PREVAIL_TORQUE_COMPENSATE_VALUE, 320, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TIGHTENING_ERROR_STATUS_2, 328, 10, ' ')
                            }
                }
            };
        }

        private int GetCurrentRevisionIndex() => (HeaderData.Revision > 1) ? 2 : 1;

        public enum DataFields
        {
            TIGHTENING_ID,
            VIN_NUMBER,
            PARAMETER_SET_ID,
            BATCH_COUNTER,
            TIGHTENING_STATUS,
            TORQUE_STATUS,
            ANGLE_STATUS,
            TORQUE,
            ANGLE,
            TIMESTAMP,
            BATCH_STATUS,
            //Rev 2 Additions
            JOB_ID,
            STRATEGY,
            STRATEGY_OPTIONS,
            BATCH_SIZE,
            RUNDOWN_ANGLE_STATUS,
            CURRENT_MONITORING_STATUS,
            SELFTAP_STATUS,
            PREVAIL_TORQUE_MONITORING_STATUS,
            PREVAIL_TORQUE_COMPENSATE_STATUS,
            TIGHTENING_ERROR_STATUS,
            RUNDOWN_ANGLE,
            CURRENT_MONITORING_VALUE,
            SELFTAP_TORQUE,
            PREVAIL_TORQUE,
            JOB_SEQUENCE_NUMBER,
            SYNC_TIGHTENING_ID,
            TOOL_SERIAL_NUMBER,
            //Rev 3 Additions
            TORQUE_VALUES_UNIT,
            RESULT_TYPE,
            //Rev 4 Additions
            IDENTIFIER_RESULT_PART_2,
            IDENTIFIER_RESULT_PART_3,
            IDENTIFIER_RESULT_PART_4,
            //Rev 5 Additions
            CUSTOMER_TIGHTENING_ERROR_CODE,
            //Rev 6 Additions
            PREVAIL_TORQUE_COMPENSATE_VALUE,
            TIGHTENING_ERROR_STATUS_2
        }
    }
}
