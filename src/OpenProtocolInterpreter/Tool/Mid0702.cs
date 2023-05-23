using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Tool
{
    public class Mid0702 : Mid, ITool, IController
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<IEnumerable<VariableDataField>> _variableDataFieldListConverter;
        public const int MID = 702;

        public int ToolNumber
        {
            get => GetField(1, (int)DataFields.ToolNumber).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.ToolNumber).SetValue(_intConverter.Convert, value);
        }
        public int NumberOfToolParameters => ToolDataUpload.Count;
        public List<VariableDataField> ToolDataUpload { get; set; }

        public Mid0702() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0702(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            _variableDataFieldListConverter = new VariableDataFieldListConverter(_intConverter);
            ToolDataUpload = new List<VariableDataField>();
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.NumberOfToolParameters).SetValue(_intConverter.Convert, ToolDataUpload.Count);
            GetField(1, (int)DataFields.EachToolDataUpload).Value = _variableDataFieldListConverter.Convert(ToolDataUpload);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            var dataFieldsField = GetField(1, (int)DataFields.EachToolDataUpload);
            dataFieldsField.Size = Header.Length - dataFieldsField.Index;
            ProcessDataFields(package);
            ToolDataUpload = _variableDataFieldListConverter.Convert(dataFieldsField.Value).ToList();
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
                                new DataField((int)DataFields.NumberOfToolParameters, 26, 2, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.EachToolDataUpload, 28, 0, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            ToolNumber,
            NumberOfToolParameters,
            EachToolDataUpload
        }
    }
}
