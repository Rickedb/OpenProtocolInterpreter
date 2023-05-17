using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Multi-spindle status
    /// <para>
    ///      The multi-spindle status is sent after each sync tightening. The multiple status contains the common
    ///      status of the multiple as well as the individual status of each spindle.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0092"/> Multi-spindle status acknowledge</para>
    /// </summary>
    public class Mid0091 : Mid, IMultiSpindle, IController, IAcknowledgeable<Mid0092>
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        private readonly IValueConverter<IEnumerable<SpindleStatus>> _spindlesStatusConverter;
        public const int MID = 91;

        public int NumberOfSpindles
        {
            get => GetField(1, (int)DataFields.NumberOfSpindles).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.NumberOfSpindles).SetValue(_intConverter.Convert, value);
        }
        public int SyncTighteningId
        {
            get => GetField(1, (int)DataFields.SyncTighteningId).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.SyncTighteningId).SetValue(_intConverter.Convert, value);
        }
        public DateTime Time
        {
            get => GetField(1, (int)DataFields.Time).GetValue(_dateConverter.Convert);
            set => GetField(1, (int)DataFields.Time).SetValue(_dateConverter.Convert, value);
        }
        public bool SyncOverallStatus
        {
            get => GetField(1, (int)DataFields.SyncOverallStatus).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.SyncOverallStatus).SetValue(_boolConverter.Convert, value);
        }
        public List<SpindleStatus> SpindlesStatus { get; set; }

        public Mid0091() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0091(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
            _dateConverter = new DateConverter();
            _spindlesStatusConverter = new SpindleStatusConverter(_intConverter, _boolConverter);
            if (SpindlesStatus == null)
                SpindlesStatus = new List<SpindleStatus>();
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.SpindleStatus).Value = _spindlesStatusConverter.Convert(SpindlesStatus);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            var spindleField = GetField(1, (int)DataFields.SpindleStatus);
            spindleField.Size = Header.Length - spindleField.Index - 2;
            base.Parse(package);
            SpindlesStatus = _spindlesStatusConverter.Convert(spindleField.Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.NumberOfSpindles, 20, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.SyncTighteningId, 24, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.Time, 31, 19),
                                new DataField((int)DataFields.SyncOverallStatus, 52, 1),
                                new DataField((int)DataFields.SpindleStatus, 55, 5)
                            }
                }
            };
        }

        protected enum DataFields
        {
            NumberOfSpindles,
            SyncTighteningId,
            Time,
            SyncOverallStatus,
            SpindleStatus
        }
    }
}
