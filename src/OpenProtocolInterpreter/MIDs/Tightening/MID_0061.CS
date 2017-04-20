using System;

namespace OpenProtocolInterpreter.MIDs.Tightening
{
    /// <summary>
    /// MID: Last tightening result data
    /// Description: Upload the last tightening result.
    /// Message sent by: Controller
    /// Answer: MID 0062 Last tightening result data acknowledge
    /// </summary>
    public class MID_0061 : MID, ITightening
    {
        private const int length = 231;
        public const int MID = 61;
        private const int revision = 1;

        public int CellID { get; set; }
        public int ChannelID { get; set; }
        public string TorqueControllerName { get; set; }
        public string VINNumber { get; set; }
        public int JobID { get; set; }
        public int ParameterSetID { get; set; }
        public int BatchSize { get; set; }
        public int BatchCounter { get; set; }
        public bool TighteningStatus { get; set; }
        public TighteningValuesStatuses TorqueStatus { get; set; }
        public TighteningValuesStatuses AngleStatus { get; set; }
        public decimal TorqueMinLimit { get; set; }
        public decimal TorqueMaxLimit { get; set; }
        public decimal TorqueFinalTarget { get; set; }
        public decimal Torque { get; set; }
        public int AngleMinLimit { get; set; }
        public int AngleMaxLimit { get; set; }
        public int AngleFinalTarget { get; set; }
        public int Angle { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime LastChangeInParameterSet { get; set; }
        public BatchStatuses BatchStatus { get; set; }
        public int TighteningID { get; set; }

        public MID_0061() : base(length, MID, revision) {  }

        internal MID_0061(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processPackage(package);

                this.CellID = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.CELL_ID].Value);
                this.ChannelID = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.CHANNEL_ID].Value);
                this.TorqueControllerName = base.RegisteredDataFields[(int)DataFields.TORQUE_CONTROLLER_NAME].Value.ToString();
                this.VINNumber = base.RegisteredDataFields[(int)DataFields.VIN_NUMBER].Value.ToString();
                this.JobID = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.JOB_ID].Value);
                this.ParameterSetID = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Value);
                this.BatchSize = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.BATCH_SIZE].Value);
                this.BatchCounter = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.BATCH_COUNTER].Value);
                this.TighteningStatus = Convert.ToBoolean(Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.TIGHTENING_STATUS].Value));
                this.TorqueStatus = (TighteningValuesStatuses)Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.TORQUE_STATUS].Value);
                this.AngleStatus = (TighteningValuesStatuses)Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.ANGLE_STATUS].Value);
                this.TorqueMinLimit = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.TORQUE_MIN_LIMIT].Value) / 100;
                this.TorqueMaxLimit = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.TORQUE_MAX_LIMIT].Value) / 100;
                this.TorqueFinalTarget = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.TORQUE_FINAL_TARGET].Value) / 100;
                this.Torque= Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.TORQUE].Value) / 100;
                this.AngleMinLimit = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.ANGLE_MIN_LIMIT].Value);
                this.AngleMaxLimit = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.ANGLE_MAX_LIMIT].Value);
                this.AngleFinalTarget = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.ANGLE_FINAL_TARGET].Value);
                this.Angle = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.ANGLE].Value);
                this.TimeStamp = base.RegisteredDataFields[(int)DataFields.TIMESTAMP].ToDateTime();
                this.LastChangeInParameterSet = base.RegisteredDataFields[(int)DataFields.LAST_CHANGE_IN_PARAMETER_SET].ToDateTime();
                this.BatchStatus = (BatchStatuses)Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.ANGLE_STATUS].Value);
                this.TighteningID = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.TIGHTENING_ID].Value);

                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields()
        {
            this.RegisteredDataFields.AddRange(
                new DataField[]
                {
                    new DataField((int)DataFields.CELL_ID, 20, 4),
                    new DataField((int)DataFields.CHANNEL_ID, 26, 2),
                    new DataField((int)DataFields.TORQUE_CONTROLLER_NAME, 30, 25),
                    new DataField((int)DataFields.VIN_NUMBER, 57, 25),
                    new DataField((int)DataFields.JOB_ID, 84, 2),
                    new DataField((int)DataFields.PARAMETER_SET_ID, 88, 3),
                    new DataField((int)DataFields.BATCH_SIZE, 93, 4),
                    new DataField((int)DataFields.BATCH_COUNTER, 99, 4),
                    new DataField((int)DataFields.TIGHTENING_STATUS, 105, 1),
                    new DataField((int)DataFields.TORQUE_STATUS, 108, 1),
                    new DataField((int)DataFields.ANGLE_STATUS, 111, 1),
                    new DataField((int)DataFields.TORQUE_MIN_LIMIT, 114, 6),
                    new DataField((int)DataFields.TORQUE_MAX_LIMIT, 122, 6),
                    new DataField((int)DataFields.TORQUE_FINAL_TARGET, 130, 6),
                    new DataField((int)DataFields.TORQUE, 138, 6),
                    new DataField((int)DataFields.ANGLE_MIN_LIMIT, 146, 5),
                    new DataField((int)DataFields.ANGLE_MAX_LIMIT, 153, 5),
                    new DataField((int)DataFields.ANGLE_FINAL_TARGET, 160, 5),
                    new DataField((int)DataFields.ANGLE, 167, 5),
                    new DataField((int)DataFields.TIMESTAMP, 174, 19),
                    new DataField((int)DataFields.LAST_CHANGE_IN_PARAMETER_SET, 195, 19),
                    new DataField((int)DataFields.BATCH_STATUS, 216, 1),
                    new DataField((int)DataFields.TIGHTENING_ID, 219, 10)
                });
        }

        public enum DataFields
        {
            CELL_ID,
            CHANNEL_ID,
            TORQUE_CONTROLLER_NAME,
            VIN_NUMBER,
            JOB_ID,
            PARAMETER_SET_ID,
            BATCH_SIZE,
            BATCH_COUNTER,
            TIGHTENING_STATUS,
            TORQUE_STATUS,
            ANGLE_STATUS,
            TORQUE_MIN_LIMIT,
            TORQUE_MAX_LIMIT,
            TORQUE_FINAL_TARGET,
            TORQUE,
            ANGLE_MIN_LIMIT,
            ANGLE_MAX_LIMIT,
            ANGLE_FINAL_TARGET,
            ANGLE,
            TIMESTAMP,
            LAST_CHANGE_IN_PARAMETER_SET,
            BATCH_STATUS,
            TIGHTENING_ID
        }

        public enum TighteningValuesStatuses
        {
            LOW,
            OK,
            HIGH
        }

        public enum BatchStatuses
        {
            NOK,
            OK,
            NOT_USED
        }
    }
}
