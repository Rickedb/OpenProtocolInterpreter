using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm status
    /// <para>The alarm status is sent after an accepted subscription of the controller alarms. 
    /// This message is used to inform the integrator that an alarm is active on the controller at subscription time.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0077"/> Alarm status acknowledge</para>
    /// </summary>
    public class Mid0076 : Mid, IAlarm, IController, IAcknowledgeable<Mid0077>
    {
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        public const int MID = 76;

        public bool AlarmStatus
        {
            get => GetField(1, (int)DataFields.ALARM_STATUS).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.ALARM_STATUS).SetValue(_boolConverter.Convert, value);
        }
        public string ErrorCode
        {
            get => GetField(1, (int)DataFields.ERROR_CODE).Value;
            set => GetField(1, (int)DataFields.ERROR_CODE).SetValue(value);
        }
        public bool ControllerReadyStatus
        {
            get => GetField(1, (int)DataFields.CONTROLLER_READY_STATUS).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.CONTROLLER_READY_STATUS).SetValue(_boolConverter.Convert, value);
        }
        public bool ToolReadyStatus
        {
            get => GetField(1, (int)DataFields.TOOL_READY_STATUS).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.TOOL_READY_STATUS).SetValue(_boolConverter.Convert, value);
        }
        public DateTime Time
        {
            get => GetField(1, (int)DataFields.TIME).GetValue(_dateConverter.Convert);
            set => GetField(1, (int)DataFields.TIME).SetValue(_dateConverter.Convert, value);
        }
        public ToolHealth ToolHealth
        {
            get => (ToolHealth)GetField(3, (int)DataFields.TOOL_HEALTH).GetValue(_intConverter.Convert);
            set => GetField(3, (int)DataFields.TOOL_HEALTH).SetValue(_intConverter.Convert, (int)value);
        }

        public Mid0076() : this(DEFAULT_REVISION)
        {

        }

        public Mid0076(Header header) : base(header)
        {
            _boolConverter = new BoolConverter();
            _dateConverter = new DateConverter();
            _intConverter = new Int32Converter();
            HandleRevision();
        }

        public Mid0076(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            HandleRevision();
            ProcessDataFields(package);
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.ALARM_STATUS, 20, 1),
                                new DataField((int)DataFields.ERROR_CODE, 23, 4, ' ', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.CONTROLLER_READY_STATUS, 29, 1),
                                new DataField((int)DataFields.TOOL_READY_STATUS, 32, 1),
                                new DataField((int)DataFields.TIME, 35, 19)
                            }
                },
                {
                    3, new List<DataField>()
                            {
                                new DataField((int)DataFields.TOOL_HEALTH, 57, 1),
                            }
                }
            };
        }

        private void HandleRevision()
        {
            var errorCodeField = GetField(1, (int)DataFields.ERROR_CODE);
            errorCodeField.Size = Header.Revision > 1 ? 5 : 4;

            int index = errorCodeField.Index + errorCodeField.Size;
            for (int i = (int)DataFields.CONTROLLER_READY_STATUS; i < RevisionsByFields[1].Count; i++)
            {
                var field = GetField(1, i);
                field.Index = 2 + index;
                index = field.Index + field.Size;
            }
        }

        protected enum DataFields
        {
            ALARM_STATUS,
            ERROR_CODE,
            CONTROLLER_READY_STATUS,
            TOOL_READY_STATUS,
            TIME,
            TOOL_HEALTH
        }
    }
}
