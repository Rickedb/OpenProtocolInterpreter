using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Tool Data upload reply with generic data
    /// <para>Upload a list of connected tools from controller.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// <para>The list will contain all tool parameters that are connected to the controller or station.</para>
    /// <para>To request the data <see cref="Communication.Mid0006"/> with required extra data (<see cref="Mid0702ExtraData"/>) is used.</para>
    /// </summary>
    public class Mid0702 : Mid, ITool, IController
    {
        public const int MID = 702;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        public int NumberOfToolPIDs { get; set; }

        [VariableDataFieldCollectionDefinition(revision: 1, field: 2, Index = 23, Size = 0, HasPrefix = false)]
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
            NumberOfToolPIDs = ToolDataUpload?.Count ?? 0; //Enforce list size even if modified
            GetField(revision: 1, field: 2).Size = ToolDataUpload?.Sum(x => x.TotalSize) ?? 0; //Enforce size of variable data fields
            return base.Pack();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 2) //VariableDataFields
            {
                dataField.Size = Header.Length - dataField.Index;
            }
            base.ProcessDataField(dataField, package);
        }
    }

    /// <summary>
    /// To request the data <see cref="Communication.Mid0006"/> Application data message request with required extra data is used
    /// <para>A check for allowed PIDs to be included in this message should be done for each controller type.</para>
    /// </summary>
    public class Mid0702ExtraData : ExtraData, IExtraDataRequest
    {
        public override int Mid => Mid0702.MID;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 0, Size = 4)]
        public int ToolNumber { get; set; }

        public Mid0702ExtraData()
        {

        }

        public Mid0702ExtraData(int revision) : base(revision)
        {

        }
    }

}
