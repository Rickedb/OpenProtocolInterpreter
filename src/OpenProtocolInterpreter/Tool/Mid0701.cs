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
            Tools ??= [];
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.TotalTools).SetValue(OpenProtocolConvert.ToString, TotalTools);
            var eachToolField = GetField(1, (int)DataFields.EachTool);
            eachToolField.Value = PackTools();
            eachToolField.Size = eachToolField.Value.Length;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);

            var eachToolField = GetField(1, (int)DataFields.EachTool);
            eachToolField.Size = Header.Length - eachToolField.Index;
            ProcessDataFields(package);
            Tools = ToolData.ParseAll(eachToolField.Value).ToList();
            return this;
        }

        protected virtual string PackTools()
        {
            string pack = string.Empty;
            foreach (var tool in Tools)
            {
                pack += tool.Pack();
            }

            return pack;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new((int)DataFields.TotalTools, 20, 3, '0', PaddingOrientation.LeftPadded, false),
                                new((int)DataFields.EachTool, 23, 3, false)
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
