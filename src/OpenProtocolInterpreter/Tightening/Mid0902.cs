using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Tightening Result DB Info Upload
    /// <para>This message contains information concerning the tightening result database on the controller.</para>
    /// <para><see cref="Communication.Mid0006"/> Application Data Message Request shall be used for fetching this message</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0902 : Mid, ITightening, IController
    {
        public const int MID = 902;

        [Int64DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 10, HasPrefix = false)]
        public long Capacity { get; set; }

        [Int64DataFieldDefinition(revision: 1, field: 2, Index = 30, Size = 10, HasPrefix = false)]
        public long OldestSequenceNumber { get; set; }

        [TimestampDataFieldDefinition(revision: 1, field: 3, Index = 40, HasPrefix = false)]
        public DateTime OldestTime { get; set; }

        [Int64DataFieldDefinition(revision: 1, field: 4, Index = 59, Size = 10, HasPrefix = false)]
        public long NewestSequenceNumber { get; set; }

        [TimestampDataFieldDefinition(revision: 1, field: 5, Index = 69, HasPrefix = false)]
        public DateTime NewestTime { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 6, Index = 88, Size = 3, HasPrefix = false)]
        public int NumberOfPIDs { get; set; }

        [VariableDataFieldCollectionDefinition(revision: 1, field: 7, Index = 91, Size = 0, HasPrefix = false)]
        public List<VariableDataField> VariableDataFields { get; set; }

        public Mid0902() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0902(Header header) : base(header)
        {
            VariableDataFields = [];
        }

        public override string Pack()
        {
            NumberOfPIDs = VariableDataFields?.Count ?? 0; //Enforce list size even if modified
            GetField(revision: 1, field: 7).Size = VariableDataFields?.Sum(x => x.TotalSize) ?? 0; //Enforce size of variable data fields
            return base.Pack();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 7) //VariableDataFields
            {
                dataField.Size = Header.Length - dataField.Index;
            }
            base.ProcessDataField(dataField, package);
        }
    }
}
