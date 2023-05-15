using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Tool data upload reply
    /// <para>Upload of tool data from the controller.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0041 : Mid, ITool, IController
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<long> _longConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        private readonly IValueConverter<decimal> _decimalConverter;
        private readonly IValueConverter<OpenEndDatas> _openEndDataConverter;
        public const int MID = 41;

        public string ToolSerialNumber
        {
            get => GetField(1, (int)DataFields.TOOL_SERIAL_NUMBER).Value;
            set => GetField(1, (int)DataFields.TOOL_SERIAL_NUMBER).SetValue(value);
        }
        public long ToolNumberOfTightenings
        {
            get => GetField(1, (int)DataFields.TOOL_NUMBER_OF_TIGHTENINGS).GetValue(_longConverter.Convert);
            set => GetField(1, (int)DataFields.TOOL_NUMBER_OF_TIGHTENINGS).SetValue(_longConverter.Convert, value);
        }
        public DateTime LastCalibrationDate
        {
            get => GetField(1, (int)DataFields.LAST_CALIBRATION_DATE).GetValue(_dateConverter.Convert);
            set => GetField(1, (int)DataFields.LAST_CALIBRATION_DATE).SetValue(_dateConverter.Convert, value);
        }
        public string ControllerSerialNumber
        {
            get => GetField(1, (int)DataFields.CONTROLLER_SERIAL_NUMBER).Value;
            set => GetField(1, (int)DataFields.CONTROLLER_SERIAL_NUMBER).SetValue(value);
        }
        //Rev 2
        public decimal CalibrationValue
        {
            get => GetField(2, (int)DataFields.CALIBRATION_VALUE).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.CALIBRATION_VALUE).SetValue(_decimalConverter.Convert, value);
        }
        public DateTime LastServiceDate
        {
            get => GetField(2, (int)DataFields.LAST_SERVICE_DATE).GetValue(_dateConverter.Convert);
            set => GetField(2, (int)DataFields.LAST_SERVICE_DATE).SetValue(_dateConverter.Convert, value);
        }
        public long TighteningsSinceService
        {
            get => GetField(2, (int)DataFields.TIGHTENINGS_SINCE_SERVICE).GetValue(_longConverter.Convert);
            set => GetField(2, (int)DataFields.TIGHTENINGS_SINCE_SERVICE).SetValue(_longConverter.Convert, value);
        }
        public ToolType ToolType
        {
            get => (ToolType)GetField(2, (int)DataFields.TOOL_TYPE).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.TOOL_TYPE).SetValue(_intConverter.Convert, (int)value);
        }
        public int MotorSize
        {
            get => GetField(2, (int)DataFields.MOTOR_SIZE).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.MOTOR_SIZE).SetValue(_intConverter.Convert, value);
        }
        public OpenEndDatas OpenEndData
        {
            get => GetField(2, (int)DataFields.OPEN_END_DATA).GetValue(_openEndDataConverter.Convert);
            set => GetField(2, (int)DataFields.OPEN_END_DATA).SetValue(_openEndDataConverter.Convert, value);
        }
        public string ControllerSoftwareVersion
        {
            get => GetField(2, (int)DataFields.CONTROLLER_SOFTWARE_VERSION).Value;
            set => GetField(2, (int)DataFields.CONTROLLER_SOFTWARE_VERSION).SetValue(value);
        }
        //Rev 3
        public decimal ToolMaxTorque
        {
            get => GetField(3, (int)DataFields.TOOL_MAX_TORQUE).GetValue(_decimalConverter.Convert);
            set => GetField(3, (int)DataFields.TOOL_MAX_TORQUE).SetValue(_decimalConverter.Convert, value);
        }
        public decimal GearRatio
        {
            get => GetField(3, (int)DataFields.GEAR_RATIO).GetValue(_decimalConverter.Convert);
            set => GetField(3, (int)DataFields.GEAR_RATIO).SetValue(_decimalConverter.Convert, value);
        }
        public decimal ToolFullSpeed
        {
            get => GetField(3, (int)DataFields.TOOL_FULL_SPEED).GetValue(_decimalConverter.Convert);
            set => GetField(3, (int)DataFields.TOOL_FULL_SPEED).SetValue(_decimalConverter.Convert, value);
        }
        //Rev 4
        public PrimaryTool PrimaryTool
        {
            get => (PrimaryTool)GetField(4, (int)DataFields.PRIMARY_TOOL).GetValue(_intConverter.Convert);
            set => GetField(4, (int)DataFields.PRIMARY_TOOL).SetValue(_intConverter.Convert, (int)value);
        }
        //Rev 5
        public string ToolModel
        {
            get => GetField(5, (int)DataFields.TOOL_MODEL).Value;
            set => GetField(5, (int)DataFields.TOOL_MODEL).SetValue(value);
        }
        //Rev 6
        public int ToolNumber
        {
            get => GetField(6, (int)DataFields.TOOL_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(6, (int)DataFields.TOOL_NUMBER).SetValue(_intConverter.Convert, value);
        }
        public string ToolArticleNumber
        {
            get => GetField(6, (int)DataFields.TOOL_ARTICLE_NUMBER).Value;
            set => GetField(6, (int)DataFields.TOOL_ARTICLE_NUMBER).SetValue(value);
        }
        //Rev 7
        public decimal RundownMinSpeed
        {
            get => GetField(7, (int)DataFields.RUNDOWN_MIN_SPEED).GetValue(_decimalConverter.Convert);
            set => GetField(7, (int)DataFields.RUNDOWN_MIN_SPEED).SetValue(_decimalConverter.Convert, value);
        }
        public decimal DownshiftMaxSpeed
        {
            get => GetField(7, (int)DataFields.DOWNSHIFT_MAX_SPEED).GetValue(_decimalConverter.Convert);
            set => GetField(7, (int)DataFields.DOWNSHIFT_MAX_SPEED).SetValue(_decimalConverter.Convert, value);
        }
        public decimal DownshiftMinSpeed
        {
            get => GetField(7, (int)DataFields.DOWNSHIFT_MIN_SPEED).GetValue(_decimalConverter.Convert);
            set => GetField(7, (int)DataFields.DOWNSHIFT_MIN_SPEED).SetValue(_decimalConverter.Convert, value);
        }

        public Mid0041() : this(DEFAULT_REVISION)
        {

        }

        public Mid0041(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            _longConverter = new Int64Converter();
            _dateConverter = new DateConverter();
            _decimalConverter = new DecimalTrucatedConverter(2);
            _openEndDataConverter = new OpenEndDataConverter(_intConverter, new BoolConverter());
        }

        public Mid0041(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.TOOL_SERIAL_NUMBER, 20, 14, ' '),
                                new DataField((int)DataFields.TOOL_NUMBER_OF_TIGHTENINGS, 36, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.LAST_CALIBRATION_DATE, 48, 19),
                                new DataField((int)DataFields.CONTROLLER_SERIAL_NUMBER, 69, 10, ' ')
                            }
                },
                {
                    2, new  List<DataField>()
                            {
                                new DataField((int)DataFields.CALIBRATION_VALUE, 81, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.LAST_SERVICE_DATE, 89, 19),
                                new DataField((int)DataFields.TIGHTENINGS_SINCE_SERVICE, 110, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TOOL_TYPE, 122, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.MOTOR_SIZE, 126, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.OPEN_END_DATA, 130, 3),
                                new DataField((int)DataFields.CONTROLLER_SOFTWARE_VERSION, 135, 19, ' ')
                            }
                },
                {
                    3, new  List<DataField>()
                            {
                                new DataField((int)DataFields.TOOL_MAX_TORQUE, 156, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.GEAR_RATIO, 164, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TOOL_FULL_SPEED, 172, 6, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                },
                {
                    4, new  List<DataField>()
                            {
                                new DataField((int)DataFields.PRIMARY_TOOL, 180, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                },
                {
                    5, new  List<DataField>()
                            {
                                new DataField((int)DataFields.TOOL_MODEL, 184, 12, ' ')
                            }
                },
                {
                    6, new  List<DataField>()
                            {
                                new DataField((int)DataFields.TOOL_NUMBER, 198, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TOOL_ARTICLE_NUMBER, 204, 30, ' ')
                            }
                },
                {
                    7, new  List<DataField>()
                            {
                                new DataField((int)DataFields.RUNDOWN_MIN_SPEED, 236, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.DOWNSHIFT_MAX_SPEED, 244, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.DOWNSHIFT_MIN_SPEED, 252, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                            }
                }
            };
        }

        protected enum DataFields
        {
            TOOL_SERIAL_NUMBER,
            TOOL_NUMBER_OF_TIGHTENINGS,
            LAST_CALIBRATION_DATE,
            CONTROLLER_SERIAL_NUMBER,
            //Rev 2
            CALIBRATION_VALUE,
            LAST_SERVICE_DATE,
            TIGHTENINGS_SINCE_SERVICE,
            TOOL_TYPE,
            MOTOR_SIZE,
            OPEN_END_DATA,
            CONTROLLER_SOFTWARE_VERSION,
            //Rev 3
            TOOL_MAX_TORQUE,
            GEAR_RATIO,
            TOOL_FULL_SPEED,
            //Rev 4
            PRIMARY_TOOL,
            //Rev 5
            TOOL_MODEL,
            //Rev 6
            TOOL_NUMBER,
            TOOL_ARTICLE_NUMBER,
            //Rev 7
            RUNDOWN_MIN_SPEED,
            DOWNSHIFT_MAX_SPEED,
            DOWNSHIFT_MIN_SPEED
        }

        public class OpenEndDatas
        {
            public bool UseOpenEnd { get; set; }
            public TighteningDirection TighteningDirection { get; set; }
            public MotorRotation MotorRotation { get; set; }

            public OpenEndDatas()
            {

            }

            public OpenEndDatas(bool useOpenEnd, TighteningDirection tighteningDirection, MotorRotation motorRotation)
            {
                UseOpenEnd = useOpenEnd;
                TighteningDirection = tighteningDirection;
                MotorRotation = motorRotation;
            }
        }
    }
}
