using System;

namespace OpenProtocolInterpreter.MIDs.Job
{
    /// <summary>
    /// MID: Job info
    /// Description: 
    ///     The Job info subscriber will receive a Job info message after a Job has been selected and after each
    ///     tightening performed in the Job.The Job info consists of the ID of the currently running Job, the Job
    ///     status, the Job batch mode, the Job batch size and the Job batch counter.
    /// Message sent by: Controller
    /// Answer: MID 0036
    /// </summary>
    public class MID_0035 : MID
    {
        private const int length = 63;
        private const int mid = 35;
        private const int revision = 1;

        public int JobID { get; set; }
        public JobStatuses JobStatus { get; set; }
        public JobBatchModes JobBatchMode { get; set; }
        public int JobBatchSize { get; set; }
        public int JobBatchCounter { get; set; }
        public DateTime TimeStamp { get; set; }

        public MID_0035(int jobId, int jobStatus, int jobBatchMode, int jobBatchSize, int jobBatchCounter, DateTime timestamp) : base(length, mid, revision)
        {
            this.registerDatafields();
            this.constructMe(jobId, (JobStatuses)jobStatus, (JobBatchModes)jobBatchMode, jobBatchSize, jobBatchCounter, timestamp);
        }

        public MID_0035(int jobId, JobStatuses jobStatus, JobBatchModes jobBatchMode, int jobBatchSize, int jobBatchCounter, DateTime timestamp) : base(length, mid, revision)
        {
            this.registerDatafields();
            this.constructMe(jobId, jobStatus, jobBatchMode, jobBatchSize, jobBatchCounter, timestamp);
        }

        public MID_0035(IMID nextTemplate) : base(length, mid, revision)
        {
            this.registerDatafields();
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            this.RegisteredDataFields[(int)DataFields.JOB_ID].Value = this.JobID;
            this.RegisteredDataFields[(int)DataFields.JOB_STATUS].Value = (int)this.JobStatus;
            this.RegisteredDataFields[(int)DataFields.JOB_BATCH_MODE].Value = (int)this.JobBatchMode;
            this.RegisteredDataFields[(int)DataFields.JOB_BATCH_SIZE].Value = this.JobBatchSize;
            this.RegisteredDataFields[(int)DataFields.JOB_BATCH_COUNTER].Value = this.JobBatchCounter;
            this.RegisteredDataFields[(int)DataFields.TIMESTAMP].Value = this.TimeStamp.ToString("yyyy-MM-dd:HH:mm:ss");
            return base.buildPackage();
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processPackage(package);

                this.JobID = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.JOB_ID].Value);
                this.JobStatus = (JobStatuses)Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.JOB_STATUS].Value);
                this.JobBatchMode = (JobBatchModes)Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.JOB_BATCH_MODE].Value);
                this.JobBatchSize = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.JOB_BATCH_SIZE].Value);
                this.JobBatchCounter = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.JOB_BATCH_COUNTER].Value);
                this.TimeStamp = base.RegisteredDataFields[(int)DataFields.TIMESTAMP].ToDateTime();

                return this;
            }

            return this.nextTemplate.processPackage(package);
        }
        
        private void constructMe(int jobId, JobStatuses jobStatus, JobBatchModes jobBatchMode, int jobBatchSize, int jobBatchCounter, DateTime timestamp)
        {
            this.JobID = jobId;
            this.JobStatus = jobStatus;
            this.JobBatchMode = jobBatchMode;
            this.JobBatchSize = jobBatchSize;
            this.JobBatchCounter = jobBatchCounter;
            this.TimeStamp = timestamp;
        }

        private void registerDatafields()
        {
            this.RegisteredDataFields.AddRange(
                new DataField[]
                {
                    new DataField((int)DataFields.JOB_ID, 20, 2),
                    new DataField((int)DataFields.JOB_STATUS, 24, 1),
                    new DataField((int)DataFields.JOB_BATCH_MODE, 27, 1),
                    new DataField((int)DataFields.JOB_BATCH_SIZE, 30, 4),
                    new DataField((int)DataFields.JOB_BATCH_COUNTER, 36, 4),
                    new DataField((int)DataFields.TIMESTAMP, 42, 19)
                });
        }

        public enum DataFields
        {
            JOB_ID,
            JOB_STATUS,
            JOB_BATCH_MODE,
            JOB_BATCH_SIZE,
            JOB_BATCH_COUNTER,
            TIMESTAMP
        }

        public enum JobStatuses
        {
            NOT_COMPLETED = 0,
            OK = 1,
            NOK = 2
        }

        public enum JobBatchModes
        {
            ONLY_OK = 0,
            BOTH_OK_AND_NOK = 1
        }
    }
}
