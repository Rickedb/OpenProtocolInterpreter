using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Parameter set selected
    /// <para>
    ///     A new parameter set is selected in the controller. 
    ///     The message includes the ID of the parameter set selected as well as the date and time of the 
    ///     last change in the parameter set settings. This message is also sent as an immediate response to <see cref="Mid0014"/> 
    ///     Parameter set selected subscribe.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0016"/> New parameter set selected acknowledge</para>
    /// </summary>
    public class Mid0015 : Mid, IParameterSet, IController, IAcknowledgeable<Mid0016>
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<decimal> _decimalConverter;
        private readonly IValueConverter<DateTime> _datetimeConverter;
        public const int MID = 15;

        public int ParameterSetId
        {
            get => GetField(Header.Revision, (int)DataFields.PARAMETER_SET_ID).GetValue(_intConverter.Convert);
            set => GetField(Header.Revision, (int)DataFields.PARAMETER_SET_ID).SetValue(_intConverter.Convert, value);
        }
        public DateTime LastChangeInParameterSet
        {
            get => GetField(Header.Revision, (int)DataFields.LAST_CHANGE_IN_PARAMETER_SET).GetValue(_datetimeConverter.Convert);
            set => GetField(Header.Revision, (int)DataFields.LAST_CHANGE_IN_PARAMETER_SET).SetValue(_datetimeConverter.Convert, value);
        }
        //Rev 2
        public string ParameterSetName
        {
            get => GetField(2, (int)DataFields.PARAMETER_SET_NAME).Value;
            set => GetField(2, (int)DataFields.PARAMETER_SET_NAME).SetValue(value);
        }
        public RotationDirection RotationDirection
        {
            get => (RotationDirection)GetField(2, (int)DataFields.ROTATION_DIRECTION).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.ROTATION_DIRECTION).SetValue(_intConverter.Convert, (int)value);
        }
        public int BatchSize
        {
            get => GetField(2, (int)DataFields.BATCH_SIZE).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.BATCH_SIZE).SetValue(_intConverter.Convert, value);
        }
        public decimal MinTorque
        {
            get => GetField(2, (int)DataFields.TORQUE_MIN).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.TORQUE_MIN).SetValue(_decimalConverter.Convert, value);
        }
        public decimal MaxTorque
        {
            get => GetField(2, (int)DataFields.TORQUE_MAX).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.TORQUE_MAX).SetValue(_decimalConverter.Convert, value);
        }
        public decimal TorqueFinalTarget
        {
            get => GetField(2, (int)DataFields.TORQUE_FINAL_TARGET).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.TORQUE_FINAL_TARGET).SetValue(_decimalConverter.Convert, value);
        }
        public int MinAngle
        {
            get => GetField(2, (int)DataFields.ANGLE_MIN).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.ANGLE_MIN).SetValue(_intConverter.Convert, value);
        }
        public int MaxAngle
        {
            get => GetField(2, (int)DataFields.ANGLE_MAX).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.ANGLE_MAX).SetValue(_intConverter.Convert, value);
        }
        public int AngleFinalTarget
        {
            get => GetField(2, (int)DataFields.FINAL_ANGLE_TARGET).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.FINAL_ANGLE_TARGET).SetValue(_intConverter.Convert, value);
        }
        public decimal FirstTarget
        {
            get => GetField(2, (int)DataFields.FIRST_TARGET).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.FIRST_TARGET).SetValue(_decimalConverter.Convert, value);
        }
        public decimal StartFinalAngle
        {
            get => GetField(2, (int)DataFields.START_FINAL_ANGLE).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.START_FINAL_ANGLE).SetValue(_decimalConverter.Convert, value);
        }

        public Mid0015() : this(DEFAULT_REVISION)
        {

        }

        public Mid0015(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            _datetimeConverter = new DateConverter();
            _decimalConverter = new DecimalTrucatedConverter(2);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="revision">Range: 000-002</param>
        public Mid0015(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        protected override string BuildHeader()
        {
            Header.Length = 20;
            foreach (var dataField in RevisionsByFields[Header.Revision])
                Header.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;

            return Header.ToString();
        }

        public override string Pack()
        {
            int index = 1;
            return BuildHeader() + base.Pack(RevisionsByFields[Header.Revision], ref index);
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            Header.Revision = Header.Revision > 0 ? Header.Revision : 1;
            ProcessDataFields(RevisionsByFields[Header.Revision], package);
            return this;
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
                                new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.PARAMETER_SET_NAME, 25, 25, ' '),
                                new DataField((int)DataFields.LAST_CHANGE_IN_PARAMETER_SET, 52, 19),
                                new DataField((int)DataFields.ROTATION_DIRECTION, 73, 1),
                                new DataField((int)DataFields.BATCH_SIZE, 76, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_MIN, 80, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_MAX, 88, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_FINAL_TARGET, 96, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE_MIN, 104, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE_MAX, 111, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.FINAL_ANGLE_TARGET, 118, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.FIRST_TARGET, 125, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.START_FINAL_ANGLE, 133, 6, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                }
            };
        }

        protected enum DataFields
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
