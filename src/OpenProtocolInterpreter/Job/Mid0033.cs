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
            get => GetField(1, (int)DataFields.JOB_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_ID).SetValue(_intConverter.Convert, value);
        }
        public string JobName
        {
            get => GetField(1, (int)DataFields.JOB_NAME).Value;
            set => GetField(1, (int)DataFields.JOB_NAME).SetValue(value);
        }
        public ForcedOrder ForcedOrder
        {
            get => (ForcedOrder)GetField(1, (int)DataFields.FORCED_ORDER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.FORCED_ORDER).SetValue(_intConverter.Convert, (int)value);
        }
        public int MaxTimeForFirstTightening
        {
            get => GetField(1, (int)DataFields.MAX_TIME_FOR_FIRST_TIGHTENING).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.MAX_TIME_FOR_FIRST_TIGHTENING).SetValue(_intConverter.Convert, value);
        }
        public int MaxTimeToCompleteJob
        {
            get => GetField(1, (int)DataFields.MAX_TIME_TO_COMPLETE_JOB).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.MAX_TIME_TO_COMPLETE_JOB).SetValue(_intConverter.Convert, value);
        }
        public JobBatchMode JobBatchMode
        {
            get => (JobBatchMode)GetField(1, (int)DataFields.JOB_BATCH_MODE).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.JOB_BATCH_MODE).SetValue(_intConverter.Convert, (int)value);
        }
        public bool LockAtJobDone
        {
            get => GetField(1, (int)DataFields.LOCK_AT_JOB_DONE).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.LOCK_AT_JOB_DONE).SetValue(_boolConverter.Convert, value);
        }
        public bool UseLineControl
        {
            get => GetField(1, (int)DataFields.USE_LINE_CONTROL).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.USE_LINE_CONTROL).SetValue(_boolConverter.Convert, value);
        }
        public bool RepeatJob
        {
            get => GetField(1, (int)DataFields.REPEAT_JOB).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.REPEAT_JOB).SetValue(_boolConverter.Convert, value);
        }
        public ToolLoosening ToolLoosening
        {
            get => (ToolLoosening)GetField(1, (int)DataFields.TOOL_LOOSENING).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.TOOL_LOOSENING).SetValue(_intConverter.Convert, (int)value);
        }
        public Reserved Reserved
        {
            get => (Reserved)GetField(1, (int)DataFields.RESERVED).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.RESERVED).SetValue(_intConverter.Convert, (int)value);
        }
        public int NumberOfParameterSets
        {
            get => GetField(1, (int)DataFields.NUMBER_OF_PARAMETER_SETS).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.NUMBER_OF_PARAMETER_SETS).SetValue(_intConverter.Convert, value);
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
            var psetListField = GetField(1, (int)DataFields.PARAMETER_SET_LIST);
            psetListField.Size = ParameterSetList.Count * GetEachParameterSetSize();
            psetListField.Value = _parameterSetListConverter.Convert(ParameterSetList);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            HandleRevisions();
            _parameterSetListConverter = new ParameterSetListConverter(_intConverter, _boolConverter, Header.Revision);
            var jobListField = GetField(1, (int)DataFields.PARAMETER_SET_LIST);
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
                                    new DataField((int)DataFields.PARAMETER_SET_LIST, 89, 0) // defined at runtime
                                }
                    },
                };
        }

        private void HandleRevisions()
        {
            var jobIdField = GetField(1, (int)DataFields.JOB_ID);
            if (Header.Revision > 1)
            {
                jobIdField.Size = 4;
            }
            else
            {
                jobIdField.Size = 2;
            }

            int index = jobIdField.Index + jobIdField.Size;
            for (int i = (int)DataFields.JOB_NAME; i < RevisionsByFields[1].Count; i++)
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
            PARAMETER_SET_LIST,
            //rev 3

        }

    }
}