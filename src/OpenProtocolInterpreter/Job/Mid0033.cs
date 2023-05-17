using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

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
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private IValueConverter<IEnumerable<ParameterSet>> _parameterSetListConverter;
        public const int MID = 33;

        public int JobId
        {
            get => GetField(1, (int)DataFields.JobId).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JobId).SetValue(_intConverter.Convert, value);
        }
        public string JobName
        {
            get => GetField(1, (int)DataFields.JobName).Value;
            set => GetField(1, (int)DataFields.JobName).SetValue(value);
        }
        public ForcedOrder ForcedOrder
        {
            get => (ForcedOrder)GetField(1, (int)DataFields.ForcedOrder).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.ForcedOrder).SetValue(_intConverter.Convert, (int)value);
        }
        public int MaxTimeForFirstTightening
        {
            get => GetField(1, (int)DataFields.MaxTimeForFirstTightening).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.MaxTimeForFirstTightening).SetValue(_intConverter.Convert, value);
        }
        public int MaxTimeToCompleteJob
        {
            get => GetField(1, (int)DataFields.MaxTimeToCompleteJob).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.MaxTimeToCompleteJob).SetValue(_intConverter.Convert, value);
        }
        public JobBatchMode JobBatchMode
        {
            get => (JobBatchMode)GetField(1, (int)DataFields.JobBatchDone).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JobBatchDone).SetValue(_intConverter.Convert, (int)value);
        }
        public bool LockAtJobDone
        {
            get => GetField(1, (int)DataFields.LockAtJobDone).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.LockAtJobDone).SetValue(_boolConverter.Convert, value);
        }
        public bool UseLineControl
        {
            get => GetField(1, (int)DataFields.UseLineControl).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.UseLineControl).SetValue(_boolConverter.Convert, value);
        }
        public bool RepeatJob
        {
            get => GetField(1, (int)DataFields.RepeatJob).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.RepeatJob).SetValue(_boolConverter.Convert, value);
        }
        public ToolLoosening ToolLoosening
        {
            get => (ToolLoosening)GetField(1, (int)DataFields.ToolLoosening).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.ToolLoosening).SetValue(_intConverter.Convert, (int)value);
        }
        public Reserved Reserved
        {
            get => (Reserved)GetField(1, (int)DataFields.Reserved).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.Reserved).SetValue(_intConverter.Convert, (int)value);
        }
        public int NumberOfParameterSets
        {
            get => GetField(1, (int)DataFields.NumberOfParameterSets).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.NumberOfParameterSets).SetValue(_intConverter.Convert, value);
        }
        public List<ParameterSet> ParameterSetList { get; set; }

        public Mid0033() : this(DEFAULT_REVISION)
        {

        }

        public Mid0033(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
            if (ParameterSetList == null)
                ParameterSetList = new List<ParameterSet>();
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

            _parameterSetListConverter = new ParameterSetListConverter(_intConverter, _boolConverter, Header.Revision);
            var psetListField = GetField(1, (int)DataFields.ParameterSetList);
            psetListField.Size = ParameterSetList.Count * GetEachParameterSetSize();
            psetListField.Value = _parameterSetListConverter.Convert(ParameterSetList);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            HandleRevisions();
            _parameterSetListConverter = new ParameterSetListConverter(_intConverter, _boolConverter, Header.Revision);
            var jobListField = GetField(1, (int)DataFields.ParameterSetList);
            jobListField.Size = Header.Length - jobListField.Index - 2;
            base.Parse(package);
            ParameterSetList = _parameterSetListConverter.Convert(jobListField.Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
                {
                    {
                        1, new List<DataField>()
                                {
                                    new DataField((int)DataFields.JobId, 20, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                    new DataField((int)DataFields.JobName, 24, 25, ' '),
                                    new DataField((int)DataFields.ForcedOrder, 51, 1),
                                    new DataField((int)DataFields.MaxTimeForFirstTightening, 54, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                    new DataField((int)DataFields.MaxTimeToCompleteJob, 60, 5, '0', DataField.PaddingOrientations.LeftPadded),
                                    new DataField((int)DataFields.JobBatchDone, 67, 1),
                                    new DataField((int)DataFields.LockAtJobDone, 70, 1),
                                    new DataField((int)DataFields.UseLineControl, 73, 1),
                                    new DataField((int)DataFields.RepeatJob, 76, 1),
                                    new DataField((int)DataFields.ToolLoosening, 79, 1),
                                    new DataField((int)DataFields.Reserved, 82, 1),
                                    new DataField((int)DataFields.NumberOfParameterSets, 85, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                    new DataField((int)DataFields.ParameterSetList, 89, 0) // defined at runtime
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
            switch(Header.Revision)
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