using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Parameter set data upload reply
    /// Description: 
    ///     Upload of parameter set data reply.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0013 : Mid, IParameterSet
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<decimal> _decimalConverter;
        private const int LAST_REVISION = 2;
        public const int MID = 13;

        public int ParameterSetId
        {
            get => GetField(1,(int)DataFields.PARAMETER_SET_ID).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.PARAMETER_SET_ID).SetValue(_intConverter.Convert, value);
        }
        public string ParameterSetName
        {
            get => GetField(1,(int)DataFields.PARAMETER_SET_NAME).Value;
            set => GetField(1,(int)DataFields.PARAMETER_SET_NAME).SetValue(value);
        }
        public RotationDirection RotationDirection
        {
            get => (RotationDirection)GetField(1,(int)DataFields.ROTATION_DIRECTION).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.ROTATION_DIRECTION).SetValue(_intConverter.Convert, (int)value);
        }
        public int BatchSize
        {
            get => GetField(1,(int)DataFields.BATCH_SIZE).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.BATCH_SIZE).SetValue(_intConverter.Convert, value);
        }
        public decimal MinTorque
        {
            get => GetField(1,(int)DataFields.MIN_TORQUE).GetValue(_decimalConverter.Convert);
            set => GetField(1,(int)DataFields.MIN_TORQUE).SetValue(_decimalConverter.Convert, value);
        }
        public decimal MaxTorque
        {
            get => GetField(1,(int)DataFields.MAX_TORQUE).GetValue(_decimalConverter.Convert);
            set => GetField(1,(int)DataFields.MAX_TORQUE).SetValue(_decimalConverter.Convert, value);
        }
        public decimal TorqueFinalTarget
        {
            get => GetField(1,(int)DataFields.TORQUE_FINAL_TARGET).GetValue(_decimalConverter.Convert);
            set => GetField(1,(int)DataFields.TORQUE_FINAL_TARGET).SetValue(_decimalConverter.Convert, value);
        }
        public int MinAngle
        {
            get => GetField(1,(int)DataFields.MIN_ANGLE).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.MIN_ANGLE).SetValue(_intConverter.Convert, value);
        }
        public int MaxAngle
        {
            get => GetField(1,(int)DataFields.MAX_ANGLE).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.MAX_ANGLE).SetValue(_intConverter.Convert, value);
        }
        public int AngleFinalTarget
        {
            get => GetField(1,(int)DataFields.ANGLE_FINAL_TARGET).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.ANGLE_FINAL_TARGET).SetValue(_intConverter.Convert, value);
        }
        //Rev 2
        public decimal FirstTarget
        {
            get => GetField(2,(int)DataFields.FIRST_TARGET).GetValue(_decimalConverter.Convert);
            set => GetField(2,(int)DataFields.FIRST_TARGET).SetValue(_decimalConverter.Convert, value);
        }
        public decimal StartFinalAngle
        {
            get => GetField(2,(int)DataFields.START_FINAL_TARGET).GetValue(_decimalConverter.Convert);
            set => GetField(2,(int)DataFields.START_FINAL_TARGET).SetValue(_decimalConverter.Convert, value);
        }

        public MID_0013(int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            _decimalConverter = new DecimalTrucatedConverter(2);
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="parameterSetId">Three ASCII digits, range 000-999</param>
        /// <param name="parameterSetName">25 ASCII characters. Right padded with space if name is less than 25 characters.</param>
        /// <param name="rotationDirection">1=CW (Clockwise), 2=CCW (Counter Clockwise)</param>
        /// <param name="batchSize">2 ASCII digits, range 00-99</param>
        /// <param name="minTorque">The torque min limit is multiplied by 100 and sent as an integer (2 decimals truncated). It is six bytes long and is specified by six ASCII digits.</param>
        /// <param name="maxTorque">The torque max limit is multiplied by 100 and sent as an integer (2 decimals truncated). It is six bytes long and is specified by six ASCII digits.</param>
        /// <param name="torqueFinalTarget">The torque final target is multiplied by 100 and sent as an integer (2 decimals truncated). It is six bytes long and is specified by six ASCII digits.</param>
        /// <param name="minAngle">The angle min value is five bytes long and is specified by five ASCII digits.Range: 00000-99999.</param>
        /// <param name="maxAngle">The angle max value is five bytes long and is specified by five ASCII digits.Range: 00000-99999.</param>
        /// <param name="angleFinalTarget">The target angle is specified in degrees. 5 ASCII digits. Range: 00000-99999.</param>
        /// <param name="revision">Revision number (default = 1)</param>
        public MID_0013(int parameterSetId, string parameterSetName, RotationDirection rotationDirection, int batchSize, decimal minTorque, decimal maxTorque, 
            decimal torqueFinalTarget, int minAngle, int maxAngle, int angleFinalTarget, int revision = 1) : this(revision)
        {
            ParameterSetId = parameterSetId;
            ParameterSetName = ParameterSetName;
            RotationDirection = rotationDirection;
            BatchSize = batchSize;
            MinTorque = minTorque;
            MaxTorque = maxTorque;
            TorqueFinalTarget = torqueFinalTarget;
            MinAngle = minAngle;
            MaxAngle = maxAngle;
            AngleFinalTarget = angleFinalTarget;
        }

        /// <summary>
        /// Revision 2 Constructor
        /// </summary>
        /// <param name="parameterSetId">Three ASCII digits, range 000-999</param>
        /// <param name="parameterSetName">25 ASCII characters. Right padded with space if name is less than 25 characters.</param>
        /// <param name="rotationDirection">1=CW (Clockwise), 2=CCW (Counter Clockwise)</param>
        /// <param name="batchSize">2 ASCII digits, range 00-99</param>
        /// <param name="minTorque">The torque min limit is multiplied by 100 and sent as an integer (2 decimals truncated). It is six bytes long and is specified by six ASCII digits.</param>
        /// <param name="maxTorque">The torque max limit is multiplied by 100 and sent as an integer (2 decimals truncated). It is six bytes long and is specified by six ASCII digits.</param>
        /// <param name="torqueFinalTarget">The torque final target is multiplied by 100 and sent as an integer (2 decimals truncated). It is six bytes long and is specified by six ASCII digits.</param>
        /// <param name="minAngle">The angle min value is five bytes long and is specified by five ASCII digits.Range: 00000-99999.</param>
        /// <param name="maxAngle">The angle max value is five bytes long and is specified by five ASCII digits.Range: 00000-99999.</param>
        /// <param name="angleFinalTarget">The target angle is specified in degrees. 5 ASCII digits. Range: 00000-99999.</param>
        /// <param name="firstTarget">The torque first target is multiplied by 100 and sent as an integer (2 decimals truncated). It is six bytes long and is specified by six ASCII digits.</param>
        /// <param name="startFinalAngle">The start final angle is the torque to reach the snug level. The start final angle is multiplied by 100 and sent as an integer (2 decimals truncated). It is six bytes long and is specified by six ASCII digits.</param>
        /// <param name="revision">Revision number (default = 1)</param>
        public MID_0013(int parameterSetId, string parameterSetName, RotationDirection rotationDirection, int batchSize, decimal minTorque, decimal maxTorque, 
            decimal torqueFinalTarget, int minAngle, int maxAngle, int angleFinalTarget, decimal firstTarget, decimal startFinalAngle, int revision = 2) 
            : this(parameterSetId, parameterSetName, rotationDirection, batchSize, minTorque, maxTorque, 
                  torqueFinalTarget, minAngle, maxAngle, angleFinalTarget, revision)
        {
            FirstTarget = firstTarget;
            StartFinalAngle = startFinalAngle;
        }

        internal MID_0013(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();
            //Rev 1
            if (ParameterSetId < 0 || ParameterSetId > 999)
                failed.Add(new ArgumentOutOfRangeException(nameof(ParameterSetId), "Range: 000-999").Message);
            if (ParameterSetName.Length > 25)
                failed.Add(new ArgumentOutOfRangeException(nameof(ParameterSetName), "Max of 25 characters").Message);
            if (BatchSize < 0 || BatchSize > 99)
                failed.Add(new ArgumentOutOfRangeException(nameof(BatchSize), "Range: 00-99").Message);
            if (MinAngle < 0 || MinAngle > 99999)
                failed.Add(new ArgumentOutOfRangeException(nameof(MinAngle), "Range: 00000-99999").Message);
            if (MaxAngle < 0 || MaxAngle > 99999)
                failed.Add(new ArgumentOutOfRangeException(nameof(MaxAngle), "Range: 00000-99999").Message);
            if (AngleFinalTarget < 0 || AngleFinalTarget > 99999)
                failed.Add(new ArgumentOutOfRangeException(nameof(AngleFinalTarget), "Range: 00000-99999").Message);

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
                                new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.PARAMETER_SET_NAME, 25, 25, ' '),
                                new DataField((int)DataFields.ROTATION_DIRECTION, 52, 1, '0'),
                                new DataField((int)DataFields.BATCH_SIZE, 55, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.MIN_TORQUE, 59, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.MAX_TORQUE, 67, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_FINAL_TARGET, 75, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.MIN_ANGLE, 83, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.MAX_ANGLE, 90, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE_FINAL_TARGET, 97, 5, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                },
                {
                    2, new  List<DataField>()
                            {
                                new DataField((int)DataFields.FIRST_TARGET, 104, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.START_FINAL_TARGET, 112, 6, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                }
            };
        }

        public enum DataFields
        {
            PARAMETER_SET_ID,
            PARAMETER_SET_NAME,
            ROTATION_DIRECTION,
            BATCH_SIZE,
            MIN_TORQUE,
            MAX_TORQUE,
            TORQUE_FINAL_TARGET,
            MIN_ANGLE,
            MAX_ANGLE,
            ANGLE_FINAL_TARGET,
            //Rev 2
            FIRST_TARGET,
            START_FINAL_TARGET
        }
    }
}
