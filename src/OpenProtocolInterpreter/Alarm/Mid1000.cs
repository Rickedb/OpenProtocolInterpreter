using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm
    /// <para>An alarm has appeared in the controller. The current alarm is uploaded from the controller to the integrator.
    /// This MID replace the old alarm MID 0071.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0071"/> Alarm status acknowledge</para>
    /// </summary>
    public class Mid1000 : Mid, IAlarm, IController, IAcknowledgeable<Mid1001>
    {
        public const int MID = 1000;

        public string AlarmCode
        {
            get => GetField(1, DataFields.AlarmCode).Value;
            set => GetField(1, DataFields.AlarmCode).SetValue(value);
        }
        public DateTime Time
        {
            get => GetField(1, DataFields.Time).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, DataFields.Time).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int NumberOfDataFields => AlarmDataFields.Count;
        public List<VariableDataField> AlarmDataFields { get; set; }

        public Mid1000() : this(DEFAULT_REVISION)
        {

        }

        public Mid1000(Header header) : base(header)
        {
            AlarmDataFields = [];
        }

        public Mid1000(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
            
        }

        public override string Pack()
        {
            GetField(1, DataFields.NumberOfDataFields).SetValue(OpenProtocolConvert.ToString, AlarmDataFields.Count);
            GetField(1, DataFields.EachAlarmDataField).Value = OpenProtocolConvert.ToString(AlarmDataFields);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            var dataFieldsField = GetField(1, DataFields.EachAlarmDataField);
            dataFieldsField.Size = Header.Length - dataFieldsField.Index;
            ProcessDataFields(package);
            AlarmDataFields = VariableDataField.ParseAll(dataFieldsField.Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.String(DataFields.AlarmCode, 20, 5, PaddingOrientation.RightPadded, false),
                                DataField.Timestamp(DataFields.Time, 25, false),
                                DataField.Number(DataFields.NumberOfDataFields, 44, 3, false),
                                DataField.Volatile(DataFields.EachAlarmDataField, 47, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            AlarmCode,
            Time,
            NumberOfDataFields,
            EachAlarmDataField
        }
    }
}
