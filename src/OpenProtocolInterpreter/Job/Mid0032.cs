using System;
using System.Collections.Generic;
using System.Text;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Job data upload request
    /// <para>Request to upload the data for a specific Job from the controller.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Mid0033"/> Job data upload or <see cref="Communication.Mid0004"/> Command error, Job ID not present</para>
    /// </summary>
    public class Mid0032 : Mid, IJob, IIntegrator, IAnswerableBy<Mid0033>, IDeclinableCommand
    {
        public const int MID = 32;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.JobIdNotPresent };

        [Int32DataFieldDefinition(field: 1, revision: 1, Index = 20, Size = 2, HasPrefix = false)]
        [Int32DataFieldDefinition(field: 1, revision: 2, Index = 20, Size = 4, HasPrefix = false)]
        public int JobId { get; set; }

        public Mid0032() : this(DEFAULT_REVISION)
        {

        }

        public Mid0032(Header header) : base(header)
        {

        }

        public Mid0032(int revision) : this(new Header()
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
                        Header.Length += dataField.TotalSize;
                }
            }

            return Header.ToString();
        }

        public override string Pack()
        {
            var builder = new StringBuilder(BuildHeader());

            var fromRevision = Header.StandardizedRevision > 1 ? 2 : 1;
            int prefixIndex = 1;
            for (int i = fromRevision; i <= Header.StandardizedRevision; i++)
            {
                builder.Append(Pack(i, ref prefixIndex));
            }
            return builder.ToString();
        }

        public override Mid Parse(ReadOnlySpan<char> package)
        {
            Header = ProcessHeader(package);
            var fromRevision = Header.StandardizedRevision > 1 ? 2 : 1;
            for (int i = fromRevision; i <= Header.StandardizedRevision; i++)
            {
                if (RevisionsByFields.TryGetValue(i, out var fields))
                    ProcessDataFields(fields, package);
            }
            return this;
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            JobId
        }
    }
}
