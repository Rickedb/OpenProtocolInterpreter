using System;
using System.Collections.Generic;

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
        public const int MID = 41;

        public string ToolSerialNumber
        {
            get => GetField(1, (int)DataFields.ToolSerialNumber).Value;
            set => GetField(1, (int)DataFields.ToolSerialNumber).SetValue(value);
        }
        public long ToolNumberOfTightenings
        {
            get => GetField(1, (int)DataFields.ToolNumberOfTightenings).GetValue(OpenProtocolConvert.ToInt64);
            set => GetField(1, (int)DataFields.ToolNumberOfTightenings).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime LastCalibrationDate
        {
            get => GetField(1, (int)DataFields.LastCalibrationDate).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, (int)DataFields.LastCalibrationDate).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string ControllerSerialNumber
        {
            get => GetField(1, (int)DataFields.ControllerSerialNumber).Value;
            set => GetField(1, (int)DataFields.ControllerSerialNumber).SetValue(value);
        }
        //Rev 2
        public decimal CalibrationValue
        {
            get => GetField(2, (int)DataFields.CalibrationValue).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.CalibrationValue).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public DateTime LastServiceDate
        {
            get => GetField(2, (int)DataFields.LastServiceDate).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(2, (int)DataFields.LastServiceDate).SetValue(OpenProtocolConvert.ToString, value);
        }
        public long TighteningsSinceService
        {
            get => GetField(2, (int)DataFields.TighteningsSinceService).GetValue(OpenProtocolConvert.ToInt64);
            set => GetField(2, (int)DataFields.TighteningsSinceService).SetValue(OpenProtocolConvert.ToString, value);
        }
        public ToolType ToolType
        {
            get => (ToolType)GetField(2, (int)DataFields.ToolType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.ToolType).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public int MotorSize
        {
            get => GetField(2, (int)DataFields.MotorSize).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.MotorSize).SetValue(OpenProtocolConvert.ToString, value);
        }
        public OpenEndData OpenEndData
        {
            get => GetField(2, (int)DataFields.OpenEndData).GetValue(OpenEndData.Parse);
            set => GetField(2, (int)DataFields.OpenEndData).SetValue(PackOpenEndData, value);
        }
        public string ControllerSoftwareVersion
        {
            get => GetField(2, (int)DataFields.ControllerSoftwareVersion).Value;
            set => GetField(2, (int)DataFields.ControllerSoftwareVersion).SetValue(value);
        }
        //Rev 3
        public decimal ToolMaxTorque
        {
            get => GetField(3, (int)DataFields.ToolMaxTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(3, (int)DataFields.ToolMaxTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal GearRatio
        {
            get => GetField(3, (int)DataFields.GearRatio).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(3, (int)DataFields.GearRatio).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal ToolFullSpeed
        {
            get => GetField(3, (int)DataFields.ToolFullSpeed).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(3, (int)DataFields.ToolFullSpeed).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        //Rev 4
        public PrimaryTool PrimaryTool
        {
            get => (PrimaryTool)GetField(4, (int)DataFields.PrimaryTool).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(4, (int)DataFields.PrimaryTool).SetValue(OpenProtocolConvert.ToString, (int)value);
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
            get => GetField(6, (int)DataFields.ToolNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(6, (int)DataFields.ToolNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string ToolArticleNumber
        {
            get => GetField(6, (int)DataFields.ToolArticleNumber).Value;
            set => GetField(6, (int)DataFields.ToolArticleNumber).SetValue(value);
        }
        //Rev 7
        public decimal RundownMinSpeed
        {
            get => GetField(7, (int)DataFields.RundownMinSpeed).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(7, (int)DataFields.RundownMinSpeed).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal DownshiftMaxSpeed
        {
            get => GetField(7, (int)DataFields.DownshiftMaxSpeed).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(7, (int)DataFields.DownshiftMaxSpeed).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal DownshiftMinSpeed
        {
            get => GetField(7, (int)DataFields.DownshiftMinSpeed).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(7, (int)DataFields.DownshiftMinSpeed).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }

        public Mid0041() : this(DEFAULT_REVISION)
        {

        }

        public Mid0041(Header header) : base(header)
        {
        }

        public Mid0041(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }

        protected virtual string PackOpenEndData(char paddingChar, int size, DataField.PaddingOrientations orientation, OpenEndData value)
            => value.Pack();

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
    }
}
