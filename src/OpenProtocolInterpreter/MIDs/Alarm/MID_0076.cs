using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MIDs.Alarm
{
    /// <summary>
    /// MID: Alarm status
    /// Description: 
    ///      The alarm status is sent after an accepted subscription of the controller alarms. 
    ///      This message is used to inform the integrator that an alarm is active on the controller at subscription time.
    /// Message sent by: Controller
    /// Answer : MID 0077 Alarm status acknowledge
    /// </summary>
    public class MID_0076 : MID, IAlarm
    {
        public const int MID = 76;
        private const int length = 53;
        private const int revision = 1;

        public AlarmStatusesData AlarmStatusData { get; set; }

        public MID_0076() : base(length, MID, revision)
        {

        }

        internal MID_0076(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                this.AlarmStatusData = new AlarmStatusesData().getAlarmStatusFromPackage(package);
                return this;
            }


            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.ALARM_STATUS_DATA, 20, 35));
        }

        public enum DataFields
        {
            ALARM_STATUS_DATA
        }

        public class AlarmStatusesData
        {
            private List<DataField> fields;
            public bool AlarmStatus { get; set; }
            public string ErrorCode { get; set; }
            public bool ControllerReadyStatus { get; set; }
            public bool ToolReadyStatus { get; set; }
            public DateTime Time { get; set; }

            public AlarmStatusesData() { this.registerFields(); }

            public AlarmStatusesData getAlarmStatusFromPackage(string package)
            {
                this.processFields(package);
                AlarmStatusesData alarmStatus = new AlarmStatusesData();

                this.AlarmStatus = this.fields[(int)Fields.ALARM_STATUS].ToBoolean();
                this.ErrorCode = this.fields[(int)Fields.ERROR_CODE].ToString();
                this.ControllerReadyStatus = this.fields[(int)Fields.CONTROLLER_READY_STATUS].ToBoolean();
                this.ToolReadyStatus = this.fields[(int)Fields.TOOL_READY_STATUS].ToBoolean();
                this.Time = this.fields[(int)Fields.TIME].ToDateTime();

                return alarmStatus;
            }

            public override string ToString()
            {
                string package = string.Empty;

                return base.ToString();
            }

            private void processFields(string package)
            {
                foreach (var field in this.fields)
                    field.Value = package.Substring(2 + field.Index, field.Size);
            }

            private void registerFields()
            {
                this.fields = new List<DataField>();
                this.fields.AddRange(new DataField[] {
                        new DataField((int)Fields.ALARM_STATUS, 20, 1),
                        new DataField((int)Fields.ERROR_CODE, 23, 4),
                        new DataField((int)Fields.CONTROLLER_READY_STATUS, 29, 1),
                        new DataField((int)Fields.TOOL_READY_STATUS, 32, 1),
                        new DataField((int)Fields.TIME, 35, 19)
                 });
            }

            public enum Fields
            {
                ALARM_STATUS,
                ERROR_CODE,
                CONTROLLER_READY_STATUS,
                TOOL_READY_STATUS,
                TIME
            }
        }
    }
}
