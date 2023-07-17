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
        public const int MID = 106;

        public int TotalNumberOfMessages
        {
            get => GetField(1, (int)DataFields.TotalNumberOfMessages).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.TotalNumberOfMessages).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int MessageNumber
        {
            get => GetField(1, (int)DataFields.MessageNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.MessageNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int DataNumberSystem
        {
            get => GetField(1, (int)DataFields.DataNumberSystem).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.DataNumberSystem).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int StationNumber
        {
            get => GetField(1, (int)DataFields.StationNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.StationNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string StationName
        {
            get => GetField(1, (int)DataFields.StationName).Value;
            set => GetField(1, (int)DataFields.StationName).SetValue(value);
        }
        public DateTime Time
        {
            get => GetField(1, (int)DataFields.Time).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, (int)DataFields.Time).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int ModeNumber
        {
            get => GetField(1, (int)DataFields.ModeNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.ModeNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string ModeName
        {
            get => GetField(1, (int)DataFields.ModeName).Value;
            set => GetField(1, (int)DataFields.ModeName).SetValue(value);
        }
        public bool SimpleStatus
        {
            get => GetField(1, (int)DataFields.SimpleStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, (int)DataFields.SimpleStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public PowerMacsStatus PMStatus
        {
            get => (PowerMacsStatus)GetField(1, (int)DataFields.PMStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.PMStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public string WpId
        {
            get => GetField(1, (int)DataFields.WPId).Value;
            set => GetField(1, (int)DataFields.WPId).SetValue(value);
        }
        public int NumberOfBolts
        {
            get => GetField(1, (int)DataFields.NumberOfBolts).GetValue(OpenProtocolConvert.ToInt32);
            private set => GetField(1, (int)DataFields.NumberOfBolts).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<BoltData> BoltsData { get; set; }
        public int TotalSpecialValues
        {
            get => GetField(1, (int)DataFields.NumberOfSpecialValues).GetValue(OpenProtocolConvert.ToInt32);
            private set => GetField(1, (int)DataFields.NumberOfSpecialValues).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<SpecialValue> SpecialValues { get; set; }
        public SystemSubType SystemSubType
        {
            get => (SystemSubType)GetField(4, (int)DataFields.SystemSubType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(4, (int)DataFields.SystemSubType).SetValue(OpenProtocolConvert.ToString, (int)value);
        }

        public Mid0106() : this(DEFAULT_REVISION)
        {

        }

        public Mid0106(Header header) : base(header)
        {
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
            GetField(1, (int)DataFields.BoltData).Value = PackBoltsData();
            GetField(1, (int)DataFields.SpecialValues).Value = PackSpecialValues();

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

            int numberOfBolts = OpenProtocolConvert.ToInt32(package.Substring(GetField(1, (int)DataFields.NumberOfBolts).Index + 2, GetField(1, (int)DataFields.NumberOfBolts).Size));
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

            BoltsData = ParseBoltsData(GetField(1, (int)DataFields.BoltData).Value);
            SpecialValues = SpecialValue.ParseAll(GetField(1, (int)DataFields.SpecialValues).Value, TotalSpecialValues, false).ToList();
            return this;
        }

        protected virtual string PackBoltsData()
        {
            string package = string.Empty;
            foreach (var bolt in BoltsData)
            {
                package += $"13{OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, bolt.OrdinalBoltNumber)}";
                package += $"14{OpenProtocolConvert.ToString(bolt.SimpleBoltStatus)}";
                package += $"15{OpenProtocolConvert.ToString((int)bolt.TorqueStatus)}";
                package += $"16{OpenProtocolConvert.ToString((int)bolt.AngleStatus)}";
                package += $"17{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltTorque)}";
                package += $"18{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltAngle)}";
                package += $"19{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltTorqueHighLimit)}";
                package += $"20{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltTorqueLowLimit)}";
                package += $"21{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltAngleHighLimit)}";
                package += $"22{OpenProtocolConvert.ToString('0', 7, PaddingOrientation.RightPadded, bolt.BoltAngleLowLimit)}";
            }

            return package;
        }

        protected virtual string PackSpecialValues()
        {
            string package = string.Empty;
            foreach (var v in SpecialValues)
            {
                package += v.Pack(false);
            }

            return package;
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
                                        new DataField((int)DataFields.TotalNumberOfMessages, 20, 2, '0', PaddingOrientation.LeftPadded),
                                        new DataField((int)DataFields.MessageNumber, 24, 2, '0', PaddingOrientation.LeftPadded),
                                        new DataField((int)DataFields.DataNumberSystem, 28, 10, '0', PaddingOrientation.LeftPadded),
                                        new DataField((int)DataFields.StationNumber, 40, 2, '0', PaddingOrientation.LeftPadded),
                                        new DataField((int)DataFields.StationName, 44, 20, ' '),
                                        new DataField((int)DataFields.Time, 66, 19),
                                        new DataField((int)DataFields.ModeNumber, 87, 2, '0', PaddingOrientation.LeftPadded),
                                        new DataField((int)DataFields.ModeName, 91, 20, ' '),
                                        new DataField((int)DataFields.SimpleStatus, 113, 1),
                                        new DataField((int)DataFields.PMStatus, 116, 1),
                                        new DataField((int)DataFields.WPId, 119, 40, ' '),
                                        new DataField((int)DataFields.NumberOfBolts, 161, 2, '0', PaddingOrientation.LeftPadded),
                                        new DataField((int)DataFields.BoltData, 165, 67, false),
                                        new DataField((int)DataFields.NumberOfSpecialValues, 0, 2, '0', PaddingOrientation.LeftPadded),
                                        new DataField((int)DataFields.SpecialValues, 0, 0, false)
                                }
                    },
                    {
                        4, new List<DataField>()
                                {
                                        new DataField((int)DataFields.SystemSubType, 0, 3, '0', PaddingOrientation.LeftPadded)
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
