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
            get => GetField(1, (int)DataFields.ToolSerialNumber).Value;
            set => GetField(1, (int)DataFields.ToolSerialNumber).SetValue(value);
        }
        public long ToolNumberOfTightenings
        {
            get => GetField(1, (int)DataFields.ToolNumberOfTightenings).GetValue(_longConverter.Convert);
            set => GetField(1, (int)DataFields.ToolNumberOfTightenings).SetValue(_longConverter.Convert, value);
        }
        public DateTime LastCalibrationDate
        {
            get => GetField(1, (int)DataFields.LastCalibrationDate).GetValue(_dateConverter.Convert);
            set => GetField(1, (int)DataFields.LastCalibrationDate).SetValue(_dateConverter.Convert, value);
        }
        public string ControllerSerialNumber
        {
            get => GetField(1, (int)DataFields.ControllerSerialNumber).Value;
            set => GetField(1, (int)DataFields.ControllerSerialNumber).SetValue(value);
        }
        //Rev 2
        public decimal CalibrationValue
        {
            get => GetField(2, (int)DataFields.CalibrationValue).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.CalibrationValue).SetValue(_decimalConverter.Convert, value);
        }
        public DateTime LastServiceDate
        {
            get => GetField(2, (int)DataFields.LastServiceDate).GetValue(_dateConverter.Convert);
            set => GetField(2, (int)DataFields.LastServiceDate).SetValue(_dateConverter.Convert, value);
        }
        public long TighteningsSinceService
        {
            get => GetField(2, (int)DataFields.TighteningsSinceService).GetValue(_longConverter.Convert);
            set => GetField(2, (int)DataFields.TighteningsSinceService).SetValue(_longConverter.Convert, value);
        }
        public ToolType ToolType
        {
            get => (ToolType)GetField(2, (int)DataFields.ToolType).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.ToolType).SetValue(_intConverter.Convert, (int)value);
        }
        public int MotorSize
        {
            get => GetField(2, (int)DataFields.MotorSize).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.MotorSize).SetValue(_intConverter.Convert, value);
        }
        public OpenEndDatas OpenEndData
        {
            get => GetField(2, (int)DataFields.OpenEndData).GetValue(_openEndDataConverter.Convert);
            set => GetField(2, (int)DataFields.OpenEndData).SetValue(_openEndDataConverter.Convert, value);
        }
        public string ControllerSoftwareVersion
        {
            get => GetField(2, (int)DataFields.ControllerSoftwareVersion).Value;
            set => GetField(2, (int)DataFields.ControllerSoftwareVersion).SetValue(value);
        }
        //Rev 3
        public decimal ToolMaxTorque
        {
            get => GetField(3, (int)DataFields.ToolMaxTorque).GetValue(_decimalConverter.Convert);
            set => GetField(3, (int)DataFields.ToolMaxTorque).SetValue(_decimalConverter.Convert, value);
        }
        public decimal GearRatio
        {
            get => GetField(3, (int)DataFields.GearRatio).GetValue(_decimalConverter.Convert);
            set => GetField(3, (int)DataFields.GearRatio).SetValue(_decimalConverter.Convert, value);
        }
        public decimal ToolFullSpeed
        {
            get => GetField(3, (int)DataFields.ToolFullSpeed).GetValue(_decimalConverter.Convert);
            set => GetField(3, (int)DataFields.ToolFullSpeed).SetValue(_decimalConverter.Convert, value);
        }
        //Rev 4
        public PrimaryTool PrimaryTool
        {
            get => (PrimaryTool)GetField(4, (int)DataFields.PrimaryTool).GetValue(_intConverter.Convert);
            set => GetField(4, (int)DataFields.PrimaryTool).SetValue(_intConverter.Convert, (int)value);
        }
        //Rev 5
        public string ToolModel
        {
            get => GetField(5, (int)DataFields.ToolModel).Value;
            set => GetField(5, (int)DataFields.ToolModel).SetValue(value);
        }
        //Rev 6
        public int ToolNumber
        {
            get => GetField(6, (int)DataFields.ToolNumber).GetValue(_intConverter.Convert);
            set => GetField(6, (int)DataFields.ToolNumber).SetValue(_intConverter.Convert, value);
        }
        public string ToolArticleNumber
        {
            get => GetField(6, (int)DataFields.ToolArticleNumber).Value;
            set => GetField(6, (int)DataFields.ToolArticleNumber).SetValue(value);
        }
        //Rev 7
        public decimal RundownMinSpeed
        {
            get => GetField(7, (int)DataFields.RundownMinSpeed).GetValue(_decimalConverter.Convert);
            set => GetField(7, (int)DataFields.RundownMinSpeed).SetValue(_decimalConverter.Convert, value);
        }
        public decimal DownshiftMaxSpeed
        {
            get => GetField(7, (int)DataFields.DownshiftMaxSpeed).GetValue(_decimalConverter.Convert);
            set => GetField(7, (int)DataFields.DownshiftMaxSpeed).SetValue(_decimalConverter.Convert, value);
        }
        public decimal DownshiftMinSpeed
        {
            get => GetField(7, (int)DataFields.DownshiftMinSpeed).GetValue(_decimalConverter.Convert);
            set => GetField(7, (int)DataFields.DownshiftMinSpeed).SetValue(_decimalConverter.Convert, value);
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
                                new DataField((int)DataFields.ToolSerialNumber, 20, 14, ' '),
                                new DataField((int)DataFields.ToolNumberOfTightenings, 36, 10, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.LastCalibrationDate, 48, 19),
                                new DataField((int)DataFields.ControllerSerialNumber, 69, 10, ' ')
                            }
                },
                {
                    2, new  List<DataField>()
                            {
                                new DataField((int)DataFields.CalibrationValue, 81, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.LastServiceDate, 89, 19),
                                new DataField((int)DataFields.TighteningsSinceService, 110, 10, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ToolType, 122, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.MotorSize, 126, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.OpenEndData, 130, 3),
                                new DataField((int)DataFields.ControllerSoftwareVersion, 135, 19, ' ')
                            }
                },
                {
                    3, new  List<DataField>()
                            {
                                new DataField((int)DataFields.ToolMaxTorque, 156, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.GearRatio, 164, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ToolFullSpeed, 172, 6, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                },
                {
                    4, new  List<DataField>()
                            {
                                new DataField((int)DataFields.PrimaryTool, 180, 2, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                },
                {
                    5, new  List<DataField>()
                            {
                                new DataField((int)DataFields.ToolModel, 184, 12, ' ')
                            }
                },
                {
                    6, new  List<DataField>()
                            {
                                new DataField((int)DataFields.ToolNumber, 198, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ToolArticleNumber, 204, 30, ' ')
                            }
                },
                {
                    7, new  List<DataField>()
                            {
                                new DataField((int)DataFields.RundownMinSpeed, 236, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.DownshiftMaxSpeed, 244, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.DownshiftMinSpeed, 252, 6, '0', DataField.PaddingOrientations.LeftPadded),
                            }
                }
            };
        }

        protected enum DataFields
        {
            ToolSerialNumber,
            ToolNumberOfTightenings,
            LastCalibrationDate,
            ControllerSerialNumber,
            //Rev 2
            CalibrationValue,
            LastServiceDate,
            TighteningsSinceService,
            ToolType,
            MotorSize,
            OpenEndData,
            ControllerSoftwareVersion,
            //Rev 3
            ToolMaxTorque,
            GearRatio,
            ToolFullSpeed,
            //Rev 4
            PrimaryTool,
            //Rev 5
            ToolModel,
            //Rev 6
            ToolNumber,
            ToolArticleNumber,
            //Rev 7
            RundownMinSpeed,
            DownshiftMaxSpeed,
            DownshiftMinSpeed
        }

        public class OpenEndDatas
        {
            //TODO: Move outside
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
