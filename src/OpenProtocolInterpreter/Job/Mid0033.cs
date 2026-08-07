using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Job data upload reply
    /// <para>This message is sent as a reply to the <see cref="Mid0032"/> Job data request.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0033 : Mid, IJob, IController
    {
        public const int MID = 33;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 2)]
        [Int32DataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 4)]
        public int JobId { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 2, Index = 24, Size = 25)]
        [StringDataFieldDefinition(revision: 2, field: 2, Index = 26, Size = 25)]
        public string JobName { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 3, Index = 51, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 3, Index = 53, Size = 1)]
        public ForcedOrder ForcedOrder { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 4, Index = 54, Size = 4)]
        [Int32DataFieldDefinition(revision: 2, field: 4, Index = 56, Size = 4)]
        public int MaxTimeForFirstTightening { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 5, Index = 60, Size = 5)]
        [Int32DataFieldDefinition(revision: 2, field: 5, Index = 62, Size = 5)]
        public int MaxTimeToCompleteJob { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 6, Index = 67, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 6, Index = 69, Size = 1)]
        public JobBatchMode JobBatchMode { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 7, Index = 70, Size = 1)]
        [BooleanDataFieldDefinition(revision: 2, field: 7, Index = 72, Size = 1)]
        public bool LockAtJobDone { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 8, Index = 73)]
        [BooleanDataFieldDefinition(revision: 2, field: 8, Index = 75)]
        public bool UseLineControl { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 9, Index = 76)]
        [BooleanDataFieldDefinition(revision: 2, field: 9, Index = 78)]
        public bool RepeatJob { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 10, Index = 79, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 10, Index = 81, Size = 1)]
        public ToolLoosening ToolLoosening { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 11, Index = 82, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 11, Index = 84, Size = 1)]
        public Reserved Reserved { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 12, Index = 85, Size = 2)]
        [Int32DataFieldDefinition(revision: 2, field: 12, Index = 87, Size = 2)]
        public int NumberOfParameterSets { get; set; }

        [ParameterSetCollectionDefinition(revision: 1, field: 13, Index = 89, Size = 0)]
        [ParameterSetCollectionDefinition(revision: 2, field: 13, Index = 91, Size = 0)]
        [ParameterSetCollectionDefinition(revision: 3, field: 13, Index = 91, Size = 0)]
        [ParameterSetCollectionDefinition(revision: 4, field: 13, Index = 91, Size = 0)]
        [ParameterSetCollectionDefinition(revision: 5, field: 13, Index = 91, Size = 0)]
        public List<ParameterSet> ParameterSetList { get; set; } = new List<ParameterSet>();

        public Mid0033() : this(DEFAULT_REVISION)
        {

        }

        public Mid0033(Header header) : base(header)
        {
            ParameterSetList ??= [];
        }

        public Mid0033(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        protected override string BuildHeader()
        {
            Header.Length = Header.DefaultSize;
            var fromRevision = Header.StandardizedRevision > 1 ? 2 : 1;
            for (int i = fromRevision; i <= Header.StandardizedRevision; i++)
            {
                if (RevisionsByFields.TryGetValue(i, out var dataFields))
                {
                    foreach (var dataField in dataFields)
                    {
                        if (dataField.Field == 13) //ParameterSetList
                            continue;
                        Header.Length += dataField.TotalSize;
                    }
                }
            }

            Header.Length += GetField(nameof(ParameterSetList)).TotalSize;
            return Header.ToString();
        }

        public override string Pack()
        {
            NumberOfParameterSets = ParameterSetList?.Count ?? 0;
            GetField(nameof(ParameterSetList)).Size = NumberOfParameterSets * ParameterSet.Size(Header.StandardizedRevision);
            var builder = new StringBuilder(BuildHeader());
            var fields = DataFieldsByRevision().ToList();
            builder.Append(base.Pack(fields));
            return builder.ToString();
        }

        protected override void ProcessDataFields(IEnumerable<DataField> dataFields, ReadOnlySpan<char> package)
        {
            foreach (var dataField in DataFieldsByRevision())
                ProcessDataField(dataField, package);
        }

        private IEnumerable<DataField> DataFieldsByRevision()
        {
            var fromRevision = Header.StandardizedRevision > 1 ? 2 : 1;
            for (int i = fromRevision; i <= Header.StandardizedRevision; i++)
            {
                if (RevisionsByFields.TryGetValue(i, out var dataFields))
                {
                    foreach (var dataField in dataFields)
                    {
                        if (dataField.Field == 13) //ParameterSetList
                            continue;

                        yield return dataField;
                    }
                }
            }

            yield return GetField(nameof(ParameterSetList));
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 13) //ParameterSetList
            {
                dataField.Size = NumberOfParameterSets * ParameterSet.Size(Header.StandardizedRevision);
            }
            base.ProcessDataField(dataField, package);
        }
    }
}
