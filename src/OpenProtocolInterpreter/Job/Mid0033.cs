using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Job data upload reply
    /// <para>This message is sent as a reply to the <see cref="Mid0032"/> Job data request.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0033 : Mid, IJob, IController
    {
        public const int MID = 33;

        public int JobId
        {
            get => GetField(1, (int)DataFields.JobId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.JobId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string JobName
        {
            get => GetField(1, (int)DataFields.JobName).Value;
            set => GetField(1, (int)DataFields.JobName).SetValue(value);
        }
        public ForcedOrder ForcedOrder
        {
            get => (ForcedOrder)GetField(1, (int)DataFields.ForcedOrder).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.ForcedOrder).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public int MaxTimeForFirstTightening
        {
            get => GetField(1, (int)DataFields.MaxTimeForFirstTightening).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.MaxTimeForFirstTightening).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int MaxTimeToCompleteJob
        {
            get => GetField(1, (int)DataFields.MaxTimeToCompleteJob).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.MaxTimeToCompleteJob).SetValue(OpenProtocolConvert.ToString, value);
        }
        public JobBatchMode JobBatchMode
        {
            get => (JobBatchMode)GetField(1, (int)DataFields.JobBatchDone).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.JobBatchDone).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public bool LockAtJobDone
        {
            get => GetField(1, (int)DataFields.LockAtJobDone).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, (int)DataFields.LockAtJobDone).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool UseLineControl
        {
            get => GetField(1, (int)DataFields.UseLineControl).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, (int)DataFields.UseLineControl).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool RepeatJob
        {
            get => GetField(1, (int)DataFields.RepeatJob).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, (int)DataFields.RepeatJob).SetValue(OpenProtocolConvert.ToString, value);
        }
        public ToolLoosening ToolLoosening
        {
            get => (ToolLoosening)GetField(1, (int)DataFields.ToolLoosening).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.ToolLoosening).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public Reserved Reserved
        {
            get => (Reserved)GetField(1, (int)DataFields.Reserved).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.Reserved).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public int NumberOfParameterSets
        {
            get => GetField(1, (int)DataFields.NumberOfParameterSets).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.NumberOfParameterSets).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<ParameterSet> ParameterSetList { get; set; }

        public Mid0033() : this(DEFAULT_REVISION)
        {

        }

        public Mid0033(Header header) : base(header)
        {
            ParameterSetList ??= [];
            HandleRevisions();
        }

        public Mid0033(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        public override string Pack()
        {
            HandleRevisions();
            NumberOfParameterSets = ParameterSetList.Count;

            var psetListField = GetField(1, (int)DataFields.ParameterSetList);
            psetListField.Size = ParameterSetList.Count * GetEachParameterSetSize();
            psetListField.Value = PackParameterSetList();
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            HandleRevisions();
            var jobListField = GetField(1, (int)DataFields.ParameterSetList);
            jobListField.Size = Header.Length - jobListField.Index - 2;
            base.Parse(package);
            ParameterSetList = ParameterSet.ParseAll(jobListField.Value, Header.Revision).ToList();
            return this;
        }

        protected virtual string PackParameterSetList()
        {
            var packages = new List<string>();
            foreach (var pset in ParameterSetList)
            {
                packages.Add(pset.Pack(Header.Revision));
            }

            return string.Join(";", packages) + ";";
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
                {
                    {
                        1, new List<DataField>()
                                {
                                    new((int)DataFields.JobId, 20, 2, '0', PaddingOrientation.LeftPadded),
                                    new((int)DataFields.JobName, 24, 25, ' '),
                                    new((int)DataFields.ForcedOrder, 51, 1),
                                    new((int)DataFields.MaxTimeForFirstTightening, 54, 4, '0', PaddingOrientation.LeftPadded),
                                    new((int)DataFields.MaxTimeToCompleteJob, 60, 5, '0', PaddingOrientation.LeftPadded),
                                    new((int)DataFields.JobBatchDone, 67, 1),
                                    new((int)DataFields.LockAtJobDone, 70, 1),
                                    new((int)DataFields.UseLineControl, 73, 1),
                                    new((int)DataFields.RepeatJob, 76, 1),
                                    new((int)DataFields.ToolLoosening, 79, 1),
                                    new((int)DataFields.Reserved, 82, 1),
                                    new((int)DataFields.NumberOfParameterSets, 85, 2, '0', PaddingOrientation.LeftPadded),
                                    new((int)DataFields.ParameterSetList, 89, 0) // defined at runtime
                                }
                    },
                };
        }

        private void HandleRevisions()
        {
            var jobIdField = GetField(1, (int)DataFields.JobId);
            if (Header.Revision > 1)
            {
                jobIdField.Size = 4;
            }
            else
            {
                jobIdField.Size = 2;
            }

            int index = jobIdField.Index + jobIdField.Size;
            for (int i = (int)DataFields.JobName; i < RevisionsByFields[1].Count; i++)
            {
                var field = GetField(1, i);
                field.Index = 2 + index;
                index = field.Index + field.Size;
            }
        }

        private int GetEachParameterSetSize()
        {
            switch (Header.Revision)
            {
                case 3: return 44;
                case 4: return 49;
                default: return 12;
            };
        }

        protected enum DataFields
        {
            JobId,
            JobName,
            ForcedOrder,
            MaxTimeForFirstTightening,
            MaxTimeToCompleteJob,
            JobBatchDone,
            LockAtJobDone,
            UseLineControl,
            RepeatJob,
            ToolLoosening,
            Reserved,
            NumberOfParameterSets,
            ParameterSetList,
            //rev 3
        }
    }
}