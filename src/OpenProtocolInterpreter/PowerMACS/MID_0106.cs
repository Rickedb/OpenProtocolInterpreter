using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// MID: Last PowerMACS tightening result Station data
    /// Description: 
    ///    This MID contains the station part and some of the Bolt data of the last result data. After this message
    ///    has been sent the integrator selects if it also wants to have the Bolt and step data.If this data is
    ///    requested, then the integrator sends the message MID 0108 Last PowerMACS tightening result data
    ///    acknowledge, with the parameter Bolt Data set to TRUE. If only the station data is wanted the
    ///    parameter Bolt Data is set to FALSE.
    ///    This telegram is also used for Power MACS systems running a Press. The layout of the telegram is
    ///    exactly the same but some of the fields have slightly different definitions. The fields for Torque are
    ///    used for Force values and the fields for Angle are used for Stroke values. Press systems also use
    ///    different identifiers for the optional data on bolt and step level. A press system always use revision 4
    ///    or higher of the telegram
    ///    Note: All values that are undefined in the results will be sent as all spaces (ASCII 0x20). This will for
    ///    instance happen with the Torque Status if no measuring value for Bolt T was available for the
    ///    tightening.
    /// Message sent by: Controller
    /// Answer: MID 0108 Last Power MACS tightening result data acknowledge
    /// </summary>
    public class MID_0106 : Mid, IPowerMACS
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        private IValueConverter<IEnumerable<BoltData>> _boltDataListConverter;
        private IValueConverter<IEnumerable<SpecialValue>> _specialValueListConverter;
        private const int LAST_REVISION = 4;
        public const int MID = 106;

        public int TotalNumberOfMessages
        {
            get => GetField(1, (int)DataFields.TOTAL_NUMBER_OF_MESSAGES).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.TOTAL_NUMBER_OF_MESSAGES).SetValue(_intConverter.Convert, value);
        }
        public int MessageNumber
        {
            get => GetField(1, (int)DataFields.MESSAGE_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.MESSAGE_NUMBER).SetValue(_intConverter.Convert, value);
        }
        public int DataNumberSystem
        {
            get => GetField(1, (int)DataFields.DATA_NUMBER_SYSTEM).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.DATA_NUMBER_SYSTEM).SetValue(_intConverter.Convert, value);
        }
        public int StationNumber
        {
            get => GetField(1, (int)DataFields.STATION_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.STATION_NUMBER).SetValue(_intConverter.Convert, value);
        }
        public string StationName
        {
            get => GetField(1, (int)DataFields.STATION_NAME).Value;
            set => GetField(1, (int)DataFields.STATION_NAME).SetValue(value);
        }
        public DateTime Time
        {
            get => GetField(1, (int)DataFields.TIME).GetValue(_dateConverter.Convert);
            set => GetField(1, (int)DataFields.TIME).SetValue(_dateConverter.Convert, value);
        }
        public int ModeNumber
        {
            get => GetField(1, (int)DataFields.MODE_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.MODE_NUMBER).SetValue(_intConverter.Convert, value);
        }
        public string ModeName
        {
            get => GetField(1, (int)DataFields.MODE_NAME).Value;
            set => GetField(1, (int)DataFields.MODE_NAME).SetValue(value);
        }
        public bool SimpleStatus
        {
            get => GetField(1, (int)DataFields.MODE_NUMBER).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.MODE_NUMBER).SetValue(_boolConverter.Convert, value);
        }
        public PowerMacsStatus PMStatus
        {
            get => (PowerMacsStatus)GetField(1, (int)DataFields.PM_STATUS).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.PM_STATUS).SetValue(_intConverter.Convert, (int)value);
        }
        public string WpId
        {
            get => GetField(1, (int)DataFields.WP_ID).Value;
            set => GetField(1, (int)DataFields.WP_ID).SetValue(value);
        }
        public int NumberOfBolts
        {
            get => GetField(1, (int)DataFields.NUMBER_OF_BOLTS).GetValue(_intConverter.Convert);
            private set => GetField(1, (int)DataFields.NUMBER_OF_BOLTS).SetValue(_intConverter.Convert, value);
        }
        public List<BoltData> BoltsData { get; set; }
        public int TotalSpecialValues
        {
            get => GetField(1, (int)DataFields.NUMBER_OF_SPECIAL_VALUES).GetValue(_intConverter.Convert);
            private set => GetField(1, (int)DataFields.NUMBER_OF_SPECIAL_VALUES).SetValue(_intConverter.Convert, value);
        }
        public List<SpecialValue> SpecialValues { get; set; }
        public SystemSubType SystemSubType
        {
            get => (SystemSubType)GetField(4, (int)DataFields.SYSTEM_SUB_TYPE).GetValue(_intConverter.Convert);
            set => GetField(4, (int)DataFields.SYSTEM_SUB_TYPE).SetValue(_intConverter.Convert, (int)value);
        }

        public MID_0106(int revision = LAST_REVISION, int? noAckFlag = 0) : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
            _dateConverter = new DateConverter();
            BoltsData = new List<BoltData>();
            SpecialValues = new List<SpecialValue>();
        }

        internal MID_0106(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string Pack()
        {
            NumberOfBolts = BoltsData.Count;
            TotalSpecialValues = SpecialValues.Count;
            _boltDataListConverter = new BoltDataListConverter(NumberOfBolts);
            _specialValueListConverter = new SpecialValueListConverter(TotalSpecialValues);
            GetField(1, (int)DataFields.BOLT_DATA).Value = _boltDataListConverter.Convert(BoltsData);
            GetField(1, (int)DataFields.SPECIAL_VALUES).Value = _specialValueListConverter.Convert(SpecialValues);

            string package = BuildHeader();
            int prefixIndex = 1;
            for (int i = 1; i <= (HeaderData.Revision > 0 ? HeaderData.Revision : 1); i++)
                foreach (var dataField in RevisionsByFields[i])
                {
                    if (dataField.Field == (int)DataFields.NUMBER_OF_SPECIAL_VALUES)
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
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);

                int numberOfBolts = _intConverter.Convert(package.Substring(GetField(1, (int)DataFields.NUMBER_OF_BOLTS).Index + 2, GetField(1, (int)DataFields.NUMBER_OF_BOLTS).Size));
                GetField(1, (int)DataFields.BOLT_DATA).Size *= numberOfBolts;

                var numberOfSpecialValuesField = GetField(1, (int)DataFields.NUMBER_OF_SPECIAL_VALUES);
                numberOfSpecialValuesField.Index = GetField(1, (int)DataFields.BOLT_DATA).Index + GetField(1, (int)DataFields.BOLT_DATA).Size;

                var specialValues = GetField(1, (int)DataFields.SPECIAL_VALUES);
                specialValues.Index = numberOfSpecialValuesField.Index + numberOfSpecialValuesField.Size + 2;
                if (HeaderData.Revision > 3)
                {
                    specialValues.Size = package.Length - GetField(4, (int)DataFields.SYSTEM_SUB_TYPE).Size - 2;
                    GetField(4, (int)DataFields.SYSTEM_SUB_TYPE).Index = specialValues.Index + specialValues.Size;
                }
                else
                    specialValues.Size = package.Length - specialValues.Index;
                ProcessDataFields(package);

                _boltDataListConverter = new BoltDataListConverter(numberOfBolts);
                _specialValueListConverter = new SpecialValueListConverter(TotalSpecialValues);
                BoltsData = _boltDataListConverter.Convert(GetField(1, (int)DataFields.BOLT_DATA).Value).ToList();
                SpecialValues = _specialValueListConverter.Convert(GetField(1, (int)DataFields.SPECIAL_VALUES).Value).ToList();
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
                                        new DataField((int)DataFields.TOTAL_NUMBER_OF_MESSAGES, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.MESSAGE_NUMBER, 24, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.DATA_NUMBER_SYSTEM, 28, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.STATION_NUMBER, 40, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.STATION_NAME, 44, 20, ' '),
                                        new DataField((int)DataFields.TIME, 66, 19),
                                        new DataField((int)DataFields.MODE_NUMBER, 87, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.MODE_NAME, 91, 20, ' '),
                                        new DataField((int)DataFields.SIMPLE_STATUS, 113, 1),
                                        new DataField((int)DataFields.PM_STATUS, 116, 1),
                                        new DataField((int)DataFields.WP_ID, 119, 40, ' '),
                                        new DataField((int)DataFields.NUMBER_OF_BOLTS, 161, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.BOLT_DATA, 165, 67, false),
                                        new DataField((int)DataFields.NUMBER_OF_SPECIAL_VALUES, 0, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.SPECIAL_VALUES, 0, 0, false)
                                }
                    },
                    { 2, new List<DataField>() },
                    { 3, new List<DataField>() },
                    {
                        4, new List<DataField>()
                                {
                                        new DataField((int)DataFields.SYSTEM_SUB_TYPE, 0, 3, '0', DataField.PaddingOrientations.LEFT_PADDED)
                                }
                    }
                };
        }

        public enum DataFields
        {
            TOTAL_NUMBER_OF_MESSAGES,
            MESSAGE_NUMBER,
            DATA_NUMBER_SYSTEM,
            STATION_NUMBER,
            STATION_NAME,
            TIME,
            MODE_NUMBER,
            MODE_NAME,
            SIMPLE_STATUS,
            PM_STATUS,
            WP_ID,
            NUMBER_OF_BOLTS,
            BOLT_DATA,
            NUMBER_OF_SPECIAL_VALUES,
            SPECIAL_VALUES,
            //Rev 4
            SYSTEM_SUB_TYPE
        }
    }
}
