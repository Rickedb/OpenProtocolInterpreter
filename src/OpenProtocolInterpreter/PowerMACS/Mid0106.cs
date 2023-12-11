using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public const int MID = 106;

        public int TotalNumberOfMessages
        {
            get => GetField(1, DataFields.TotalNumberOfMessages).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.TotalNumberOfMessages).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int MessageNumber
        {
            get => GetField(1, DataFields.MessageNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.MessageNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int DataNumberSystem
        {
            get => GetField(1, DataFields.DataNumberSystem).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.DataNumberSystem).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int StationNumber
        {
            get => GetField(1, DataFields.StationNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.StationNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string StationName
        {
            get => GetField(1, DataFields.StationName).Value;
            set => GetField(1, DataFields.StationName).SetValue(value);
        }
        public DateTime Time
        {
            get => GetField(1, DataFields.Time).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, DataFields.Time).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int ModeNumber
        {
            get => GetField(1, DataFields.ModeNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.ModeNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string ModeName
        {
            get => GetField(1, DataFields.ModeName).Value;
            set => GetField(1, DataFields.ModeName).SetValue(value);
        }
        public bool SimpleStatus
        {
            get => GetField(1, DataFields.SimpleStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, DataFields.SimpleStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public PowerMacsStatus PMStatus
        {
            get => (PowerMacsStatus)GetField(1, DataFields.PMStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.PMStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string WpId
        {
            get => GetField(1, DataFields.WPId).Value;
            set => GetField(1, DataFields.WPId).SetValue(value);
        }
        public int NumberOfBolts
        {
            get => GetField(1, DataFields.NumberOfBolts).GetValue(OpenProtocolConvert.ToInt32);
            private set => GetField(1, DataFields.NumberOfBolts).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<BoltData> BoltsData { get; set; }
        public int TotalSpecialValues
        {
            get => GetField(1, DataFields.NumberOfSpecialValues).GetValue(OpenProtocolConvert.ToInt32);
            private set => GetField(1, DataFields.NumberOfSpecialValues).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<SpecialValue> SpecialValues { get; set; }
        public SystemSubType SystemSubType
        {
            get => (SystemSubType)GetField(4, DataFields.SystemSubType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(4, DataFields.SystemSubType).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0106() : this(DEFAULT_REVISION)
        {

        }

        public Mid0106(Header header) : base(header)
        {
            BoltsData ??= [];
            SpecialValues ??= [];
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
            GetField(1, DataFields.BoltData).Value = PackBoltsData();
            GetField(1, DataFields.SpecialValues).Value = PackSpecialValues();

            var builder = new StringBuilder(BuildHeader());
            int prefixIndex = 1;
            for (int i = 1; i <= (Header.Revision > 0 ? Header.Revision : 1); i++)
                foreach (var dataField in RevisionsByFields[i])
                {
                    if (dataField.Field == (int)DataFields.NumberOfSpecialValues)
                        prefixIndex = 23;

                    if (dataField.HasPrefix)
                    {
                        builder.Append(prefixIndex.ToString("D2"));
                        prefixIndex++;
                    }

                    builder.Append(dataField.Value);
                }

            return builder.ToString();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);

            int numberOfBolts = OpenProtocolConvert.ToInt32(package.Substring(GetField(1, DataFields.NumberOfBolts).Index + 2, GetField(1, DataFields.NumberOfBolts).Size));
            GetField(1, DataFields.BoltData).Size *= numberOfBolts;

            var numberOfSpecialValuesField = GetField(1, DataFields.NumberOfSpecialValues);
            numberOfSpecialValuesField.Index = GetField(1, DataFields.BoltData).Index + GetField(1, DataFields.BoltData).Size;

            var specialValues = GetField(1, DataFields.SpecialValues);
            specialValues.Index = numberOfSpecialValuesField.Index + numberOfSpecialValuesField.Size + 2;
            if (Header.Revision > 3)
            {
                specialValues.Size = Header.Length - GetField(4, DataFields.SystemSubType).Size - 2;
                GetField(4, DataFields.SystemSubType).Index = specialValues.Index + specialValues.Size;
            }
            else
            {
                specialValues.Size = Header.Length - specialValues.Index;
            }

            ProcessDataFields(package);

            BoltsData = ParseBoltsData(GetField(1, DataFields.BoltData).Value);
            SpecialValues = SpecialValue.ParseAll(GetField(1, DataFields.SpecialValues).Value, TotalSpecialValues, false).ToList();
            return this;
        }

        protected virtual string PackBoltsData()
        {
            var builder = new StringBuilder();
            foreach (var bolt in BoltsData)
            {
                builder.Append($"13{OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, bolt.OrdinalBoltNumber)}");
                builder.Append($"14{OpenProtocolConvert.ToString(bolt.SimpleBoltStatus)}");
                builder.Append($"15{OpenProtocolConvert.ToString(bolt.TorqueStatus)}");
                builder.Append($"16{OpenProtocolConvert.ToString(bolt.AngleStatus)}");
                builder.Append($"17{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltTorque)}");
                builder.Append($"18{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltAngle)}");
                builder.Append($"19{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltTorqueHighLimit)}");
                builder.Append($"20{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltTorqueLowLimit)}");
                builder.Append($"21{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltAngleHighLimit)}");
                builder.Append($"22{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltAngleLowLimit)}");
            }

            return builder.ToString();
        }

        protected virtual string PackSpecialValues()
        {
            var builder = new StringBuilder();
            foreach (var v in SpecialValues)
            {
                builder.Append(v.Pack(false));
            }

            return builder.ToString();
        }

        protected virtual List<BoltData> ParseBoltsData(string value)
        {
            var list = new List<BoltData>();
            if (string.IsNullOrWhiteSpace(value))
            {
                return list;
            }

            var bolts = new List<string>();
            for (int i = 0; i < NumberOfBolts; i++)
                bolts.Add(value.Substring(i * 67, 67));

            foreach (var bolt in bolts)
            {
                var obj = new BoltData()
                {
                    OrdinalBoltNumber = OpenProtocolConvert.ToInt32(bolt.Substring(2, 2)),
                    SimpleBoltStatus = OpenProtocolConvert.ToBoolean(bolt.Substring(6, 1)),
                    TorqueStatus = (TorqueStatus)OpenProtocolConvert.ToInt32(bolt.Substring(9, 1)),
                    AngleStatus = (AngleStatus)OpenProtocolConvert.ToInt32(bolt.Substring(12, 1)),
                    BoltTorque = OpenProtocolConvert.ToDecimal(bolt.Substring(15, 7)),
                    BoltAngle = OpenProtocolConvert.ToDecimal(bolt.Substring(24, 7)),
                    BoltTorqueHighLimit = OpenProtocolConvert.ToDecimal(bolt.Substring(33, 7)),
                    BoltTorqueLowLimit = OpenProtocolConvert.ToDecimal(bolt.Substring(42, 7)),
                    BoltAngleHighLimit = OpenProtocolConvert.ToDecimal(bolt.Substring(51, 7)),
                    BoltAngleLowLimit = OpenProtocolConvert.ToDecimal(bolt.Substring(60, 7)),
                };

                list.Add(obj);
            }

            return list;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
                {
                    {
                        1, new List<DataField>()
                                {
                                        DataField.Number(DataFields.TotalNumberOfMessages, 20, 2),
                                        DataField.Number(DataFields.MessageNumber, 24, 2),
                                        DataField.Number(DataFields.DataNumberSystem, 28, 10),
                                        DataField.Number(DataFields.StationNumber, 40, 2),
                                        DataField.String(DataFields.StationName, 44, 20),
                                        DataField.Timestamp(DataFields.Time, 66),
                                        DataField.Number(DataFields.ModeNumber, 87, 2),
                                        DataField.String(DataFields.ModeName, 91, 20),
                                        DataField.Boolean(DataFields.SimpleStatus, 113),
                                        DataField.Number(DataFields.PMStatus, 116, 1),
                                        DataField.String(DataFields.WPId, 119, 40),
                                        DataField.Number(DataFields.NumberOfBolts, 161, 2),
                                        new(DataFields.BoltData, 165, 67, false),
                                        DataField.Number(DataFields.NumberOfSpecialValues, 0, 2),
                                        DataField.Volatile(DataFields.SpecialValues, false)
                                }
                    },
                    {
                        4, new List<DataField>()
                                {
                                        DataField.Number(DataFields.SystemSubType, 0, 3)
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
