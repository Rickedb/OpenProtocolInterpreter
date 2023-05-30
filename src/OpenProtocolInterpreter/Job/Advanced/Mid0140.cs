using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Execute dynamic Job request
    /// <para>
    ///     The integrator requests a dynamical Job to be executed i.e. the Job sent from the integrator is
    ///     immediately executed(if possible) by the controller but not saved in the memory.A dynamical Job
    ///     lifetime is the time for the Job to be executed.If the controller is powered off before the completion of
    ///     the Job, the dynamical Job is lost.
    /// </para>
    /// <para>Do note the limitation when sending this message on a serial connection due to the size of the read buffer (256 bytes) in the controller.</para>
    /// <para>In such case the number of programs in the Job list is limited.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0140 : Mid, IAdvancedJob, IIntegrator, IAcceptableCommand
    {
        public const int MID = 140;

        public int JobId
        {
            get => GetField(GetNormalizedRevision(), (int)DataFields.JobId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetNormalizedRevision(), (int)DataFields.JobId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string JobName
        {
            get => GetField(GetNormalizedRevision(), (int)DataFields.JobName).Value;
            set => GetField(GetNormalizedRevision(), (int)DataFields.JobName).SetValue(value);
        }
        public int NumberOfParameterSets
        {
            get => GetField(GetNormalizedRevision(), (int)DataFields.NumberOfParameterSets).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetNormalizedRevision(), (int)DataFields.NumberOfParameterSets).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<AdvancedJob> JobList { get; set; }
        public ForcedOrder ForcedOrder
        {
            get => (ForcedOrder)GetField(GetNormalizedRevision(), (int)DataFields.ForcedOrder).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetNormalizedRevision(), (int)DataFields.ForcedOrder).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public bool LockAtJobDone
        {
            get => GetField(GetNormalizedRevision(), (int)DataFields.LockAtJobDone).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(GetNormalizedRevision(), (int)DataFields.LockAtJobDone).SetValue(OpenProtocolConvert.ToString, value);
        }
        public ToolLoosening ToolLoosening
        {
            get => (ToolLoosening)GetField(GetNormalizedRevision(), (int)DataFields.ToolLoosening).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetNormalizedRevision(), (int)DataFields.ToolLoosening).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public bool RepeatJob
        {
            get => GetField(GetNormalizedRevision(), (int)DataFields.RepeatJob).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(GetNormalizedRevision(), (int)DataFields.RepeatJob).SetValue(OpenProtocolConvert.ToString, value);
        }
        public BatchMode BatchMode
        {
            get => (BatchMode)GetField(GetNormalizedRevision(), (int)DataFields.JobBatchDone).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetNormalizedRevision(), (int)DataFields.JobBatchDone).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public bool BatchStatusAtIncrement
        {
            get => GetField(GetNormalizedRevision(), (int)DataFields.BatchStatusAtIncrement).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(GetNormalizedRevision(), (int)DataFields.BatchStatusAtIncrement).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool DecrementBatchAtOkLoosening
        {
            get => GetField(GetNormalizedRevision(), (int)DataFields.DecrementBatchAtOkLoosening).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(GetNormalizedRevision(), (int)DataFields.DecrementBatchAtOkLoosening).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int MaxTimeForFirstTightening
        {
            get => GetField(GetNormalizedRevision(), (int)DataFields.MaxTimeForFirstTightening).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetNormalizedRevision(), (int)DataFields.MaxTimeForFirstTightening).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int MaxTimeToCompleteJob
        {
            get => GetField(GetNormalizedRevision(), (int)DataFields.MaxTimeToCompleteJob).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetNormalizedRevision(), (int)DataFields.MaxTimeToCompleteJob).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int DisplayResultAtAutoSelect
        {
            get => GetField(GetNormalizedRevision(), (int)DataFields.DisplayResultAtAutoSelect).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetNormalizedRevision(), (int)DataFields.DisplayResultAtAutoSelect).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool UsingLineControl
        {
            get => GetField(GetNormalizedRevision(), (int)DataFields.UseLineControl).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(GetNormalizedRevision(), (int)DataFields.UseLineControl).SetValue(OpenProtocolConvert.ToString, value);
        }
        public IdentifierPart IdentifierResultPart
        {
            get => (IdentifierPart)GetField(GetNormalizedRevision(), (int)DataFields.IdentifierResultPart).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetNormalizedRevision(), (int)DataFields.IdentifierResultPart).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public bool ResultOfNonTightenings
        {
            get => GetField(GetNormalizedRevision(), (int)DataFields.ResultOfNonTightenings).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(GetNormalizedRevision(), (int)DataFields.ResultOfNonTightenings).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool ResetAllIdentifiersAtJobDone
        {
            get => GetField(GetNormalizedRevision(), (int)DataFields.ResetAllIdentifiersAtJobDone).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(GetNormalizedRevision(), (int)DataFields.ResetAllIdentifiersAtJobDone).SetValue(OpenProtocolConvert.ToString, value);
        }
        public Reserved Reserved
        {
            get => (Reserved)GetField(GetNormalizedRevision(), (int)DataFields.Reserved).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetNormalizedRevision(), (int)DataFields.Reserved).SetValue(OpenProtocolConvert.ToString, (int)value);
        }

        public int JobSequenceNumber
        {
            get => GetField(GetNormalizedRevision(), (int)DataFields.JobSequenceNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(GetNormalizedRevision(), (int)DataFields.JobSequenceNumber).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0140() : this(DEFAULT_REVISION)
        {

        }

        public Mid0140(Header header) : base(header)
        {
            JobList = new List<AdvancedJob>();
        }

        public Mid0140(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }

        public override string Pack()
        {
            var revision = GetNormalizedRevision();
            var jobListField = GetField(revision, (int)DataFields.JobList);
            jobListField.Size = JobList.Count * GetJobListSize();
            AdjustDataFieldsIndexes();
            jobListField.Value = PackJobList();
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            int length = Header.Length;
            var revision = GetNormalizedRevision();
            foreach (var rev in RevisionsByFields[revision])
                length -= rev.Size;

            var jobListField = GetField(revision, (int)DataFields.JobList);
            jobListField.Size = length;
            AdjustDataFieldsIndexes();
            base.ProcessDataFields(package);
            JobList = AdvancedJob.ParseAll(jobListField.Value, Header.Revision).ToList();
            return this;
        }

        protected virtual string PackJobList()
        {
            var advancedJobsList = new List<string>();

            foreach (var job in JobList)
            {
                advancedJobsList.Add(job.Pack(Header.Revision));
            }

            return string.Join(";", advancedJobsList);
        }

        private void AdjustDataFieldsIndexes()
        {
            var revision = GetNormalizedRevision();
            var jobListField = GetField(revision, (int)DataFields.JobList);
            jobListField.Size = NumberOfParameterSets * GetJobListSize();
            int index = jobListField.Index + jobListField.Size + 2;
            int startAt = revision != 2 ? (int)DataFields.ForcedOrder : (int)DataFields.JobSequenceNumber;
            foreach (var field in RevisionsByFields[revision])
            {
                if (field.Field >= startAt)
                {
                    field.Index = index;
                    index += 2 + field.Size;
                }
            }

        }

        private int GetNormalizedRevision()
        {
            if (Header.Revision == 999)
            {
                return 1;
            }

            return Header.Revision;
        }

        private int GetJobListSize()
        {
            var revision = GetNormalizedRevision();
            switch (revision)
            {
                case 2: return 52;
                case 3: return 63;
                case 999: return 18;
                default: return 15;
            };
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
                {
                    {
                        1, new List<DataField>()
                                {
                                        new DataField((int)DataFields.JobId, 20, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.JobName, 26, 25, ' '),
                                        new DataField((int)DataFields.NumberOfParameterSets, 53, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.JobList, 57, 0),
                                        new DataField((int)DataFields.ForcedOrder, 0, 1),
                                        new DataField((int)DataFields.LockAtJobDone, 0, 1),
                                        new DataField((int)DataFields.ToolLoosening, 0, 1),
                                        new DataField((int)DataFields.RepeatJob, 0, 1),
                                        new DataField((int)DataFields.JobBatchDone, 0, 1),
                                        new DataField((int)DataFields.BatchStatusAtIncrement, 0, 1),
                                        new DataField((int)DataFields.DecrementBatchAtOkLoosening, 0, 1),
                                        new DataField((int)DataFields.MaxTimeForFirstTightening, 0, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.MaxTimeToCompleteJob, 0, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.DisplayResultAtAutoSelect, 0, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.UseLineControl, 0, 1),
                                        new DataField((int)DataFields.IdentifierResultPart, 0, 1),
                                        new DataField((int)DataFields.ResultOfNonTightenings, 0, 1),
                                        new DataField((int)DataFields.ResetAllIdentifiersAtJobDone, 0, 1),
                                        new DataField((int)DataFields.Reserved, 0, 1)
                                }
                    },
                    {
                        2, new List<DataField>()
                                {
                                        new DataField((int)DataFields.JobId, 20, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.JobName, 26, 25, ' '),
                                        new DataField((int)DataFields.NumberOfParameterSets, 53, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.JobList, 57, 0),
                                        new DataField((int)DataFields.JobSequenceNumber, 0, 5),
                                }
                    },
                    {
                        3, new List<DataField>()
                                {
                                        new DataField((int)DataFields.JobId, 20, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.JobName, 26, 25, ' '),
                                        new DataField((int)DataFields.NumberOfParameterSets, 53, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.JobList, 57, 0),
                                        new DataField((int)DataFields.ForcedOrder, 0, 1),
                                        new DataField((int)DataFields.LockAtJobDone, 0, 1),
                                        new DataField((int)DataFields.MaxTimeForFirstTightening, 0, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.MaxTimeToCompleteJob, 0, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.DisplayResultAtAutoSelect, 0, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.UseLineControl, 0, 1),
                                        new DataField((int)DataFields.IdentifierResultPart, 0, 1),
                                        new DataField((int)DataFields.ResultOfNonTightenings, 0, 1),
                                        new DataField((int)DataFields.ResetAllIdentifiersAtJobDone, 0, 1),
                                        new DataField((int)DataFields.Reserved, 0, 1),
                                        new DataField((int)DataFields.JobSequenceNumber, 0, 5)
                                }
                    }
                };
        }

        protected enum DataFields
        {
            JobId,
            JobName,
            NumberOfParameterSets,
            JobList,
            ForcedOrder,
            LockAtJobDone,
            ToolLoosening,
            RepeatJob,
            JobBatchDone,
            BatchStatusAtIncrement,
            DecrementBatchAtOkLoosening,
            MaxTimeForFirstTightening,
            MaxTimeToCompleteJob,
            DisplayResultAtAutoSelect,
            UseLineControl,
            IdentifierResultPart,
            ResultOfNonTightenings,
            ResetAllIdentifiersAtJobDone,
            Reserved,

            //Rev 2
            JobSequenceNumber
        }
    }
}
