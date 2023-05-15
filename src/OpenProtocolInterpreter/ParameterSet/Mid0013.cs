using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<decimal> _decimalConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        public const int MID = 13;

        public int ParameterSetId
        {
            get => GetField(1, (int)DataFields.PARAMETER_SET_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.PARAMETER_SET_ID).SetValue(_intConverter.Convert, value);
        }
        public string ParameterSetName
        {
            get => GetField(1, (int)DataFields.PARAMETER_SET_NAME).Value;
            set => GetField(1, (int)DataFields.PARAMETER_SET_NAME).SetValue(value);
        }
        public RotationDirection RotationDirection
        {
            get => (RotationDirection)GetField(1, (int)DataFields.ROTATION_DIRECTION).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.ROTATION_DIRECTION).SetValue(_intConverter.Convert, (int)value);
        }
        public int BatchSize
        {
            get => GetField(1, (int)DataFields.BATCH_SIZE).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.BATCH_SIZE).SetValue(_intConverter.Convert, value);
        }
        public decimal MinTorque
        {
            get => GetField(1, (int)DataFields.MIN_TORQUE).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.MIN_TORQUE).SetValue(_decimalConverter.Convert, value);
        }
        public decimal MaxTorque
        {
            get => GetField(1, (int)DataFields.MAX_TORQUE).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.MAX_TORQUE).SetValue(_decimalConverter.Convert, value);
        }
        public decimal TorqueFinalTarget
        {
            get => GetField(1, (int)DataFields.TORQUE_FINAL_TARGET).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.TORQUE_FINAL_TARGET).SetValue(_decimalConverter.Convert, value);
        }
        public int MinAngle
        {
            get => GetField(1, (int)DataFields.MIN_ANGLE).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.MIN_ANGLE).SetValue(_intConverter.Convert, value);
        }
        public int MaxAngle
        {
            get => GetField(1, (int)DataFields.MAX_ANGLE).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.MAX_ANGLE).SetValue(_intConverter.Convert, value);
        }
        public int AngleFinalTarget
        {
            get => GetField(1, (int)DataFields.ANGLE_FINAL_TARGET).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.ANGLE_FINAL_TARGET).SetValue(_intConverter.Convert, value);
        }
        //Rev 2
        public decimal FirstTarget
        {
            get => GetField(2, (int)DataFields.FIRST_TARGET).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.FIRST_TARGET).SetValue(_decimalConverter.Convert, value);
        }
        public decimal StartFinalAngle
        {
            get => GetField(2, (int)DataFields.START_FINAL_TARGET).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.START_FINAL_TARGET).SetValue(_decimalConverter.Convert, value);
        }
        //Rev 5
        public DateTime LastChangeInParameterSet
        {
            get => GetField(5, (int)DataFields.LAST_CHANGE_IN_PARAMETER_SET).GetValue(_dateConverter.Convert);
            set => GetField(5, (int)DataFields.LAST_CHANGE_IN_PARAMETER_SET).SetValue(_dateConverter.Convert, value);
        }

        public Mid0013() : this(DEFAULT_REVISION)
        {

        }

        public Mid0013(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            _decimalConverter = new DecimalTrucatedConverter(2);
            _dateConverter = new DateConverter();
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
                },
                {
                    5, new  List<DataField>()
                            {
                                new DataField((int)DataFields.LAST_CHANGE_IN_PARAMETER_SET, 120, 19),
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
            START_FINAL_TARGET,
            //Rev 5
            LAST_CHANGE_IN_PARAMETER_SET
        }
    }
}
