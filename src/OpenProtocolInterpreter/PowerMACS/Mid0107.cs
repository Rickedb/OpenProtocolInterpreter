using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// Last Power MACS tightening result Bolt data
    /// <para>
    ///    This message contains the cycle data for one Bolt, both Bolt data and step data. It is only sent if 
    ///    the acknowledgement of the message <see cref="Mid0106"/> Last PowerMACS tightening result station data had the parameter 
    ///    Bolt Data set to TRUE. The next Bolt data is sent if the acknowledgement has the parameter Bolt Data set to TRUE.
    ///    This telegram is also used for Power MACS systems running a Press.The layout of the telegram is exactly the 
    ///    same but some of the fields have slightly different definitions. The fields for Torque are used for Force values 
    ///    and the fields for Angle are used for Stroke values. Press systems also use different identifiers for the optional 
    ///    data on bolt and step level. Press systems always use revision 4 or higher of the telegram.Values in the fixed part
    ///    that are undefined in the results will be sent as all spaces (ASCII 0x20). 
    /// </para>
    /// <para>
    ///    This can happen with the Customer Error Code if this function is not activated.
    /// </para>
    /// <para>
    ///    Note 2: The Bolt results and step results are only sent when the value exists in the result. This means,
    ///    for example, that if no high limit is programmed for Peak T, then the value Peak T + will not be sent
    ///    even if limits for Peak T are defined in the reporter.
    /// </para>   
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0108"/> Last PowerMACS tightening result data acknowledge</para>
    /// </summary>
    public class Mid0107 : Mid, IPowerMACS, IController, IAcknowledgeable<Mid0108>
    {
        private readonly IValueConverter<bool> _boolConverter;
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<DateTime> _dateConverter;
        private readonly IValueConverter<IEnumerable<BoltResult>> _boltResultConverter;
        private readonly IValueConverter<IEnumerable<StepResult>> _stepResultConverter;
        private IValueConverter<IEnumerable<SpecialValue>> _specialValueConverter;
        public const int MID = 107;

        public int TotalNumberOfMessages
        {
            get => GetField(1, (int)DataFields.TotalNumberOfMessages).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.TotalNumberOfMessages).SetValue(_intConverter.Convert, value);
        }
        public int MessageNumber
        {
            get => GetField(1, (int)DataFields.MessageNumber).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.MessageNumber).SetValue(_intConverter.Convert, value);
        }
        public int DataNumberSystem
        {
            get => GetField(1, (int)DataFields.DataNumberSystem).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.DataNumberSystem).SetValue(_intConverter.Convert, value);
        }
        public int StationNumber
        {
            get => GetField(1, (int)DataFields.StationNumber).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.StationNumber).SetValue(_intConverter.Convert, value);
        }
        public DateTime Time
        {
            get => GetField(1, (int)DataFields.Time).GetValue(_dateConverter.Convert);
            set => GetField(1, (int)DataFields.Time).SetValue(_dateConverter.Convert, value);
        }
        public int BoltNumber
        {
            get => GetField(1, (int)DataFields.BoltNumber).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.BoltNumber).SetValue(_intConverter.Convert, value);
        }
        public string BoltName
        {
            get => GetField(1, (int)DataFields.BoltName).Value;
            set => GetField(1, (int)DataFields.BoltName).SetValue(value);
        }
        public string ProgramName
        {
            get => GetField(1, (int)DataFields.ProgramName).Value;
            set => GetField(1, (int)DataFields.ProgramName).SetValue(value);
        }
        public PowerMacsStatus PowerMacsStatus
        {
            get => (PowerMacsStatus)GetField(1, (int)DataFields.PMStatus).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.PMStatus).SetValue(_intConverter.Convert, (int)value);
        }
        public string Errors
        {
            get => GetField(1, (int)DataFields.Errors).Value;
            set => GetField(1, (int)DataFields.Errors).SetValue(value);
        }
        public string CustomerErrorCode
        {
            get => GetField(1, (int)DataFields.CustomerErrorCode).Value;
            set => GetField(1, (int)DataFields.CustomerErrorCode).SetValue(value);
        }
        public int NumberOfBoltResults
        {
            get => GetField(1, (int)DataFields.NumberOfBoltResults).GetValue(_intConverter.Convert);
            private set => GetField(1, (int)DataFields.NumberOfBoltResults).SetValue(_intConverter.Convert, value);
        }
        public List<BoltResult> BoltResults { get; set; }
        public int NumberOfStepResults
        {
            get => GetField(1, (int)DataFields.NumberOfStepResults).GetValue(_intConverter.Convert);
            private set => GetField(1, (int)DataFields.NumberOfStepResults).SetValue(_intConverter.Convert, value);
        }
        public bool AllStepDataSent
        {
            get => GetField(1, (int)DataFields.AllStepDataSent).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.AllStepDataSent).SetValue(_boolConverter.Convert, value);
        }
        public List<StepResult> StepResults { get; set; }
        public int NumberOfSpecialValues
        {
            get => GetField(1, (int)DataFields.NumberOfSpecialValues).GetValue(_intConverter.Convert);
            private set => GetField(1, (int)DataFields.NumberOfSpecialValues).SetValue(_intConverter.Convert, value);
        }
        public List<SpecialValue> SpecialValues { get; set; }

        public Mid0107() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
            
        }

        public Mid0107(Header header) : base(header)
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

        public override string Pack()
        {
            NumberOfBoltResults = BoltResults.Count;
            NumberOfStepResults = StepResults.Count;
            NumberOfSpecialValues = SpecialValues.Count;
            _specialValueConverter = new SpecialValueListConverter(_intConverter, NumberOfSpecialValues, true);

            GetField(1, (int)DataFields.BoltResults).SetValue(_boltResultConverter.Convert(BoltResults));
            GetField(1, (int)DataFields.StepResults).SetValue(_stepResultConverter.Convert(StepResults));
            GetField(1, (int)DataFields.SpecialValues).SetValue(_specialValueConverter.Convert(SpecialValues));

            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);

            int numberOfBoltResults = _intConverter.Convert(GetValue(GetField(1, (int)DataFields.NumberOfBoltResults), package));
            var boltResultField = GetField(1, (int)DataFields.BoltResults);
            boltResultField.Size = 29 * numberOfBoltResults;

            var numberOfStepResultsField = GetField(1, (int)DataFields.NumberOfStepResults);
            numberOfStepResultsField.Index = boltResultField.Index + boltResultField.Size;

            var allStepDataSentField = GetField(1, (int)DataFields.AllStepDataSent);
            allStepDataSentField.Index = 2 + numberOfStepResultsField.Index + numberOfStepResultsField.Size;

            var stepResultsField = GetField(1, (int)DataFields.StepResults);
            stepResultsField.Index = 2 + allStepDataSentField.Index + allStepDataSentField.Size;

            int numberOfStepResults = _intConverter.Convert(GetValue(numberOfStepResultsField, package));
            stepResultsField.Size = 31 * numberOfStepResults;

            var numberOfSpecialValuesField = GetField(1, (int)DataFields.NumberOfSpecialValues);
            numberOfSpecialValuesField.Index = stepResultsField.Index + stepResultsField.Size;

            var specialValuesField = GetField(1, (int)DataFields.SpecialValues);
            specialValuesField.Index = 2 + numberOfSpecialValuesField.Index + numberOfSpecialValuesField.Size;
            specialValuesField.Size = Header.Length - specialValuesField.Index;

            ProcessDataFields(package);
            _specialValueConverter = new SpecialValueListConverter(_intConverter, NumberOfSpecialValues, true);

            BoltResults = _boltResultConverter.Convert(boltResultField.Value).ToList();
            StepResults = _stepResultConverter.Convert(stepResultsField.Value).ToList();
            SpecialValues = _specialValueConverter.Convert(specialValuesField.Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
                {
                    {
                        1, new List<DataField>()
                                {
                                        new DataField((int)DataFields.TotalNumberOfMessages, 20, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.MessageNumber, 24, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.DataNumberSystem, 28, 10, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.StationNumber, 40, 2),
                                        new DataField((int)DataFields.Time, 44, 19),
                                        new DataField((int)DataFields.BoltNumber, 65, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.BoltName, 71, 20),
                                        new DataField((int)DataFields.ProgramName, 93, 20),
                                        new DataField((int)DataFields.PMStatus, 115, 1),
                                        new DataField((int)DataFields.Errors, 118, 50),
                                        new DataField((int)DataFields.CustomerErrorCode, 170, 4),
                                        new DataField((int)DataFields.NumberOfBoltResults, 176, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.BoltResults, 180, 0, false),
                                        new DataField((int)DataFields.NumberOfStepResults, 0, 3, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.AllStepDataSent, 0, 1),
                                        new DataField((int)DataFields.StepResults, 0, 0, false),
                                        new DataField((int)DataFields.NumberOfSpecialValues, 0, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                        new DataField((int)DataFields.SpecialValues, 0, 0, false)
                                }
                    },
                    {
                        4, new List<DataField>()
                                {
                                        new DataField((int)DataFields.SystemSubType, 0, 3, '0', DataField.PaddingOrientations.LeftPadded)
                                }
                    }
                };
        }

        protected enum DataFields
        {
            TotalNumberOfMessages,
            MessageNumber,
            DataNumberSystem,
            StationNumber,
            Time,
            BoltNumber,
            BoltName,
            ProgramName,
            PMStatus,
            Errors,
            CustomerErrorCode,
            NumberOfBoltResults,
            BoltResults,
            NumberOfStepResults,
            AllStepDataSent,
            StepResults,
            NumberOfSpecialValues,
            SpecialValues,
            SystemSubType
        }
    }
}
