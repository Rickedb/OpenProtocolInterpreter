using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Job ID upload reply
    /// <para>
    ///     The transmission of all the valid Job IDs of the controller.
    ///     The data field contains the number of valid Jobs currently present in the controller, and the ID of each Job.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0031 : Mid, IJob, IController
    {
        public const int MID = 31;

        [Int32DataFieldDefinition(field: 1, revision: 1, Index = 20, Size = 2, HasPrefix = false)]
        [Int32DataFieldDefinition(field: 1, revision: 2, Index = 20, Size = 4, HasPrefix = false)]
        public int TotalJobs { get; set; }

        [Int32CollectionDefinition(field: 2, revision: 1, Index = 22, Size = 2, EachFieldSize = 2, HasPrefix = false)]
        [Int32CollectionDefinition(field: 2, revision: 2, Index = 24, Size = 4, EachFieldSize = 4, HasPrefix = false)]
        public List<int> JobIds { get; set; }

        public Mid0031() : this(DEFAULT_REVISION)
        {

        }

        public Mid0031(Header header) : base(header)
        {
            JobIds ??= [];
        }

        public Mid0031(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }

        protected override string BuildHeader()
        {
            var fields = RevisionsByFields[Header.StandardizedRevision];
            Header.Length = Header.DefaultSize + fields.Sum(dataField => dataField.TotalSize);
            return Header.ToString();
        }

        public override Mid Parse(ReadOnlySpan<char> package)
        {
            Header = ProcessHeader(package);
            var fields = RevisionsByFields[Header.StandardizedRevision];
            ProcessDataFields(fields, package);
            return this;
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 2) //JobIds
            {
                var jobSize = Header.StandardizedRevision == 1 ? 2 : 4;
                dataField.Size = TotalJobs * jobSize;
            }
            base.ProcessDataField(dataField, package);
        }

        public override string Pack()
        {
            var jobSize = Header.StandardizedRevision == 1 ? 2 : 4;
            GetField(nameof(JobIds)).Size = JobIds.Count * jobSize;
            var fields = RevisionsByFields[Header.StandardizedRevision];
            var builder = new StringBuilder(BuildHeader());

            builder.Append(Pack(fields));
            return builder.ToString();
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            NumberOfJobs,
            EachJobId
        }
    }
}
