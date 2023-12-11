using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public const int MID = 107;

        public int TotalNumberOfMessages
        {
            get => GetField(1, DataFields.TotalNumberOfMessages).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.TotalNumberOfMessages).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int MessageNumber
        {
            get => GetField(1, DataFields.MessageNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.MessageNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int DataNumberSystem
        {
            get => GetField(1, DataFields.DataNumberSystem).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.DataNumberSystem).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int StationNumber
        {
            get => GetField(1, DataFields.StationNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.StationNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime Time
        {
            get => GetField(1, DataFields.Time).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, DataFields.Time).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int BoltNumber
        {
            get => GetField(1, DataFields.BoltNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.BoltNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string BoltName
        {
            get => GetField(1, DataFields.BoltName).Value;
            set => GetField(1, DataFields.BoltName).SetValue(value);
        }
        public string ProgramName
        {
            get => GetField(1, DataFields.ProgramName).Value;
            set => GetField(1, DataFields.ProgramName).SetValue(value);
        }
        public PowerMacsStatus PowerMacsStatus
        {
            get => (PowerMacsStatus)GetField(1, DataFields.PMStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.PMStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string Errors
        {
            get => GetField(1, DataFields.Errors).Value;
            set => GetField(1, DataFields.Errors).SetValue(value);
        }
        public string CustomerErrorCode
        {
            get => GetField(1, DataFields.CustomerErrorCode).Value;
            set => GetField(1, DataFields.CustomerErrorCode).SetValue(value);
        }
        public int NumberOfBoltResults
        {
            get => GetField(1, DataFields.NumberOfBoltResults).GetValue(OpenProtocolConvert.ToInt32);
            private set => GetField(1, DataFields.NumberOfBoltResults).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<BoltResult> BoltResults { get; set; }
        public int NumberOfStepResults
        {
            get => GetField(1, DataFields.NumberOfStepResults).GetValue(OpenProtocolConvert.ToInt32);
            private set => GetField(1, DataFields.NumberOfStepResults).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool AllStepDataSent
        {
            get => GetField(1, DataFields.AllStepDataSent).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, DataFields.AllStepDataSent).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<StepResult> StepResults { get; set; }
        public int NumberOfSpecialValues
        {
            get => GetField(1, DataFields.NumberOfSpecialValues).GetValue(OpenProtocolConvert.ToInt32);
            private set => GetField(1, DataFields.NumberOfSpecialValues).SetValue(OpenProtocolConvert.ToString, value);
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
            BoltResults ??= [];
            StepResults ??= [];
            SpecialValues ??= [];
        }

        public override string Pack()
        {
            NumberOfBoltResults = BoltResults.Count;
            NumberOfStepResults = StepResults.Count;
            NumberOfSpecialValues = SpecialValues.Count;

            GetField(1, DataFields.BoltResults).SetValue(PackBoltResultList());
            GetField(1, DataFields.StepResults).SetValue(PackStepResults());
            GetField(1, DataFields.SpecialValues).SetValue(PackSpecialValues());

            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);

            int numberOfBoltResults = OpenProtocolConvert.ToInt32(GetValue(GetField(1, DataFields.NumberOfBoltResults), package));
            var boltResultField = GetField(1, DataFields.BoltResults);
            boltResultField.Size = 29 * numberOfBoltResults;

            var numberOfStepResultsField = GetField(1, DataFields.NumberOfStepResults);
            numberOfStepResultsField.Index = boltResultField.Index + boltResultField.Size;

            var allStepDataSentField = GetField(1, DataFields.AllStepDataSent);
            allStepDataSentField.Index = 2 + numberOfStepResultsField.Index + numberOfStepResultsField.Size;

            var stepResultsField = GetField(1, DataFields.StepResults);
            stepResultsField.Index = 2 + allStepDataSentField.Index + allStepDataSentField.Size;

            int numberOfStepResults = OpenProtocolConvert.ToInt32(GetValue(numberOfStepResultsField, package));
            stepResultsField.Size = 31 * numberOfStepResults;

            var numberOfSpecialValuesField = GetField(1, DataFields.NumberOfSpecialValues);
            numberOfSpecialValuesField.Index = stepResultsField.Index + stepResultsField.Size;

            var specialValuesField = GetField(1, DataFields.SpecialValues);
            specialValuesField.Index = 2 + numberOfSpecialValuesField.Index + numberOfSpecialValuesField.Size;
            specialValuesField.Size = Header.Length - specialValuesField.Index;

            ProcessDataFields(package);

            BoltResults = ParseBoltResultList(boltResultField.Value);
            StepResults = ParseStepResults(stepResultsField.Value);
            SpecialValues = SpecialValue.ParseAll(specialValuesField.Value, NumberOfSpecialValues, true).ToList();
            return this;
        }

        protected virtual string PackBoltResultList()
        {
            var builder = new StringBuilder();
            foreach (var bolt in BoltResults)
            {
                builder.Append(OpenProtocolConvert.TruncatePadded(' ', 20, PaddingOrientation.RightPadded, bolt.VariableName));
                builder.Append(bolt.Type.Type);
                if (bolt.Type.Type == DataType.DataTypes[1].Type) // Integer
                {
                    builder.Append(OpenProtocolConvert.ToString('0', 7, PaddingOrientation.LeftPadded, (int)bolt.Value));
                }
                else if (bolt.Type.Type == DataType.DataTypes[2].Type) // Decimal
                {
                    builder.Append(OpenProtocolConvert.ToString('0', 7, PaddingOrientation.LeftPadded, (decimal)bolt.Value));
                }
            }

            return builder.ToString();
        }

        protected virtual string PackStepResults()
        {
            var builder = new StringBuilder();
            foreach (var step in StepResults)
            {
                builder.Append(OpenProtocolConvert.TruncatePadded(' ', 20, PaddingOrientation.RightPadded, step.VariableName));
                builder.Append(step.Type.Type);
                if (step.Type.Type == DataType.DataTypes[1].Type) // Integer
                {
                    builder.Append(OpenProtocolConvert.ToString('0', 7, PaddingOrientation.LeftPadded, (int)step.Value));
                }
                else if (step.Type.Type == DataType.DataTypes[2].Type) // Decimal
                {
                    builder.Append(OpenProtocolConvert.ToString('0', 7, PaddingOrientation.LeftPadded, (decimal)step.Value));
                }
                builder.Append(OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, step.StepNumber));
            }

            return builder.ToString();
        }

        protected virtual string PackSpecialValues()
        {
            var builder = new StringBuilder();
            foreach (var v in SpecialValues)
            {
                builder.Append(v.Pack(true));
            }

            return builder.ToString();
        }

        protected virtual List<BoltResult> ParseBoltResultList(string section)
        {
            var list = new List<BoltResult>();
            for (int i = 0; i < section.Length; i += 29)
            {
                var result = new BoltResult()
                {
                    VariableName = section.Substring(i, 20),
                    Type = DataType.DataTypes.First(x => x.Type.Trim() == section.Substring(20 + i, 2).Trim())
                };

                var resultValue = section.Substring(22 + i, 7);
                if (result.Type.Type == DataType.DataTypes[1].Type) // Integer
                {
                    result.Value = OpenProtocolConvert.ToInt32(resultValue);
                }
                else if (result.Type.Type == DataType.DataTypes[2].Type) // Decimal
                {
                    result.Value = OpenProtocolConvert.ToDecimal(resultValue);
                }

                list.Add(result);
            }

            return list;
        }

        protected virtual List<StepResult> ParseStepResults(string section)
        {
            var list = new List<StepResult>();
            for (int i = 0; i < section.Length; i += 31)
            {
                var result = new StepResult()
                {
                    VariableName = section.Substring(i, 20),
                    Type = DataType.DataTypes.First(x => x.Type.Trim() == section.Substring(20 + i, 2).Trim()),
                    StepNumber = OpenProtocolConvert.ToInt32(section.Substring(29 + i, 2))
                };

                var resultValue = section.Substring(22 + i, 7);
                if (result.Type.Type == DataType.DataTypes[1].Type) // Integer
                {
                    result.Value = OpenProtocolConvert.ToInt32(resultValue);
                }
                else if (result.Type.Type == DataType.DataTypes[2].Type) // Decimal
                {
                    int decimalPlaces = resultValue.Split('.')[1].Length;
                    result.Value = OpenProtocolConvert.ToDecimal(resultValue);
                }

                list.Add(result);
            }

            return list;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
                {
                    {
                        1, new List<DataField>()
                                {
                                        DataField.Number(DataFields.TotalNumberOfMessages, 20, 2),
                                        DataField.Number(DataFields.MessageNumber, 24, 2),
                                        DataField.Number(DataFields.DataNumberSystem, 28, 10),
                                        DataField.Number(DataFields.StationNumber, 40, 2),
                                        DataField.Timestamp(DataFields.Time, 44),
                                        DataField.Number(DataFields.BoltNumber, 65, 4),
                                        DataField.String(DataFields.BoltName, 71, 20),
                                        DataField.String(DataFields.ProgramName, 93, 20),
                                        DataField.Number(DataFields.PMStatus, 115, 1),
                                        DataField.String(DataFields.Errors, 118, 50),
                                        DataField.String(DataFields.CustomerErrorCode, 170, 4),
                                        DataField.Number(DataFields.NumberOfBoltResults, 176, 2),
                                        DataField.Volatile(DataFields.BoltResults, 180, false),
                                        DataField.Number(DataFields.NumberOfStepResults, 0, 3),
                                        DataField.Boolean(DataFields.AllStepDataSent, 0),
                                        DataField.Volatile(DataFields.StepResults, 0, false),
                                        DataField.Number(DataFields.NumberOfSpecialValues, 0, 2),
                                        DataField.Volatile(DataFields.SpecialValues, 0, false)
                                }
                    },
                    {
                        4, new List<DataField>()
                                {
                                        DataField.Number(DataFields.SystemSubType, 0, 3)
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
