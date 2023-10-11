using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Tool
{
    public class Mid0702 : Mid, ITool, IController
    {
        public const int MID = 702;

        public int ToolNumber
        {
            get => GetField(1, (int)DataFields.ToolNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.ToolNumber).SetValue(OpenProtocolConvert.ToString, value);
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
            ToolDataUpload = [];
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.NumberOfToolParameters).SetValue(OpenProtocolConvert.ToString, ToolDataUpload.Count);
            GetField(1, (int)DataFields.EachToolDataUpload).Value = OpenProtocolConvert.ToString(ToolDataUpload);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            var dataFieldsField = GetField(1, (int)DataFields.EachToolDataUpload);
            dataFieldsField.Size = Header.Length - dataFieldsField.Index;
            ProcessDataFields(package);
            ToolDataUpload = VariableDataField.ParseAll(dataFieldsField.Value).ToList();
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
                                new((int)DataFields.NumberOfToolParameters, 26, 2, '0', PaddingOrientation.LeftPadded, false),
                                new((int)DataFields.EachToolDataUpload, 28, 0, false)
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
