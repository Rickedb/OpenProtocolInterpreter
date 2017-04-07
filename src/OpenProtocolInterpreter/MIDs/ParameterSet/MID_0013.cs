namespace OpenProtocolInterpreter.MIDs.ParameterSet
{
    /// <summary>
    /// MID: Parameter set data upload reply
    /// Description: 
    ///     Upload of parameter set data reply.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0013 : MID
    {
        private readonly IMID nextTemplate;

        private const int length = 104;
        private const int mid = 13;
        private const int revision = 1;

        public int ParameterSetID { get; set; }
        public string ParameterSetName { get; set; }
        public RotationDirections RotationDirection { get; set; }
        public int BatchSize { get; set; }
        public decimal MinTorque { get; set; }
        public decimal MaxTorque { get; set; }
        public decimal TorqueFinalTarget { get; set; }
        public int MinAngle { get; set; }
        public int MaxAngle { get; set; }
        public int AngleFinalTarget { get; set; }

        public MID_0013() : base(length, mid, revision) { }

        public MID_0013(int parameterSetId, string parameterSetName, RotationDirections rotationDirection, int batchSize,
                        decimal minTorque, decimal maxTorque, decimal torqueFinalTarget, int minAngle, int maxAngle, 
                        int angleFinalTarget) : base(length, mid, revision)
        {
            this.ParameterSetID = parameterSetId;
            this.ParameterSetName = parameterSetName;
            this.RotationDirection = rotationDirection;
            this.BatchSize = batchSize;
            this.MinTorque = minTorque;
            this.MaxTorque = maxTorque;
            this.TorqueFinalTarget = torqueFinalTarget;
            this.MinAngle = minAngle;
            this.MaxAngle = maxAngle;
            this.AngleFinalTarget = angleFinalTarget;
        }

        internal MID_0013(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {

            base.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Value = this.ParameterSetID;
            base.RegisteredDataFields[(int)DataFields.PARAMETER_SET_NAME].Value = this.ParameterSetName;
            base.RegisteredDataFields[(int)DataFields.ROTATION_DIRECTION].Value = this.RotationDirection;
            base.RegisteredDataFields[(int)DataFields.BATCH_SIZE].Value = this.BatchSize;
            base.RegisteredDataFields[(int)DataFields.MIN_TORQUE].Value = this.MinTorque;
            base.RegisteredDataFields[(int)DataFields.MAX_TORQUE].Value = this.MaxTorque;
            base.RegisteredDataFields[(int)DataFields.TORQUE_FINAL_TARGET].Value = this.TorqueFinalTarget;
            base.RegisteredDataFields[(int)DataFields.MIN_ANGLE].Value = this.MinAngle;
            base.RegisteredDataFields[(int)DataFields.MAX_ANGLE].Value = this.MaxAngle;
            base.RegisteredDataFields[(int)DataFields.ANGLE_FINAL_TARGET].Value = this.AngleFinalTarget;

            return base.buildPackage();
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processPackage(package);

                this.ParameterSetID = base.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].ToInt32();
                this.ParameterSetName = base.RegisteredDataFields[(int)DataFields.PARAMETER_SET_NAME].Value.ToString();
                this.RotationDirection = (RotationDirections)base.RegisteredDataFields[(int)DataFields.ROTATION_DIRECTION].ToInt32();
                this.BatchSize = base.RegisteredDataFields[(int)DataFields.BATCH_SIZE].ToInt32() / 100;
                this.MinTorque = base.RegisteredDataFields[(int)DataFields.MIN_TORQUE].ToInt32() / 100;
                this.MaxTorque = base.RegisteredDataFields[(int)DataFields.MAX_TORQUE].ToInt32() / 100;
                this.TorqueFinalTarget = base.RegisteredDataFields[(int)DataFields.TORQUE_FINAL_TARGET].ToInt32();
                this.MinAngle = base.RegisteredDataFields[(int)DataFields.MIN_ANGLE].ToInt32();
                this.MaxAngle = base.RegisteredDataFields[(int)DataFields.MAX_ANGLE].ToInt32();
                this.AngleFinalTarget = base.RegisteredDataFields[(int)DataFields.ANGLE_FINAL_TARGET].ToInt32();

                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        private void registerDatafields()
        {
            this.RegisteredDataFields.AddRange(
                new DataField[]
                {
                    new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3),
                    new DataField((int)DataFields.PARAMETER_SET_NAME, 25, 25),
                    new DataField((int)DataFields.ROTATION_DIRECTION, 52, 1),
                    new DataField((int)DataFields.BATCH_SIZE, 55, 2),
                    new DataField((int)DataFields.MIN_TORQUE, 59, 6),
                    new DataField((int)DataFields.MAX_TORQUE, 67, 6),
                    new DataField((int)DataFields.TORQUE_FINAL_TARGET, 75, 6),
                    new DataField((int)DataFields.MIN_ANGLE, 83, 5),
                    new DataField((int)DataFields.MAX_ANGLE, 90, 5),
                    new DataField((int)DataFields.ANGLE_FINAL_TARGET, 97, 5)
                });
        }

        public enum DataFields
        {
            PARAMETER_SET_ID,
            PARAMETER_SET_NAME,
            ROTATION_DIRECTION,
            BATCH_SIZE,
            MIN_TORQUE,
            MAX_TORQUE,
            TORQUE_FINAL_TARGET,
            MIN_ANGLE,
            MAX_ANGLE,
            ANGLE_FINAL_TARGET
        }

        public enum RotationDirections
        {
            CLOCKWISE = 1,
            COUNTER_CLOCKWISE = 2
        }
    }
}
