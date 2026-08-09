using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Select Job
    /// <para>Message to select Job. If the requested ID is not present in the controller, then the command will not be performed.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Job can not be set, or Invalid data</para>
    /// </summary>
    public class Mid0038 : Mid, IJob, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 38;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.JobCannotBeSet, Error.InvalidData };

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 2, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 4, HasPrefix = false)]
        public int JobId { get; set; }

        public Mid0038() : this(DEFAULT_REVISION)
        {

        }

        public Mid0038(Header header) : base(header)
        {

        }

        public Mid0038(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        protected override string BuildHeader()
        {
            Header.Length = Header.DefaultSize;
            if (RevisionsByFields.TryGetValue(Header.StandardizedRevision, out var dataFields))
            {
                Header.Length += dataFields.Sum(x => x.TotalSize);
            }

            return Header.ToString();
        }

        public override string Pack()
        {
            var builder = new StringBuilder(BuildHeader());

            builder.Append(base.Pack(RevisionsByFields[Header.StandardizedRevision]));
            return builder.ToString();
        }

        public override Mid Parse(ReadOnlySpan<char> package)
        {
            Header = ProcessHeader(package);
            ProcessDataFields(RevisionsByFields[Header.StandardizedRevision], package);
            return this;
        }
    }
}
