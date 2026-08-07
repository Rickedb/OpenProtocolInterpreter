using System;
using System.Collections.Generic;

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

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        public int TotalTools { get; set; }

        [ToolDataCollectionDefinition(revision: 1, field: 2, Index = 23, Size = 0, HasPrefix = false)]
        public List<ToolData> Tools { get; set; } = new List<ToolData>();

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
            TotalTools = Tools?.Count ?? 0; //Enforce list size even if modified
            GetField(revision: 1, field: 2).Size = TotalTools * ToolData.SectionSize; //Enforce size of variable data fields
            return base.Pack();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 2) //Tools
            {
                dataField.Size = TotalTools * ToolData.SectionSize;
            }
            base.ProcessDataField(dataField, package);
        }
    }
}
