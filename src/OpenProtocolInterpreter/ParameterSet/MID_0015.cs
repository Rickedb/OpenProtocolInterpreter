using OpenProtocolInterpreter.Helpers;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Parameter set selected
    /// Description: 
    ///     A new parameter set is selected in the controller. 
    ///     The message includes the ID of the parameter set selected as well as the date and time of the 
    ///     last change in the parameter set settings. This message is also sent as an immediate response to MID 0014 
    ///     Parameter set selected subscribe.
    /// Message sent by: Controller
    /// Answer: MID 0016 New parameter set selected acknowledge
    /// </summary>
    public class MID_0015 : MID, IParameterSet
    {
        private const int length = 42;
        public const int MID = 15;
        private const int lastRevision = 2;

        public int ParameterSetID { get; set; }
        public DateTime LastChangeInParameterSet { get; set; }
        //Rev 2
        public string ParameterSetName { get; set; }
        public RotationDirections RotationDirection { get; set; }
        public int BatchSize { get; set; }
        public float TorqueMin { get; set; }
        public float TorqueMax { get; set; }
        public float TorqueFinalTarget { get; set; }
        public int AngleMin { get; set; }
        public int AngleMax { get; set; }
        public int FinalAngleTarget { get; set; }
        public float FirstTarget { get; set; }
        public float StartFinalAngle { get; set; }

        public MID_0015(int revision = lastRevision) : base(length, MID, revision) { }

        internal MID_0015(IMID nextTemplate) : base(length, MID, lastRevision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            if (base.HeaderData.Revision == 1)
            {
                string package = base.BuildHeader();
                package += this.ParameterSetID.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Size, '0');
                package += this.LastChangeInParameterSet.ToString("yyyy-MM-dd:HH:mm:ss");
                return package;
            }
            else
            {
                return string.Empty;
            }
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.UpdateRevisionFromPackage(package);
                if (base.HeaderData.Revision == 1)
                    this.processRevision1(package);
                else
                    this.processRevision2(package);
                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void loadRevisionsFields()
        {
            base.RevisionsByFields = new Dictionary<int, IEnumerable<DataField>>()
            {
                {
                    1, new DataField[] { } //Way too diferent from common way, so it will be done manually
                },
                {
                    2, new DataField []
                            {
                                new DataField((int)DataFields.PARAMETER_SET_ID, 20, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.PARAMETER_SET_NAME, 25, 25, ' '),
                                new DataField((int)DataFields.LAST_CHANGE_IN_PARAMETER_SET, 52, 19),
                                new DataField((int)DataFields.ROTATION_DIRECTION, 73, 1),
                                new DataField((int)DataFields.BATCH_SIZE, 76, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_MIN, 80, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_MAX, 88, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TORQUE_FINAL_TARGET, 96, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE_MIN, 104, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.ANGLE_MAX, 110, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.FINAL_ANGLE_TARGET, 117, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.FIRST_TARGET, 124, 6, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.START_FINAL_ANGLE, 132, 6, '0', DataField.PaddingOrientations.LEFT_PADDED)

                            }
                }
            };
        }

        private void processRevision1(string package)
        {
            this.HeaderData = base.ProcessHeader(package);
            this.ParameterSetID = Convert.ToInt32(package.Substring(20, 3));
            this.LastChangeInParameterSet = new DataField(1, "23", 19, package.Substring(23, 19)).ToDateTime();
        }

        private void processRevision2(string package)
        {
            base.ProcessPackage(package);
            this.ParameterSetID = base.RegisteredDataFields.getDataField((int)DataFields.PARAMETER_SET_ID).ToInt32();
            this.ParameterSetName = base.RegisteredDataFields.getDataField((int)DataFields.PARAMETER_SET_NAME).ToString();
            this.LastChangeInParameterSet = base.RegisteredDataFields.getDataField((int)DataFields.LAST_CHANGE_IN_PARAMETER_SET).ToDateTime();
            this.RotationDirection = (RotationDirections)base.RegisteredDataFields.getDataField((int)DataFields.ROTATION_DIRECTION).ToInt32();
            this.BatchSize = base.RegisteredDataFields.getDataField((int)DataFields.BATCH_SIZE).ToInt32();
            this.TorqueMin = base.RegisteredDataFields.getDataField((int)DataFields.TORQUE_MIN).ToFloat();
            this.TorqueMax = base.RegisteredDataFields.getDataField((int)DataFields.TORQUE_MAX).ToFloat();
            this.TorqueFinalTarget = base.RegisteredDataFields.getDataField((int)DataFields.TORQUE_FINAL_TARGET).ToFloat();
            this.AngleMin = base.RegisteredDataFields.getDataField((int)DataFields.ANGLE_MIN).ToInt32();
            this.AngleMax = base.RegisteredDataFields.getDataField((int)DataFields.ANGLE_MAX).ToInt32();
            this.FinalAngleTarget = base.RegisteredDataFields.getDataField((int)DataFields.FINAL_ANGLE_TARGET).ToInt32();
            this.FirstTarget = base.RegisteredDataFields.getDataField((int)DataFields.FIRST_TARGET).ToFloat();
            this.StartFinalAngle = base.RegisteredDataFields.getDataField((int)DataFields.START_FINAL_ANGLE).ToFloat();
        }

        private string buildRevision1()
        {
            return this.ParameterSetID.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.PARAMETER_SET_ID].Size, '0');
        }

        private string buildRevision2()
        {
            base.RegisteredDataFields.getDataField((int)DataFields.PARAMETER_SET_ID).setPaddedLeftValue(this.ParameterSetID);
            base.RegisteredDataFields.getDataField((int)DataFields.PARAMETER_SET_NAME).setPaddedLeftValue(this.ParameterSetName);
            base.RegisteredDataFields.getDataField((int)DataFields.LAST_CHANGE_IN_PARAMETER_SET).setDateTime(this.LastChangeInParameterSet);
            base.RegisteredDataFields.getDataField((int)DataFields.ROTATION_DIRECTION).setPaddedLeftValue(this.RotationDirection);
            base.RegisteredDataFields.getDataField((int)DataFields.PARAMETER_SET_ID).setPaddedLeftValue(this.ParameterSetID);
            base.RegisteredDataFields.getDataField((int)DataFields.PARAMETER_SET_ID).setPaddedLeftValue(this.ParameterSetID);
            base.RegisteredDataFields.getDataField((int)DataFields.PARAMETER_SET_ID).setPaddedLeftValue(this.ParameterSetID);
            base.RegisteredDataFields.getDataField((int)DataFields.PARAMETER_SET_ID).setPaddedLeftValue(this.ParameterSetID);
            base.RegisteredDataFields.getDataField((int)DataFields.PARAMETER_SET_ID).setPaddedLeftValue(this.ParameterSetID);
            base.RegisteredDataFields.getDataField((int)DataFields.PARAMETER_SET_ID).setPaddedLeftValue(this.ParameterSetID);
            base.RegisteredDataFields.getDataField((int)DataFields.PARAMETER_SET_ID).setPaddedLeftValue(this.ParameterSetID);
            base.RegisteredDataFields.getDataField((int)DataFields.PARAMETER_SET_ID).setPaddedLeftValue(this.ParameterSetID);
            return this.BuildPackage();
        }

        public enum RotationDirections
        {
            CLOCKWISE = 1,
            COUNTER_CLOCKWISE = 2
        }

        public enum DataFields
        {
            PARAMETER_SET_ID,
            LAST_CHANGE_IN_PARAMETER_SET,
            //Rev 2
            PARAMETER_SET_NAME,
            ROTATION_DIRECTION,
            BATCH_SIZE,
            TORQUE_MIN,
            TORQUE_MAX,
            TORQUE_FINAL_TARGET,
            ANGLE_MIN,
            ANGLE_MAX,
            FINAL_ANGLE_TARGET,
            FIRST_TARGET,
            START_FINAL_ANGLE
        }
    }
}
