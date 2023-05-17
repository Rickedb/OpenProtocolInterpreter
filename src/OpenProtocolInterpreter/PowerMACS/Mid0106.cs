using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// Last PowerMACS tightening result Station data
    /// <para>
    ///    This MID contains the station part and some of the Bolt data of the last result data. After this message
    ///    has been sent the integrator selects if it also wants to have the Bolt and step data.If this data is
    ///    requested, then the integrator sends the message <see cref="Mid0108"/> Last PowerMACS tightening result data
    ///    acknowledge, with the parameter Bolt Data set to TRUE. If only the station data is wanted the
    ///    parameter Bolt Data is set to FALSE.
    /// </para>
    /// <para>
    ///    This telegram is also used for Power MACS systems running a Press. The layout of the telegram is
    ///    exactly the same but some of the fields have slightly different definitions. The fields for Torque are
    ///    used for Force values and the fields for Angle are used for Stroke values. Press systems also use
    ///    different identifiers for the optional data on bolt and step level. A press system always use revision 4
    ///    or higher of the telegram
    /// </para>
    /// <para>
    ///    Note: All values that are undefined in the results will be sent as all spaces (ASCII 0x20). This will for
    ///    instance happen with the Torque Status if no measuring value for Bolt T was available for the
    ///    tightening.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0108"/> Last Power MACS tightening result data acknowledge</para>
    /// </summary>
    public class Mid0106 : Mid, IPowerMACS, IController, IAcknowledgeable<Mid0108>
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<decimal> _decimalConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        private IValueConverter<IEnumerable<BoltData>> _boltDataListConverter;
        private IValueConverter<IEnumerable<SpecialValue>> _specialValueListConverter;
        public const int MID = 106;

        public int TotalNumberOfMessages
        {
            get => GetField(1, (int)DataFields.TotalNumberOfMessages).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.TotalNumberOfMessages).SetValue(_intConverter.Convert, value);
        }
        public int MessageNumber
        {
            get => GetField(1, (int)DataFields.MessageNumber).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.MessageNumber).SetValue(_intConverter.Convert, value);
        }
        public int DataNumberSystem
        {
            get => GetField(1, (int)DataFields.DataNumberSystem).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.DataNumberSystem).SetValue(_intConverter.Convert, value);
        }
        public int StationNumber
        {
            get => GetField(1, (int)DataFields.StationNumber).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.StationNumber).SetValue(_intConverter.Convert, value);
        }
        public string StationName
        {
            get => GetField(1, (int)DataFields.StationName).Value;
            set => GetField(1, (int)DataFields.StationName).SetValue(value);
        }
        public DateTime Time
        {
            get => GetField(1, (int)DataFields.Time).GetValue(_dateConverter.Convert);
            set => GetField(1, (int)DataFields.Time).SetValue(_dateConverter.Convert, value);
        }
        public int ModeNumber
        {
            get => GetField(1, (int)DataFields.ModeNumber).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.ModeNumber).SetValue(_intConverter.Convert, value);
        }
        public string ModeName
        {
            get => GetField(1, (int)DataFields.ModeName).Value;
            set => GetField(1, (int)DataFields.ModeName).SetValue(value);
        }
        public bool SimpleStatus
        {
            get => GetField(1, (int)DataFields.SimpleStatus).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.SimpleStatus).SetValue(_boolConverter.Convert, value);
        }
        public PowerMacsStatus PMStatus
        {
            get => (PowerMacsStatus)GetField(1, (int)DataFields.PMStatus).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.PMStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public string WpId
        {
            get => GetField(1, (int)DataFields.WPId).Value;
            set => GetField(1, (int)DataFields.WPId).SetValue(value);
        }
        public int NumberOfBolts
        {
            get => GetField(1, (int)DataFields.NumberOfBolts).GetValue(_intConverter.Convert);
            private set => GetField(1, (int)DataFields.NumberOfBolts).SetValue(_intConverter.Convert, value);
        }
        public List<BoltData> BoltsData { get; set; }
        public int TotalSpecialValues
        {
            get => GetField(1, (int)DataFields.NumberOfSpecialValues).GetValue(_intConverter.Convert);
            private set => GetField(1, (int)DataFields.NumberOfSpecialValues).SetValue(_intConverter.Convert, value);
        }
        public List<SpecialValue> SpecialValues { get; set; }
        public SystemSubType SystemSubType
        {
            get => (SystemSubType)GetField(4, (int)DataFields.SystemSubType).GetValue(_intConverter.Convert);
            set => GetField(4, (int)DataFields.SystemSubType).SetValue(_intConverter.Convert, (int)value);
        }

        public Mid0106() : this(DEFAULT_REVISION)
        {

        }

        public Mid0106(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
            _dateConverter = new DateConverter();
            _decimalConverter = new DecimalConverter();
            if (BoltsData == null)
                BoltsData = new List<BoltData>();
            if (SpecialValues == null)
                SpecialValues = new List<SpecialValue>();
        }

        public Mid0106(int revision) : this(new Header()
        {
            Mid = MID, 
            Revision = revision
        })
        {
        }

        public override string Pack()
        {
            NumberOfBolts = BoltsData.Count;
            TotalSpecialValues = SpecialValues.Count;
            _boltDataListConverter = new BoltDataListConverter(_intConverter, _boolConverter, _decimalConverter, NumberOfBolts);
            _specialValueListConverter = new SpecialValueListConverter(_intConverter, TotalSpecialValues);
            GetField(1, (int)DataFields.BoltData).Value = _boltDataListConverter.Convert(BoltsData);
            GetField(1, (int)DataFields.SpecialValues).Value = _specialValueListConverter.Convert(SpecialValues);

            string package = BuildHeader();
            int prefixIndex = 1;
            for (int i = 1; i <= (Header.Revision > 0 ? Header.Revision : 1); i++)
                foreach (var dataField in RevisionsByFields[i])
                {
                    if (dataField.Field == (int)DataFields.NumberOfSpecialValues)
                        prefixIndex = 23;

                    if (dataField.HasPrefix)
                    {
                        package += prefixIndex.ToString().PadLeft(2, '0') + dataField.Value;
                        prefixIndex++;
                    }
                    else
                        package += dataField.Value;
                }

            return package;
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);

            int numberOfBolts = _intConverter.Convert(package.Substring(GetField(1, (int)DataFields.NumberOfBolts).Index + 2, GetField(1, (int)DataFields.NumberOfBolts).Size));
            GetField(1, (int)DataFields.BoltData).Size *= numberOfBolts;

            var numberOfSpecialValuesField = GetField(1, (int)DataFields.NumberOfSpecialValues);
            numberOfSpecialValuesField.Index = GetField(1, (int)DataFields.BoltData).Index + GetField(1, (int)DataFields.BoltData).Size;

            var specialValues = GetField(1, (int)DataFields.SpecialValues);
            specialValues.Index = numberOfSpecialValuesField.Index + numberOfSpecialValuesField.Size + 2;
            if (Header.Revision > 3)
            {
                specialValues.Size = Header.Length - GetField(4, (int)DataFields.SystemSubType).Size - 2;
                GetField(4, (int)DataFields.SystemSubType).Index = specialValues.Index + specialValues.Size;
            }
            else
            {
                specialValues.Size = Header.Length - specialValues.Index;
            }

            ProcessDataFields(package);

            _boltDataListConverter = new BoltDataListConverter(_intConverter, _boolConverter, _decimalConverter, numberOfBolts);
            _specialValueListConverter = new SpecialValueListConverter(_intConverter, TotalSpecialValues);
            BoltsData = _boltDataListConverter.Convert(GetField(1, (int)DataFields.BoltData).Value).ToList();
            SpecialValues = _specialValueListConverter.Convert(GetField(1, (int)DataFields.SpecialValues).Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
                {
                    {
                        1, new List<DataField>()
                                {
                                        new DataField((int)DataFields.TotalNumberOfMessages, 20, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.MessageNumber, 24, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.DataNumberSystem, 28, 10, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.StationNumber, 40, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.StationName, 44, 20, ' '),
                                        new DataField((int)DataFields.Time, 66, 19),
                                        new DataField((int)DataFields.ModeNumber, 87, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.ModeName, 91, 20, ' '),
                                        new DataField((int)DataFields.SimpleStatus, 113, 1),
                                        new DataField((int)DataFields.PMStatus, 116, 1),
                                        new DataField((int)DataFields.WPId, 119, 40, ' '),
                                        new DataField((int)DataFields.NumberOfBolts, 161, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.BoltData, 165, 67, false),
                                        new DataField((int)DataFields.NumberOfSpecialValues, 0, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.SpecialValues, 0, 0, false)
                                }
                    },
                    {
                        4, new List<DataField>()
                                {
                                        new DataField((int)DataFields.SystemSubType, 0, 3, '0', DataField.PaddingOrientations.LeftPadded)
                                }
                    }
                };
        }

        protected enum DataFields
        {
            TotalNumberOfMessages,
            MessageNumber,
            DataNumberSystem,
            StationNumber,
            StationName,
            Time,
            ModeNumber,
            ModeName,
            SimpleStatus,
            PMStatus,
            WPId,
            NumberOfBolts,
            BoltData,
            NumberOfSpecialValues,
            SpecialValues,
            //Rev 4
            SystemSubType
        }
    }
}
