using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Parameter set data upload reply
    /// <para>Upload of parameter set data reply.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0013 : Mid, IParameterSet, IController
    {
        public const int MID = 13;

        public int ParameterSetId
        {
            get => GetField(1, DataFields.ParameterSetId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.ParameterSetId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string ParameterSetName
        {
            get => GetField(1, DataFields.ParameterSetName).Value;
            set => GetField(1, DataFields.ParameterSetName).SetValue(value);
        }
        public RotationDirection RotationDirection
        {
            get => (RotationDirection)GetField(1, DataFields.RotationDirection).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.RotationDirection).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int BatchSize
        {
            get => GetField(1, DataFields.BatchSize).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.BatchSize).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal MinTorque
        {
            get => GetField(1, DataFields.MinTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, DataFields.MinTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal MaxTorque
        {
            get => GetField(1, DataFields.MaxTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, DataFields.MaxTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal TorqueFinalTarget
        {
            get => GetField(1, DataFields.TorqueFinalTarget).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, DataFields.TorqueFinalTarget).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int MinAngle
        {
            get => GetField(1, DataFields.MinAngle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.MinAngle).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int MaxAngle
        {
            get => GetField(1, DataFields.MaxAngle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.MaxAngle).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int AngleFinalTarget
        {
            get => GetField(1, DataFields.AngleFinalTarget).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.AngleFinalTarget).SetValue(OpenProtocolConvert.ToString, value);
        }
        //Rev 2
        public decimal FirstTarget
        {
            get => GetField(2, DataFields.FirstTarget).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, DataFields.FirstTarget).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal StartFinalAngle
        {
            get => GetField(2, DataFields.StartFinalTarget).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, DataFields.StartFinalTarget).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        //Rev 5
        public DateTime LastChangeInParameterSet
        {
            get => GetField(5, DataFields.LastChangeInParameterSet).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(5, DataFields.LastChangeInParameterSet).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0013() : this(DEFAULT_REVISION)
        {

        }

        public Mid0013(Header header) : base(header)
        {
            
        }

        public Mid0013(int revision) : this(new Header()
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
                                DataField.Number(DataFields.ParameterSetId, 20, 3),
                                DataField.String(DataFields.ParameterSetName, 25, 25),
                                DataField.Number(DataFields.RotationDirection, 52, 1),
                                DataField.Number(DataFields.BatchSize, 55, 2),
                                DataField.Number(DataFields.MinTorque, 59, 6),
                                DataField.Number(DataFields.MaxTorque, 67, 6),
                                DataField.Number(DataFields.TorqueFinalTarget, 75, 6),
                                DataField.Number(DataFields.MinAngle, 83, 5),
                                DataField.Number(DataFields.MaxAngle, 90, 5),
                                DataField.Number(DataFields.AngleFinalTarget, 97, 5)
                            }
                },
                {
                    2, new  List<DataField>()
                            {
                                DataField.Number(DataFields.FirstTarget, 104, 6),
                                DataField.Number(DataFields.StartFinalTarget, 112, 6)
                            }
                },
                {
                    5, new  List<DataField>()
                            {
                                DataField.Timestamp(DataFields.LastChangeInParameterSet, 120),
                            }
                }
            };
        }

        protected enum DataFields
        {
            ParameterSetId,
            ParameterSetName,
            RotationDirection,
            BatchSize,
            MinTorque,
            MaxTorque,
            TorqueFinalTarget,
            MinAngle,
            MaxAngle,
            AngleFinalTarget,
            //Rev 2
            FirstTarget,
            StartFinalTarget,
            //Rev 5
            LastChangeInParameterSet
        }
    }
}
