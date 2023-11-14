using System;
using System.Collections.Generic;

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
        public const int MID = 15;

        public int ParameterSetId
        {
            get => GetField(Header.Revision, (int)DataFields.ParameterSetId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.Revision, (int)DataFields.ParameterSetId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime LastChangeInParameterSet
        {
            get => GetField(Header.Revision, (int)DataFields.LastChangeInParameterSet).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(Header.Revision, (int)DataFields.LastChangeInParameterSet).SetValue(OpenProtocolConvert.ToString, value);
        }
        //Rev 2
        public string ParameterSetName
        {
            get => GetField(2, (int)DataFields.ParameterSetName).Value;
            set => GetField(2, (int)DataFields.ParameterSetName).SetValue(value);
        }
        public RotationDirection RotationDirection
        {
            get => (RotationDirection)GetField(2, (int)DataFields.RotationDirection).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.RotationDirection).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public int BatchSize
        {
            get => GetField(2, (int)DataFields.BatchSize).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.BatchSize).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal MinTorque
        {
            get => GetField(2, (int)DataFields.TorqueMin).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.TorqueMin).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal MaxTorque
        {
            get => GetField(2, (int)DataFields.TorqueMax).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.TorqueMax).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal TorqueFinalTarget
        {
            get => GetField(2, (int)DataFields.TorqueFinalTarget).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.TorqueFinalTarget).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public int MinAngle
        {
            get => GetField(2, (int)DataFields.AngleMin).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.AngleMin).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int MaxAngle
        {
            get => GetField(2, (int)DataFields.AngleMax).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.AngleMax).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int AngleFinalTarget
        {
            get => GetField(2, (int)DataFields.FinalAngleTarget).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.FinalAngleTarget).SetValue(OpenProtocolConvert.ToString, value);
        }
        public decimal FirstTarget
        {
            get => GetField(2, (int)DataFields.FirstTarget).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.FirstTarget).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }
        public decimal StartFinalAngle
        {
            get => GetField(2, (int)DataFields.StartFinalAngle).GetValue(OpenProtocolConvert.ToTruncatedDecimal);
            set => GetField(2, (int)DataFields.StartFinalAngle).SetValue(OpenProtocolConvert.TruncatedDecimalToString, value);
        }

        public Mid0015() : this(DEFAULT_REVISION)
        {

        }

        public Mid0015(Header header) : base(header)
        {
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
            return BuildHeader() + base.Pack(Header.Revision, ref index);
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            Header.Revision = Header.Revision > 0 ? Header.Revision : 1;
            ProcessDataFields(Header.Revision, package);
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new((int)DataFields.ParameterSetId, 20, 3, '0', PaddingOrientation.LeftPadded, false),
                                new((int)DataFields.LastChangeInParameterSet, 23, 19, false)
                            }
                },
                {
                    2, new  List<DataField>()
                            {
                                new((int)DataFields.ParameterSetId, 20, 3, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.ParameterSetName, 25, 25, ' '),
                                new((int)DataFields.LastChangeInParameterSet, 52, 19),
                                new((int)DataFields.RotationDirection, 73, 1),
                                new((int)DataFields.BatchSize, 76, 2, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.TorqueMin, 80, 6, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.TorqueMax, 88, 6, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.TorqueFinalTarget, 96, 6, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.AngleMin, 104, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.AngleMax, 111, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.FinalAngleTarget, 118, 5, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.FirstTarget, 125, 6, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.StartFinalAngle, 133, 6, '0', PaddingOrientation.LeftPadded)
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
