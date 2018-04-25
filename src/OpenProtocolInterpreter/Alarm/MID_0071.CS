using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// MID: Alarm
    /// Description: 
    ///      An alarm has appeared in the controller. 
    ///      The current alarm is uploaded from the controller to the integrator.
    /// 
    /// Message sent by: Controller
    /// Answer: MID 0072 Alarm acknowledge
    /// </summary>
    public class MID_0071 : Mid, IAlarm
    {
        private const int length = 53;
        public const int MID = 71;
        private const int revision = 1;

        public Alarms AlarmData { get; set; }

        public MID_0071() : base(length, MID, revision)
        {
            AlarmData = new Alarms();
        }

        internal MID_0071(IMid nextTemplate) : base(length, MID, revision)
        {
            AlarmData = new Alarms();
            NextTemplate = nextTemplate;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                AlarmData = new Alarms().getAlarmFromPackage(package);
                return this;
            }
                

            return NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.ALARM_DATA, 20, 33));
        }

        public enum DataFields
        {
            ALARM_DATA
        }

        public class Alarms
        {
            private List<DataField> fields;
            public string ErrorCode { get; set; }
            public bool ControllerReadyStatus { get; set; }
            public bool ToolReadyStatus { get; set; }
            public DateTime Time { get; set; }

            public Alarms() { registerFields(); }

            public Alarms getAlarmFromPackage(string package)
            {
                processFields(package);

                ErrorCode = fields[(int)Fields.ERROR_CODE].ToString();
                ControllerReadyStatus = fields[(int)Fields.CONTROLLER_READY_STATUS].ToBoolean();
                ToolReadyStatus = fields[(int)Fields.TOOL_READY_STATUS].ToBoolean();
                Time = fields[(int)Fields.TIME].ToDateTime();

                return this;
            }

            public override string ToString()
            {
                string package = string.Empty;

                return base.ToString();
            }

            private void processFields(string package)
            {
                foreach (var field in fields)
                    field.Value = package.Substring(2 + field.Index, field.Size);
            }

            private void registerFields()
            {
                fields = new List<DataField>();
                fields.AddRange(new DataField[] {
                        new DataField((int)Fields.ERROR_CODE, 20, 4),
                        new DataField((int)Fields.CONTROLLER_READY_STATUS, 26, 1),
                        new DataField((int)Fields.TOOL_READY_STATUS, 29, 1),
                        new DataField((int)Fields.TIME, 32, 19)
                 });
            }

            public enum Fields
            {
                ERROR_CODE,
                CONTROLLER_READY_STATUS,
                TOOL_READY_STATUS,
                TIME
            }
        }
    }
}
