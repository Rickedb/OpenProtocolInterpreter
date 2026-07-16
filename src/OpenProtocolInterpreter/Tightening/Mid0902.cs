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

        [Int64DataFieldDefinition(field: 1, revision: 1, Size = 10, HasPrefix = false)]
        public long Capacity { get; set; }

        [Int64DataFieldDefinition(field: 2, revision: 1, Size = 10, HasPrefix = false)]
        public long OldestSequenceNumber { get; set; }

        [TimestampDataFieldDefinition(field: 3, revision: 1, HasPrefix = false)]
        public DateTime OldestTime { get; set; }

        [Int64DataFieldDefinition(field: 4, revision: 1, Size = 10, HasPrefix = false)]
        public long NewestSequenceNumber { get; set; }

        [TimestampDataFieldDefinition(field: 5, revision: 1, HasPrefix = false)]
        public DateTime NewestTime { get; set; }

        [Int32DataFieldDefinition(field: 6, revision: 1, Size = 3, HasPrefix = false)]
        public int NumberOfPIDs { get; set; }

        [VariableDataFieldCollectionDefinition(field: 7, revision: 1, HasPrefix = false)]
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

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            Capacity,
            OldestSequenceNumber,
            OldestTime,
            NewestSequenceNumber,
            NewestTime,
            NumberOfPIDs,
            VariableDataFields
        }
    }
}
