using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Multi-spindle result
    /// <para>
    ///     The multi-spindle result is sent after each sync tightening and if it is subscribed. The multiple results
    ///     contain the common status of the multiple as well as the individual tightening result(torque and angle)
    ///     of each spindle.
    /// </para>
    /// <para>
    ///     This telegram is also used for PowerMACS systems running a Press.The layout of the telegram is
    ///     exactly the same but some of the fields have slightly different definitions.The fields for Torque are
    ///     used for Force values and the fields for Angle are used for Stroke values. A press system always uses
    ///     revision 4 or higher of the telegram.
    /// </para>    
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0102"/> Multi-spindle result acknowledge</para>
    /// </summary>
    public class Mid0101 : Mid, IMultiSpindle, IController, IAcknowledgeable<Mid0102>
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<decimal> _decimalConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        private readonly IValueConverter<IEnumerable<SpindleOrPressStatus>> _spindleOrPressStatusListConverter;

        public const int MID = 101;

        public int NumberOfSpindlesOrPresses
        {
            get => GetField(1, (int)DataFields.NumberOfSpindlesOrPresses).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.NumberOfSpindlesOrPresses).SetValue(_intConverter.Convert, value);
        }
        public string VinNumber
        {
            get => GetField(1, (int)DataFields.VinNumber).Value;
            set => GetField(1, (int)DataFields.VinNumber).SetValue(value);
        }
        public int JobId
        {
            get => GetField(1, (int)DataFields.JobId).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JobId).SetValue(_intConverter.Convert, value);
        }
        public int ParameterSetId
        {
            get => GetField(1, (int)DataFields.ParameterSetId).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.ParameterSetId).SetValue(_intConverter.Convert, value);
        }
        public int BatchSize
        {
            get => GetField(1, (int)DataFields.BatchSize).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.BatchSize).SetValue(_intConverter.Convert, value);
        }
        public int BatchCounter
        {
            get => GetField(1, (int)DataFields.BatchCounter).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.BatchCounter).SetValue(_intConverter.Convert, value);
        }
        public BatchStatus BatchStatus
        {
            get => (BatchStatus)GetField(1, (int)DataFields.BatchStatus).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.BatchStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public decimal TorqueOrForceMinLimit
        {
            get => GetField(1, (int)DataFields.TorqueOrForceMinLimit).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.TorqueOrForceMinLimit).SetValue(_decimalConverter.Convert, value);
        }
        public decimal TorqueOrForceMaxLimit
        {
            get => GetField(1, (int)DataFields.TorqueOrForceMaxLimit).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.TorqueOrForceMaxLimit).SetValue(_decimalConverter.Convert, value);
        }
        public decimal TorqueOrForceFinalTarget
        {
            get => GetField(1, (int)DataFields.TorqueOrForceFinalTarget).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.TorqueOrForceFinalTarget).SetValue(_decimalConverter.Convert, value);
        }
        public decimal AngleOrStrokeMinLimit
        {
            get => GetField(1, (int)DataFields.AngleOrStrokeMinLimit).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.AngleOrStrokeMinLimit).SetValue(_decimalConverter.Convert, value);
        }
        public decimal AngleOrStrokeMaxLimit
        {
            get => GetField(1, (int)DataFields.AngleOrStrokeMaxLimit).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.AngleOrStrokeMaxLimit).SetValue(_decimalConverter.Convert, value);
        }
        public decimal FinalAngleOrStrokeTarget
        {
            get => GetField(1, (int)DataFields.FinalAngleOrStrokeTarget).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.FinalAngleOrStrokeTarget).SetValue(_decimalConverter.Convert, value);
        }
        public DateTime LastChangeInParameterSet
        {
            get => GetField(1, (int)DataFields.LastChangeInParameterSet).GetValue(_dateConverter.Convert);
            set => GetField(1, (int)DataFields.LastChangeInParameterSet).SetValue(_dateConverter.Convert, value);
        }
        public DateTime TimeStamp
        {
            get => GetField(1, (int)DataFields.Timestamp).GetValue(_dateConverter.Convert);
            set => GetField(1, (int)DataFields.Timestamp).SetValue(_dateConverter.Convert, value);
        }
        public int SyncTighteningId
        {
            get => GetField(1, (int)DataFields.SyncTighteningId).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.SyncTighteningId).SetValue(_intConverter.Convert, value);
        }
        public bool SyncOverallStatus
        {
            get => GetField(1, (int)DataFields.SyncOverallStatus).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.SyncOverallStatus).SetValue(_boolConverter.Convert, value);
        }
        public List<SpindleOrPressStatus> SpindlesOrPressesStatus { get; set; }
        public SystemSubType SystemSubType
        {
            get => (SystemSubType)GetField(4, (int)DataFields.SystemSubType).GetValue(_intConverter.Convert);
            set => GetField(4, (int)DataFields.SystemSubType).SetValue(_intConverter.Convert, (int)value);
        }
        public int JobSequenceNumber
        {
            get => GetField(5, (int)DataFields.JobSequenceNumber).GetValue(_intConverter.Convert);
            set => GetField(5, (int)DataFields.JobSequenceNumber).SetValue(_intConverter.Convert, value);
        }

        public Mid0101() : this(DEFAULT_REVISION)
        {

        }

        public Mid0101(Header header) : base(header)
        {
            _boolConverter = new BoolConverter();
            _intConverter = new Int32Converter();
            _dateConverter = new DateConverter();
            _decimalConverter = new DecimalTrucatedConverter(2);
            _spindleOrPressStatusListConverter = new SpindleOrPressStatusListConverter(_intConverter, _boolConverter, _decimalConverter);
        }

        public Mid0101(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        public override string Pack()
        {
            var spindesOrPressesStatusField = GetField(1, (int)DataFields.SpindesOrPressesStatus);
            spindesOrPressesStatusField.Size = SpindlesOrPressesStatus.Count * 18;
            spindesOrPressesStatusField.Value = _spindleOrPressStatusListConverter.Convert(SpindlesOrPressesStatus);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            var spindleOrPressesField = GetField(1, (int)DataFields.NumberOfSpindlesOrPresses);
            int spindleOrPresses = _intConverter.Convert(package.Substring(spindleOrPressesField.Index + 2, spindleOrPressesField.Size));
            var spindesOrPressesStatusField = GetField(1, (int)DataFields.SpindesOrPressesStatus);
            spindesOrPressesStatusField.Size = spindleOrPresses * 18;
            if(Header.Revision > 3)
            {
                var systemSubTypeField = GetField(4, (int)DataFields.SystemSubType);
                systemSubTypeField.Index = spindesOrPressesStatusField.Index + spindesOrPressesStatusField.Size + 2;
                if(Header.Revision > 4)
                {
                    GetField(5, (int)DataFields.JobSequenceNumber).Index = systemSubTypeField.Index + systemSubTypeField.Size + 2;
                }
            }
            ProcessDataFields(package);
            SpindlesOrPressesStatus = _spindleOrPressStatusListConverter.Convert(spindesOrPressesStatusField.Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.NumberOfSpindlesOrPresses, 20, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.VinNumber, 24, 25, ' '),
                                new DataField((int)DataFields.JobId, 51, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ParameterSetId, 55, 3, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.BatchSize, 60, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.BatchCounter, 66, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.BatchStatus, 72, 1),
                                new DataField((int)DataFields.TorqueOrForceMinLimit, 75, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TorqueOrForceMaxLimit, 83, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.TorqueOrForceFinalTarget, 91, 6, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.AngleOrStrokeMinLimit, 99, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.AngleOrStrokeMaxLimit, 106, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.FinalAngleOrStrokeTarget, 113, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.LastChangeInParameterSet, 120, 19),
                                new DataField((int)DataFields.Timestamp, 141, 19),
                                new DataField((int)DataFields.SyncTighteningId, 162, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.SyncOverallStatus, 169, 1),
                                new DataField((int)DataFields.SpindesOrPressesStatus, 172, 0)
                            }
                },
                {
                    4, new List<DataField>()
                            {
                                new DataField((int)DataFields.SystemSubType, 0, 3, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                },
                {
                    5, new List<DataField>()
                            {
                                new DataField((int)DataFields.JobSequenceNumber, 0, 5, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                }
            };
        }

        protected enum DataFields
        {
            NumberOfSpindlesOrPresses,
            VinNumber,
            JobId,
            ParameterSetId,
            BatchSize,
            BatchCounter,
            BatchStatus,
            TorqueOrForceMinLimit,
            TorqueOrForceMaxLimit,
            TorqueOrForceFinalTarget,
            AngleOrStrokeMinLimit,
            AngleOrStrokeMaxLimit,
            FinalAngleOrStrokeTarget,
            Target,
            LastChangeInParameterSet,
            Timestamp,
            SyncTighteningId,
            SyncOverallStatus,
            SpindesOrPressesStatus,
            //Rev 4
            SystemSubType,
            //Rev 5
            JobSequenceNumber
        }
    }
}
