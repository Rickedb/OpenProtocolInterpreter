using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private readonly IValueConverter<IEnumerable<Job>> _jobListConverter;
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private const int LAST_REVISION = 3;
        public const int MID = 33;

        public int JobID
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
            JobList = new List<Job>();
        }

        internal MID_0033(IMID nextTemplate) : this()
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
            JobList = new List<Job>();
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            string package = base.BuildHeader();
            package += this.JobData.ToString();
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
            if (HeaderData.Revision > 1)
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
            internal List<DataField> _datafields;

            public int ChannelID { get; set; }
            public int TypeID { get; set; }
            public bool AutoValue { get; set; }
            public int BatchSize { get; set; }
            public int Socket { get; set; }
            public string JobStepName { get; set; }
            public int JobStepType { get; set; }


            public Job()
            {

            }

            public List<Job> getJobsFromPackage(string package)
            {
                List<Job> jobs = new List<Job>();

                var stringJobs = package.Substring(91).Split(';');
                foreach (string job in stringJobs)
                {
                    var jobParams = job.Split(':');
                    if (jobParams.Count() == 4)
                        jobs.Add(new Job()
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
                            ChannelID.ToString().PadLeft(2, '0'),
                            TypeID.ToString().PadLeft(3, '0'),
                            Convert.ToInt32(AutoValue).ToString(),
                            BatchSize.ToString().PadLeft(2, '0')
                    }) + ";";
            }
        }

        private class JobConverter : IValueConverter<IEnumerable<Job>>
        {
            private readonly IValueConverter<int> _intConverter;
            private readonly IValueConverter<bool> _boolConverter;
            private readonly int _revision;
            private readonly int _jobDataSize;

            public JobConverter(IValueConverter<int> intConverter, int revision)
            {
                _intConverter = intConverter;
                _revision = revision;
                if(_revision < 3)
                    _jobDataSize = 12;
                else
                    _jobDataSize = 44;
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
                throw new NotImplementedException();
            }

            public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, IEnumerable<Job> value)
            {
                throw new NotImplementedException();
            }

            private Job GetRevision1or2(string[] fields)
            {
                
                return new Job
                {
                    ChannelID = _intConverter.Convert(fields[0]),
                    TypeID = _intConverter.Convert(fields[1]),
                    AutoValue = _boolConverter.Convert(fields[2]),
                    BatchSize = _intConverter.Convert(fields[3])
                };
            }

            private Job GetRevision3(string[] fields)
            {
                var job = GetRevision1or2(fields);
                job.Socket = _intConverter.Convert(fields[4]);
                job.JobStepName = fields[5];
                job.JobStepType = _intConverter.Convert(fields[6]);
                return job;
            }
        }
    }
}
