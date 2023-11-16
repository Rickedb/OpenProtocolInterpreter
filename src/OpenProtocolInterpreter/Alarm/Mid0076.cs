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
        public const int MID = 76;

        public bool AlarmStatus
        {
            get => GetField(1, DataFields.AlarmStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, DataFields.AlarmStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string ErrorCode
        {
            get => GetField(1, DataFields.ErrorCode).Value;
            set => GetField(1, DataFields.ErrorCode).SetValue(value);
        }
        public bool ControllerReadyStatus
        {
            get => GetField(1, DataFields.ControllerReadyStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, DataFields.ControllerReadyStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool ToolReadyStatus
        {
            get => GetField(1, DataFields.ToolReadyStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, DataFields.ToolReadyStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime Time
        {
            get => GetField(1, DataFields.Time).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, DataFields.Time).SetValue(OpenProtocolConvert.ToString, value);
        }
        public ToolHealth ToolHealth
        {
            get => (ToolHealth)GetField(3, DataFields.ToolHealth).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(3, DataFields.ToolHealth).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0076() : this(DEFAULT_REVISION)
        {

        }

        public Mid0076(Header header) : base(header)
        {
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
                                DataField.Boolean(DataFields.AlarmStatus, 20),
                                DataField.String(DataFields.ErrorCode, 23, 4, PaddingOrientation.LeftPadded),
                                DataField.Boolean(DataFields.ControllerReadyStatus, 29),
                                DataField.Boolean(DataFields.ToolReadyStatus, 32),
                                DataField.Timestamp(DataFields.Time, 35)
                            }
                },
                {
                    3, new List<DataField>()
                            {
                                DataField.Number(DataFields.ToolHealth, 57, 1),
                            }
                }
            };
        }

        private void HandleRevision()
        {
            var errorCodeField = GetField(1, DataFields.ErrorCode);
            errorCodeField.Size = Header.Revision > 1 ? 5 : 4;

            int index = errorCodeField.Index + errorCodeField.Size;
            for (int i = (int)DataFields.ControllerReadyStatus; i < RevisionsByFields[1].Count; i++)
            {
                var field = GetField(1, i);
                field.Index = 2 + index;
                index = field.Index + field.Size;
            }
        }

        protected enum DataFields
        {
            AlarmStatus,
            ErrorCode,
            ControllerReadyStatus,
            ToolReadyStatus,
            Time,
            ToolHealth
        }
    }
}
