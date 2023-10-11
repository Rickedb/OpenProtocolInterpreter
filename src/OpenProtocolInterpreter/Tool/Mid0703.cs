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
        public const int MID = 703;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.CalibrationFailed };

        public int ToolNumber
        {
            get => GetField(1, (int)DataFields.ToolNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.ToolNumber).SetValue(OpenProtocolConvert.ToString, value);
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
            CalibrationParameters = [];
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.NumberOfCalibrationParameters).SetValue(OpenProtocolConvert.ToString, CalibrationParameters.Count);
            GetField(1, (int)DataFields.EachCalibrationParameter).Value = OpenProtocolConvert.ToString(CalibrationParameters);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            var dataFieldsField = GetField(1, (int)DataFields.EachCalibrationParameter);
            dataFieldsField.Size = Header.Length - dataFieldsField.Index;
            ProcessDataFields(package);
            CalibrationParameters = VariableDataField.ParseAll(dataFieldsField.Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new((int)DataFields.ToolNumber, 20, 4, '0', PaddingOrientation.LeftPadded),
                                new((int)DataFields.NumberOfCalibrationParameters, 26, 2, '0', PaddingOrientation.LeftPadded, false),
                                new((int)DataFields.EachCalibrationParameter, 28, 0, false)
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
