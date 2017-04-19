using System;

namespace OpenProtocolInterpreter.MIDs.Tool
{
    /// <summary>
    /// MID: Tool data upload reply
    /// Description: 
    ///     Upload of tool data from the controller.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0041 : MID, ITool
    {
        private const int length = 81;
        private const int mid = 41;
        private const int revision = 1;

        public string ToolSerialNumber { get; set; }
        public int ToolNumberOfTIghtenings { get; set; }
        public DateTime LastCalibrationDate { get; set; }
        public string ControllerSerialNumber { get; set; }

        public MID_0041() : base(length, mid, revision) { }

        public MID_0041(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            this.RegisteredDataFields[(int)DataFields.TOOL_SERIAL_NUMBER].Value = this.ToolSerialNumber;
            this.RegisteredDataFields[(int)DataFields.TOOL_NUMBER_OF_TIGHTENINGS].Value = this.ToolNumberOfTIghtenings;
            this.RegisteredDataFields[(int)DataFields.LAST_CALIBRATION_DATE].Value = this.LastCalibrationDate.ToString("yyyy-MM-dd:HH:mm:ss");
            this.RegisteredDataFields[(int)DataFields.CONTROLLER_SERIAL_NUMBER].Value = this.ControllerSerialNumber;

            return base.buildPackage();
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processPackage(package);

                this.ToolSerialNumber = this.RegisteredDataFields[(int)DataFields.TOOL_SERIAL_NUMBER].Value.ToString();
                this.ToolNumberOfTIghtenings = this.RegisteredDataFields[(int)DataFields.TOOL_NUMBER_OF_TIGHTENINGS].ToInt32();
                this.LastCalibrationDate = this.RegisteredDataFields[(int)DataFields.LAST_CALIBRATION_DATE].ToDateTime();
                this.ControllerSerialNumber = this.RegisteredDataFields[(int)DataFields.CONTROLLER_SERIAL_NUMBER].Value.ToString();

                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() 
        {
            this.RegisteredDataFields.AddRange(new DataField[]
            {
                new DataField((int)DataFields.TOOL_SERIAL_NUMBER, 20, 14),
                new DataField((int)DataFields.TOOL_NUMBER_OF_TIGHTENINGS, 36, 10),
                new DataField((int)DataFields.LAST_CALIBRATION_DATE, 48, 19),
                new DataField((int)DataFields.CONTROLLER_SERIAL_NUMBER, 69, 10)
            });

        }

        public enum DataFields
        {
            TOOL_SERIAL_NUMBER,
            TOOL_NUMBER_OF_TIGHTENINGS,
            LAST_CALIBRATION_DATE,
            CONTROLLER_SERIAL_NUMBER
        }
    }
}
