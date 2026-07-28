using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// <para>Job info</para>
    ///     <para>The Job info subscriber will receive a Job info message after a Job has been selected and after each
    ///     tightening performed in the Job.The Job info consists of the ID of the currently running Job, the Job
    ///     status, the Job batch mode, the Job batch size and the Job batch counter.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0036"/></para>
    /// </summary>
    public class Mid0035 : Mid, IJob, IController, IAcknowledgeable<Mid0036>
    {
        public const int MID = 35;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 2)]
        [Int32DataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 4)]
        public int JobId { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 24, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 2, Index = 26, Size = 1)]
        public JobStatus JobStatus { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 3, Index = 27, Size = 1)]
        [Int32DataFieldDefinition(revision: 2, field: 3, Index = 29, Size = 1)]
        public JobBatchMode JobBatchMode { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 4, Index = 30, Size = 4)]
        [Int32DataFieldDefinition(revision: 2, field: 4, Index = 32, Size = 4)]
        public int JobBatchSize { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 5, Index = 36, Size = 4)]
        [Int32DataFieldDefinition(revision: 2, field: 5, Index = 38, Size = 4)]
        public int JobBatchCounter { get; set; }

        [TimestampDataFieldDefinition(revision: 1, field: 6, Index = 42)]
        [TimestampDataFieldDefinition(revision: 2, field: 6, Index = 44)]
        public DateTime TimeStamp { get; set; }

        //Rev 3
        [Int32DataFieldDefinition(revision: 3, field: 7, Index = 65, Size = 3)]
        public int JobCurrentStep { get; set; }

        [Int32DataFieldDefinition(revision: 3, field: 8, Index = 70, Size = 3)]
        public int JobTotalNumberOfSteps { get; set; }

        [Int32DataFieldDefinition(revision: 3, field: 9, Index = 75, Size = 2)]
        public int JobStepType { get; set; }

        //Rev 4
        [Int32DataFieldDefinition(revision: 4, field: 10, Index = 79, Size = 2)]
        public JobTighteningStatus JobTighteningStatus { get; set; }

        //Rev 5
        [Int32DataFieldDefinition(revision: 5, field: 11, Index = 83, Size = 5)]
        public int JobSequenceNumber { get; set; }

        [StringDataFieldDefinition(revision: 5, field: 12, Index = 90, Size = 25)]
        public string VinNumber { get; set; }

        [StringDataFieldDefinition(revision: 5, field: 13, Index = 117, Size = 25)]
        public string IdentifierResultPart2 { get; set; }

        [StringDataFieldDefinition(revision: 5, field: 14, Index = 144, Size = 25)]
        public string IdentifierResultPart3 { get; set; }

        [StringDataFieldDefinition(revision: 5, field: 15, Index = 171, Size = 25)]
        public string IdentifierResultPart4 { get; set; }

        //Rev 6
        [StringDataFieldDefinition(revision: 6, field: 16, Index = 198, Size = 25)]
        public string JointId { get; set; }

        public Mid0035() : this(DEFAULT_REVISION)
        {

        }

        public Mid0035(Header header) : base(header)
        {
        }

        public Mid0035(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }

        protected override string BuildHeader()
        {
            Header.Length = Header.DefaultSize + DataFieldsByRevision().Sum(x => x.TotalSize);
            return Header.ToString();
        }

        public override string Pack()
        {
            var builder = new StringBuilder();
            var fields = DataFieldsByRevision().OrderBy(x => x.Index).ToList();
            builder.Append(BuildHeader());
            builder.Append(base.Pack(fields));
            return builder.ToString();
        }

        protected override void ProcessDataFields(ReadOnlySpan<char> package)
        {
            var fields = DataFieldsByRevision().OrderBy(x => x.Index).ToList();
            base.ProcessDataFields(fields, package);
        }

        private IEnumerable<DataField> DataFieldsByRevision()
        {
            var fromRevision = Header.StandardizedRevision > 1 ? 2 : 1;
            var toRevision = Header.StandardizedRevision;

            for (int i = fromRevision; i <= toRevision; i++)
            {
                foreach (var dataField in RevisionsByFields[i])
                    yield return dataField;
            }
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            //rev 1 and 2
            JobId,
            JobStatus,
            JobBatchMode,
            JobBatchSize,
            JobBatchCounter,
            Timestamp,
            //rev 3
            JobCurrentStep,
            JobTotalNumberOfSteps,
            JobStepType,
            //rev 4
            JobTighteningStatus,
            //rev5
            JobSequenceNumber,
            VinNumber,
            IdentifierResultPart2,
            IdentifierResultPart3,
            IdentifierResultPart4,
            //Rev 6
            JointId
        }
    }

}
