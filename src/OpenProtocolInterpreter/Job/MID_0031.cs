using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// MID: Job ID upload reply
    /// Description:
    ///     The transmission of all the valid Job IDs of the controller. 
    ///     The data field contains the number of valid Jobs currently present in the controller, and the ID of each Job.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0031 : MID, IJob
    {
        private const int length = 24;
        public const int MID = 31;
        private const int revision = 1;

        public int TotalJobs { get; private set; }
        public List<int> JobIds { get; set; }

        public MID_0031() : base(length, MID, revision) { this.JobIds = new List<int>(); }

        internal MID_0031(IMID nextTemplate) : base(length, MID, revision)
        {
            this.JobIds = new List<int>();
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            if (this.JobIds.Count == 0)
                throw new ArgumentException("Job IDs list cannot be empty!!");

            string package = base.BuildHeader();
            package += this.JobIds.Count.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.NUMBER_OF_JOBS].Size, '0');

            var datafield = this.RegisteredDataFields[(int)DataFields.EACH_JOB_ID];
            foreach (int param in this.JobIds)
                package += param.ToString().PadLeft(datafield.Size, '0');

            return package;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                this.HeaderData = base.ProcessHeader(package);

                var datafield = this.RegisteredDataFields[(int)DataFields.NUMBER_OF_JOBS];
                this.TotalJobs = Convert.ToInt32(package.Substring(datafield.Index, datafield.Size));

                datafield = this.RegisteredDataFields[(int)DataFields.EACH_JOB_ID];
                int packageIndex = datafield.Index;
                for (int i = 0; i < this.TotalJobs; i++)
                {
                    this.JobIds.Add(Convert.ToInt32(package.Substring(packageIndex, datafield.Size)));
                    packageIndex += datafield.Size;
                }

                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.AddRange(
                new DataField[]
                {
                    new DataField((int)DataFields.NUMBER_OF_JOBS, 20, 2),
                    new DataField((int)DataFields.EACH_JOB_ID, 22, 2),
                });
        }

        public enum DataFields
        {
            NUMBER_OF_JOBS,
            EACH_JOB_ID
        }
    }
}
