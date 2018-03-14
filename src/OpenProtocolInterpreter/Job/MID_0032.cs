using System;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// MID: Job data upload request
    /// Description:
    ///     Request to upload the data for a specific Job from the controller.
    /// Message sent by: Integrator
    /// Answer: MID 0033 Job data upload or MID 0004 Command error, Job ID not present
    /// </summary>
    public class MID_0032 : MID, IJob
    {
        private const int length = 22;
        public const int MID = 32;
        private const int revision = 1;

        public int JobID { get; set; }

        public MID_0032() : base(length, MID, revision) { }

        public MID_0032(int jobId) : base(length, MID, revision) { this.JobID = jobId; }

        internal MID_0032(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            string package = base.BuildHeader();
            package += this.JobID.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.JOB_ID].Size, '0');
            return package;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                this.HeaderData = base.ProcessHeader(package);

                var datafield = this.RegisteredDataFields[(int)DataFields.JOB_ID];
                this.JobID = Convert.ToInt32(package.Substring(datafield.Index, datafield.Size));

                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }


        protected override void RegisterDatafields() 
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.JOB_ID, 20, 2));
        }

        public enum DataFields
        {
            JOB_ID
        }
    }
}
