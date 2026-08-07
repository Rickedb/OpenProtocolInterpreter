using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Result
{
    /// <summary>
    /// Operation result object data
    /// <para>
    ///     This message contains the cycle data for one object, both data for the whole process and data related to
    ///     the different steps in the process.The user defined values are preconfigured in the controller via the
    ///     configuration tool. The message uses the Variable Parameter pattern for transmission of the values.
    /// </para>
    /// <para>
    ///     Note: Only values that exist in the result will be sent.So the actual data received may vary between
    ///     the cycles if the settings differ between different programs.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>
    ///     Answer: <see cref="Mid1203"/> Operation result data acknowledge or
    ///             <see cref="Communication.Mid0005"/> with <see cref="Mid1202"/> in the data field.
    /// </para>
    ///
    ///         If the sequence number acknowledge functionality is used there is no need for these acknowledges.
    /// </summary>
    public class Mid1202 : Mid, IResult, IController, IAcknowledgeable<Mid1203>, IAcceptableCommand
    {
        public const int MID = 1202;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        public int TotalNumberOfMessages { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 23, Size = 3, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 2, field: 2, Index = 23, Size = 3, HasPrefix = false)]
        public int MessageNumber { get; set; }

        [Int64DataFieldDefinition(revision: 1, field: 3, Index = 26, Size = 10, HasPrefix = false)]
        [Int64DataFieldDefinition(revision: 2, field: 3, Index = 26, Size = 10, HasPrefix = false)]
        public long ResultDataIdentifier { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 4, Index = 36, Size = 4, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 2, field: 4, Index = 36, Size = 4, HasPrefix = false)]
        public int ObjectId { get; set; }

        [StringDataFieldDefinition(revision: 2, field: 5, Index = 40, Size = 36, HasPrefix = false)]
        public string NodeGuid { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 5, Index = 40, Size = 3, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 2, field: 6, Index = 76, Size = 3, HasPrefix = false)]
        public int NumberOfDataFields { get; set; }

        [VariableDataFieldCollectionDefinition(revision: 1, field: 6, Index = 43, Size = 0, HasPrefix = false)]
        [VariableDataFieldCollectionDefinition(revision: 2, field: 7, Index = 79, Size = 0, HasPrefix = false)]
        public List<VariableDataField> VariableDataFields { get; set; }

        public Mid1202() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid1202(Header header) : base(header)
        {
            VariableDataFields = [];
        }

        protected override string BuildHeader()
        {
            var fields = DataFieldsByRevision();
            Header.Length = Header.DefaultSize + fields.Sum(x => x.TotalSize);
            return Header.ToString();
        }

        public override string Pack()
        {
            NumberOfDataFields = VariableDataFields?.Count ?? 0; //Enforce list size even if modified
            var field = Header.StandardizedRevision > 1 ? 7 : 6;
            GetField(revision: Header.StandardizedRevision, field: field).Size = VariableDataFields?.Sum(x => x.TotalSize) ?? 0; //Enforce size of variable data fields

            var builder = new StringBuilder();
            builder.Append(BuildHeader());
            builder.Append(Pack(DataFieldsByRevision()));
            return builder.ToString();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            switch (dataField.Field)
            {
                case 6 when dataField is DataField<List<VariableDataField>>:
                case 7 when dataField is DataField<List<VariableDataField>>:
                    dataField.Size = Header.Length - dataField.Index;
                    break;
            }

            base.ProcessDataField(dataField, package);
        }

        protected override void ProcessDataFields(ReadOnlySpan<char> package)
        {
            foreach (var field in DataFieldsByRevision())
                ProcessDataField(field, package);
        }

        private IEnumerable<DataField> DataFieldsByRevision()
        {
            var previousField = default(DataField);
            foreach (var dataField in RevisionsByFields[Header.StandardizedRevision])
            {
                if (previousField != null && dataField.Index == 0)
                {
                    dataField.Index = previousField.Index + previousField.TotalSize;
                }

                previousField = dataField;
                yield return dataField;
            }
        }
    }
}
