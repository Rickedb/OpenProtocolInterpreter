using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Execute dynamic Job request
    /// <para>
    ///     The integrator requests a dynamical Job to be executed i.e. the Job sent from the integrator is
    ///     immediately executed(if possible) by the controller but not saved in the memory.A dynamical Job
    ///     lifetime is the time for the Job to be executed.If the controller is powered off before the completion of
    ///     the Job, the dynamical Job is lost.
    /// </para>
    /// <para>Do note the limitation when sending this message on a serial connection due to the size of the read buffer (256 bytes) in the controller.</para>
    /// <para>In such case the number of programs in the Job list is limited.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0140 : Mid, IAdvancedJob, IIntegrator, IAcceptableCommand
    {
        public const int MID = 140;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 4)]
        [Int32DataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 4)]
        [Int32DataFieldDefinition(revision: 3, field: 1, Index = 20, Size = 4)]
        [Int32DataFieldDefinition(revision: 4, field: 1, Index = 20, Size = 4)]
        [Int32DataFieldDefinition(revision: 999, field: 1, Index = 20, Size = 4)]
        public int JobId { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 2, Index = 26, Size = 25)]
        [StringDataFieldDefinition(revision: 2, field: 2, Index = 26, Size = 25)]
        [StringDataFieldDefinition(revision: 3, field: 2, Index = 26, Size = 25)]
        [StringDataFieldDefinition(revision: 4, field: 2, Index = 26, Size = 25)]
        [StringDataFieldDefinition(revision: 999, field: 2, Index = 26, Size = 25)]
        public string JobName { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 3, Index = 53, Size = 2)]
        [Int32DataFieldDefinition(revision: 2, field: 3, Index = 53, Size = 2)]
        [Int32DataFieldDefinition(revision: 3, field: 3, Index = 53, Size = 2)]
        [Int32DataFieldDefinition(revision: 4, field: 3, Index = 53, Size = 2)]
        [Int32DataFieldDefinition(revision: 999, field: 3, Index = 53, Size = 2)]
        public int NumberOfParameterSets { get; set; }

        [AdvancedJobCollectionDefinition(revision: 1, field: 4, Index = 57, Size = 0)]
        [AdvancedJobCollectionDefinition(revision: 2, field: 4, Index = 57, Size = 0)]
        [AdvancedJobCollectionDefinition(revision: 3, field: 4, Index = 57, Size = 0)]
        [AdvancedJobCollectionDefinition(revision: 4, field: 4, Index = 57, Size = 0)]
        [AdvancedJobCollectionDefinition(revision: 999, field: 4, Index = 57, Size = 0)]
        public List<AdvancedJob> JobList { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 5, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 5, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 3, field: 5, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 4, field: 5, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 999, field: 5, Index = 0, Size = 1)]
        public ForcedOrder ForcedOrder { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 6, Index = 0)]
        [BooleanDataFieldDefinition(revision: 2, field: 6, Index = 0)]
        [BooleanDataFieldDefinition(revision: 3, field: 6, Index = 0)]
        [BooleanDataFieldDefinition(revision: 4, field: 6, Index = 0)]
        [BooleanDataFieldDefinition(revision: 999, field: 6, Index = 0)]
        public bool LockAtJobDone { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 7, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 7, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 999, field: 7, Index = 0, Size = 1)]
        public ToolLoosening ToolLoosening { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 8, Index = 0)]
        [BooleanDataFieldDefinition(revision: 2, field: 8, Index = 0)]
        [BooleanDataFieldDefinition(revision: 3, field: 7, Index = 0)]
        [BooleanDataFieldDefinition(revision: 4, field: 7, Index = 0)]
        [BooleanDataFieldDefinition(revision: 999, field: 8, Index = 0)]
        public bool RepeatJob { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 9, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 9, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 999, field: 9, Index = 0, Size = 1)]
        public BatchMode BatchMode { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 10, Index = 0)]
        [BooleanDataFieldDefinition(revision: 2, field: 10, Index = 0)]
        [BooleanDataFieldDefinition(revision: 999, field: 10, Index = 0)]
        public bool BatchStatusAtIncrement { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 11, Index = 0)]
        [BooleanDataFieldDefinition(revision: 2, field: 11, Index = 0)]
        [BooleanDataFieldDefinition(revision: 999, field: 11, Index = 0)]
        public bool DecrementBatchAtOkLoosening { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 12, Index = 0, Size = 4)]
        [Int32DataFieldDefinition(revision: 2, field: 12, Index = 0, Size = 4)]
        [Int32DataFieldDefinition(revision: 3, field: 8, Index = 0, Size = 4)]
        [Int32DataFieldDefinition(revision: 4, field: 8, Index = 0, Size = 4)]
        [Int32DataFieldDefinition(revision: 999, field: 12, Index = 0, Size = 4)]
        public int MaxTimeForFirstTightening { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 13, Index = 0, Size = 5)]
        [Int32DataFieldDefinition(revision: 2, field: 13, Index = 0, Size = 5)]
        [Int32DataFieldDefinition(revision: 3, field: 9, Index = 0, Size = 5)]
        [Int32DataFieldDefinition(revision: 4, field: 9, Index = 0, Size = 5)]
        [Int32DataFieldDefinition(revision: 999, field: 13, Index = 0, Size = 5)]
        public int MaxTimeToCompleteJob { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 14, Index = 0, Size = 4)]
        [Int32DataFieldDefinition(revision: 2, field: 14, Index = 0, Size = 4)]
        [Int32DataFieldDefinition(revision: 3, field: 10, Index = 0, Size = 4)]
        [Int32DataFieldDefinition(revision: 4, field: 10, Index = 0, Size = 4)]
        [Int32DataFieldDefinition(revision: 999, field: 14, Index = 0, Size = 4)]
        public int DisplayResultAtAutoSelect { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 15, Index = 0)]
        [BooleanDataFieldDefinition(revision: 2, field: 15, Index = 0)]
        [BooleanDataFieldDefinition(revision: 3, field: 11, Index = 0)]
        [BooleanDataFieldDefinition(revision: 4, field: 11, Index = 0)]
        [BooleanDataFieldDefinition(revision: 999, field: 15, Index = 0)]
        public bool UsingLineControl { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 16, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 16, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 3, field: 12, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 4, field: 12, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 999, field: 16, Index = 0, Size = 1)]
        public IdentifierPart IdentifierResultPart { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 17, Index = 0)]
        [BooleanDataFieldDefinition(revision: 2, field: 17, Index = 0)]
        [BooleanDataFieldDefinition(revision: 3, field: 13, Index = 0)]
        [BooleanDataFieldDefinition(revision: 4, field: 13, Index = 0)]
        [BooleanDataFieldDefinition(revision: 999, field: 17, Index = 0)]
        public bool ResultOfNonTightenings { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 18, Index = 0)]
        [BooleanDataFieldDefinition(revision: 2, field: 18, Index = 0)]
        [BooleanDataFieldDefinition(revision: 3, field: 14, Index = 0)]
        [BooleanDataFieldDefinition(revision: 4, field: 14, Index = 0)]
        [BooleanDataFieldDefinition(revision: 999, field: 18, Index = 0)]
        public bool ResetAllIdentifiersAtJobDone { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 19, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 19, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 3, field: 15, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 4, field: 15, Index = 0, Size = 1)]
        [Int32DataFieldDefinition(revision: 999, field: 19, Index = 0, Size = 1)]
        public Reserved Reserved { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 20, Index = 0, Size = 5)]
        [Int32DataFieldDefinition(revision: 3, field: 16, Index = 0, Size = 5)]
        [Int32DataFieldDefinition(revision: 4, field: 16, Index = 0, Size = 5)]
        public int JobSequenceNumber { get; set; }

        public Mid0140() : this(DEFAULT_REVISION)
        {

        }

        public Mid0140(Header header) : base(header)
        {
            JobList = [];
        }

        public Mid0140(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }

        protected override string BuildHeader()
        {
            Header.Length = Header.DefaultSize;
            if (RevisionsByFields.Any())
            {
                var fields = DataFieldsByRevision();
                Header.Length += fields.Sum(x => x.TotalSize);
            }

            return Header.ToString();
        }

        public override string Pack()
        {
            var builder = new StringBuilder();
            var fields = DataFieldsByRevision().OrderBy(f => f.Index).ToList();
            int prefixIndex = 1;
            builder.Append(BuildHeader());
            builder.Append(Pack(fields, ref prefixIndex));

            return builder.ToString();
        }

        protected override void ProcessDataFields(ReadOnlySpan<char> package)
        {
            foreach (var field in DataFieldsByRevision())
            {
                ProcessDataField(field, package);
            }
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 4) //JobList
            {
                dataField.Size = NumberOfParameterSets * AdvancedJob.GetDefaultSize(Header.StandardizedRevision);
            }
            base.ProcessDataField(dataField, package);
        }

        private IEnumerable<DataField> DataFieldsByRevision()
        {
            var previousField = default(DataField);
            foreach (var dataField in RevisionsByFields[Header.StandardizedRevision].OrderBy(x => x.Field))
            {
                if (previousField != null && dataField.Index == 0)
                {
                    dataField.Index = previousField.Index + previousField.TotalSize;
                }

                previousField = dataField;
                yield return dataField;
            }
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            JobId,
            JobName,
            NumberOfParameterSets,
            JobList,
            ForcedOrder,
            LockAtJobDone,
            ToolLoosening,
            RepeatJob,
            JobBatchDone,
            BatchStatusAtIncrement,
            DecrementBatchAtOkLoosening,
            MaxTimeForFirstTightening,
            MaxTimeToCompleteJob,
            DisplayResultAtAutoSelect,
            UseLineControl,
            IdentifierResultPart,
            ResultOfNonTightenings,
            ResetAllIdentifiersAtJobDone,
            Reserved,

            //Rev 2
            JobSequenceNumber
        }
    }
}
