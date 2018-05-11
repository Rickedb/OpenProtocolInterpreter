using System;

namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Job off
    /// Description: Set the controller in Job off mode or reset the Job off mode.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0130 : Mid, IAdvancedJob
    {
        private const int length = 20;
        public const int MID = 130;
        private const int revision = 1;

        /// <summary>
        /// <para>False => Set Job Off</para>
        /// <para>True => Reset Job Off</para> 
        /// </summary>
        public bool JobOffStatus { get; set; }

        public MID_0130() : base(length, MID, revision) { }

        internal MID_0130(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            return base.BuildHeader() + Convert.ToInt32(JobOffStatus).ToString();
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.ProcessHeader(package);
                JobOffStatus = Convert.ToBoolean(Convert.ToInt32(package.Substring(base.RegisteredDataFields[(int)DataFields.JOB_OFF_STATUS].Index, base.RegisteredDataFields[(int)DataFields.JOB_OFF_STATUS].Size)));
                return this;
            }

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.JOB_OFF_STATUS, 20, 1));
        }

        public enum DataFields
        {
            JOB_OFF_STATUS
        }
    }
}
