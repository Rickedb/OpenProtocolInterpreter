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
            get => GetField(Header.StandardizedRevision, DataFields.JobId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.JobId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string JobName
        {
            get => GetField(Header.StandardizedRevision, DataFields.JobName).Value;
            set => GetField(Header.StandardizedRevision, DataFields.JobName).SetValue(value);
        }
        public int NumberOfParameterSets
        {
            get => GetField(Header.StandardizedRevision, DataFields.NumberOfParameterSets).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.NumberOfParameterSets).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<AdvancedJob> JobList { get; set; }
        public ForcedOrder ForcedOrder
        {
            get => (ForcedOrder)GetField(Header.StandardizedRevision, DataFields.ForcedOrder).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.ForcedOrder).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool LockAtJobDone
        {
            get => GetField(Header.StandardizedRevision, DataFields.LockAtJobDone).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(Header.StandardizedRevision, DataFields.LockAtJobDone).SetValue(OpenProtocolConvert.ToString, value);
        }
        public ToolLoosening ToolLoosening
        {
            get => (ToolLoosening)GetField(Header.StandardizedRevision, DataFields.ToolLoosening).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.ToolLoosening).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool RepeatJob
        {
            get => GetField(Header.StandardizedRevision, DataFields.RepeatJob).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(Header.StandardizedRevision, DataFields.RepeatJob).SetValue(OpenProtocolConvert.ToString, value);
        }
        public BatchMode BatchMode
        {
            get => (BatchMode)GetField(Header.StandardizedRevision, DataFields.JobBatchDone).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.JobBatchDone).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool BatchStatusAtIncrement
        {
            get => GetField(Header.StandardizedRevision, DataFields.BatchStatusAtIncrement).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(Header.StandardizedRevision, DataFields.BatchStatusAtIncrement).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool DecrementBatchAtOkLoosening
        {
            get => GetField(Header.StandardizedRevision, DataFields.DecrementBatchAtOkLoosening).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(Header.StandardizedRevision, DataFields.DecrementBatchAtOkLoosening).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int MaxTimeForFirstTightening
        {
            get => GetField(Header.StandardizedRevision, DataFields.MaxTimeForFirstTightening).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.MaxTimeForFirstTightening).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int MaxTimeToCompleteJob
        {
            get => GetField(Header.StandardizedRevision, DataFields.MaxTimeToCompleteJob).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.MaxTimeToCompleteJob).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int DisplayResultAtAutoSelect
        {
            get => GetField(Header.StandardizedRevision, DataFields.DisplayResultAtAutoSelect).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.DisplayResultAtAutoSelect).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool UsingLineControl
        {
            get => GetField(Header.StandardizedRevision, DataFields.UseLineControl).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(Header.StandardizedRevision, DataFields.UseLineControl).SetValue(OpenProtocolConvert.ToString, value);
        }
        public IdentifierPart IdentifierResultPart
        {
            get => (IdentifierPart)GetField(Header.StandardizedRevision, DataFields.IdentifierResultPart).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.IdentifierResultPart).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool ResultOfNonTightenings
        {
            get => GetField(Header.StandardizedRevision, DataFields.ResultOfNonTightenings).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(Header.StandardizedRevision, DataFields.ResultOfNonTightenings).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool ResetAllIdentifiersAtJobDone
        {
            get => GetField(Header.StandardizedRevision, DataFields.ResetAllIdentifiersAtJobDone).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(Header.StandardizedRevision, DataFields.ResetAllIdentifiersAtJobDone).SetValue(OpenProtocolConvert.ToString, value);
        }
        public Reserved Reserved
        {
            get => (Reserved)GetField(Header.StandardizedRevision, DataFields.Reserved).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.Reserved).SetValue(OpenProtocolConvert.ToString, value);
        }

        public int JobSequenceNumber
        {
            get => GetField(Header.StandardizedRevision, DataFields.JobSequenceNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.JobSequenceNumber).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0140() : this(DEFAULT_REVISION)
        {

        }

        public Mid0140(Header header) : base(header)
        {
            JobList = [];
        }

        public Mid0140(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }
        protected override string BuildHeader()
        {
            var revision = Header.StandardizedRevision;
            Header.Length = 20 + RevisionsByFields[revision].Sum(x=> x.Size + (x.HasPrefix ? 2 : 0));
            return Header.ToString();
        }

        public override string Pack()
        {
            var revision = Header.StandardizedRevision;
            ResetDataFields(revision);
            var jobListField = GetField(revision, DataFields.JobList);
            jobListField.Size = JobList.Count * AdvancedJob.GetDefaultSize(revision);
            AdjustDataFieldsIndexes(jobListField.Index + jobListField.Size + 2, revision);
            jobListField.Value = PackJobList(revision);
            int prefixIndex = 1;
            return string.Concat(BuildHeader(), base.Pack(revision, ref prefixIndex));
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            int length = Header.Length;
            var revision = Header.StandardizedRevision;
            ResetDataFields(revision);
            var numberOfParameterSetsField = RevisionsByFields[revision].First(x => x.Field == (int)DataFields.NumberOfParameterSets);
            var numberOfParameterSets = int.Parse(package.Substring(numberOfParameterSetsField.Index + 2, numberOfParameterSetsField.Size));
            var jobListField = GetField(revision, DataFields.JobList);
            jobListField.Size = numberOfParameterSets * AdvancedJob.GetDefaultSize(revision);
            AdjustDataFieldsIndexes(jobListField.Index + jobListField.Size + 2, revision);
            base.ProcessDataFields(revision, package);
            JobList = AdvancedJob.ParseAll(jobListField.Value, revision).ToList();
            return this;
        }

        protected virtual string PackJobList(int revision)
        {
            var advancedJobsList = new List<string>();

            foreach (var job in JobList)
            {
                advancedJobsList.Add(job.Pack(revision));
            }

            return string.Join(";", advancedJobsList) + ";";
        }

        private void AdjustDataFieldsIndexes(int currentIndex, int revision)
        {
            foreach (var field in RevisionsByFields[revision])
            {
                if (field.Field > (int)DataFields.JobList)
                {
                    field.Index = currentIndex;
                    currentIndex += 2 + field.Size;
                }
            }

        }

        private void ResetDataFields(int revision)
        {
            //TODO: think of a better approach in case user repeats packing or parsing
            var fields = RevisionsByFields[revision].Where(x => x.Field > (int)DataFields.JobList);
            foreach (var field in fields)
                field.Index = 0;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            //All the workarounds are made due to inconsistent "additions" from protocol, since there are many fields moved
            //to JobList/Parameter list, the DataFields start to shuffle every revision
            return new Dictionary<int, List<DataField>>()
                {
                    {
                        1, new List<DataField>()
                                {
                                        DataField.Number(DataFields.JobId, 20, 4),
                                        DataField.String(DataFields.JobName, 26, 25),
                                        DataField.Number(DataFields.NumberOfParameterSets, 53, 2),
                                        DataField.Volatile(DataFields.JobList, 57),
                                        DataField.Number(DataFields.ForcedOrder, 0, 1),
                                        DataField.Boolean(DataFields.LockAtJobDone, 0),
                                        DataField.Number(DataFields.ToolLoosening, 0, 1),
                                        DataField.Boolean(DataFields.RepeatJob, 0),
                                        DataField.Number(DataFields.JobBatchDone, 0, 1),
                                        DataField.Boolean(DataFields.BatchStatusAtIncrement, 0),
                                        DataField.Boolean(DataFields.DecrementBatchAtOkLoosening, 0),
                                        DataField.Number(DataFields.MaxTimeForFirstTightening, 0, 4),
                                        DataField.Number(DataFields.MaxTimeToCompleteJob, 0, 5),
                                        DataField.Number(DataFields.DisplayResultAtAutoSelect, 0, 4),
                                        DataField.Boolean(DataFields.UseLineControl, 0),
                                        DataField.Number(DataFields.IdentifierResultPart, 0, 1),
                                        DataField.Boolean(DataFields.ResultOfNonTightenings, 0),
                                        DataField.Boolean(DataFields.ResetAllIdentifiersAtJobDone, 0),
                                        DataField.Number(DataFields.Reserved, 0, 1)
                                }
                    },
                    {
                        2, new List<DataField>()
                                {
                                        DataField.Number(DataFields.JobId, 20, 4),
                                        DataField.String(DataFields.JobName, 26, 25),
                                        DataField.Number(DataFields.NumberOfParameterSets, 53, 2),
                                        DataField.Volatile(DataFields.JobList, 57),
                                        DataField.Number(DataFields.ForcedOrder, 0, 1),
                                        DataField.Boolean(DataFields.LockAtJobDone, 0),
                                        DataField.Number(DataFields.ToolLoosening, 0, 1),
                                        DataField.Boolean(DataFields.RepeatJob, 0),
                                        DataField.Number(DataFields.JobBatchDone, 0, 1),
                                        DataField.Boolean(DataFields.BatchStatusAtIncrement, 0),
                                        DataField.Boolean(DataFields.DecrementBatchAtOkLoosening, 0),
                                        DataField.Number(DataFields.MaxTimeForFirstTightening, 0, 4),
                                        DataField.Number(DataFields.MaxTimeToCompleteJob, 0, 5),
                                        DataField.Number(DataFields.DisplayResultAtAutoSelect, 0, 4),
                                        DataField.Boolean(DataFields.UseLineControl, 0),
                                        DataField.Number(DataFields.IdentifierResultPart, 0, 1),
                                        DataField.Boolean(DataFields.ResultOfNonTightenings, 0),
                                        DataField.Boolean(DataFields.ResetAllIdentifiersAtJobDone, 0),
                                        DataField.Number(DataFields.Reserved, 0, 1),
                                        DataField.Number(DataFields.JobSequenceNumber, 0, 5),
                                }
                    },
                    {
                        3, new List<DataField>()
                                {
                                        DataField.Number(DataFields.JobId, 20, 4),
                                        DataField.String(DataFields.JobName, 26, 25),
                                        DataField.Number(DataFields.NumberOfParameterSets, 53, 2),
                                        DataField.Volatile(DataFields.JobList, 57),
                                        DataField.Number(DataFields.ForcedOrder, 0, 1),
                                        DataField.Boolean(DataFields.LockAtJobDone, 0),
                                        DataField.Boolean(DataFields.RepeatJob, 0),
                                        DataField.Number(DataFields.MaxTimeForFirstTightening, 0, 4),
                                        DataField.Number(DataFields.MaxTimeToCompleteJob, 0, 5),
                                        DataField.Number(DataFields.DisplayResultAtAutoSelect, 0, 4),
                                        DataField.Boolean(DataFields.UseLineControl, 0),
                                        DataField.Number(DataFields.IdentifierResultPart, 0, 1),
                                        DataField.Boolean(DataFields.ResultOfNonTightenings, 0),
                                        DataField.Boolean(DataFields.ResetAllIdentifiersAtJobDone, 0),
                                        DataField.Number(DataFields.Reserved, 0, 1),
                                        DataField.Number(DataFields.JobSequenceNumber, 0, 5)
                                }
                    },
                    {
                        4, new List<DataField>()
                                {
                                        DataField.Number(DataFields.JobId, 20, 4),
                                        DataField.String(DataFields.JobName, 26, 25),
                                        DataField.Number(DataFields.NumberOfParameterSets, 53, 2),
                                        DataField.Volatile(DataFields.JobList, 57),
                                        DataField.Number(DataFields.ForcedOrder, 0, 1),
                                        DataField.Boolean(DataFields.LockAtJobDone, 0),
                                        DataField.Boolean(DataFields.RepeatJob, 0),
                                        DataField.Number(DataFields.MaxTimeForFirstTightening, 0, 4),
                                        DataField.Number(DataFields.MaxTimeToCompleteJob, 0, 5),
                                        DataField.Number(DataFields.DisplayResultAtAutoSelect, 0, 4),
                                        DataField.Boolean(DataFields.UseLineControl, 0),
                                        DataField.Number(DataFields.IdentifierResultPart, 0, 1),
                                        DataField.Boolean(DataFields.ResultOfNonTightenings, 0),
                                        DataField.Boolean(DataFields.ResetAllIdentifiersAtJobDone, 0),
                                        DataField.Number(DataFields.Reserved, 0, 1),
                                        DataField.Number(DataFields.JobSequenceNumber, 0, 5)
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
