using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Set calibration value request with generic data
    /// <para>
    ///     This message is sent by the integrator in order to set the calibration value of the tool.
    /// </para>    
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///             <see cref="Communication.Mid0004"/> Command error, with code Calibration failed
    /// </para>
    /// </summary>
    public class Mid0703 : Mid, ITool, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<IEnumerable<VariableDataField>> _variableDataFieldListConverter;
        public const int MID = 703;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.CalibrationFailed };

        public int ToolNumber
        {
            get => GetField(1, (int)DataFields.ToolNumber).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.ToolNumber).SetValue(_intConverter.Convert, value);
        }
        public int NumberOfCalibrationParameters => CalibrationParameters.Count;
        public List<VariableDataField> CalibrationParameters { get; set; }

        public Mid0703() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0703(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            _variableDataFieldListConverter = new VariableDataFieldListConverter(_intConverter);
            CalibrationParameters = new List<VariableDataField>();
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.NumberOfCalibrationParameters).SetValue(_intConverter.Convert, CalibrationParameters.Count);
            GetField(1, (int)DataFields.EachCalibrationParameter).Value = _variableDataFieldListConverter.Convert(CalibrationParameters);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            var dataFieldsField = GetField(1, (int)DataFields.EachCalibrationParameter);
            dataFieldsField.Size = Header.Length - dataFieldsField.Index;
            ProcessDataFields(package);
            CalibrationParameters = _variableDataFieldListConverter.Convert(dataFieldsField.Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.ToolNumber, 20, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.NumberOfCalibrationParameters, 26, 2, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.EachCalibrationParameter, 28, 0, false)
                            }
                }
            };
        }
        protected enum DataFields
        {
            ToolNumber,
            NumberOfCalibrationParameters,
            EachCalibrationParameter
        }
    }
}
