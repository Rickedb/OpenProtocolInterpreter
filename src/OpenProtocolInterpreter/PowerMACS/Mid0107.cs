using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// MID: Last Power MACS tightening result Bolt data
    /// Description: 
    ///    This message contains the cycle data for one Bolt, both Bolt data and step data. It is only sent if 
    ///    the acknowledgement of the message MID 0106 Last PowerMACS tightening result station data had the parameter 
    ///    Bolt Data set to TRUE. The next Bolt data is sent if the acknowledgement has the parameter Bolt Data set to TRUE.
    ///    This telegram is also used for Power MACS systems running a Press.The layout of the telegram is exactly the 
    ///    same but some of the fields have slightly different definitions. The fields for Torque are used for Force values 
    ///    and the fields for Angle are used for Stroke values. Press systems also use different identifiers for the optional 
    ///    data on bolt and step level. Press systems always use revision 4 or higher of the telegram.Values in the fixed part
    ///    that are undefined in the results will be sent as all spaces (ASCII 0x20). 
    ///    This can happen with the Customer Error Code if this function is not activated.
    ///    Note 2: The Bolt results and step results are only sent when the value exists in the result. This means,
    ///    for example, that if no high limit is programmed for Peak T, then the value Peak T + will not be sent
    ///    even if limits for Peak T are defined in the reporter.
    /// Message sent by: Controller
    /// Answer: MID 0108 Last PowerMACS tightening result data acknowledge
    /// </summary>
    public class Mid0107 : Mid, IPowerMACS
    {
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        private readonly IValueConverter<IEnumerable<BoltResult>> _boltResultConverter;
        private readonly IValueConverter<IEnumerable<StepResult>> _stepResultConverter;
        private IValueConverter<IEnumerable<SpecialValue>> _specialValueConverter;
        private const int LAST_REVISION = 4;
        public const int MID = 107;

        public int TotalNumberOfMessages
        {
            get => GetField(1, (int)DataFields.TOTAL_NUMBER_OF_MESSAGES).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.TOTAL_NUMBER_OF_MESSAGES).SetValue(_intConverter.Convert, value);
        }
        public int MessageNumber
        {
            get => GetField(1, (int)DataFields.MESSAGE_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.MESSAGE_NUMBER).SetValue(_intConverter.Convert, value);
        }
        public int DataNumberSystem
        {
            get => GetField(1, (int)DataFields.DATA_NUMBER_SYSTEM).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.DATA_NUMBER_SYSTEM).SetValue(_intConverter.Convert, value);
        }
        public int StationNumber
        {
            get => GetField(1, (int)DataFields.STATION_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.STATION_NUMBER).SetValue(_intConverter.Convert, value);
        }
        public DateTime Time
        {
            get => GetField(1, (int)DataFields.TIME).GetValue(_dateConverter.Convert);
            set => GetField(1, (int)DataFields.TIME).SetValue(_dateConverter.Convert, value);
        }
        public int BoltNumber
        {
            get => GetField(1, (int)DataFields.BOLT_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.BOLT_NUMBER).SetValue(_intConverter.Convert, value);
        }
        public string BoltName
        {
            get => GetField(1, (int)DataFields.BOLT_NAME).Value;
            set => GetField(1, (int)DataFields.BOLT_NAME).SetValue(value);
        }
        public string ProgramName
        {
            get => GetField(1, (int)DataFields.PROGRAM_NAME).Value;
            set => GetField(1, (int)DataFields.PROGRAM_NAME).SetValue(value);
        }
        public PowerMacsStatuses PowerMacsStatus
        {
            get => (PowerMacsStatuses)GetField(1, (int)DataFields.PM_STATUS).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.PM_STATUS).SetValue(_intConverter.Convert, (int)value);
        }
        public string Errors
        {
            get => GetField(1, (int)DataFields.ERRORS).Value;
            set => GetField(1, (int)DataFields.ERRORS).SetValue(value);
        }
        public string CustomerErrorCode
        {
            get => GetField(1, (int)DataFields.CUSTOMER_ERROR_CODE).Value;
            set => GetField(1, (int)DataFields.CUSTOMER_ERROR_CODE).SetValue(value);
        }
        public int NumberOfBoltResults
        {
            get => GetField(1, (int)DataFields.NUMBER_OF_BOLT_RESULTS).GetValue(_intConverter.Convert);
            private set => GetField(1, (int)DataFields.NUMBER_OF_BOLT_RESULTS).SetValue(_intConverter.Convert, value);
        }
        public List<BoltResult> BoltResults { get; set; }
        public int NumberOfStepResults
        {
            get => GetField(1, (int)DataFields.NUMBER_OF_STEP_RESULTS).GetValue(_intConverter.Convert);
            private set => GetField(1, (int)DataFields.NUMBER_OF_STEP_RESULTS).SetValue(_intConverter.Convert, value);
        }
        public bool AllStepDataSent
        {
            get => GetField(1, (int)DataFields.ALL_STEP_DATA_SENT).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.ALL_STEP_DATA_SENT).SetValue(_boolConverter.Convert, value);
        }
        public List<StepResult> StepResults { get; set; }
        public int NumberOfSpecialValues
        {
            get => GetField(1, (int)DataFields.NUMBER_OF_SPECIAL_VALUES).GetValue(_intConverter.Convert);
            private set => GetField(1, (int)DataFields.NUMBER_OF_SPECIAL_VALUES).SetValue(_intConverter.Convert, value);
        }
        public List<SpecialValue> SpecialValues { get; set; }

        public Mid0107() : base(MID, LAST_REVISION)
        {
            _boolConverter = new BoolConverter();
            _intConverter = new Int32Converter();
            _dateConverter = new DateConverter();
            _boltResultConverter = new BoltResultConverter(_intConverter);
            _stepResultConverter = new StepResultConverter(_intConverter);

            if (BoltResults == null)
                BoltResults = new List<BoltResult>();
            if (StepResults == null)
                StepResults = new List<StepResult>();
            if (SpecialValues == null)
                SpecialValues = new List<SpecialValue>();
        }

        internal Mid0107(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string Pack()
        {
            NumberOfBoltResults = BoltResults.Count;
            NumberOfStepResults = StepResults.Count;
            NumberOfSpecialValues = SpecialValues.Count;
            _specialValueConverter = new SpecialValueListConverter(_intConverter, NumberOfSpecialValues, true);

            GetField(1, (int)DataFields.BOLT_RESULTS).SetValue(_boltResultConverter.Convert(BoltResults));
            GetField(1, (int)DataFields.STEP_RESULTS).SetValue(_stepResultConverter.Convert(StepResults));
            GetField(1, (int)DataFields.SPECIAL_VALUES).SetValue(_specialValueConverter.Convert(SpecialValues));

            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);

                int numberOfBoltResults = _intConverter.Convert(GetValue(GetField(1, (int)DataFields.NUMBER_OF_BOLT_RESULTS), package));
                var boltResultField = GetField(1, (int)DataFields.BOLT_RESULTS);
                boltResultField.Size = 29 * numberOfBoltResults;

                var numberOfStepResultsField = GetField(1, (int)DataFields.NUMBER_OF_STEP_RESULTS);
                numberOfStepResultsField.Index = boltResultField.Index + boltResultField.Size;

                var allStepDataSentField = GetField(1, (int)DataFields.ALL_STEP_DATA_SENT);
                allStepDataSentField.Index = 2 + numberOfStepResultsField.Index + numberOfStepResultsField.Size;

                var stepResultsField = GetField(1, (int)DataFields.STEP_RESULTS);
                stepResultsField.Index = 2 + allStepDataSentField.Index + allStepDataSentField.Size;

                int numberOfStepResults = _intConverter.Convert(GetValue(numberOfStepResultsField, package));
                stepResultsField.Size = 31 * numberOfStepResults;

                var numberOfSpecialValuesField = GetField(1, (int)DataFields.NUMBER_OF_SPECIAL_VALUES);
                numberOfSpecialValuesField.Index = stepResultsField.Index + stepResultsField.Size;

                var specialValuesField = GetField(1, (int)DataFields.SPECIAL_VALUES);
                specialValuesField.Index = 2 + numberOfSpecialValuesField.Index + numberOfSpecialValuesField.Size;
                specialValuesField.Size = package.Length - specialValuesField.Index;

                ProcessDataFields(package);
                _specialValueConverter = new SpecialValueListConverter(_intConverter, NumberOfSpecialValues, true);

                BoltResults = _boltResultConverter.Convert(boltResultField.Value).ToList();
                StepResults = _stepResultConverter.Convert(stepResultsField.Value).ToList();
                SpecialValues = _specialValueConverter.Convert(specialValuesField.Value).ToList();
                return this;
            }

            return NextTemplate.Parse(package);
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
                {
                    {
                        1, new List<DataField>()
                                {
                                        new DataField((int)DataFields.TOTAL_NUMBER_OF_MESSAGES, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.MESSAGE_NUMBER, 24, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.DATA_NUMBER_SYSTEM, 28, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.STATION_NUMBER, 40, 2),
                                        new DataField((int)DataFields.TIME, 44, 19),
                                        new DataField((int)DataFields.BOLT_NUMBER, 65, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.BOLT_NAME, 71, 20),
                                        new DataField((int)DataFields.PROGRAM_NAME, 93, 20),
                                        new DataField((int)DataFields.PM_STATUS, 115, 1),
                                        new DataField((int)DataFields.ERRORS, 118, 50),
                                        new DataField((int)DataFields.CUSTOMER_ERROR_CODE, 170, 4),
                                        new DataField((int)DataFields.NUMBER_OF_BOLT_RESULTS, 176, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.BOLT_RESULTS, 180, 0, false),
                                        new DataField((int)DataFields.NUMBER_OF_STEP_RESULTS, 0, 3, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.ALL_STEP_DATA_SENT, 0, 1),
                                        new DataField((int)DataFields.STEP_RESULTS, 0, 0, false),
                                        new DataField((int)DataFields.NUMBER_OF_SPECIAL_VALUES, 0, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                        new DataField((int)DataFields.SPECIAL_VALUES, 0, 0, false)
                                }
                    },
                    { 2, new List<DataField>() },
                    { 3, new List<DataField>() },
                    {
                        4, new List<DataField>()
                                {
                                        new DataField((int)DataFields.SYSTEM_SUB_TYPE, 0, 3, '0', DataField.PaddingOrientations.LEFT_PADDED)
                                }
                    }
                };
        }

        public enum DataFields
        {
            TOTAL_NUMBER_OF_MESSAGES,
            MESSAGE_NUMBER,
            DATA_NUMBER_SYSTEM,
            STATION_NUMBER,
            TIME,
            BOLT_NUMBER,
            BOLT_NAME,
            PROGRAM_NAME,
            PM_STATUS,
            ERRORS,
            CUSTOMER_ERROR_CODE,
            NUMBER_OF_BOLT_RESULTS,
            BOLT_RESULTS,
            NUMBER_OF_STEP_RESULTS,
            ALL_STEP_DATA_SENT,
            STEP_RESULTS,
            NUMBER_OF_SPECIAL_VALUES,
            SPECIAL_VALUES,
            SYSTEM_SUB_TYPE
        }

        public enum PowerMacsStatuses
        {
            OK = 0,
            OKR = 1,
            NOK = 2,
            TERMNOK = 3
        }
    }
}
