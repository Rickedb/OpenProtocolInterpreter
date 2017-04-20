using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.Job
{
    /// <summary>
    /// MID: Job data upload reply
    /// Description:
    ///     This message is sent as a reply to the MID 0032 Job data request.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0033 : MID, IJob
    {
        private const int length = 20;
        public const int MID = 33;
        private const int revision = 1;

        public JobDatas JobData { get; set; }

        public MID_0033() : base(length, MID, revision) {  }

        internal MID_0033(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            string package = base.buildHeader();
            package += this.JobData.ToString();
            return package;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                this.HeaderData = base.processHeader(package);
                this.JobData = new JobDatas().getJobDataFromPackage(package);
                return this;
            }

            return this.nextTemplate.processPackage(package);
        }


        protected override void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.JOB_DATA, 20, 71));
        }

        public enum DataFields
        {
            JOB_DATA
        }

        public class JobDatas
        {
            private List<DataField> fields;
            public int JobID { get; set; }
            public string JobName { get; set; }
            public ForcedOrders ForcedOrder { get; set; }
            public int MaxTimeForFirstTightening { get; set; }
            public int MaxTimeToCompleteJob { get; set; }
            public JobBatchModes JobBatchMode { get; set; }
            public bool LockAtJobDone { get; set; }
            public bool UseLineControl { get; set; }
            public bool RepeatJob { get; set; }
            public ToolLoosenings ToolLoosening { get; set; }
            public Reserveds Reserved { get; set; }
            public int NumberOfParameterSets { get; set; }
            public List<Jobs> JobList { get; set; }

            public JobDatas() { this.JobList = new List<Jobs>(); this.registerFields(); }

            public JobDatas getJobDataFromPackage(string package)
            {
                this.processFields(package);
                JobDatas jobData = new JobDatas();

                this.JobID = this.fields[(int)Fields.JOB_ID].ToInt32();
                this.JobName = this.fields[(int)Fields.JOB_NAME].ToString();
                this.ForcedOrder = (ForcedOrders)this.fields[(int)Fields.FORCED_ORDER].ToInt32();
                this.MaxTimeForFirstTightening = this.fields[(int)Fields.MAX_TIME_FOR_FIRST_TIGHTENING].ToInt32();
                this.MaxTimeToCompleteJob = this.fields[(int)Fields.MAX_TIME_TO_COMPLETE_JOB].ToInt32();
                this.JobBatchMode = (JobBatchModes)this.fields[(int)Fields.JOB_BATCH_MODE].ToInt32();
                this.LockAtJobDone = this.fields[(int)Fields.LOCK_AT_JOB_DONE].ToBoolean();
                this.UseLineControl = this.fields[(int)Fields.USE_LINE_CONTROL].ToBoolean();
                this.RepeatJob = this.fields[(int)Fields.REPEAT_JOB].ToBoolean();
                this.ToolLoosening = (ToolLoosenings)this.fields[(int)Fields.TOOL_LOOSENING].ToInt32();
                this.Reserved = (Reserveds)this.fields[(int)Fields.RESERVED].ToInt32();
                this.NumberOfParameterSets = this.fields[(int)Fields.NUMBER_OF_PARAMETER_SETS].ToInt32();

                jobData.JobList = new Jobs().getJobsFromPackage(package.Substring(89));
                return jobData;
            }

            public override string ToString()
            {
                string package = string.Empty;

                foreach (var dataField in this.fields)
                    dataField.Value = package.Substring(2 + dataField.Index, dataField.Size);
                for (int i = 1; i < this.fields.Count + 1; i++)
                    package += i.ToString().PadLeft(2, '0') + fields[i - 1].getPaddedLeftValue();
                foreach (Jobs job in this.JobList)
                    package += job.ToString();

                return base.ToString();
            }

            private void processFields(string package)
            {
                foreach (var field in this.fields)
                    field.Value = package.Substring(2 + field.Index, field.Size);
            }

            private void registerFields()
            {
                this.fields = new List<DataField>();
                this.fields.AddRange(new DataField[] {
                        new DataField((int)Fields.JOB_ID, 20, 2),
                        new DataField((int)Fields.JOB_NAME, 24, 25),
                        new DataField((int)Fields.FORCED_ORDER, 51, 1),
                        new DataField((int)Fields.MAX_TIME_FOR_FIRST_TIGHTENING, 54, 4),
                        new DataField((int)Fields.MAX_TIME_TO_COMPLETE_JOB, 60, 5),
                        new DataField((int)Fields.JOB_BATCH_MODE, 67, 1),
                        new DataField((int)Fields.LOCK_AT_JOB_DONE, 70, 1),
                        new DataField((int)Fields.USE_LINE_CONTROL, 73, 1),
                        new DataField((int)Fields.REPEAT_JOB, 76, 1),
                        new DataField((int)Fields.TOOL_LOOSENING, 79, 1),
                        new DataField((int)Fields.RESERVED, 82, 1),
                        new DataField((int)Fields.NUMBER_OF_PARAMETER_SETS, 85, 2)
                 });
            }

            public enum Fields
            {
                JOB_ID,
                JOB_NAME,
                FORCED_ORDER,
                MAX_TIME_FOR_FIRST_TIGHTENING,
                MAX_TIME_TO_COMPLETE_JOB,
                JOB_BATCH_MODE,
                LOCK_AT_JOB_DONE,
                USE_LINE_CONTROL,
                REPEAT_JOB,
                TOOL_LOOSENING,
                RESERVED,
                NUMBER_OF_PARAMETER_SETS
            }

            public enum ForcedOrders
            {
                FREE_ORDER = 0,
                FORCED_ORDER = 1,
                FREE_AND_FORCED_ORDER = 2
            }

            public enum JobBatchModes
            {
                ONLY_OK_TIGHTENINGS = 0,
                OK_AND_NOK_TIGHTENINGS = 1
            }

            public enum ToolLoosenings
            {
                ENABLED = 0,
                DISABLED = 1,
                ENABLE_ONLY_ON_NOK_TIGHTENINGS = 2
            }

            public enum Reserveds
            {
                E = 0,
                G = 1
            }

            public class Jobs
            {
                public int ChannelID { get; set; }
                public int TypeID { get; set; }
                public bool AutoValue { get; set; }
                public int BatchSize { get; set; }

                public List<Jobs> getJobsFromPackage(string package)
                {
                    List<Jobs> jobs = new List<Jobs>();

                    var stringJobs = package.Substring(91).Split(';');
                    foreach (string job in stringJobs)
                    {
                        var jobParams = job.Split(':');
                        if (jobParams.Count() == 4)
                            jobs.Add(new Jobs()
                            {
                                ChannelID = Convert.ToInt32(jobParams[0]),
                                TypeID = Convert.ToInt32(jobParams[1]),
                                AutoValue = Convert.ToBoolean(Convert.ToInt32(jobParams[2])),
                                BatchSize = Convert.ToInt32(jobParams[3])
                            });
                    }

                    return jobs;
                }

                public override string ToString()
                {
                    return string.Join(":",
                        new string[]{
                            this.ChannelID.ToString().PadLeft(2, '0'),
                            this.TypeID.ToString().PadLeft(3, '0'),
                            Convert.ToInt32(this.AutoValue).ToString(),
                            this.BatchSize.ToString().PadLeft(2, '0')
                        }) + ";";
                }
            }
        }
    }
}
