using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Parameter set data upload reply
    /// Description: 
    ///     Upload of parameter set data reply.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0013 : MID, IParameterSet
    {
        private readonly Dictionary<int, Action> revisionsActions;
        private const int length = 120;
        public const int MID = 13;
        private const int lastRevision = 2;

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
        //Rev 2
        public decimal FirstTarget { get; set; }
        public decimal StartFinalAngle { get; set; }

        public MID_0013(int revision = lastRevision) : base(length, MID, revision)
        {
            this.revisionsActions = new Dictionary<int, Action>()
            {
                { 1, this.buildRevision1 },
                { 2, this.buildRevision2 }
            };
        }

        internal MID_0013(IMID nextTemplate) : base(length, MID, lastRevision)
        {
            this.NextTemplate = nextTemplate;
            this.revisionsActions = new Dictionary<int, Action>()
            {
                { 1, this.processRevision1 },
                { 2, this.processRevision2 }
            };
        }

        public override string BuildPackage()
        {
            for (int i = 1; i <= this.HeaderData.Revision; i++)
                this.revisionsActions[i]();
            return base.BuildPackage();
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.UpdateRevisionFromPackage(package);
                base.ProcessPackage(package);
                for (int i = 1; i <= this.HeaderData.Revision; i++)
                    this.revisionsActions[i]();
                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void loadRevisionsFields()
        {
            base.RevisionsByFields = new Dictionary<int, IEnumerable<DataField>>()
            {
                {
                    1, new DataField[]
                            {
                                new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3, '0'),
                                new DataField((int)DataFields.PARAMETER_SET_NAME, 25, 25, ' '),
                                new DataField((int)DataFields.ROTATION_DIRECTION, 52, 1, '0'),
                                new DataField((int)DataFields.BATCH_SIZE, 55, 2, '0'),
                                new DataField((int)DataFields.MIN_TORQUE, 59, 6, '0'),
                                new DataField((int)DataFields.MAX_TORQUE, 67, 6, '0'),
                                new DataField((int)DataFields.TORQUE_FINAL_TARGET, 75, 6, '0'),
                                new DataField((int)DataFields.MIN_ANGLE, 83, 5, '0'),
                                new DataField((int)DataFields.MAX_ANGLE, 90, 5, '0'),
                                new DataField((int)DataFields.ANGLE_FINAL_TARGET, 97, 5, '0')
                            }
                },
                {
                    2, new DataField []
                            {
                                new DataField((int)DataFields.FIRST_TARGET, 104, 6, '0'),
                                new DataField((int)DataFields.START_FINAL_TARGET, 112, 6, '0')
                            }
                }
            };
        }

        private void processRevision1()
        {
            this.ParameterSetID = base.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].ToInt32();
            this.ParameterSetName = base.RegisteredDataFields[(int)DataFields.PARAMETER_SET_NAME].Value.ToString();
            this.RotationDirection = (RotationDirections)base.RegisteredDataFields[(int)DataFields.ROTATION_DIRECTION].ToInt32();
            this.BatchSize = base.RegisteredDataFields[(int)DataFields.BATCH_SIZE].ToInt32();
            this.MinTorque = base.RegisteredDataFields[(int)DataFields.MIN_TORQUE].ToInt32() / 100;
            this.MaxTorque = base.RegisteredDataFields[(int)DataFields.MAX_TORQUE].ToInt32() / 100;
            this.TorqueFinalTarget = base.RegisteredDataFields[(int)DataFields.TORQUE_FINAL_TARGET].ToInt32();
            this.MinAngle = base.RegisteredDataFields[(int)DataFields.MIN_ANGLE].ToInt32();
            this.MaxAngle = base.RegisteredDataFields[(int)DataFields.MAX_ANGLE].ToInt32();
            this.AngleFinalTarget = base.RegisteredDataFields[(int)DataFields.ANGLE_FINAL_TARGET].ToInt32();
        }

        private void processRevision2()
        {
            this.FirstTarget = base.RegisteredDataFields[(int)DataFields.FIRST_TARGET].ToInt32() / 100;
            this.StartFinalAngle = base.RegisteredDataFields[(int)DataFields.START_FINAL_TARGET].ToInt32() / 100;
        }

        private void buildRevision1()
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
        }

        private void buildRevision2()
        {
            base.RegisteredDataFields[(int)DataFields.FIRST_TARGET].Value = this.FirstTarget;
            base.RegisteredDataFields[(int)DataFields.START_FINAL_TARGET].Value = this.StartFinalAngle;
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
            ANGLE_FINAL_TARGET,
            //Rev 2
            FIRST_TARGET,
            START_FINAL_TARGET
        }

        public enum RotationDirections
        {
            CLOCKWISE = 1,
            COUNTER_CLOCKWISE = 2
        }
    }
}
