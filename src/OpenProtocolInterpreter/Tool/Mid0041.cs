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
            get => GetField(1, DataFields.ToolSerialNumber).Value;
            set => GetField(1, DataFields.ToolSerialNumber).SetValue(value);
        }
        public long ToolNumberOfTightenings
        {
            get => GetField(1, DataFields.ToolNumberOfTightenings).GetValue(OpenProtocolConvert.ToInt64);
            set => GetField(1, DataFields.ToolNumberOfTightenings).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime LastCalibrationDate
        {
            get => GetField(1, DataFields.LastCalibrationDate).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, DataFields.LastCalibrationDate).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string ControllerSerialNumber
        {
            get => GetField(1, DataFields.ControllerSerialNumber).Value;
            set => GetField(1, DataFields.ControllerSerialNumber).SetValue(value);
        }
        //Rev 2
        public decimal CalibrationValue
        {
            get => GetField(2, DataFields.CalibrationValue).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, DataFields.CalibrationValue).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public DateTime LastServiceDate
        {
            get => GetField(2, DataFields.LastServiceDate).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(2, DataFields.LastServiceDate).SetValue(OpenProtocolConvert.ToString, value);
        }
        public long TighteningsSinceService
        {
            get => GetField(2, DataFields.TighteningsSinceService).GetValue(OpenProtocolConvert.ToInt64);
            set => GetField(2, DataFields.TighteningsSinceService).SetValue(OpenProtocolConvert.ToString, value);
        }
        public ToolType ToolType
        {
            get => (ToolType)GetField(2, DataFields.ToolType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.ToolType).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int MotorSize
        {
            get => GetField(2, DataFields.MotorSize).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.MotorSize).SetValue(OpenProtocolConvert.ToString, value);
        }
        public OpenEndData OpenEndData
        {
            get => GetField(2, DataFields.OpenEndData).GetValue(OpenEndData.Parse);
            set => GetField(2, DataFields.OpenEndData).SetValue(PackOpenEndData, value);
        }
        public string ControllerSoftwareVersion
        {
            get => GetField(2, DataFields.ControllerSoftwareVersion).Value;
            set => GetField(2, DataFields.ControllerSoftwareVersion).SetValue(value);
        }
        //Rev 3
        public decimal ToolMaxTorque
        {
            get => GetField(3, DataFields.ToolMaxTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(3, DataFields.ToolMaxTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal GearRatio
        {
            get => GetField(3, DataFields.GearRatio).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(3, DataFields.GearRatio).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal ToolFullSpeed
        {
            get => GetField(3, DataFields.ToolFullSpeed).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(3, DataFields.ToolFullSpeed).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        //Rev 4
        public PrimaryTool PrimaryTool
        {
            get => (PrimaryTool)GetField(4, DataFields.PrimaryTool).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(4, DataFields.PrimaryTool).SetValue(OpenProtocolConvert.ToString, value);
        }
        //Rev 5
        public string ToolModel
        {
            get => GetField(5, DataFields.ToolModel).Value;
            set => GetField(5, DataFields.ToolModel).SetValue(value);
        }
        //Rev 6
        public int ToolNumber
        {
            get => GetField(6, DataFields.ToolNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(6, DataFields.ToolNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string ToolArticleNumber
        {
            get => GetField(6, DataFields.ToolArticleNumber).Value;
            set => GetField(6, DataFields.ToolArticleNumber).SetValue(value);
        }
        //Rev 7
        public decimal RundownMinSpeed
        {
            get => GetField(7, DataFields.RundownMinSpeed).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(7, DataFields.RundownMinSpeed).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal DownshiftMaxSpeed
        {
            get => GetField(7, DataFields.DownshiftMaxSpeed).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(7, DataFields.DownshiftMaxSpeed).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal DownshiftMinSpeed
        {
            get => GetField(7, DataFields.DownshiftMinSpeed).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(7, DataFields.DownshiftMinSpeed).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
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

        protected virtual string PackOpenEndData(char paddingChar, int size, PaddingOrientation orientation, OpenEndData value)
            => value.Pack();

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.String(DataFields.ToolSerialNumber, 20, 14),
                                DataField.Number(DataFields.ToolNumberOfTightenings, 36, 10),
                                DataField.Timestamp(DataFields.LastCalibrationDate, 48),
                                DataField.String(DataFields.ControllerSerialNumber, 69, 10)
                            }
                },
                {
                    2, new  List<DataField>()
                            {
                                DataField.Number(DataFields.CalibrationValue, 81, 6),
                                DataField.Timestamp(DataFields.LastServiceDate, 89),
                                DataField.Number(DataFields.TighteningsSinceService, 110, 10),
                                DataField.Number(DataFields.ToolType, 122, 2),
                                DataField.Number(DataFields.MotorSize, 126, 2),
                                new(DataFields.OpenEndData, 130, 3),
                                DataField.String(DataFields.ControllerSoftwareVersion, 135, 19)
                            }
                },
                {
                    3, new  List<DataField>()
                            {
                                DataField.Number(DataFields.ToolMaxTorque, 156, 6),
                                DataField.Number(DataFields.GearRatio, 164, 6),
                                DataField.Number(DataFields.ToolFullSpeed, 172, 6)
                            }
                },
                {
                    4, new  List<DataField>()
                            {
                                DataField.Number(DataFields.PrimaryTool, 180, 2)
                            }
                },
                {
                    5, new  List<DataField>()
                            {
                                DataField.String(DataFields.ToolModel, 184, 12)
                            }
                },
                {
                    6, new  List<DataField>()
                            {
                                DataField.Number(DataFields.ToolNumber, 198, 4),
                                DataField.String(DataFields.ToolArticleNumber, 204, 30)
                            }
                },
                {
                    7, new  List<DataField>()
                            {
                                DataField.Number(DataFields.RundownMinSpeed, 236, 6),
                                DataField.Number(DataFields.DownshiftMaxSpeed, 244, 6),
                                DataField.Number(DataFields.DownshiftMinSpeed, 252, 6),
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
