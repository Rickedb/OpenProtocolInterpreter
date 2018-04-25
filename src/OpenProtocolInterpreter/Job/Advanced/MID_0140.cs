using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// MID: Execute dynamic Job request
    /// Description: The integrator requests a dynamical Job to be executed i.e. the Job sent from the integrator is
    /// immediately executed(if possible) by the controller but not saved in the memory.A dynamical Job
    /// lifetime is the time for the Job to be executed.If the controller is powered off before the completion of
    /// the Job, the dynamical Job is lost.
    /// 
    /// Do note the limitation when sending this message on a serial connection due to the size of the read buffer 
    /// (256 bytes) in the controller. 
    /// In such case the number of programs in the Job list is limited.
    /// The following revisions are available for this MID.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0140 : Mid, IAdvancedJob
    {
        private const int length = 20;
        public const int MID = 140;
        private const int revision = 1;
        

        public int JobID { get; set; }
        public string JobName { get; set; }
        public int NumberOfParameterSets { get; set; }
        public List<Job> JobList { get; set; }
        public ForcedOrders ForcedOrder { get; set; }
        public bool LockAtJobDone { get; set; }
        public ToolLoosenings ToolLoosening { get; set; }
        public bool RepeatJob { get; set; }
        public BatchModes BatchMode { get; set; }
        public bool BatchStatusAtIncrement { get; set; }
        public bool DecrementBatchAtOKLoosening { get; set; }
        public int MaxTimeForFirstTightening { get; set; }
        public int MaxTimeToCompleteJob { get; set; }
        public int DisplayResultAtAutoSelect { get; set; }
        public bool UsingLineControl{ get; set; }
        public IdentifierPart IdentifierResultPartOne { get; set; }
        public bool ResultOfNonTightenings { get; set; }
        public bool ResetAllIdentifiersAtJobDone { get; set; }
        public Reserveds Reserved { get; set; }

        public MID_0140() : base(length, MID, revision) { JobList = new List<Job>(); }

        internal MID_0140(IMid nextTemplate) : base(length, MID, revision)
        {
            JobList = new List<Job>();
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            return base.BuildPackage();
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                NumberOfParameterSets = Convert.ToInt32(package.Substring(base.RegisteredDataFields[(int)DataFields.NUMBER_OF_PARAMETER_SETS].Index, base.RegisteredDataFields[(int)DataFields.NUMBER_OF_PARAMETER_SETS].Size));
                base.RegisteredDataFields[(int)DataFields.JOB_LIST].Size = NumberOfParameterSets * Job.JobPackageSize;
                adjustDataFieldsIndexes();
                base.ProcessPackage(package);

                JobID = base.RegisteredDataFields[(int)DataFields.JOB_ID].ToInt32();
                JobName = base.RegisteredDataFields[(int)DataFields.JOB_NAME].Value.ToString();
                JobList = new Job().getJobsFromPackage(base.RegisteredDataFields[(int)DataFields.JOB_LIST].Value.ToString()).ToList();
                ForcedOrder = (ForcedOrders)base.RegisteredDataFields[(int)DataFields.FORCED_ORDER].ToInt32();
                LockAtJobDone = base.RegisteredDataFields[(int)DataFields.LOCK_AT_JOB_DONE].ToBoolean();
                ToolLoosening = (ToolLoosenings)base.RegisteredDataFields[(int)DataFields.TOOL_LOOSENING].ToInt32();
                RepeatJob = base.RegisteredDataFields[(int)DataFields.REPEAT_JOB].ToBoolean();
                BatchMode = (BatchModes)base.RegisteredDataFields[(int)DataFields.JOB_BATCH_MODE].ToInt32();
                BatchStatusAtIncrement = base.RegisteredDataFields[(int)DataFields.BATCH_STATUS_AT_INCREMENT].ToBoolean();
                DecrementBatchAtOKLoosening = base.RegisteredDataFields[(int)DataFields.DECREMENT_BATCH_AT_OK_LOOSENING].ToBoolean();
                MaxTimeForFirstTightening = base.RegisteredDataFields[(int)DataFields.MAX_TIME_FOR_FIRST_TIGHTENING].ToInt32();
                MaxTimeToCompleteJob = base.RegisteredDataFields[(int)DataFields.MAX_TIME_TO_COMPLETE_JOB].ToInt32();
                DisplayResultAtAutoSelect = base.RegisteredDataFields[(int)DataFields.DISPLAY_RESULT_AT_AUTO_SELECT].ToInt32();
                UsingLineControl = base.RegisteredDataFields[(int)DataFields.USE_LINE_CONTROL].ToBoolean();
                IdentifierResultPartOne = (IdentifierPart)base.RegisteredDataFields[(int)DataFields.IDENTIFIER_RESULT_PART].ToInt32();
                ResultOfNonTightenings = base.RegisteredDataFields[(int)DataFields.RESULT_OF_NON_TIGHTENINGS].ToBoolean();
                ResetAllIdentifiersAtJobDone = base.RegisteredDataFields[(int)DataFields.RESET_ALL_IDENTIFIERS_AT_JOB_DONE].ToBoolean();
                Reserved = (Reserveds)base.RegisteredDataFields[(int)DataFields.RESERVED].ToInt32();

                return this;
            }

            return NextTemplate.ProcessPackage(package);
        }

        private void adjustDataFieldsIndexes()
        {
            base.RegisteredDataFields[(int)DataFields.FORCED_ORDER].Index = 2 + base.RegisteredDataFields[(int)DataFields.JOB_LIST].Index + base.RegisteredDataFields[(int)DataFields.JOB_LIST].Size;

            int forcedOrderIndex = base.RegisteredDataFields[(int)DataFields.FORCED_ORDER].Index;
            for(int i = (int)DataFields.LOCK_AT_JOB_DONE; i <= RegisteredDataFields.Count; i++)
                base.RegisteredDataFields[i].Index = 2 + base.RegisteredDataFields[i - 1].Index + base.RegisteredDataFields[i - 1].Size;
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.AddRange(
                new DataField[]
                {
                    new DataField((int)DataFields.JOB_ID, 20, 4),
                    new DataField((int)DataFields.JOB_NAME, 26, 25),
                    new DataField((int)DataFields.NUMBER_OF_PARAMETER_SETS, 53, 2),
                    new DataField((int)DataFields.JOB_LIST, 57, 0),
                    new DataField((int)DataFields.FORCED_ORDER, 0, 1),
                    new DataField((int)DataFields.LOCK_AT_JOB_DONE, 0, 1),
                    new DataField((int)DataFields.TOOL_LOOSENING, 0, 1),
                    new DataField((int)DataFields.REPEAT_JOB, 0, 1),
                    new DataField((int)DataFields.JOB_BATCH_MODE, 0, 1),
                    new DataField((int)DataFields.BATCH_STATUS_AT_INCREMENT, 0, 1),
                    new DataField((int)DataFields.DECREMENT_BATCH_AT_OK_LOOSENING, 0, 1),
                    new DataField((int)DataFields.MAX_TIME_FOR_FIRST_TIGHTENING, 0, 4),
                    new DataField((int)DataFields.MAX_TIME_TO_COMPLETE_JOB, 0, 4),
                    new DataField((int)DataFields.DISPLAY_RESULT_AT_AUTO_SELECT, 0, 4),
                    new DataField((int)DataFields.USE_LINE_CONTROL, 0, 1),
                    new DataField((int)DataFields.IDENTIFIER_RESULT_PART, 0, 1),
                    new DataField((int)DataFields.RESULT_OF_NON_TIGHTENINGS, 0, 1),
                    new DataField((int)DataFields.RESET_ALL_IDENTIFIERS_AT_JOB_DONE, 0, 1),
                    new DataField((int)DataFields.RESERVED, 0, 1)
                });
        }

        public enum ForcedOrders
        {
            FREE_ORDER = 0,
            FORCED_ORDER = 1,
            FREE_AND_FORCED = 2
        }

        public enum ToolLoosenings
        {
            ENABLED = 0,
            DISABLED = 1,
            ENABLE_ONLY_ON_NOK_TIGHTENING = 2
        }

        public enum BatchModes
        {
            ONLY_OK = 0,
            BOTH_OK_AND_NOK = 1
        }

        public enum IdentifierPart
        {
            JOB_VIN_NUMBER = 0,
            OTHER = 1
        }

        public enum Reserveds
        {
            E = 0,
            G = 1
        }

        public enum DataFields
        {
            JOB_ID,
            JOB_NAME,
            NUMBER_OF_PARAMETER_SETS,
            JOB_LIST,
            FORCED_ORDER,
            LOCK_AT_JOB_DONE,
            TOOL_LOOSENING,
            REPEAT_JOB,
            JOB_BATCH_MODE,
            BATCH_STATUS_AT_INCREMENT,
            DECREMENT_BATCH_AT_OK_LOOSENING,
            MAX_TIME_FOR_FIRST_TIGHTENING,
            MAX_TIME_TO_COMPLETE_JOB,
            DISPLAY_RESULT_AT_AUTO_SELECT,
            USE_LINE_CONTROL,
            IDENTIFIER_RESULT_PART,
            RESULT_OF_NON_TIGHTENINGS,
            RESET_ALL_IDENTIFIERS_AT_JOB_DONE,
            RESERVED
        }

        public class Job
        {
            private List<DataField> fields;
            public const int JobPackageSize = 15;
            public int ChannelID { get; set; }
            public int ProgramID { get; set; }
            public bool AutoSelect { get; set; }
            public int BatchSize { get; set; }
            public int MaxCoherentNOK { get; set; }

            public Job()
            {
                fields = new List<DataField>();
                registerDatafields();
            }

            public IEnumerable<Job> getJobsFromPackage(string package)
            {
                List<Job> obj = new List<Job>();

                var jobs = package.Split(';');
                foreach (string jobData in jobs)
                    obj.Add(getJobFromPackage(jobData));

                return obj;
            }

            private Job getJobFromPackage(string package)
            {
                Job job = new Job();

                var data = package.Split(':');
                job.ChannelID = Convert.ToInt32(data[0]);
                job.ProgramID = Convert.ToInt32(data[1]);
                job.AutoSelect = Convert.ToBoolean(Convert.ToInt32(data[2]));
                job.BatchSize = Convert.ToInt32(data[3]);
                job.MaxCoherentNOK = Convert.ToInt32(data[4]);

                return job;
            }

            private void registerDatafields()
            {
                fields.AddRange(
                    new DataField[]
                    {
                            new DataField((int)DataFields.CHANNEL_ID, 0, 2),
                            new DataField((int)DataFields.PROGRAM_ID, 3, 3),
                            new DataField((int)DataFields.AUTO_SELECT, 7, 1),
                            new DataField((int)DataFields.BATCH_SIZE, 9, 2),
                            new DataField((int)DataFields.MAX_COHERENT_NOK, 11, 2)
                    });
            }

            public enum DataFields
            {
                CHANNEL_ID,
                PROGRAM_ID,
                AUTO_SELECT,
                BATCH_SIZE,
                MAX_COHERENT_NOK
            }
        }
    }
}
