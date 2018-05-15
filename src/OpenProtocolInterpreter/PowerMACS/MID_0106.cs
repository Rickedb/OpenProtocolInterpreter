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
        public PowerMacsStatuses PMStatus { get; set; }
        public string WpId { get; set; }
        public int NumberOfBolts { get; set; }
        public List<BoltData> BoltsData { get; set; }
        public List<SpecialValue> SpecialValues { get; set; }

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
            if (base.IsCorrectType(package))
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

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.AddRange(
                new DataField[]
                {
                            new DataField((int)DataFields.TOTAL_NUMBER_OF_MESSAGES, 20, 2),
                            new DataField((int)DataFields.MESSAGE_NUMBER, 24, 2),
                            new DataField((int)DataFields.DATA_NUMBER_SYSTEM,28, 10),
                            new DataField((int)DataFields.STATION_NUMBER, 40, 2),
                            new DataField((int)DataFields.STATION_NAME, 44, 20),
                            new DataField((int)DataFields.TIME, 66, 19),
                            new DataField((int)DataFields.MODE_NUMBER, 87, 2),
                            new DataField((int)DataFields.MODE_NAME, 91, 20),
                            new DataField((int)DataFields.SIMPLE_STATUS, 113, 1),
                            new DataField((int)DataFields.PM_STATUS, 116, 1),
                            new DataField((int)DataFields.WP_ID, 119, 40),
                            new DataField((int)DataFields.NUMBER_OF_BOLTS, 161, 2),
                            new DataField((int)DataFields.BOLT_DATA, 165, 0),
                            new DataField((int)DataFields.NUMBER_OF_SPECIAL_VALUES, 0, 0),
                });
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
            NUMBER_OF_SPECIAL_VALUES
        }

        public enum PowerMacsStatuses
        {
            OK = 0,
            OKR = 1,
            NOK = 2,
            TERMNOK = 3
        }

        public class BoltData
        {
            private List<DataField> fields;
            public int OrdinalBoltNumber { get; set; }
            public bool SimpleBoltStatus { get; set; }
            public TorqueStatuses TorqueStatus { get; set; }
            public AngleStatuses AngleStatus { get; set; }
            public float BoltTorque { get; set; }
            public float BoltAngle { get; set; }
            public float BoltTorqueHighLimit { get; set; }
            public float BoltTorqueLowLimit { get; set; }
            public float BoltAngleHighLimit { get; set; }
            public float BoltAngleLowLimit { get; set; }

            public BoltData()
            {
                fields = new List<DataField>();
                registerDatafields();
            }

            public IEnumerable<BoltData> getBoltDatasFromPackage(int totalBolts, string package)
            {
                List<BoltData> obj = new List<BoltData>();

                for (int i = 0; i < totalBolts; i++)
                    obj.Add(getBoltFromPackage(package.Substring(i * 67, 67)));

                return obj;
            }

            private BoltData getBoltFromPackage(string package)
            {
                BoltData bolt = new BoltData();

                foreach (DataField field in fields)
                    field.Value = package.Substring(field.Index + 2, field.Size);

                bolt.OrdinalBoltNumber = fields[(int)DataFields.ORDINAL_BOLT_NUMBER].ToInt32();
                bolt.SimpleBoltStatus = fields[(int)DataFields.SIMPLE_BOLT_STATUS].ToBoolean();
                bolt.TorqueStatus = (TorqueStatuses)fields[(int)DataFields.TORQUE_STATUS].ToInt32();
                bolt.AngleStatus = (AngleStatuses)fields[(int)DataFields.ANGLE_STATUS].ToInt32();
                bolt.BoltTorque = fields[(int)DataFields.BOLT_TORQUE].ToFloat();
                bolt.BoltAngle = fields[(int)DataFields.BOLT_ANGLE].ToFloat();
                bolt.BoltTorqueHighLimit = fields[(int)DataFields.BOLT_TORQUE_HIGH_LIMIT].ToFloat();
                bolt.BoltTorqueLowLimit = fields[(int)DataFields.BOLT_TORQUE_LOW_LIMIT].ToFloat();
                bolt.BoltAngleHighLimit = fields[(int)DataFields.BOLT_ANGLE_HIGH_LIMIT].ToFloat();
                bolt.BoltAngleLowLimit = fields[(int)DataFields.BOLT_ANGLE_LOW_LIMIT].ToFloat();

                return bolt;
            }

            private void registerDatafields()
            {
                fields.AddRange(
                    new DataField[]
                    {
                            new DataField((int)DataFields.ORDINAL_BOLT_NUMBER, 0, 2),
                            new DataField((int)DataFields.SIMPLE_BOLT_STATUS, 4, 1),
                            new DataField((int)DataFields.TORQUE_STATUS, 7, 1),
                            new DataField((int)DataFields.ANGLE_STATUS, 10, 1),
                            new DataField((int)DataFields.BOLT_TORQUE, 13, 7),
                            new DataField((int)DataFields.BOLT_ANGLE, 22, 7),
                            new DataField((int)DataFields.BOLT_TORQUE_HIGH_LIMIT, 31, 7),
                            new DataField((int)DataFields.BOLT_TORQUE_LOW_LIMIT, 40, 7),
                            new DataField((int)DataFields.BOLT_ANGLE_HIGH_LIMIT, 49, 7),
                            new DataField((int)DataFields.BOLT_ANGLE_LOW_LIMIT, 58, 7)
                    });
            }

            public enum TorqueStatuses
            {
                UNDEFINED = -1,
                BOLT_TORQUE_LOW = 0,
                BOLT_TORQUE_OK = 1,
                BOLT_TORQUE_HIGH = 2
            }

            public enum AngleStatuses
            {
                UNDEFINED = -1,
                BOLT_ANGLE_LOW = 0,
                BOLT_ANGLE_OK = 1,
                BOLT_ANGLE_HIGH = 2
            }

            public enum DataFields
            {
                ORDINAL_BOLT_NUMBER,
                SIMPLE_BOLT_STATUS,
                TORQUE_STATUS,
                ANGLE_STATUS,
                BOLT_TORQUE,
                BOLT_ANGLE,
                BOLT_TORQUE_HIGH_LIMIT,
                BOLT_TORQUE_LOW_LIMIT,
                BOLT_ANGLE_HIGH_LIMIT,
                BOLT_ANGLE_LOW_LIMIT
            }
        }

        public class SpecialValue
        {
            private List<DataField> fields;
            public string VariableName { get; set; }
            public DataType Type { get; set; }
            public int Length { get; set; }
            public object Value { get; set; }

            public SpecialValue()
            {
                fields = new List<DataField>();
                RegisterDatafields();
            }

            public IEnumerable<SpecialValue> getSpecialValuesFromPackage(string package)
            {
                List<SpecialValue> obj = new List<SpecialValue>();
                int numberOfSpecialValues = Convert.ToInt32(package.Substring(2, 2));

                int index = 4;
                for (int i = 0; i < numberOfSpecialValues; i++)
                {
                    int valueLength = Convert.ToInt32(package.Substring(index + fields[(int)DataFields.LENGTH].Index, fields[(int)DataFields.LENGTH].Size));
                    int totalSpecialValueLength = fields[(int)DataFields.LENGTH].Index + fields[(int)DataFields.LENGTH].Size + valueLength;

                    obj.Add(getSpecialValue(package.Substring(index, totalSpecialValueLength)));
                    index += totalSpecialValueLength;
                }

                return obj;
            }

            private SpecialValue getSpecialValue(string package)
            {
                SpecialValue val = new SpecialValue
                {
                    VariableName = package.Substring(fields[(int)DataFields.VARIABLE_NAME].Index, fields[(int)DataFields.VARIABLE_NAME].Size),
                    Type = DataType.DataTypes.FirstOrDefault(x => x.Type == package.Substring(fields[(int)DataFields.TYPE].Index, fields[(int)DataFields.TYPE].Size).Trim()),
                    Length = Convert.ToInt32(package.Substring(fields[(int)DataFields.LENGTH].Index, fields[(int)DataFields.LENGTH].Size))
                };
                val.Value = package.Substring(fields[(int)DataFields.VALUE].Index, val.Length);

                return val;
            }

            private void RegisterDatafields()
            {
                fields.AddRange(
                    new DataField[]
                    {
                            new DataField((int)DataFields.VARIABLE_NAME, 0, 20),
                            new DataField((int)DataFields.TYPE, 20, 2),
                            new DataField((int)DataFields.LENGTH, 22, 2),
                            new DataField((int)DataFields.VALUE, 24, 0)
                    });
            }

            public enum DataFields
            {
                VARIABLE_NAME,
                TYPE,
                LENGTH,
                VALUE
            }
        }
    }
}
