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
        private readonly IValueConverter<IEnumerable<BoltData>> _boltDataListConverter;
        private readonly IValueConverter<IEnumerable<SpecialValue>> _specialValueListConverter;
        private const int LAST_REVISION = 4;
        public const int MID = 106;

        public int TotalNumberOfMessages { get; set; }
        public int MessageNumber { get; set; }
        public int DataNumberSystem { get; set; }
        public int StationNumber { get; set; }
        public string StationName { get; set; }
        public DateTime Time { get; set; }
        public int ModeNumber { get; set; }
        public string ModeName { get; set; }
        public bool SimpleStatus { get; set; }
        public PowerMacsStatus PMStatus { get; set; }
        public string WpId { get; set; }
        public int NumberOfBolts { get; set; }
        public List<BoltData> BoltsData { get; set; }
        public List<SpecialValue> SpecialValues { get; set; }
        public SystemSubType SystemSubType { get; set; }

        public MID_0106(int revision = LAST_REVISION, int? noAckFlag = 0) : base(MID, LAST_REVISION)
        {
            BoltsData = new List<BoltData>();
            SpecialValues = new List<SpecialValue>();
        }

        internal MID_0106(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string Pack()
        {
            //TODO
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                base.HeaderData.Length = package.Length;
                base.Parse(package);

                TotalNumberOfMessages = base.RegisteredDataFields[(int)DataFields.TOTAL_NUMBER_OF_MESSAGES].ToInt32();
                MessageNumber = base.RegisteredDataFields[(int)DataFields.MESSAGE_NUMBER].ToInt32();
                DataNumberSystem = base.RegisteredDataFields[(int)DataFields.DATA_NUMBER_SYSTEM].ToInt32();
                StationNumber = base.RegisteredDataFields[(int)DataFields.STATION_NUMBER].ToInt32();
                StationName = base.RegisteredDataFields[(int)DataFields.STATION_NAME].Value.ToString();
                Time = base.RegisteredDataFields[(int)DataFields.TIME].ToDateTime();
                ModeNumber = base.RegisteredDataFields[(int)DataFields.MODE_NUMBER].ToInt32();
                ModeName = base.RegisteredDataFields[(int)DataFields.MODE_NAME].Value.ToString();
                SimpleStatus = base.RegisteredDataFields[(int)DataFields.SIMPLE_STATUS].ToBoolean();
                WpId = base.RegisteredDataFields[(int)DataFields.WP_ID].Value.ToString();
                PMStatus = (PowerMacsStatuses)base.RegisteredDataFields[(int)DataFields.PM_STATUS].ToInt32();
                WpId = base.RegisteredDataFields[(int)DataFields.WP_ID].ToString();
                NumberOfBolts = base.RegisteredDataFields[(int)DataFields.NUMBER_OF_BOLTS].ToInt32();

                base.RegisteredDataFields[(int)DataFields.BOLT_DATA].Size = (TotalNumberOfMessages - 1) * 67; //BoltData size
                BoltsData = new BoltData().getBoltDatasFromPackage(TotalNumberOfMessages - 1, package.Substring(base.RegisteredDataFields[(int)DataFields.BOLT_DATA].Index, base.RegisteredDataFields[(int)DataFields.BOLT_DATA].Size)).ToList();

                base.RegisteredDataFields[(int)DataFields.BOLT_DATA].Index = base.RegisteredDataFields[(int)DataFields.BOLT_DATA].Index + base.RegisteredDataFields[(int)DataFields.BOLT_DATA].Size;
                SpecialValues = new SpecialValue().getSpecialValuesFromPackage(package.Substring(base.RegisteredDataFields[(int)DataFields.BOLT_DATA].Index)).ToList();

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
                                        new DataField((int)DataFields.BOLT_DATA, 165, 0),
                                        new DataField((int)DataFields.NUMBER_OF_SPECIAL_VALUES, 0, 0)
                                }
                    },
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
            //Rev 4
            SYSTEM_SUB_TYPE
        }
    }
}
