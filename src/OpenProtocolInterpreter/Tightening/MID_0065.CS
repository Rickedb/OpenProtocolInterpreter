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
        private const int length = 118;
        public const int MID = 65;
        private const int revision = 1;

        public int TighteningId { get; set; }
        public string VinNumber { get; set; }
        public int ParameterSetId { get; set; }
        public int BatchCounter { get; set; }
        public bool TighteningStatus { get; set; }
        public TighteningValueStatus TorqueStatus { get; set; }
        public TighteningValueStatus AngleStatus { get; set; }
        public decimal Torque { get; set; }
        public int Angle { get; set; }
        public DateTime TimeStamp { get; set; }
        public BatchStatus BatchStatus { get; set; }


        public MID_0065() : base(length, MID, revision) { }

        internal MID_0065(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override Mid ProcessPackage(string package)
        {
            if (IsCorrectType(package))
            {
                base.ProcessPackage(package);

                TighteningId = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.TIGHTENING_ID].Value);
                VinNumber = base.RegisteredDataFields[(int)DataFields.VIN_NUMBER].Value.ToString();
                ParameterSetId = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Value);
                BatchCounter = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.BATCH_COUNTER].Value);
                TighteningStatus = Convert.ToBoolean(Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.TIGHTENING_STATUS].Value));
                TorqueStatus = (TighteningValuesStatuses)Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.TORQUE_STATUS].Value);
                AngleStatus = (TighteningValuesStatuses)Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.ANGLE_STATUS].Value);
                Torque = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.TORQUE].Value) / 100m;
                Angle = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.ANGLE].Value);
                TimeStamp = base.RegisteredDataFields[(int)DataFields.TIMESTAMP].ToDateTime();
                BatchStatus = (BatchStatuses)Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.ANGLE_STATUS].Value);

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
