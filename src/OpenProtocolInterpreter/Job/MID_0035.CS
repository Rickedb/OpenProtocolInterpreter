using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Job
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
    public class MID_0035 : Mid, IJob
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<DateTime> _datetimeConverter;
        public const int MID = 35;
        private const int LAST_REVISION = 4;

        public int JobId
        {
            get
            {
                UpdateFieldsIndexBasedOnRevision();
                return RevisionsByFields[1][(int)DataFields.JOB_ID].GetValue(_intConverter.Convert);
            }
            set
            {
                UpdateFieldsIndexBasedOnRevision();
                RevisionsByFields[1][(int)DataFields.JOB_ID].SetValue(_intConverter.Convert, value);
            }
        }
        public JobStatus JobStatus
        {
            get => (JobStatus)RevisionsByFields[1][(int)DataFields.JOB_STATUS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.JOB_STATUS].SetValue(_intConverter.Convert, (int)value);
        }
        public JobBatchMode JobBatchMode
        {
            get => (JobBatchMode)RevisionsByFields[1][(int)DataFields.JOB_BATCH_MODE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.JOB_BATCH_MODE].SetValue(_intConverter.Convert, (int)value);
        }
        public int JobBatchSize
        {
            get => RevisionsByFields[1][(int)DataFields.JOB_BATCH_SIZE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.JOB_BATCH_SIZE].SetValue(_intConverter.Convert, value);
        }
        public int JobBatchCounter
        {
            get => RevisionsByFields[1][(int)DataFields.JOB_BATCH_COUNTER].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.JOB_BATCH_COUNTER].SetValue(_intConverter.Convert, value);
        }
        public DateTime TimeStamp
        {
            get => RevisionsByFields[1][(int)DataFields.TIMESTAMP].GetValue(_datetimeConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.TIMESTAMP].SetValue(_datetimeConverter.Convert, value);
        }
        //Rev 3
        public int JobCurrentStep 
        {
            get => RevisionsByFields[3][(int)DataFields.JOB_CURRENT_STEP].GetValue(_intConverter.Convert);
            set => RevisionsByFields[3][(int)DataFields.JOB_CURRENT_STEP].SetValue(_intConverter.Convert, value);
        }
        public int JobTotalNumberOfSteps
        {
            get => RevisionsByFields[3][(int)DataFields.JOB_TOTAL_NUMBER_OF_STEPS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[3][(int)DataFields.JOB_TOTAL_NUMBER_OF_STEPS].SetValue(_intConverter.Convert, value);
        }
        public int JobStepType
        {
            get => RevisionsByFields[3][(int)DataFields.JOB_STEP_TYPE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[3][(int)DataFields.JOB_STEP_TYPE].SetValue(_intConverter.Convert, value);
        }
        //Rev 4
        public JobTighteningStatus JobTighteningStatus
        {
            get => (JobTighteningStatus)RevisionsByFields[4][(int)DataFields.JOB_TIGHTENING_STATUS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[4][(int)DataFields.JOB_TIGHTENING_STATUS].SetValue(_intConverter.Convert, (int)value);
        }

        public MID_0035(int? noAckFlag = 0, int revision = LAST_REVISION) : base(MID, LAST_REVISION, noAckFlag) { }

        /// <summary>
        /// Revision 1 and 2 Constructor
        /// </summary>
        /// <param name="jobId">The Job ID is specified by two/four ASCII characters, range 00-99/0000-9999 <para>*Depend on revision</para></param>
        /// <param name="jobStatus">The Job batch status is specified by one ASCII character.</param>
        /// <param name="jobBatchMode">The Job batch mode is the way to count the tightening in a Job only the OK or both OK and NOK.</param>
        /// <param name="jobBatchSize">This parameter gives the total number of tightening in the Job.The Job batch size is four bytes long. Four ASCII characters, range 0000-9999.</param>
        /// <param name="jobBatchCounter">This parameter gives the current value of the Job batch counter.The Job is completed when the Job batch counter is equal to the Job batch size. The Job batch counter is four bytes long. Four ASCII characters, range 0000-9999.</param>
        /// <param name="timestamp">Time stamp for the Job info. The time stamp is 19 bytes long and is specified by 19 ASCII characters</param>
        /// <param name="ackFlag">0=Ack needed, 1=No Ack needed</param>
        /// <param name="revision">Revision number (default = 2)</param>
        public MID_0035(int jobId, JobStatus jobStatus, JobBatchMode jobBatchMode,
            int jobBatchSize, int jobBatchCounter, DateTime timestamp, int? noAckFlag = 0, int revision = 2) : this(noAckFlag, revision)
        {
            JobId = jobId;
            JobStatus = jobStatus;
            JobBatchMode = jobBatchMode;
            JobBatchSize = jobBatchSize;
            JobBatchCounter = jobBatchCounter;
            TimeStamp = timestamp;
        }

        /// <summary>
        /// Revision 3
        /// </summary>
        /// <param name="jobId">The Job ID is specified by two/four ASCII characters, range 00-99/0000-9999 <para>*Depend on revision</para></param>
        /// <param name="jobStatus">The Job batch status is specified by one ASCII character.</param>
        /// <param name="jobBatchMode">The Job batch mode is the way to count the tightening in a Job only the OK or both OK and NOK.</param>
        /// <param name="jobBatchSize">This parameter gives the total number of tightening in the Job.The Job batch size is four bytes long. Four ASCII characters, range 0000-9999.</param>
        /// <param name="jobBatchCounter">This parameter gives the current value of the Job batch counter.The Job is completed when the Job batch counter is equal to the Job batch size. The Job batch counter is four bytes long. Four ASCII characters, range 0000-9999.</param>
        /// <param name="timestamp">Time stamp for the Job info. The time stamp is 19 bytes long and is specified by 19 ASCII characters</param>
        /// <param name="jobCurrentStep">The number of the step currently executed in the job. 3 bytes long, 3 ASCII characters range 000-999. <para>For PF4000, PF3000 is zero reported.</para></param>
        /// <param name="jobTotalNumberOfSteps">The total number of steps in the job. 3 bytes long, 3 ASCII characters range 000-999. <para>For PF4000, PF3000 is zero reported.</para></param>
        /// <param name="jobStepType">Job step type = Two ASCII characters, range 00-99 
        /// <para>Batch step = 1</para>
        /// <para>Reserved = 2-6</para>
        /// <para>For PF4000, PF3000 is zero reported.</para>
        /// </param>
        /// <param name="ackFlag">0=Ack needed, 1=No Ack needed</param>
        /// <param name="revision">Revision number (default = 3)</param>
        public MID_0035(int jobId, JobStatus jobStatus, JobBatchMode jobBatchMode,
           int jobBatchSize, int jobBatchCounter, DateTime timestamp, int jobCurrentStep, int jobTotalNumberOfSteps,
           int jobStepType, int? noAckFlag = 0, int revision = 3) 
            : this(jobId, jobStatus, jobBatchMode, jobBatchSize, jobBatchCounter, timestamp, noAckFlag, revision)
        {
            JobCurrentStep = jobCurrentStep;
            JobTotalNumberOfSteps = jobTotalNumberOfSteps;
            JobStepType = jobStepType;
        }

        /// <summary>
        /// Revision 4 Constructor
        /// </summary>
        /// <param name="jobId">The Job ID is specified by two/four ASCII characters, range 00-99/0000-9999 <para>*Depend on revision</para></param>
        /// <param name="jobStatus">The Job batch status is specified by one ASCII character.</param>
        /// <param name="jobBatchMode">The Job batch mode is the way to count the tightening in a Job only the OK or both OK and NOK.</param>
        /// <param name="jobBatchSize">This parameter gives the total number of tightening in the Job.The Job batch size is four bytes long. Four ASCII characters, range 0000-9999.</param>
        /// <param name="jobBatchCounter">This parameter gives the current value of the Job batch counter.The Job is completed when the Job batch counter is equal to the Job batch size. The Job batch counter is four bytes long. Four ASCII characters, range 0000-9999.</param>
        /// <param name="timestamp">Time stamp for the Job info. The time stamp is 19 bytes long and is specified by 19 ASCII characters</param>
        /// <param name="jobTighteningStatus">The Job tightening status is specified by two ASCII character.</param>
        /// <param name="ackFlag">0=Ack needed, 1=No Ack needed</param>
        /// <param name="revision">Revision number (default = 4)</param>
        public MID_0035(int jobId, JobStatus jobStatus, JobBatchMode jobBatchMode,
           int jobBatchSize, int jobBatchCounter, DateTime timestamp, JobTighteningStatus jobTighteningStatus, 
           int? noAckFlag = 0, int revision = 4)
            : this(jobId, jobStatus, jobBatchMode, jobBatchSize, jobBatchCounter, timestamp, noAckFlag, revision)
        {
            JobTighteningStatus = jobTighteningStatus;
        }

        internal MID_0035(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);
                UpdateFieldsIndexBasedOnRevision();
                base.Parse(package);
                return this;
            }

            return NextTemplate.Parse(package);
        }

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();

            if (HeaderData.Revision == 1)
            {
                if (JobId < 0 || JobId > 99)
                    failed.Add(new ArgumentOutOfRangeException(nameof(JobId), "Range: 00-99").Message);
            }
            else
            {
                if (JobId < 0 || JobId > 9999)
                    failed.Add(new ArgumentOutOfRangeException(nameof(JobId), "Range: 0000-9999").Message);
            }

            if(JobBatchSize < 0 || JobBatchSize > 9999)
                failed.Add(new ArgumentOutOfRangeException(nameof(JobBatchSize), "Range: 0000-9999").Message);

            if (JobBatchCounter < 0 || JobBatchCounter > 9999)
                failed.Add(new ArgumentOutOfRangeException(nameof(JobBatchCounter), "Range: 0000-9999").Message);

            if(HeaderData.Revision == 3)
            {
                if (JobCurrentStep < 0 || JobCurrentStep > 999)
                    failed.Add(new ArgumentOutOfRangeException(nameof(JobCurrentStep), "Range: 000-999").Message);

                if (JobTotalNumberOfSteps < 0 || JobTotalNumberOfSteps > 999)
                    failed.Add(new ArgumentOutOfRangeException(nameof(JobTotalNumberOfSteps), "Range: 000-999").Message);

                if (JobStepType < 0 || JobStepType > 99)
                    failed.Add(new ArgumentOutOfRangeException(nameof(JobStepType), "Range: 00-99").Message);
            }

            errors = failed;
            return errors.Any();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.JOB_ID, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.JOB_STATUS, 24, 1),
                                new DataField((int)DataFields.JOB_BATCH_MODE, 27, 1),
                                new DataField((int)DataFields.JOB_BATCH_SIZE, 30, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.JOB_BATCH_COUNTER, 36, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TIMESTAMP, 42, 19)
                            }
                },
                {
                    3, new  List<DataField>()
                            {
                                new DataField((int)DataFields.JOB_CURRENT_STEP, 65, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.JOB_TOTAL_NUMBER_OF_STEPS, 70, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.JOB_STEP_TYPE, 75, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                },
                {
                    4, new  List<DataField>()
                            {
                                new DataField((int)DataFields.JOB_TIGHTENING_STATUS, 79, 2, ' ', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                }
            };
        }

        private void UpdateFieldsIndexBasedOnRevision()
        {
            if (HeaderData.Revision > 1 && RevisionsByFields[1][(int)DataFields.JOB_ID].Size == 2)
            {
                RevisionsByFields[1][(int)DataFields.JOB_ID].Size = 4;
                for (int i = (int)DataFields.JOB_STATUS; i < RevisionsByFields[1].Count; i++)
                    RevisionsByFields[1][i].Index += 2;
            }
        }
    }

    public enum DataFields
    {
        //rev 1 and 2
        JOB_ID,
        JOB_STATUS,
        JOB_BATCH_MODE,
        JOB_BATCH_SIZE,
        JOB_BATCH_COUNTER,
        TIMESTAMP,
        //rev 3
        JOB_CURRENT_STEP,
        JOB_TOTAL_NUMBER_OF_STEPS,
        JOB_STEP_TYPE,
        //rev 4
        JOB_TIGHTENING_STATUS
    }
}
