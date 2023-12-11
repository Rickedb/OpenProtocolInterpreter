using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Tool Data status reply with generic data
    /// <para>
    ///     Upload requested parameters from given tool.
    /// </para>    
    /// <para>Message sent by: Controller</para>
    /// <para>
    ///     Answer: None
    /// </para>
    /// <para>
    ///     The list will contain requested parameters from the tool.
    /// </para>
    /// </summary>
    public class Mid0704 : Mid, ITool, IController
    {
        public const int MID = 704;

        public int NumberOfDataFields
        {
            get => GetField(1, DataFields.NumberOfDataFields).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.NumberOfDataFields).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<VariableDataField> VariableDataFields { get; set; }

        public Mid0704() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0704(Header header) : base(header)
        {
        }

        public override string Pack()
        {
            var revision = Header.StandardizedRevision;
            GetField(revision, DataFields.VariableDataFields).SetValue(OpenProtocolConvert.ToString(VariableDataFields));

            var index = 1;
            return string.Concat(BuildHeader(), base.Pack(revision, ref index));
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);

            var field = GetField(1, DataFields.VariableDataFields);
            field.Size = Header.Length - field.Index;
            base.Parse(package);
            VariableDataFields = VariableDataField.ParseAll(field.Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Number(DataFields.NumberOfDataFields, 20, 3, false),
                                DataField.Volatile(DataFields.VariableDataFields, 23, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            NumberOfDataFields,
            VariableDataFields
        }
    }
}
