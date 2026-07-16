using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Set Parameter set batch size
    /// <para>This message gives the possibility to set the batch size of a parameter set at run time.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error, Invalid data
    /// </para>
    /// </summary>
    public class Mid0019 : Mid, IParameterSet, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 19;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.InvalidData };

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        public int ParameterSetId { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 23, Size = 2, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 2, field: 2, Index = 23, Size = 4, HasPrefix = false)]
        public int BatchSize { get; set; }

        public Mid0019() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0019(Header header) : base(header)
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
            var fields = DataFieldsByRevision().ToList();

            int prefixIndex = 1;
            builder.Append(BuildHeader());
            builder.Append(Pack(fields, ref prefixIndex));

            return builder.ToString();
        }


        protected override void ProcessDataFields(ReadOnlySpan<char> package)
        {
            var fields = DataFieldsByRevision().ToList();
            base.ProcessDataFields(fields, package);
        }

        private IEnumerable<DataField> DataFieldsByRevision()
            => RevisionsByFields[Header.StandardizedRevision];

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            ParameterSetId,
            BatchSize
        }
    }
}
