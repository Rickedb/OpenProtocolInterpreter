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
        private const int LAST_REVISION = 5;
        public const int MID = 41;

        public string ToolSerialNumber
        {
            get => GetField(1,(int)DataFields.TOOL_SERIAL_NUMBER).Value;
            set => GetField(1,(int)DataFields.TOOL_SERIAL_NUMBER).SetValue(value);
        }
        public long ToolNumberOfTightenings
        { 
            get => GetField(1,(int)DataFields.TOOL_NUMBER_OF_TIGHTENINGS).GetValue(_longConverter.Convert);
            set => GetField(1,(int)DataFields.TOOL_NUMBER_OF_TIGHTENINGS).SetValue(_longConverter.Convert, value);
        }
        public DateTime LastCalibrationDate
        {
            get => GetField(1,(int)DataFields.LAST_CALIBRATION_DATE).GetValue(_dateConverter.Convert);
            set => GetField(1,(int)DataFields.LAST_CALIBRATION_DATE).SetValue(_dateConverter.Convert, value);
        }
        public string ControllerSerialNumber
        {
            get => GetField(1,(int)DataFields.CONTROLLER_SERIAL_NUMBER).Value;
            set => GetField(1,(int)DataFields.CONTROLLER_SERIAL_NUMBER).SetValue(value);
        }
        //Rev 2
        public decimal CalibrationValue
        {
            get => GetField(2,(int)DataFields.CALIBRATION_VALUE).GetValue(_decimalConverter.Convert);
            set => GetField(2,(int)DataFields.CALIBRATION_VALUE).SetValue(_decimalConverter.Convert, value);
        }
        public DateTime LastServiceDate
        {
            get => GetField(2,(int)DataFields.LAST_SERVICE_DATE).GetValue(_dateConverter.Convert);
            set => GetField(2,(int)DataFields.LAST_SERVICE_DATE).SetValue(_dateConverter.Convert, value);
        }
        public long TighteningsSinceService
        {
            get => GetField(2,(int)DataFields.TIGHTENINGS_SINCE_SERVICE).GetValue(_longConverter.Convert);
            set => GetField(2,(int)DataFields.TIGHTENINGS_SINCE_SERVICE).SetValue(_longConverter.Convert, value);
        }
        public ToolType ToolType
        {
            get => (ToolType)GetField(2,(int)DataFields.TOOL_TYPE).GetValue(_intConverter.Convert);
            set => GetField(2,(int)DataFields.TOOL_TYPE).SetValue(_intConverter.Convert, (int)value);
        }
        public int MotorSize
        {
            get => GetField(2,(int)DataFields.MOTOR_SIZE).GetValue(_intConverter.Convert);
            set => GetField(2,(int)DataFields.MOTOR_SIZE).SetValue(_intConverter.Convert, value);
        }
        public OpenEndDatas OpenEndData
        {
            get => GetField(2,(int)DataFields.OPEN_END_DATA).GetValue(_openEndDataConverter.Convert);
            set => GetField(2,(int)DataFields.OPEN_END_DATA).SetValue(_openEndDataConverter.Convert, value);
        }
        public string ControllerSoftwareVersion
        {
            get => GetField(2,(int)DataFields.CONTROLLER_SOFTWARE_VERSION).Value;
            set => GetField(2,(int)DataFields.CONTROLLER_SOFTWARE_VERSION).SetValue(value);
        }
        //Rev 3
        public decimal ToolMaxTorque
        {
            get => GetField(3,(int)DataFields.TOOL_MAX_TORQUE).GetValue(_decimalConverter.Convert);
            set => GetField(3,(int)DataFields.TOOL_MAX_TORQUE).SetValue(_decimalConverter.Convert, value);
        }
        public decimal GearRatio
        {
            get => GetField(3,(int)DataFields.GEAR_RATIO).GetValue(_decimalConverter.Convert);
            set => GetField(3,(int)DataFields.GEAR_RATIO).SetValue(_decimalConverter.Convert, value);
        }
        public decimal ToolFullSpeed
        {
            get => GetField(3,(int)DataFields.TOOL_FULL_SPEED).GetValue(_decimalConverter.Convert);
            set => GetField(3,(int)DataFields.TOOL_FULL_SPEED).SetValue(_decimalConverter.Convert, value);
        }
        //Rev 4
        public PrimaryTool PrimaryTool
        {
            get => (PrimaryTool)GetField(4,(int)DataFields.PRIMARY_TOOL).GetValue(_intConverter.Convert);
            set => GetField(4,(int)DataFields.PRIMARY_TOOL).SetValue(_intConverter.Convert, (int)value);
        }
        //Rev 5
        public string ToolModel
        {
            get => GetField(5,(int)DataFields.TOOL_MODEL).Value;
            set => GetField(5,(int)DataFields.TOOL_MODEL).SetValue(value);
        }

        public Mid0041() : this(LAST_REVISION)
        {

        }

        public Mid0041(int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            _longConverter = new Int64Converter();
            _dateConverter = new DateConverter();
            _decimalConverter = new DecimalTrucatedConverter(2);
            _openEndDataConverter = new OpenEndDataConverter(_intConverter, new BoolConverter());
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="toolSerialNumber">14 ASCII characters</param>
        /// <param name="toolNumberOfTightenings">10 ASCII digits. Max 4294967295</param>
        /// <param name="lastCalibrationDate">19 ASCII characters.</param>
        /// <param name="controllerSerialNumber">10 ASCII characters</param>
        /// <param name="revision">Revision number (default = 1)</param>
        public Mid0041(string toolSerialNumber, long toolNumberOfTightenings,  DateTime lastCalibrationDate, 
            string controllerSerialNumber, int revision = 1) : this(revision)
        {
            ToolSerialNumber = toolSerialNumber;
            ToolNumberOfTightenings = toolNumberOfTightenings;
            LastCalibrationDate = lastCalibrationDate;
            ControllerSerialNumber = controllerSerialNumber;
        }

        /// <summary>
        /// Revision 2 Constructor
        /// </summary>
        /// <param name="toolSerialNumber">14 ASCII characters</param>
        /// <param name="toolNumberOfTightenings">10 ASCII digits. Max 4294967295</param>
        /// <param name="lastCalibrationDate">19 ASCII characters.</param>
        /// <param name="controllerSerialNumber">10 ASCII characters</param>
        /// <param name="calibrationValue">The tool calibration value is multiplied by 100 and sent as an integer (2 decimals truncated). Six ASCII digits.</param>
        /// <param name="lastServiceDate">19 ASCII characters.</param>
        /// <param name="tighteningsSinceService">The number of tightenings since last service is specified by 10 ASCII digits. Max 4294967295.</param>
        /// <param name="toolType">The tool type is specified by 2 ASCII digits</param>
        /// <param name="motorSize">The motor size is specified by 2 ASCII digits, range 00-99.
        /// <para>00 = no motor, 01-99 = motor size xx in Atlas Copco
        /// nomenclature, or motor size = 10xx in Atlas Copco nomenclature </para>
        /// <para>(certain numbers correspond to 2
        /// different motor sizes, for example 62 for both motor
        /// size 62 and motor size 1062)</para></param>
        /// <param name="openEndData">The open end data is specified by 3 ASCII digits. 
        /// <para>The first digit represents the “use open end”: 1=true, 0=false.</para>
        /// <para>The second digit indicates the tightening direction: 0=CW, 1=CCW.</para>
        /// <para>The third digit indicates motor rotation: 0=normal,1=inverted.</para></param>
        /// <param name="controllerSoftwareVersion">The software version is specified by 19 ASCII characters.</param>
        /// <param name="revision">Revision number (default = 2)</param>
        public Mid0041(string toolSerialNumber, long toolNumberOfTightenings, DateTime lastCalibrationDate, 
            string controllerSerialNumber, decimal calibrationValue, DateTime lastServiceDate,
            long tighteningsSinceService, ToolType toolType, int motorSize, OpenEndDatas openEndData,
            string controllerSoftwareVersion, int revision = 2) 
            : this(toolSerialNumber, toolNumberOfTightenings, lastCalibrationDate, controllerSerialNumber, revision)
        {
            CalibrationValue = calibrationValue;
            LastServiceDate = lastServiceDate;
            TighteningsSinceService = tighteningsSinceService;
            ToolType = toolType;
            MotorSize = motorSize;
            OpenEndData = openEndData;
            ControllerSoftwareVersion = controllerSoftwareVersion;
        }

        /// <summary>
        /// Revision 3 Constructor
        /// </summary>
        /// <param name="toolSerialNumber">14 ASCII characters</param>
        /// <param name="toolNumberOfTightenings">10 ASCII digits. Max 4294967295</param>
        /// <param name="lastCalibrationDate">19 ASCII characters.</param>
        /// <param name="controllerSerialNumber">10 ASCII characters</param>
        /// <param name="calibrationValue">The tool calibration value is multiplied by 100 and sent as an integer (2 decimals truncated). Six ASCII digits.</param>
        /// <param name="lastServiceDate">19 ASCII characters.</param>
        /// <param name="tighteningsSinceService">The number of tightenings since last service is specified by 10 ASCII digits. Max 4294967295.</param>
        /// <param name="toolType">The tool type is specified by 2 ASCII digits</param>
        /// <param name="motorSize">The motor size is specified by 2 ASCII digits, range 00-99.
        /// <para>00 = no motor, 01-99 = motor size xx in Atlas Copco
        /// nomenclature, or motor size = 10xx in Atlas Copco nomenclature </para>
        /// <para>(certain numbers correspond to 2
        /// different motor sizes, for example 62 for both motor
        /// size 62 and motor size 1062)</para></param>
        /// <param name="openEndData">The open end data is specified by 3 ASCII digits. 
        /// <para>The first digit represents the “use open end”: 1=true, 0=false.</para>
        /// <para>The second digit indicates the tightening direction: 0=CW, 1=CCW.</para>
        /// <para>The third digit indicates motor rotation: 0=normal,1=inverted.</para>
        /// </param>
        /// <param name="controllerSoftwareVersion">The software version is specified by 19 ASCII characters.</param>
        /// <param name="toolMaxTorque">The tool max toque value is multiplied by 100 and sent as an integer(2 decimals truncated). Six ASCII digits.</param>
        /// <param name="gearRatio">The gear ratio value is multiplied by 100 and sent as an integer(2 decimals truncated). Six ASCII digits.</param>
        /// <param name="toolFullSpeed">The tool full speed value is multiplied by 100 and sent as an integer(2 decimals truncated). Six ASCII digits.</param>
        /// <param name="revision">Revision number (default = 3)</param>
        public Mid0041(string toolSerialNumber, long toolNumberOfTightenings, DateTime lastCalibrationDate,
            string controllerSerialNumber, decimal calibrationValue, DateTime lastServiceDate,
            long tighteningsSinceService, ToolType toolType, int motorSize, OpenEndDatas openEndData,
            string controllerSoftwareVersion, decimal toolMaxTorque, decimal gearRatio, decimal toolFullSpeed, 
            int revision = 3) : this(toolSerialNumber, toolNumberOfTightenings, lastCalibrationDate, 
                                        controllerSerialNumber, calibrationValue, lastServiceDate, 
                                        tighteningsSinceService, toolType, motorSize, openEndData, 
                                        controllerSoftwareVersion, revision)
        {
            ToolMaxTorque = toolMaxTorque;
            GearRatio = gearRatio;
            ToolFullSpeed = toolFullSpeed;
        }

        /// <summary>
        /// Revision 4 Constructor
        /// </summary>
        /// <param name="toolSerialNumber">14 ASCII characters</param>
        /// <param name="toolNumberOfTightenings">10 ASCII digits. Max 4294967295</param>
        /// <param name="lastCalibrationDate">19 ASCII characters.</param>
        /// <param name="controllerSerialNumber">10 ASCII characters</param>
        /// <param name="calibrationValue">The tool calibration value is multiplied by 100 and sent as an integer (2 decimals truncated). Six ASCII digits.</param>
        /// <param name="lastServiceDate">19 ASCII characters.</param>
        /// <param name="tighteningsSinceService">The number of tightenings since last service is specified by 10 ASCII digits. Max 4294967295.</param>
        /// <param name="toolType">The tool type is specified by 2 ASCII digits</param>
        /// <param name="motorSize">The motor size is specified by 2 ASCII digits, range 00-99.
        /// <para>00 = no motor, 01-99 = motor size xx in Atlas Copco
        /// nomenclature, or motor size = 10xx in Atlas Copco nomenclature </para>
        /// <para>(certain numbers correspond to 2
        /// different motor sizes, for example 62 for both motor
        /// size 62 and motor size 1062)</para></param>
        /// <param name="openEndData">The open end data is specified by 3 ASCII digits. 
        /// <para>The first digit represents the “use open end”: 1=true, 0=false.</para>
        /// <para>The second digit indicates the tightening direction: 0=CW, 1=CCW.</para>
        /// <para>The third digit indicates motor rotation: 0=normal,1=inverted.</para>
        /// </param>
        /// <param name="controllerSoftwareVersion">The software version is specified by 19 ASCII characters.</param>
        /// <param name="toolMaxTorque">The tool max toque value is multiplied by 100 and sent as an integer(2 decimals truncated). Six ASCII digits.</param>
        /// <param name="gearRatio">The gear ratio value is multiplied by 100 and sent as an integer(2 decimals truncated). Six ASCII digits.</param>
        /// <param name="toolFullSpeed">The tool full speed value is multiplied by 100 and sent as an integer(2 decimals truncated). Six ASCII digits.</param>
        /// <param name="primaryTool">Primary tool. The primary tool is two byte-long and specified by two ASCII digits.</param>
        /// <param name="revision">Revision number (default = 4)</param>
        public Mid0041(string toolSerialNumber, long toolNumberOfTightenings, DateTime lastCalibrationDate,
            string controllerSerialNumber, decimal calibrationValue, DateTime lastServiceDate,
            long tighteningsSinceService, ToolType toolType, int motorSize, OpenEndDatas openEndData,
            string controllerSoftwareVersion, decimal toolMaxTorque, decimal gearRatio, decimal toolFullSpeed,
            PrimaryTool primaryTool, int revision = 4) 
            : this(toolSerialNumber, toolNumberOfTightenings, lastCalibrationDate, controllerSerialNumber, 
                  calibrationValue, lastServiceDate, tighteningsSinceService, toolType, motorSize, openEndData,
                  controllerSoftwareVersion, toolMaxTorque, gearRatio, toolFullSpeed, revision)
        {
            PrimaryTool = primaryTool;
        }

        /// <summary>
        /// Revision 5 Constructor
        /// </summary>
        /// <param name="toolSerialNumber">14 ASCII characters</param>
        /// <param name="toolNumberOfTightenings">10 ASCII digits. Max 4294967295</param>
        /// <param name="lastCalibrationDate">19 ASCII characters.</param>
        /// <param name="controllerSerialNumber">10 ASCII characters</param>
        /// <param name="calibrationValue">The tool calibration value is multiplied by 100 and sent as an integer (2 decimals truncated). Six ASCII digits.</param>
        /// <param name="lastServiceDate">19 ASCII characters.</param>
        /// <param name="tighteningsSinceService">The number of tightenings since last service is specified by 10 ASCII digits. Max 4294967295.</param>
        /// <param name="toolType">The tool type is specified by 2 ASCII digits</param>
        /// <param name="motorSize">The motor size is specified by 2 ASCII digits, range 00-99.
        /// <para>00 = no motor, 01-99 = motor size xx in Atlas Copco
        /// nomenclature, or motor size = 10xx in Atlas Copco nomenclature </para>
        /// <para>(certain numbers correspond to 2
        /// different motor sizes, for example 62 for both motor
        /// size 62 and motor size 1062)</para></param>
        /// <param name="openEndData">The open end data is specified by 3 ASCII digits. 
        /// <para>The first digit represents the “use open end”: 1=true, 0=false.</para>
        /// <para>The second digit indicates the tightening direction: 0=CW, 1=CCW.</para>
        /// <para>The third digit indicates motor rotation: 0=normal,1=inverted.</para>
        /// </param>
        /// <param name="controllerSoftwareVersion">The software version is specified by 19 ASCII characters.</param>
        /// <param name="toolMaxTorque">The tool max toque value is multiplied by 100 and sent as an integer(2 decimals truncated). Six ASCII digits.</param>
        /// <param name="gearRatio">The gear ratio value is multiplied by 100 and sent as an integer(2 decimals truncated). Six ASCII digits.</param>
        /// <param name="toolFullSpeed">The tool full speed value is multiplied by 100 and sent as an integer(2 decimals truncated). Six ASCII digits.</param>
        /// <param name="primaryTool">Primary tool. The primary tool is two byte-long and specified by two ASCII digits.</param>
        /// <param name="toolModel">12 ASCII characters with padding at the end of the string if needed.The padding is done spaces.</param>
        /// <param name="revision">Revision number (default = 5)</param>
        public Mid0041(string toolSerialNumber, long toolNumberOfTightenings, DateTime lastCalibrationDate,
            string controllerSerialNumber, decimal calibrationValue, DateTime lastServiceDate,
            long tighteningsSinceService, ToolType toolType, int motorSize, OpenEndDatas openEndData,
            string controllerSoftwareVersion, decimal toolMaxTorque, decimal gearRatio, decimal toolFullSpeed,
            PrimaryTool primaryTool, string toolModel , int revision = 5) 
            : this(toolSerialNumber, toolNumberOfTightenings, lastCalibrationDate, controllerSerialNumber, 
                  calibrationValue, lastServiceDate, tighteningsSinceService, toolType, motorSize, openEndData,
                  controllerSoftwareVersion, toolMaxTorque, gearRatio, toolFullSpeed, primaryTool, revision)
        {
            ToolModel = toolModel;
        }

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();
            //Rev 1
            if (ToolSerialNumber.Length > 14)
                failed.Add(new ArgumentOutOfRangeException(nameof(ToolSerialNumber), "Max of 14 characters").Message);
            if (ToolNumberOfTightenings < 0 || ToolNumberOfTightenings > 4294967295)
                failed.Add(new ArgumentOutOfRangeException(nameof(ToolNumberOfTightenings), "Range: 0000000000-4294967295").Message);
            if (ControllerSerialNumber.Length > 10)
                failed.Add(new ArgumentOutOfRangeException(nameof(ControllerSerialNumber), "Max of 10 characters").Message);

            if (HeaderData.Revision > 1) //Rev 2
            {
                if (TighteningsSinceService < 0 || TighteningsSinceService > 4294967295)
                    failed.Add(new ArgumentOutOfRangeException(nameof(TighteningsSinceService), "Range: 0000000000-4294967295").Message);

                if (MotorSize < 0 || MotorSize > 99)
                    failed.Add(new ArgumentOutOfRangeException(nameof(MotorSize), "Range: 00-99").Message);

                if (ControllerSoftwareVersion.Length > 19)
                    failed.Add(new ArgumentOutOfRangeException(nameof(ControllerSoftwareVersion), "Max of 19 characters").Message);

                if (HeaderData.Revision > 4) //Rev 5
                {
                    if (ToolModel.Length > 12)
                        failed.Add(new ArgumentOutOfRangeException(nameof(ToolModel), "Max of 12 characters").Message);
                }
            }
            errors = failed;
            return errors.Any();
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
                }
            };
        }

        public enum DataFields
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
            //Rev 5,
            TOOL_MODEL
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
