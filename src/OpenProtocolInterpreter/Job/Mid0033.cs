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

        [Int32DataFieldDefinition(field: 1, revision: 1, Index = 20, Size = 2)]
        [Int32DataFieldDefinition(field: 1, revision: 2, Index = 20, Size = 4)]
        public int JobId { get; set; }

        [StringDataFieldDefinition(field: 2, revision: 1, Index = 24, Size = 25)]
        [StringDataFieldDefinition(field: 2, revision: 2, Index = 26, Size = 25)]
        public string JobName { get; set; }

        [Int32DataFieldDefinition(field: 3, revision: 1, Index = 51, Size = 1)]
        [Int32DataFieldDefinition(field: 3, revision: 2, Index = 53, Size = 1)]
        public ForcedOrder ForcedOrder { get; set; }

        [Int32DataFieldDefinition(field: 4, revision: 1, Index = 54, Size = 4)]
        [Int32DataFieldDefinition(field: 4, revision: 2, Index = 56, Size = 4)]
        public int MaxTimeForFirstTightening { get; set; }

        [Int32DataFieldDefinition(field: 5, revision: 1, Index = 60, Size = 5)]
        [Int32DataFieldDefinition(field: 5, revision: 2, Index = 62, Size = 5)]
        public int MaxTimeToCompleteJob { get; set; }

        [Int32DataFieldDefinition(field: 6, revision: 1, Index = 67, Size = 1)]
        [Int32DataFieldDefinition(field: 6, revision: 2, Index = 69, Size = 1)]
        public JobBatchMode JobBatchMode { get; set; }

        [BooleanDataFieldDefinition(field: 7, revision: 1, Index = 70, Size = 1)]
        [BooleanDataFieldDefinition(field: 7, revision: 2, Index = 72, Size = 1)]
        public bool LockAtJobDone { get; set; }

        [BooleanDataFieldDefinition(field: 8, revision: 1, Index = 73)]
        [BooleanDataFieldDefinition(field: 8, revision: 2, Index = 75)]
        public bool UseLineControl { get; set; }

        [BooleanDataFieldDefinition(field: 9, revision: 1, Index = 76)]
        [BooleanDataFieldDefinition(field: 9, revision: 2, Index = 78)]
        public bool RepeatJob { get; set; }

        [Int32DataFieldDefinition(field: 10, revision: 1, Index = 79, Size = 1)]
        [Int32DataFieldDefinition(field: 10, revision: 2, Index = 81, Size = 1)]
        public ToolLoosening ToolLoosening { get; set; }

        [Int32DataFieldDefinition(field: 11, revision: 1, Index = 82, Size = 1)]
        [Int32DataFieldDefinition(field: 11, revision: 2, Index = 84, Size = 1)]
        public Reserved Reserved { get; set; }

        [Int32DataFieldDefinition(field: 12, revision: 1, Index = 85, Size = 2)]
        [Int32DataFieldDefinition(field: 12, revision: 2, Index = 87, Size = 2)]
        public int NumberOfParameterSets { get; set; }

        [ParameterSetCollectionDefinition(field: 13, revision: 1, Index = 89, Size = 0)]
        [ParameterSetCollectionDefinition(field: 13, revision: 2, Index = 91, Size = 0)]
        [ParameterSetCollectionDefinition(field: 13, revision: 3, Index = 91, Size = 0)]
        [ParameterSetCollectionDefinition(field: 13, revision: 4, Index = 91, Size = 0)]
        [ParameterSetCollectionDefinition(field: 13, revision: 5, Index = 91, Size = 0)]
        public List<ParameterSet> ParameterSetList { get; set; }

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

        protected override void ProcessDataFields(List<DataField> dataFields, ReadOnlySpan<char> package)
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

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            JobId,
            JobName,
            ForcedOrder,
            MaxTimeForFirstTightening,
            MaxTimeToCompleteJob,
            JobBatchDone,
            LockAtJobDone,
            UseLineControl,
            RepeatJob,
            ToolLoosening,
            Reserved,
            NumberOfParameterSets,
            ParameterSetList
        }
    }
}
