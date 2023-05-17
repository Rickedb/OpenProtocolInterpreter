using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Tool list upload reply
    /// <para>
    ///     Upload a list of connected tools from controller.
    /// </para>    
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// <para>The list will contain all tools that are connected to the controller or station.</para>
    /// <para>To request the data <see cref="Communication.Mid0006"/> Application data message request without any extra data is used.</para>
    /// </summary>
    public class Mid0701 : Mid, ITool, IController
    {
        private readonly IValueConverter<IEnumerable<ToolData>> _toolListConverter;
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 701;

        public int TotalTools { get => Tools.Count; }
        public List<ToolData> Tools { get; set; }

        public Mid0701() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0701(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            _toolListConverter = new ToolListConverter(_intConverter);
            if (Tools == null)
            {
                Tools = new List<ToolData>();
            }
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.TotalTools).SetValue(_intConverter.Convert, TotalTools);
            var eachToolField = GetField(1, (int)DataFields.EachTool);
            eachToolField.Value = _toolListConverter.Convert(Tools);
            eachToolField.Size = eachToolField.Value.Length;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);

            var eachToolField = GetField(1, (int)DataFields.EachTool);
            eachToolField.Size = Header.Length - eachToolField.Index;
            ProcessDataFields(package);
            Tools = _toolListConverter.Convert(eachToolField.Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.TotalTools, 20, 3, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.EachTool, 23, 3, false)
                            }
                }
            };
        }
        protected enum DataFields
        {
            TotalTools,
            EachTool
        }
    }
}
