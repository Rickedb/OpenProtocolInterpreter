using System;

namespace OpenProtocolInterpreter.MotorTuning
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
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            return base.BuildHeader() + Convert.ToInt32(this.MotorTuneResult).ToString();
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                this.HeaderData = this.ProcessHeader(package);
                var dataField = base.RegisteredDataFields[(int)DataFields.MOTOR_TUNE_RESULT];
                dataField.Value = package.Substring(dataField.Index, dataField.Size);
                this.MotorTuneResult = dataField.ToBoolean();
                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.MOTOR_TUNE_RESULT, 20, 1));
        }



        public enum DataFields
        {
            MOTOR_TUNE_RESULT
        }
    }
}
