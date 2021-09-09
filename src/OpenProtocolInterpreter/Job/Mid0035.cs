using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// <para>MID: Job info</para>
    /// <para>Description:</para>
    ///     <para>The Job info subscriber will receive a Job info message after a Job has been selected and after each
    ///     tightening performed in the Job.The Job info consists of the ID of the currently running Job, the Job
    ///     status, the Job batch mode, the Job batch size and the Job batch counter.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0036"/></para>
    /// </summary>
    public class Mid0035 : Mid, IJob, IController
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<DateTime> _datetimeConverter;
        public const int MID = 35;
        private const int LAST_REVISION = 5;

        public int JobId
        {
            get => GetField(1, (int)DataFields.JOB_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_ID).SetValue(_intConverter.Convert, value);
        }
        public JobStatus JobStatus
        {
            get => (JobStatus)GetField(1, (int)DataFields.JOB_STATUS).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_STATUS).SetValue(_intConverter.Convert, (int)value);
        }
        public JobBatchMode JobBatchMode
        {
            get => (JobBatchMode)GetField(1, (int)DataFields.JOB_BATCH_MODE).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_BATCH_MODE).SetValue(_intConverter.Convert, (int)value);
        }
        public int JobBatchSize
        {
            get => GetField(1, (int)DataFields.JOB_BATCH_SIZE).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_BATCH_SIZE).SetValue(_intConverter.Convert, value);
        }
        public int JobBatchCounter
        {
            get => GetField(1, (int)DataFields.JOB_BATCH_COUNTER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_BATCH_COUNTER).SetValue(_intConverter.Convert, value);
        }
        public DateTime TimeStamp
        {
            get => GetField(1, (int)DataFields.TIMESTAMP).GetValue(_datetimeConverter.Convert);
            set => GetField(1, (int)DataFields.TIMESTAMP).SetValue(_datetimeConverter.Convert, value);
        }
        //Rev 3
        public int JobCurrentStep
        {
            get => GetField(3, (int)DataFields.JOB_CURRENT_STEP).GetValue(_intConverter.Convert);
            set => GetField(3, (int)DataFields.JOB_CURRENT_STEP).SetValue(_intConverter.Convert, value);
        }
        public int JobTotalNumberOfSteps
        {
            get => GetField(3, (int)DataFields.JOB_TOTAL_NUMBER_OF_STEPS).GetValue(_intConverter.Convert);
            set => GetField(3, (int)DataFields.JOB_TOTAL_NUMBER_OF_STEPS).SetValue(_intConverter.Convert, value);
        }
        public int JobStepType
        {
            get => GetField(3, (int)DataFields.JOB_STEP_TYPE).GetValue(_intConverter.Convert);
            set => GetField(3, (int)DataFields.JOB_STEP_TYPE).SetValue(_intConverter.Convert, value);
        }
        //Rev 4
        public JobTighteningStatus JobTighteningStatus
        {
            get => (JobTighteningStatus)GetField(4, (int)DataFields.JOB_TIGHTENING_STATUS).GetValue(_intConverter.Convert);
            set => GetField(4, (int)DataFields.JOB_TIGHTENING_STATUS).SetValue(_intConverter.Convert, (int)value);
        }
        //Rev 5
        public int JobSequenceNumber
        {
            get => GetField(5, (int)DataFields.JOB_SEQUENCE_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(5, (int)DataFields.JOB_SEQUENCE_NUMBER).SetValue(_intConverter.Convert, (int)value);
        }

        public string VinNumber
        {
            get => GetField(5, (int)DataFields.VIN_NUMBER).Value;
            set => GetField(5, (int)DataFields.VIN_NUMBER).SetValue(value);
        }

        public string IdentifierResultPart2
        {
            get => GetField(5, (int)DataFields.IDENTIFIER_RESULT_PART2).Value;
            set => GetField(5, (int)DataFields.IDENTIFIER_RESULT_PART2).SetValue(value);
        }

        public string IdentifierResultPart3
        {
            get => GetField(5, (int)DataFields.IDENTIFIER_RESULT_PART3).Value;
            set => GetField(5, (int)DataFields.IDENTIFIER_RESULT_PART3).SetValue(value);
        }

        public string IdentifierResultPart4
        {
            get => GetField(5, (int)DataFields.IDENTIFIER_RESULT_PART4).Value;
            set => GetField(5, (int)DataFields.IDENTIFIER_RESULT_PART4).SetValue(value);
        }

        public Mid0035() : this(LAST_REVISION)
        {

        }

        public Mid0035(int revision = LAST_REVISION, int? noAckFlag = 0) : base(MID, revision, noAckFlag)
        {
            _intConverter = new Int32Converter();
            _datetimeConverter = new DateConverter();
            HandleRevision();
        }

        /// <summary>
        /// Revision 1 and 2 Constructor
        /// </summary>
        /// <param name="jobId">The Job ID is specified by two/four ASCII characters, range 00-99/0000-9999 <para>*Depend on revision</para></param>
        /// <param name="jobStatus">The Job batch status is specified by one ASCII character.</param>
        /// <param name="jobBatchMode">The Job batch mode is the way to count the tightening in a Job only the OK or both OK and NOK.</param>
        /// <param name="jobBatchSize">This parameter gives the total number of tightening in the Job.The Job batch size is four bytes long. Four ASCII characters, range 0000-9999.</param>
        /// <param name="jobBatchCounter">This parameter gives the current value of the Job batch counter.The Job is completed when the Job batch counter is equal to the Job batch size. The Job batch counter is four bytes long. Four ASCII characters, range 0000-9999.</param>
        /// <param name="timestamp">Time stamp for the Job info. The time stamp is 19 bytes long and is specified by 19 ASCII characters</param>
        /// <param name="noAckFlag">0=Ack needed, 1=No Ack needed</param>
        /// <param name="revision">Revision number (default = 2)</param>
        public Mid0035(int jobId, JobStatus jobStatus, JobBatchMode jobBatchMode,
            int jobBatchSize, int jobBatchCounter, DateTime timestamp, int revision = 2, int? noAckFlag = 0) : this(revision, noAckFlag)
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
        /// <param name="noAckFlag">0=Ack needed, 1=No Ack needed</param>
        /// <param name="revision">Revision number (default = 3)</param>
        public Mid0035(int jobId, JobStatus jobStatus, JobBatchMode jobBatchMode,
           int jobBatchSize, int jobBatchCounter, DateTime timestamp, int jobCurrentStep, int jobTotalNumberOfSteps,
           int jobStepType, int revision = 3, int? noAckFlag = 0)
            : this(jobId, jobStatus, jobBatchMode, jobBatchSize, jobBatchCounter, timestamp, revision, noAckFlag)
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
        /// <param name="noAckFlag">0=Ack needed, 1=No Ack needed</param>
        /// <param name="revision">Revision number (default = 4)</param>
        public Mid0035(int jobId, JobStatus jobStatus, JobBatchMode jobBatchMode,
           int jobBatchSize, int jobBatchCounter, DateTime timestamp, JobTighteningStatus jobTighteningStatus,
           int revision = 4, int? noAckFlag = 0)
            : this(jobId, jobStatus, jobBatchMode, jobBatchSize, jobBatchCounter, timestamp, revision, noAckFlag)
        {
            JobTighteningStatus = jobTighteningStatus;
        }

        /// <summary>
        /// Revision 5 Constructor
        /// </summary>
        /// <param name="jobId">The Job ID is specified by two/four ASCII characters, range 00-99/0000-9999 <para>*Depend on revision</para></param>
        /// <param name="jobStatus">The Job batch status is specified by one ASCII character.</param>
        /// <param name="jobBatchMode">The Job batch mode is the way to count the tightening in a Job only the OK or both OK and NOK.</param>
        /// <param name="jobBatchSize">This parameter gives the total number of tightening in the Job.The Job batch size is four bytes long. Four ASCII characters, range 0000-9999.</param>
        /// <param name="jobBatchCounter">This parameter gives the current value of the Job batch counter.The Job is completed when the Job batch counter is equal to the Job batch size. The Job batch counter is four bytes long. Four ASCII characters, range 0000-9999.</param>
        /// <param name="timestamp">Time stamp for the Job info. The time stamp is 19 bytes long and is specified by 19 ASCII characters</param>
        /// <param name="jobTighteningStatus">The Job tightening status is specified by two ASCII character.</param>
        /// <param name="jobSequenceNumber">The Job sequence number is unique for each Job.</param>
        /// <param name="vinNumber">The VIN number is 25 bytes long and is specified by 25 ASCII characters.</param>
        /// <param name="identifierResultPart2">The identifier result part 2 is 25 bytes long and is specified by 25 ASCII characters.</param>
        /// <param name="identifierResultPart3">The identifier result part 3 is 25 bytes long and is specified by 25 ASCII characters.</param>
        /// <param name="identifierResultPart4">The identifier result part 4 is 25 bytes long and is specified by 25 ASCII characters.</param>
        /// <param name="noAckFlag">0=Ack needed, 1=No Ack needed</param>
        /// <param name="revision">Revision number (default = 4)</param>
        public Mid0035(int jobId, JobStatus jobStatus, JobBatchMode jobBatchMode,
           int jobBatchSize, int jobBatchCounter, DateTime timestamp, JobTighteningStatus jobTighteningStatus,
           int jobSequenceNumber, string vinNumber, string identifierResultPart2, string identifierResultPart3,
           string identifierResultPart4, int revision = 5, int? noAckFlag = 0)
            : this(jobId, jobStatus, jobBatchMode, jobBatchSize, jobBatchCounter, timestamp, jobTighteningStatus, revision, noAckFlag)
        {
            JobSequenceNumber = jobSequenceNumber;
            VinNumber = vinNumber;
            IdentifierResultPart2 = identifierResultPart2;
            IdentifierResultPart3 = identifierResultPart3;
            IdentifierResultPart4 = identifierResultPart4;
        }

        public override Mid Parse(string package)
        {
            HeaderData = ProcessHeader(package);
            HandleRevision();
            ProcessDataFields(package);
            return this;
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

            if (JobBatchSize < 0 || JobBatchSize > 9999)
                failed.Add(new ArgumentOutOfRangeException(nameof(JobBatchSize), "Range: 0000-9999").Message);

            if (JobBatchCounter < 0 || JobBatchCounter > 9999)
                failed.Add(new ArgumentOutOfRangeException(nameof(JobBatchCounter), "Range: 0000-9999").Message);

            if (HeaderData.Revision == 3)
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
                { 2, new List<DataField>() },
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
                },
                {
                    5, new  List<DataField>()
                    {
                        new DataField((int)DataFields.JOB_SEQUENCE_NUMBER, 83, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.VIN_NUMBER, 90 , 25, ' ', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.IDENTIFIER_RESULT_PART2, 117, 25, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.IDENTIFIER_RESULT_PART3, 144, 25, '0', DataField.PaddingOrientations.LEFT_PADDED),
                        new DataField((int)DataFields.IDENTIFIER_RESULT_PART4, 171, 25, '0', DataField.PaddingOrientations.LEFT_PADDED),
                    }
                }
            };
        }

        private void HandleRevision()
        {
            var jobIdField = GetField(1, (int)DataFields.JOB_ID);
            if (HeaderData.Revision > 1)
            {
                jobIdField.Size = 4;
            }
            else
            {
                jobIdField.Size = 2;
            }

            int index = jobIdField.Index + jobIdField.Size;
            for (int i = (int)DataFields.JOB_STATUS; i < RevisionsByFields[1].Count; i++)
            {
                var field = GetField(1, i);
                field.Index = 2 + index;
                index = field.Index + field.Size;
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
        JOB_TIGHTENING_STATUS,
        //rev5
        JOB_SEQUENCE_NUMBER,
        VIN_NUMBER,
        IDENTIFIER_RESULT_PART2,
        IDENTIFIER_RESULT_PART3,
        IDENTIFIER_RESULT_PART4
    }
}
