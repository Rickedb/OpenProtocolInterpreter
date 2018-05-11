using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Parameter set selected
    /// Description: 
    ///     A new parameter set is selected in the controller. 
    ///     The message includes the ID of the parameter set selected as well as the date and time of the 
    ///     last change in the parameter set settings. This message is also sent as an immediate response to MID 0014 
    ///     Parameter set selected subscribe.
    /// Message sent by: Controller
    /// Answer: MID 0016 New parameter set selected acknowledge
    /// </summary>
    public class MID_0015 : Mid, IParameterSet
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<decimal> _decimalConverter;
        private readonly IValueConverter<DateTime> _datetimeConverter;
        private const int LAST_REVISION = 2;
        public const int MID = 15;

        public int ParameterSetId
        {
            get => RevisionsByFields[1][(int)DataFields.PARAMETER_SET_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.PARAMETER_SET_ID].SetValue(_intConverter.Convert, value);
        }
        public DateTime LastChangeInParameterSet
        {
            get => RevisionsByFields[1][(int)DataFields.LAST_CHANGE_IN_PARAMETER_SET].GetValue(_datetimeConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.LAST_CHANGE_IN_PARAMETER_SET].SetValue(_datetimeConverter.Convert, value);
        }
        //Rev 2
        public string ParameterSetName
        {
            get => RevisionsByFields[2][(int)DataFields.PARAMETER_SET_NAME].Value;
            set => RevisionsByFields[2][(int)DataFields.PARAMETER_SET_NAME].SetValue(value);
        }
        public RotationDirection RotationDirection
        {
            get => (RotationDirection)RevisionsByFields[2][(int)DataFields.ROTATION_DIRECTION].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.ROTATION_DIRECTION].SetValue(_intConverter.Convert, (int)value);
        }
        public int BatchSize
        {
            get => RevisionsByFields[2][(int)DataFields.BATCH_SIZE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.BATCH_SIZE].SetValue(_intConverter.Convert, value);
        }
        public decimal MinTorque
        {
            get => RevisionsByFields[2][(int)DataFields.TORQUE_MIN].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.TORQUE_MIN].SetValue(_decimalConverter.Convert, value);
        }
        public decimal MaxTorque
        {
            get => RevisionsByFields[2][(int)DataFields.TORQUE_MAX].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.TORQUE_MAX].SetValue(_decimalConverter.Convert, value);
        }
        public decimal TorqueFinalTarget
        {
            get => RevisionsByFields[2][(int)DataFields.TORQUE_FINAL_TARGET].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.TORQUE_FINAL_TARGET].SetValue(_decimalConverter.Convert, value);
        }
        public int MinAngle
        {
            get => RevisionsByFields[2][(int)DataFields.ANGLE_MIN].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.ANGLE_MIN].SetValue(_intConverter.Convert, value);
        }
        public int MaxAngle
        {
            get => RevisionsByFields[2][(int)DataFields.ANGLE_MAX].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.ANGLE_MAX].SetValue(_intConverter.Convert, value);
        }
        public int AngleFinalTarget
        {
            get => RevisionsByFields[2][(int)DataFields.FINAL_ANGLE_TARGET].GetValue(_intConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.FINAL_ANGLE_TARGET].SetValue(_intConverter.Convert, value);
        }
        public decimal FirstTarget
        {
            get => RevisionsByFields[2][(int)DataFields.FIRST_TARGET].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.FIRST_TARGET].SetValue(_decimalConverter.Convert, value);
        }
        public decimal StartFinalAngle
        {
            get => RevisionsByFields[2][(int)DataFields.START_FINAL_ANGLE].GetValue(_decimalConverter.Convert);
            set => RevisionsByFields[2][(int)DataFields.START_FINAL_ANGLE].SetValue(_decimalConverter.Convert, value);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ackFlag">0=Ack needed, 1=No Ack needed (Default = 1)</param>
        /// <param name="revision">Range: 000-002</param>
        public MID_0015(int? ackFlag = 1, int revision = LAST_REVISION) : base(MID, revision, ackFlag)
        {
            _intConverter = new Int32Converter();
            _datetimeConverter = new DateConverter();
            _decimalConverter = new DecimalTrucatedConverter(2);
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="parameterSetId">Three ASCII digits, range 000-999</param>
        /// <param name="lastChangeInParameterSet">19 ASCII characters. YYYY-MM-DD:HH:MM:SS</param>
        /// <param name="ackFlag">0=Ack needed, 1=No Ack needed (Default = 1)</param>
        /// <param name="revision">Range: 000-002</param>
        public MID_0015(int parameterSetId, DateTime lastChangeInParameterSet, int? ackFlag = 1, int revision = 1) 
            : this(ackFlag, revision)
        {
            ParameterSetId = parameterSetId;
            LastChangeInParameterSet = lastChangeInParameterSet;
        }

        /// <summary>
        ///  Revision 2 Constructor
        /// </summary>
        /// <param name="parameterSetId">Three ASCII digits, range 000-999</param>
        /// <param name="parameterSetName">25 ASCII characters. Right padded with space if name is less than 25 characters.</param>
        /// <param name="lastChangeInParameterSet">19 ASCII characters. YYYY-MM-DD:HH:MM:SS</param>
        /// <param name="rotationDirection">1=CW (Clockwise), 2=CCW (Counter Clockwise)</param>
        /// <param name="batchSize">2 ASCII digits, range 00-99</param>
        /// <param name="torqueMin">The torque min limit is multiplied by 100 and sent as an integer (2 decimals truncated). It is six bytes long and is specified by six ASCII digits.</param>
        /// <param name="torqueMax">The torque max limit is multiplied by 100 and sent as an integer (2 decimals truncated. It is six bytes long and is specified by six ASCII digits.</param>
        /// <param name="torqueFinalTarget">The torque final target is multiplied by 100 and sent as an integer(2 decimals truncated). It is six bytes long and is specified by six ASCII digits.</param>
        /// <param name="angleMin">The angle min value is five bytes long and is specified by five ASCII digits.Range: 00000-99999.</param>
        /// <param name="angleMax">The angle max value is five bytes long and is specified by five ASCII digits.Range: 00000-99999.</param>
        /// <param name="finalAngleTarget">The target angle is specified in degrees. 5 ASCII digits.Range: 00000-99999.</param>
        /// <param name="firstTarget">The torque first target is multiplied by 100 and sent as an integer (2 decimals truncated). It is six bytes long and is specified by six ASCII digits.</param>
        /// <param name="startFinalAngle">The start final angle is the torque to reach the snug level.The start final angle is multiplied by 100 and sent as an integer (2 decimals truncated). It is six bytes long and is specified by six ASCII digits.</param>
        /// <param name="ackFlag">0=Ack needed, 1=No Ack needed (Default = 1)</param>
        /// <param name="revision">Range: 000-002 (Default = 2)</param>
        public MID_0015(int parameterSetId, string parameterSetName, DateTime lastChangeInParameterSet, RotationDirection rotationDirection, int batchSize,
            decimal torqueMin, decimal torqueMax, decimal torqueFinalTarget, int angleMin, int angleMax, int finalAngleTarget, decimal firstTarget, decimal startFinalAngle,
            int? ackFlag = 1, int revision = 2) : this(parameterSetId, lastChangeInParameterSet, ackFlag, revision)
        {
            ParameterSetName = parameterSetName;
            RotationDirection = rotationDirection;
            BatchSize = batchSize;
            MinTorque = torqueMin;
            MaxTorque = torqueMax;
            TorqueFinalTarget = torqueFinalTarget;
            MinAngle = angleMin;
            MaxAngle = angleMax;
            AngleFinalTarget = finalAngleTarget;
            FirstTarget = firstTarget;
            StartFinalAngle = startFinalAngle;
        }

        internal MID_0015(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string BuildPackage()
        {
            if (HeaderData.Revision == 2)
            {
                RevisionsByFields[1][(int)DataFields.PARAMETER_SET_ID].Index = 20;
                RevisionsByFields[1][(int)DataFields.LAST_CHANGE_IN_PARAMETER_SET].Index = 52;
                RevisionsByFields[1][(int)DataFields.PARAMETER_SET_ID].HasPrefix = RevisionsByFields[1][(int)DataFields.LAST_CHANGE_IN_PARAMETER_SET].HasPrefix = true;
            }

            return base.BuildPackage();
        }

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);
                if(HeaderData.Revision == 2)
                {
                    RevisionsByFields[1][(int)DataFields.PARAMETER_SET_ID].Index = 20;
                    RevisionsByFields[1][(int)DataFields.LAST_CHANGE_IN_PARAMETER_SET].Index = 52;
                    RevisionsByFields[1][(int)DataFields.PARAMETER_SET_ID].HasPrefix = RevisionsByFields[1][(int)DataFields.LAST_CHANGE_IN_PARAMETER_SET].HasPrefix = true;
                }
                ProcessDataFields(package);
                return this;
            }

            return NextTemplate.Parse(package);
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.LAST_CHANGE_IN_PARAMETER_SET, 23, 19, false)
                            }
                },
                {
                    2, new  List<DataField>()
                            {
                                new DataField((int)DataFields.PARAMETER_SET_NAME, 25, 25, ' '),
                                new DataField((int)DataFields.ROTATION_DIRECTION, 73, 1),
                                new DataField((int)DataFields.BATCH_SIZE, 76, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_MIN, 80, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_MAX, 88, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_FINAL_TARGET, 96, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE_MIN, 104, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE_MAX, 110, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.FINAL_ANGLE_TARGET, 117, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.FIRST_TARGET, 124, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.START_FINAL_ANGLE, 132, 6, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                }
            };
        }
        
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

        public enum DataFields
        {
            PARAMETER_SET_ID,
            LAST_CHANGE_IN_PARAMETER_SET,
            //Rev 2
            PARAMETER_SET_NAME,
            ROTATION_DIRECTION,
            BATCH_SIZE,
            TORQUE_MIN,
            TORQUE_MAX,
            TORQUE_FINAL_TARGET,
            ANGLE_MIN,
            ANGLE_MAX,
            FINAL_ANGLE_TARGET,
            FIRST_TARGET,
            START_FINAL_ANGLE
        }
    }
}
