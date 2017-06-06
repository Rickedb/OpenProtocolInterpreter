using System;

namespace OpenProtocolInterpreter.MIDs.MotorTuning
{
    /// <summary>
    /// MID: Motor tuning result data
    /// Description: 
    ///     Upload the last motor tuning result.
    /// Message sent by: Controller
    /// Answer: MID 0502 Motor tuning result data acknowledge
    /// </summary>
    public class MID_0501 : MID, IMotorTuning
    {
        public const int MID = 501;
        private const int length = 21;
        private const int revision = 1;

        /// <summary>
        /// <para>Motor Tune Failed = false (0)</para>
        /// <para>Motor Tune Success = true (1)</para>
        /// </summary>
        public bool MotorTuneResult { get; set; }

        public MID_0501() : base(length, MID, revision) { }

        public MID_0501(bool motorTuneResult) : base(length, MID, revision)
        {
            this.MotorTuneResult = motorTuneResult;
        }

        internal MID_0501(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            return base.buildHeader() + Convert.ToInt32(this.MotorTuneResult).ToString();
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                this.HeaderData = this.processHeader(package);
                var dataField = base.RegisteredDataFields[(int)DataFields.MOTOR_TUNE_RESULT];
                dataField.Value = package.Substring(dataField.Index, dataField.Size);
                this.MotorTuneResult = dataField.ToBoolean();
                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.MOTOR_TUNE_RESULT, 20, 1));
        }



        public enum DataFields
        {
            MOTOR_TUNE_RESULT
        }
    }
}
