using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Multi-spindle result
    /// Description:
    ///     The multi-spindle result is sent after each sync tightening and if it is subscribed. The multiple results
    ///     contain the common status of the multiple as well as the individual tightening result(torque and angle)
    ///     of each spindle.
    ///     This telegram is also used for PowerMACS systems running a Press.The layout of the telegram is
    ///     exactly the same but some of the fields have slightly different definitions.The fields for Torque are
    ///     used for Force values and the fields for Angle are used for Stroke values. A press system always uses
    ///     revision 4 or higher of the telegram.
    /// Message sent by: Controller
    /// Answer: MID 0102 Multi-spindle result acknowledge
    /// </summary>
    public class Mid0101 : Mid, IMultiSpindle, IController
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<decimal> _decimalConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        private readonly IValueConverter<IEnumerable<SpindleOrPressStatus>> _spindleOrPressStatusListConverter;

        private const int LAST_REVISION = 5;
        public const int MID = 101;

        public int NumberOfSpindlesOrPresses
        {
            get => GetField(1, (int)DataFields.NUMBER_OF_SPINDLES_OR_PRESSES).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.NUMBER_OF_SPINDLES_OR_PRESSES).SetValue(_intConverter.Convert, value);
        }
        public string VinNumber
        {
            get => GetField(1, (int)DataFields.VIN_NUMBER).Value;
            set => GetField(1, (int)DataFields.VIN_NUMBER).SetValue(value);
        }
        public int JobId
        {
            get => GetField(1, (int)DataFields.JOB_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_ID).SetValue(_intConverter.Convert, value);
        }
        public int ParameterSetId
        {
            get => GetField(1, (int)DataFields.PARAMETER_SET_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.PARAMETER_SET_ID).SetValue(_intConverter.Convert, value);
        }
        public int BatchSize
        {
            get => GetField(1, (int)DataFields.BATCH_SIZE).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.BATCH_SIZE).SetValue(_intConverter.Convert, value);
        }
        public int BatchCounter
        {
            get => GetField(1, (int)DataFields.BATCH_COUNTER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.BATCH_COUNTER).SetValue(_intConverter.Convert, value);
        }
        public BatchStatus BatchStatus
        {
            get => (BatchStatus)GetField(1, (int)DataFields.BATCH_STATUS).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.BATCH_STATUS).SetValue(_intConverter.Convert, (int)value);
        }
        public decimal TorqueOrForceMinLimit
        {
            get => GetField(1, (int)DataFields.TORQUE_OR_FORCE_MIN_LIMIT).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.TORQUE_OR_FORCE_MIN_LIMIT).SetValue(_decimalConverter.Convert, value);
        }
        public decimal TorqueOrForceMaxLimit
        {
            get => GetField(1, (int)DataFields.TORQUE_OR_FORCE_MAX_LIMIT).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.TORQUE_OR_FORCE_MAX_LIMIT).SetValue(_decimalConverter.Convert, value);
        }
        public decimal TorqueOrForceFinalTarget
        {
            get => GetField(1, (int)DataFields.TORQUE_OR_FORCE_FINAL_TARGET).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.TORQUE_OR_FORCE_FINAL_TARGET).SetValue(_decimalConverter.Convert, value);
        }
        public decimal AngleOrStrokeMinLimit
        {
            get => GetField(1, (int)DataFields.ANGLE_OR_STROKE_MIN_LIMIT).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.ANGLE_OR_STROKE_MIN_LIMIT).SetValue(_decimalConverter.Convert, value);
        }
        public decimal AngleOrStrokeMaxLimit
        {
            get => GetField(1, (int)DataFields.ANGLE_OR_STROKE_MAX_LIMIT).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.ANGLE_OR_STROKE_MAX_LIMIT).SetValue(_decimalConverter.Convert, value);
        }
        public decimal FinalAngleOrStrokeTarget
        {
            get => GetField(1, (int)DataFields.FINAL_ANGLE_OR_STROKE_TARGET).GetValue(_decimalConverter.Convert);
            set => GetField(1, (int)DataFields.FINAL_ANGLE_OR_STROKE_TARGET).SetValue(_decimalConverter.Convert, value);
        }
        public DateTime LastChangeInParameterSet
        {
            get => GetField(1, (int)DataFields.LAST_CHANGE_IN_PARAMETER_SET).GetValue(_dateConverter.Convert);
            set => GetField(1, (int)DataFields.LAST_CHANGE_IN_PARAMETER_SET).SetValue(_dateConverter.Convert, value);
        }
        public DateTime TimeStamp
        {
            get => GetField(1, (int)DataFields.TIMESTAMP).GetValue(_dateConverter.Convert);
            set => GetField(1, (int)DataFields.TIMESTAMP).SetValue(_dateConverter.Convert, value);
        }
        public int SyncTighteningId
        {
            get => GetField(1, (int)DataFields.SYNC_TIGHTENING_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.SYNC_TIGHTENING_ID).SetValue(_intConverter.Convert, value);
        }
        public bool SyncOverallStatus
        {
            get => GetField(1, (int)DataFields.SYNC_OVERALL_STATUS).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.SYNC_OVERALL_STATUS).SetValue(_boolConverter.Convert, value);
        }
        public List<SpindleOrPressStatus> SpindlesOrPressesStatus { get; set; }
        public SystemSubType SystemSubType
        {
            get => (SystemSubType)GetField(4, (int)DataFields.SYSTEM_SUB_TYPE).GetValue(_intConverter.Convert);
            set => GetField(4, (int)DataFields.SYSTEM_SUB_TYPE).SetValue(_intConverter.Convert, (int)value);
        }
        public int JobSequenceNumber
        {
            get => GetField(5, (int)DataFields.JOB_SEQUENCE_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(5, (int)DataFields.JOB_SEQUENCE_NUMBER).SetValue(_intConverter.Convert, value);
        }

        public Mid0101() : this(LAST_REVISION)
        {

        }

        public Mid0101(int revision = LAST_REVISION) : base(MID, revision)
        {
            _boolConverter = new BoolConverter();
            _intConverter = new Int32Converter();
            _dateConverter = new DateConverter();
            _decimalConverter = new DecimalTrucatedConverter(2);
            _spindleOrPressStatusListConverter = new SpindleOrPressStatusListConverter(_intConverter, _boolConverter, _decimalConverter);
        }

        public override string Pack()
        {
            var spindesOrPressesStatusField = GetField(1, (int)DataFields.SPINDLES_OR_PRESSES_STATUS);
            spindesOrPressesStatusField.Size = SpindlesOrPressesStatus.Count * 18;
            spindesOrPressesStatusField.Value = _spindleOrPressStatusListConverter.Convert(SpindlesOrPressesStatus);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            HeaderData = ProcessHeader(package);
            var spindleOrPressesField = GetField(1, (int)DataFields.NUMBER_OF_SPINDLES_OR_PRESSES);
            int spindleOrPresses = _intConverter.Convert(package.Substring(spindleOrPressesField.Index + 2, spindleOrPressesField.Size));
            var spindesOrPressesStatusField = GetField(1, (int)DataFields.SPINDLES_OR_PRESSES_STATUS);
            spindesOrPressesStatusField.Size = spindleOrPresses * 18;
            if(HeaderData.Revision > 3)
            {
                var systemSubTypeField = GetField(4, (int)DataFields.SYSTEM_SUB_TYPE);
                systemSubTypeField.Index = spindesOrPressesStatusField.Index + spindesOrPressesStatusField.Size + 2;
                if(HeaderData.Revision > 4)
                {
                    GetField(5, (int)DataFields.JOB_SEQUENCE_NUMBER).Index = systemSubTypeField.Index + systemSubTypeField.Size + 2;
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
                                new DataField((int)DataFields.NUMBER_OF_SPINDLES_OR_PRESSES, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.VIN_NUMBER, 24, 25, ' '),
                                new DataField((int)DataFields.JOB_ID, 51, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.PARAMETER_SET_ID, 55, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.BATCH_SIZE, 60, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.BATCH_COUNTER, 66, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.BATCH_STATUS, 72, 1),
                                new DataField((int)DataFields.TORQUE_OR_FORCE_MIN_LIMIT, 75, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_OR_FORCE_MAX_LIMIT, 83, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_OR_FORCE_FINAL_TARGET, 91, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE_OR_STROKE_MIN_LIMIT, 99, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE_OR_STROKE_MAX_LIMIT, 106, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.FINAL_ANGLE_OR_STROKE_TARGET, 113, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.LAST_CHANGE_IN_PARAMETER_SET, 120, 19),
                                new DataField((int)DataFields.TIMESTAMP, 141, 19),
                                new DataField((int)DataFields.SYNC_TIGHTENING_ID, 162, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.SYNC_OVERALL_STATUS, 169, 1),
                                new DataField((int)DataFields.SPINDLES_OR_PRESSES_STATUS, 172, 0)
                            }
                },
                { 2, new List<DataField>() },
                { 3, new List<DataField>() },
                {
                    4, new List<DataField>()
                            {
                                new DataField((int)DataFields.SYSTEM_SUB_TYPE, 0, 3, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                },
                {
                    5, new List<DataField>()
                            {
                                new DataField((int)DataFields.JOB_SEQUENCE_NUMBER, 0, 5, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                }
            };
        }

        public enum DataFields
        {
            NUMBER_OF_SPINDLES_OR_PRESSES,
            VIN_NUMBER,
            JOB_ID,
            PARAMETER_SET_ID,
            BATCH_SIZE,
            BATCH_COUNTER,
            BATCH_STATUS,
            TORQUE_OR_FORCE_MIN_LIMIT,
            TORQUE_OR_FORCE_MAX_LIMIT,
            TORQUE_OR_FORCE_FINAL_TARGET,
            ANGLE_OR_STROKE_MIN_LIMIT,
            ANGLE_OR_STROKE_MAX_LIMIT,
            FINAL_ANGLE_OR_STROKE_TARGET,
            TARGET,
            LAST_CHANGE_IN_PARAMETER_SET,
            TIMESTAMP,
            SYNC_TIGHTENING_ID,
            SYNC_OVERALL_STATUS,
            SPINDLES_OR_PRESSES_STATUS,
            //Rev 4
            SYSTEM_SUB_TYPE,
            //Rev 5
            JOB_SEQUENCE_NUMBER
        }
    }
}
