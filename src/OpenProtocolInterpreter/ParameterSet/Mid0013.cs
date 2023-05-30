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
            get => GetField(1, (int)DataFields.ParameterSetId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.ParameterSetId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string ParameterSetName
        {
            get => GetField(1, (int)DataFields.ParameterSetName).Value;
            set => GetField(1, (int)DataFields.ParameterSetName).SetValue(value);
        }
        public RotationDirection RotationDirection
        {
            get => (RotationDirection)GetField(1, (int)DataFields.RotationDirection).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.RotationDirection).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public int BatchSize
        {
            get => GetField(1, (int)DataFields.BatchSize).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.BatchSize).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal MinTorque
        {
            get => GetField(1, (int)DataFields.MinTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, (int)DataFields.MinTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal MaxTorque
        {
            get => GetField(1, (int)DataFields.MaxTorque).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, (int)DataFields.MaxTorque).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal TorqueFinalTarget
        {
            get => GetField(1, (int)DataFields.TorqueFinalTarget).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(1, (int)DataFields.TorqueFinalTarget).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int MinAngle
        {
            get => GetField(1, (int)DataFields.MinAngle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.MinAngle).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int MaxAngle
        {
            get => GetField(1, (int)DataFields.MaxAngle).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.MaxAngle).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int AngleFinalTarget
        {
            get => GetField(1, (int)DataFields.AngleFinalTarget).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.AngleFinalTarget).SetValue(OpenProtocolConvert.ToString, value);
        }
        //Rev 2
        public decimal FirstTarget
        {
            get => GetField(2, (int)DataFields.FirstTarget).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.FirstTarget).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal StartFinalAngle
        {
            get => GetField(2, (int)DataFields.StartFinalTarget).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.StartFinalTarget).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        //Rev 5
        public DateTime LastChangeInParameterSet
        {
            get => GetField(5, (int)DataFields.LastChangeInParameterSet).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(5, (int)DataFields.LastChangeInParameterSet).SetValue(OpenProtocolConvert.ToString, value);
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
                                new DataField((int)DataFields.ParameterSetId, 20, 3, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ParameterSetName, 25, 25, ' '),
                                new DataField((int)DataFields.RotationDirection, 52, 1, '0'),
                                new DataField((int)DataFields.BatchSize, 55, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.MinTorque, 59, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.MaxTorque, 67, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TorqueFinalTarget, 75, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.MinAngle, 83, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.MaxAngle, 90, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.AngleFinalTarget, 97, 5, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                },
                {
                    2, new  List<DataField>()
                            {
                                new DataField((int)DataFields.FirstTarget, 104, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.StartFinalTarget, 112, 6, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                },
                {
                    5, new  List<DataField>()
                            {
                                new DataField((int)DataFields.LastChangeInParameterSet, 120, 19),
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
