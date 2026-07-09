using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Number of offline results
    /// <para>Number of results when offline</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0066 : Mid, ITightening, IController
    {
        public const int MID = 66;

        [Int32DataFieldDefinition(field: 1, revision: 1, Index = 20, Size = 2)]
        [Int32DataFieldDefinition(field: 1, revision: 2, Index = 20, Size = 3)]
        public int NumberOfOfflineResults { get; set; }

        [Int32DataFieldDefinition(field: 2, revision: 2, Index = 25, Size = 3)]
        public int NumberOfOfflineCurves { get; set; }


        public Mid0066() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0066(Header header) : base(header)
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

        public override string Pack()
        {
            var fields = RevisionsByFields[Header.StandardizedRevision];
            var builder = new StringBuilder(BuildHeader());

            int prefixIndex = 1;
            builder.Append(Pack(fields, ref prefixIndex));
            return builder.ToString();
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            NumberOfOfflineResults,
            NumberOfOfflineCurves
        }
    }
}
