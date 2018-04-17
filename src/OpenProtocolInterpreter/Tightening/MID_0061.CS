using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

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

        public int CellId { get; set; }
        public int ChannelId { get; set; }
        public string TorqueControllerName { get; set; }
        public string VinNumber { get; set; }
        public int JobId { get; set; }
        public int ParameterSetId { get; set; }
        public int BatchSize { get; set; }
        public int BatchCounter { get; set; }
        public bool TighteningStatus { get; set; }
        public TighteningValueStatus TorqueStatus { get; set; }
        public TighteningValueStatus AngleStatus { get; set; }
        public decimal TorqueMinLimit { get; set; }
        public decimal TorqueMaxLimit { get; set; }
        public decimal TorqueFinalTarget { get; set; }
        public decimal Torque { get; set; }
        public int AngleMinLimit { get; set; }
        public int AngleMaxLimit { get; set; }
        public int AngleFinalTarget { get; set; }
        public int Angle { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime LastChangeInParameterSet { get; set; }
        public BatchStatus BatchStatus { get; set; }
        public long TighteningId { get; set; }

        public MID_0061() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
            _longConverter = new Int64Converter();
            _boolConverter = new BoolConverter();
            _decimalConverter = new DecimalTrucatedConverter(2);
            _dateConverter = new DateConverter();
        }

        internal MID_0061(IMID nextTemplate) : this() => NextTemplate = nextTemplate;

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.ProcessPackage(package);

                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
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
