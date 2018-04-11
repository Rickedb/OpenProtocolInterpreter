using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Job
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
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private IValueConverter<IEnumerable<Job>> _jobListConverter;
        private const int LAST_REVISION = 3;
        public const int MID = 33;

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
        public string JobName
        {
            get => RevisionsByFields[1][(int)DataFields.JOB_NAME].Value;
            set => RevisionsByFields[1][(int)DataFields.JOB_NAME].SetValue(value);
        }
        public ForcedOrder ForcedOrder
        {
            get => (ForcedOrder)RevisionsByFields[1][(int)DataFields.FORCED_ORDER].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.FORCED_ORDER].SetValue(_intConverter.Convert, (int)value);
        }
        public int MaxTimeForFirstTightening
        {
            get => RevisionsByFields[1][(int)DataFields.MAX_TIME_FOR_FIRST_TIGHTENING].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.MAX_TIME_FOR_FIRST_TIGHTENING].SetValue(_intConverter.Convert, value);
        }
        public int MaxTimeToCompleteJob
        {
            get => RevisionsByFields[1][(int)DataFields.MAX_TIME_TO_COMPLETE_JOB].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.MAX_TIME_TO_COMPLETE_JOB].SetValue(_intConverter.Convert, value);
        }
        public JobBatchMode JobBatchMode
        {
            get => (JobBatchMode)RevisionsByFields[1][(int)DataFields.JOB_BATCH_MODE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.JOB_BATCH_MODE].SetValue(_intConverter.Convert, (int)value);
        }
        public bool LockAtJobDone
        {
            get => RevisionsByFields[1][(int)DataFields.LOCK_AT_JOB_DONE].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.LOCK_AT_JOB_DONE].SetValue(_boolConverter.Convert, value);
        }
        public bool UseLineControl
        {
            get => RevisionsByFields[1][(int)DataFields.USE_LINE_CONTROL].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.USE_LINE_CONTROL].SetValue(_boolConverter.Convert, value);
        }
        public bool RepeatJob
        {
            get => RevisionsByFields[1][(int)DataFields.REPEAT_JOB].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.REPEAT_JOB].SetValue(_boolConverter.Convert, value);
        }
        public ToolLoosening ToolLoosening
        {
            get => (ToolLoosening)RevisionsByFields[1][(int)DataFields.TOOL_LOOSENING].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.TOOL_LOOSENING].SetValue(_intConverter.Convert, (int)value);
        }
        public Reserved Reserved
        {
            get => (Reserved)RevisionsByFields[1][(int)DataFields.RESERVED].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.RESERVED].SetValue(_intConverter.Convert, (int)value);
        }
        public int NumberOfParameterSets
        {
            get => RevisionsByFields[1][(int)DataFields.NUMBER_OF_PARAMETER_SETS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.NUMBER_OF_PARAMETER_SETS].SetValue(_intConverter.Convert, value);
        }
        public List<Job> JobList { get; set; }

        public MID_0033(int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
            if (JobList == null)
                JobList = new List<Job>();
        }

        /// <summary>
        /// Revisions 1,2 and 3 constructors
        /// </summary>
        /// <param name="jobId">The Job ID is specified by two ASCII characters. Range: 00-99</param>
        /// <param name="jobName">25 ASCII characters.</param>
        /// <param name="forcedOrder">0=free order, 1=forced order, 2=free and forced</param>
        /// <param name="maxTimeForFirstTightening">Four ASCII digits, range 0000-9999, <para>00000=not used</para></param>
        /// <param name="maxTimeToCompleteJob">Five ASCII digits, range 00000-99999, <para>00000=not used</para></param>
        /// <param name="jobBatchMode">The Job batch mode is the way to count the tightening in a Job; only the OK or both OK and NOK. 
        ///     <para>0=only the OK tightenings are counted </para>
        ///     <para>1=both the OK and NOK tightenings are counted</para>
        /// </param>
        /// <param name="lockAtJobDone">False=No, True=Yes</param>
        /// <param name="useLineControl">False=No, True=Yes</param>
        /// <param name="repeatJob">False=No, True=Yes</param>
        /// <param name="toolLoosening">Tool loosening. 
        ///     <para>0=Enable</para>
        ///     <para>1=Disable</para>
        ///     <para>2=Enable only on NOK tightening</para>
        /// </param>
        /// <param name="reserved">Reserved for Job repair. 0=E, 1=G</param>
        /// <param name="numberOfParameterSets">The number of parameter sets in the Job list, defined by two ASCII characters, range 00-99.</param>
        /// <param name="jobList">A list of parameter sets (N=value from parameter “Number of parameter sets”, max 50).</param>
        /// <param name="revision">Revision number (Default = 3)</param>
        public MID_0033(int jobId, string jobName, ForcedOrder forcedOrder, int maxTimeForFirstTightening, 
            int maxTimeToCompleteJob, JobBatchMode jobBatchMode, bool lockAtJobDone, bool useLineControl, 
            bool repeatJob, ToolLoosening toolLoosening, Reserved reserved, int numberOfParameterSets, IEnumerable<Job> jobList, int revision = LAST_REVISION) 
            : this(revision)
        {
            JobId = jobId;
            JobName = jobName;
            ForcedOrder = forcedOrder;
            MaxTimeForFirstTightening = maxTimeForFirstTightening;
            MaxTimeToCompleteJob = maxTimeToCompleteJob;
            JobBatchMode = jobBatchMode;
            LockAtJobDone = lockAtJobDone;
            UseLineControl = useLineControl;
            RepeatJob = repeatJob;
            ToolLoosening = toolLoosening;
            Reserved = reserved;
            NumberOfParameterSets = numberOfParameterSets;
            JobList = jobList.ToList();
        }

        internal MID_0033(IMID nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string BuildPackage()
        {
            _jobListConverter = new JobConverter(_intConverter, (int)HeaderData.Revision);
            RevisionsByFields[1].RemoveAt((int)DataFields.JOB_LIST);
            string package = base.BuildPackage();
            package += _jobListConverter.Convert(JobList);
            return package;
        }

        public override MID ProcessPackage(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);
                UpdateFieldsIndexBasedOnRevision();
                var jobListField = RevisionsByFields[1][(int)DataFields.JOB_LIST];
                jobListField.Size = package.Length - jobListField.Index;
                base.ProcessPackage(package);
                JobList = _jobListConverter.Convert(jobListField.Value).ToList();
                return this;
            }

            return NextTemplate.ProcessPackage(package);
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
                {
                    {
                        1, new List<DataField>()
                                {
                                    new DataField((int)DataFields.JOB_ID, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                    new DataField((int)DataFields.JOB_NAME, 24, 25, ' '),
                                    new DataField((int)DataFields.FORCED_ORDER, 51, 1),
                                    new DataField((int)DataFields.MAX_TIME_FOR_FIRST_TIGHTENING, 54, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                    new DataField((int)DataFields.MAX_TIME_TO_COMPLETE_JOB, 60, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                    new DataField((int)DataFields.JOB_BATCH_MODE, 67, 1),
                                    new DataField((int)DataFields.LOCK_AT_JOB_DONE, 70, 1),
                                    new DataField((int)DataFields.USE_LINE_CONTROL, 73, 1),
                                    new DataField((int)DataFields.REPEAT_JOB, 76, 1),
                                    new DataField((int)DataFields.TOOL_LOOSENING, 79, 1),
                                    new DataField((int)DataFields.RESERVED, 82, 1),
                                    new DataField((int)DataFields.NUMBER_OF_PARAMETER_SETS, 85, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                    new DataField((int)DataFields.JOB_LIST, 87, 0) // defined at runtime
                                }
                    }
                };
        }

        private void UpdateFieldsIndexBasedOnRevision()
        {
            if (HeaderData.Revision > 1 && RevisionsByFields[1][(int)DataFields.JOB_ID].Size == 2)
            {
                RevisionsByFields[1][(int)DataFields.JOB_ID].Size = 4;
                for (int i = (int)DataFields.JOB_NAME; i < RevisionsByFields[1].Count; i++)
                    RevisionsByFields[1][i].Index += 2;
            }
        }

        public enum DataFields
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
            NUMBER_OF_PARAMETER_SETS,
            JOB_LIST
        }

        public class Job 
        {
            private readonly IValueConverter<int> _intConverter;
            private readonly IValueConverter<bool> _boolConverter;
            public Dictionary<int, List<DataField>> RevisionsByFields { get; set; }

            public int ChannelID
            {
                get => RevisionsByFields[1][(int)DataFields.CHANNEL_ID].GetValue(_intConverter.Convert);
                set => RevisionsByFields[1][(int)DataFields.CHANNEL_ID].SetValue(_intConverter.Convert, value);
            }
            public int TypeID
            {
                get => RevisionsByFields[1][(int)DataFields.TYPE_ID].GetValue(_intConverter.Convert);
                set => RevisionsByFields[1][(int)DataFields.TYPE_ID].SetValue(_intConverter.Convert, value);
            }
            public bool AutoValue
            {
                get => RevisionsByFields[1][(int)DataFields.AUTO_VALUE].GetValue(_boolConverter.Convert);
                set => RevisionsByFields[1][(int)DataFields.AUTO_VALUE].SetValue(_boolConverter.Convert, value);
            }
            public int BatchSize
            {
                get => RevisionsByFields[1][(int)DataFields.BATCH_SIZE].GetValue(_intConverter.Convert);
                set => RevisionsByFields[1][(int)DataFields.BATCH_SIZE].SetValue(_intConverter.Convert, value);
            }
            public int Socket
            {
                get => RevisionsByFields[3][(int)DataFields.SOCKET].GetValue(_intConverter.Convert);
                set => RevisionsByFields[3][(int)DataFields.SOCKET].SetValue(_intConverter.Convert, value);
            }
            public string JobStepName
            {
                get => RevisionsByFields[3][(int)DataFields.JOB_STEP_NAME].Value;
                set => RevisionsByFields[3][(int)DataFields.JOB_STEP_NAME].Value = value;
            }
            public int JobStepType
            {
                get => RevisionsByFields[3][(int)DataFields.JOB_STEP_TYPE].GetValue(_intConverter.Convert);
                set => RevisionsByFields[3][(int)DataFields.JOB_STEP_TYPE].SetValue(_intConverter.Convert, value);
            }

            public Job()
            {
                _intConverter = new Int32Converter();
                _boolConverter = new BoolConverter();
                RegisterDataFields();
            }

            /// <summary>
            /// Revision 1 and 2 Constructor
            /// </summary>
            /// <param name="channelId"></param>
            /// <param name="typeId"></param>
            /// <param name="autoValue"></param>
            /// <param name="batchSize"></param>
            public Job(int channelId, int typeId, bool autoValue, int batchSize) : this()
            {
                ChannelID = channelId;
                TypeID = typeId;
                AutoValue = autoValue;
                BatchSize = batchSize;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="channelId"></param>
            /// <param name="typeId"></param>
            /// <param name="autoValue"></param>
            /// <param name="batchSize"></param>
            /// <param name="socket"></param>
            /// <param name="jobStepName"></param>
            /// <param name="jobStepType"></param>
            public Job(int channelId, int typeId, bool autoValue, int batchSize, int socket, string jobStepName, int jobStepType) 
                : this(channelId, typeId, autoValue, batchSize)
            {
                Socket = socket;
                JobStepName = jobStepName;
                JobStepType = jobStepType;
            }

            private void RegisterDataFields()
            {
                RevisionsByFields.Add(1, new List<DataField>()
                {
                    new DataField((int)DataFields.CHANNEL_ID, 0, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                    new DataField((int)DataFields.TYPE_ID, 1, 3, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                    new DataField((int)DataFields.AUTO_VALUE, 2, 1, false),
                    new DataField((int)DataFields.BATCH_SIZE, 3, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                });

                RevisionsByFields.Add(3, new List<DataField>()
                {
                    new DataField((int)DataFields.SOCKET, 4, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                    new DataField((int)DataFields.JOB_STEP_NAME, 5, 25, ' ', DataField.PaddingOrientations.RIGHT_PADDED, false),
                    new DataField((int)DataFields.JOB_STEP_TYPE, 6, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false )
                });
            }

            public enum DataFields
            {
                //Rev 1 and 2
                CHANNEL_ID,
                TYPE_ID,
                AUTO_VALUE,
                BATCH_SIZE,
                //Rev 3
                SOCKET,
                JOB_STEP_NAME,
                JOB_STEP_TYPE
            }
        }

        private class JobConverter : IValueConverter<IEnumerable<Job>>
        {
            private readonly int _revision;

            public JobConverter(IValueConverter<int> intConverter, int revision)
            {
                _revision = revision;
            }

            public IEnumerable<Job> Convert(string value)
            {
                string[] jobDatas = value.Substring(2, value.Length - 1).Split(';');
                foreach(string jobData in jobDatas)
                {
                    string[] fields = jobData.Split(':');
                    if (_revision < 3)
                        yield return GetRevision1or2(fields);
                    else
                        yield return GetRevision3(fields);
                }
            }

            public string Convert(IEnumerable<Job> value)
            {
                List<string> packages = new List<string>();
                if (_revision < 3)
                {
                    foreach (var job in value)
                        packages.Add(GetRevision1or2(job));
                }
                else
                {
                    foreach (var job in value)
                        packages.Add(GetRevision3(job));
                }
                return string.Join(";", packages) + ";";
            }

            public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<Job> value)
            {
                return Convert(value);
            }

            private Job GetRevision1or2(string[] fields)
            {
                var job = new Job();
                GetFields(job.RevisionsByFields[1], fields);
                return job;
            }

            private string GetRevision1or2(Job job) => string.Join(":", GetFields(job.RevisionsByFields[1]));

            private Job GetRevision3(string[] fields)
            {
                var job = GetRevision1or2(fields);
                GetFields(job.RevisionsByFields[3], fields);
                return job;
            }

            private string GetRevision3(Job job)
            {
                List<string> fields = new List<string>(GetFields(job.RevisionsByFields[1]));
                fields.AddRange(GetFields(job.RevisionsByFields[3]));
                return string.Join(":", fields);
            }

            private IEnumerable<string> GetFields(List<DataField> fields)
            {
                foreach (var field in fields)
                    yield return field.Value;
            }

            private IEnumerable<DataField> GetFields(List<DataField> revisionFields, string[] fields)
            {
                foreach (var field in revisionFields)
                    field.Value = fields[field.Index];

                return revisionFields;
            }
        }

    }
}
