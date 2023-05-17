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
            get => GetField(Header.Revision, (int)DataFields.ParameterSetId).GetValue(_intConverter.Convert);
            set => GetField(Header.Revision, (int)DataFields.ParameterSetId).SetValue(_intConverter.Convert, value);
        }
        public DateTime LastChangeInParameterSet
        {
            get => GetField(Header.Revision, (int)DataFields.LastChangeInParameterSet).GetValue(_datetimeConverter.Convert);
            set => GetField(Header.Revision, (int)DataFields.LastChangeInParameterSet).SetValue(_datetimeConverter.Convert, value);
        }
        //Rev 2
        public string ParameterSetName
        {
            get => GetField(2, (int)DataFields.ParameterSetName).Value;
            set => GetField(2, (int)DataFields.ParameterSetName).SetValue(value);
        }
        public RotationDirection RotationDirection
        {
            get => (RotationDirection)GetField(2, (int)DataFields.RotationDirection).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.RotationDirection).SetValue(_intConverter.Convert, (int)value);
        }
        public int BatchSize
        {
            get => GetField(2, (int)DataFields.BatchSize).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.BatchSize).SetValue(_intConverter.Convert, value);
        }
        public decimal MinTorque
        {
            get => GetField(2, (int)DataFields.TorqueMin).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.TorqueMin).SetValue(_decimalConverter.Convert, value);
        }
        public decimal MaxTorque
        {
            get => GetField(2, (int)DataFields.TorqueMax).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.TorqueMax).SetValue(_decimalConverter.Convert, value);
        }
        public decimal TorqueFinalTarget
        {
            get => GetField(2, (int)DataFields.TorqueFinalTarget).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.TorqueFinalTarget).SetValue(_decimalConverter.Convert, value);
        }
        public int MinAngle
        {
            get => GetField(2, (int)DataFields.AngleMin).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.AngleMin).SetValue(_intConverter.Convert, value);
        }
        public int MaxAngle
        {
            get => GetField(2, (int)DataFields.AngleMax).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.AngleMax).SetValue(_intConverter.Convert, value);
        }
        public int AngleFinalTarget
        {
            get => GetField(2, (int)DataFields.FinalAngleTarget).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.FinalAngleTarget).SetValue(_intConverter.Convert, value);
        }
        public decimal FirstTarget
        {
            get => GetField(2, (int)DataFields.FirstTarget).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.FirstTarget).SetValue(_decimalConverter.Convert, value);
        }
        public decimal StartFinalAngle
        {
            get => GetField(2, (int)DataFields.StartFinalAngle).GetValue(_decimalConverter.Convert);
            set => GetField(2, (int)DataFields.StartFinalAngle).SetValue(_decimalConverter.Convert, value);
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
                                new DataField((int)DataFields.ParameterSetId, 20, 3, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.LastChangeInParameterSet, 23, 19, false)
                            }
                },
                {
                    2, new  List<DataField>()
                            {
                                new DataField((int)DataFields.ParameterSetId, 20, 3, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ParameterSetName, 25, 25, ' '),
                                new DataField((int)DataFields.LastChangeInParameterSet, 52, 19),
                                new DataField((int)DataFields.RotationDirection, 73, 1),
                                new DataField((int)DataFields.BatchSize, 76, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TorqueMin, 80, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TorqueMax, 88, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TorqueFinalTarget, 96, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.AngleMin, 104, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.AngleMax, 111, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.FinalAngleTarget, 118, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.FirstTarget, 125, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.StartFinalAngle, 133, 6, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                }
            };
        }

        protected enum DataFields
        {
            ParameterSetId,
            LastChangeInParameterSet,
            //Rev 2
            ParameterSetName,
            RotationDirection,
            BatchSize,
            TorqueMin,
            TorqueMax,
            TorqueFinalTarget,
            AngleMin,
            AngleMax,
            FinalAngleTarget,
            FirstTarget,
            StartFinalAngle
        }
    }
}
