using OpenProtocolInterpreter.Converters;
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
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<IEnumerable<AdvancedJob>> _jobListConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 140;

        public int JobId
        {
            get => RevisionsByFields[1][(int)DataFields.JOB_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.JOB_ID].SetValue(_intConverter.Convert, value);
        }
        public string JobName
        {
            get => RevisionsByFields[1][(int)DataFields.JOB_NAME].Value;
            set => RevisionsByFields[1][(int)DataFields.JOB_NAME].SetValue(value);
        }
        public int NumberOfParameterSets
        {
            get => RevisionsByFields[1][(int)DataFields.NUMBER_OF_PARAMETER_SETS].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.NUMBER_OF_PARAMETER_SETS].SetValue(_intConverter.Convert, value);
        }
        public List<AdvancedJob> JobList { get; set; }
        public ForcedOrder ForcedOrder
        {
            get => (ForcedOrder)RevisionsByFields[1][(int)DataFields.FORCED_ORDER].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.FORCED_ORDER].SetValue(_intConverter.Convert, (int)value);
        }
        public bool LockAtJobDone
        {
            get => RevisionsByFields[1][(int)DataFields.LOCK_AT_JOB_DONE].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.LOCK_AT_JOB_DONE].SetValue(_boolConverter.Convert, value);
        }
        public ToolLoosening ToolLoosening
        {
            get => (ToolLoosening)RevisionsByFields[1][(int)DataFields.TOOL_LOOSENING].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.TOOL_LOOSENING].SetValue(_intConverter.Convert, (int)value);
        }
        public bool RepeatJob
        {
            get => RevisionsByFields[1][(int)DataFields.REPEAT_JOB].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.REPEAT_JOB].SetValue(_boolConverter.Convert, value);
        }
        public BatchMode BatchMode
        {
            get => (BatchMode)RevisionsByFields[1][(int)DataFields.JOB_BATCH_MODE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.JOB_BATCH_MODE].SetValue(_intConverter.Convert, (int)value);
        }
        public bool BatchStatusAtIncrement
        {
            get => RevisionsByFields[1][(int)DataFields.BATCH_STATUS_AT_INCREMENT].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.BATCH_STATUS_AT_INCREMENT].SetValue(_boolConverter.Convert, value);
        }
        public bool DecrementBatchAtOkLoosening
        {
            get => RevisionsByFields[1][(int)DataFields.DECREMENT_BATCH_AT_OK_LOOSENING].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.DECREMENT_BATCH_AT_OK_LOOSENING].SetValue(_boolConverter.Convert, value);
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
        public int DisplayResultAtAutoSelect
        {
            get => RevisionsByFields[1][(int)DataFields.DISPLAY_RESULT_AT_AUTO_SELECT].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.DISPLAY_RESULT_AT_AUTO_SELECT].SetValue(_intConverter.Convert, value);
        }
        public bool UsingLineControl
        {
            get => RevisionsByFields[1][(int)DataFields.USE_LINE_CONTROL].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.USE_LINE_CONTROL].SetValue(_boolConverter.Convert, value);
        }
        public IdentifierPart IdentifierResultPart
        {
            get => (IdentifierPart)RevisionsByFields[1][(int)DataFields.IDENTIFIER_RESULT_PART].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.IDENTIFIER_RESULT_PART].SetValue(_intConverter.Convert, (int)value);
        }
        public bool ResultOfNonTightenings
        {
            get => RevisionsByFields[1][(int)DataFields.RESULT_OF_NON_TIGHTENINGS].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.RESULT_OF_NON_TIGHTENINGS].SetValue(_boolConverter.Convert, value);
        }
        public bool ResetAllIdentifiersAtJobDone
        {
            get => RevisionsByFields[1][(int)DataFields.RESET_ALL_IDENTIFIERS_AT_JOB_DONE].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.RESET_ALL_IDENTIFIERS_AT_JOB_DONE].SetValue(_boolConverter.Convert, value);
        }
        public Reserved Reserved
        {
            get => (Reserved)RevisionsByFields[1][(int)DataFields.RESERVED].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.RESERVED].SetValue(_intConverter.Convert, (int)value);
        }

        public MID_0140(int revision = LAST_REVISION) : base(MID, revision)
        {
            JobList = new List<AdvancedJob>();
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
            _jobListConverter = new AdvancedJobListConverter(revision);
        }

        internal MID_0140(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string Pack()
        {
            RevisionsByFields[1][(int)DataFields.JOB_LIST].Size = JobList.Count * ((HeaderData.Revision == 999) ? 18 : 15);
            AdjustDataFieldsIndexes();
            RevisionsByFields[1][(int)DataFields.JOB_LIST].Value = _jobListConverter.Convert(JobList);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);
                int length = HeaderData.Length;
                foreach (var rev in RevisionsByFields[1])
                    length -= rev.Size;

                RevisionsByFields[1][(int)DataFields.JOB_LIST].Size = length;
                AdjustDataFieldsIndexes();
                base.ProcessDataFields(package);
                JobList = _jobListConverter.Convert(RevisionsByFields[1][(int)DataFields.JOB_LIST].Value).ToList();
                return this;
            }

            return NextTemplate.Parse(package);
        }

        private void AdjustDataFieldsIndexes()
        {
            int index = RevisionsByFields[1][(int)DataFields.JOB_LIST].Index + RevisionsByFields[1][(int)DataFields.JOB_LIST].Size + 2;
            for (int i = (int)DataFields.FORCED_ORDER; i < RevisionsByFields[1].Count; i++)
            {
                RevisionsByFields[1][i].Index = index;
                index += 2 + RevisionsByFields[1][i].Size;
            }
            RevisionsByFields[1][(int)DataFields.JOB_LIST].Size = NumberOfParameterSets * 15;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
                {
                    {
                        1, new List<DataField>()
                                {
                                        new DataField((int)DataFields.JOB_ID, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.JOB_NAME, 26, 25, ' '),
                                        new DataField((int)DataFields.NUMBER_OF_PARAMETER_SETS, 53, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.JOB_LIST, 57, 0),
                                        new DataField((int)DataFields.FORCED_ORDER, 0, 1),
                                        new DataField((int)DataFields.LOCK_AT_JOB_DONE, 0, 1),
                                        new DataField((int)DataFields.TOOL_LOOSENING, 0, 1),
                                        new DataField((int)DataFields.REPEAT_JOB, 0, 1),
                                        new DataField((int)DataFields.JOB_BATCH_MODE, 0, 1),
                                        new DataField((int)DataFields.BATCH_STATUS_AT_INCREMENT, 0, 1),
                                        new DataField((int)DataFields.DECREMENT_BATCH_AT_OK_LOOSENING, 0, 1),
                                        new DataField((int)DataFields.MAX_TIME_FOR_FIRST_TIGHTENING, 0, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.MAX_TIME_TO_COMPLETE_JOB, 0, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.DISPLAY_RESULT_AT_AUTO_SELECT, 0, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.USE_LINE_CONTROL, 0, 1),
                                        new DataField((int)DataFields.IDENTIFIER_RESULT_PART, 0, 1),
                                        new DataField((int)DataFields.RESULT_OF_NON_TIGHTENINGS, 0, 1),
                                        new DataField((int)DataFields.RESET_ALL_IDENTIFIERS_AT_JOB_DONE, 0, 1),
                                        new DataField((int)DataFields.RESERVED, 0, 1)
                                }
                    }
                };
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
    }
}
