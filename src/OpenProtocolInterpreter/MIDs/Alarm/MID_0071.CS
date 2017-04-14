using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MIDs.Alarm
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
    public class MID_0071 : MID
    {
        private readonly IMID nextTemplate;

        private const int length = 53;
        private const int mid = 71;
        private const int revision = 1;

        public Alarms AlarmData { get; set; }

        public MID_0071() : base(length, mid, revision)
        {

        }

        public MID_0071(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                this.AlarmData = new Alarms().getAlarmFromPackage(package);
                return this;
            }
                

            return this.nextTemplate.processPackage(package);
        }

        private void registerDatafields()
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

            public Alarms() { this.registerFields(); }

            public Alarms getAlarmFromPackage(string package)
            {
                this.processFields(package);
                Alarms alarm = new Alarms();

                this.ErrorCode = this.fields[(int)Fields.ERROR_CODE].ToString();
                this.ControllerReadyStatus = this.fields[(int)Fields.CONTROLLER_READY_STATUS].ToBoolean();
                this.ToolReadyStatus = this.fields[(int)Fields.TOOL_READY_STATUS].ToBoolean();
                this.Time = this.fields[(int)Fields.TIME].ToDateTime();

                return alarm;
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
