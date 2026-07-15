using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// Identifier download request
    /// <para>Used by the integrator to send an identifier to the controller.</para>
    /// <para>Message sent by: Integrator</para>
    ///<para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Identifier input source not granted</para>
    /// </summary>
    public class Mid0150 : Mid, IMultipleIdentifier, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 150;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.IdentifierInputSourceNotGranted };

        [StringDataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 0, HasPrefix = false)]
        public string IdentifierData { get; set; }

        public Mid0150() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0150(Header header) : base(header)
        {
        }

        protected override string BuildHeader()
        {

            Header.Length = Header.DefaultSize + IdentifierData?.Length ?? 0;
            return Header.ToString();
        }

        public override string Pack()
        {
            if (IdentifierData?.Length > 100)
            {
                IdentifierData = IdentifierData.Substring(0, 100);
            }

            return base.Pack();
        }

        public override Mid Parse(ReadOnlySpan<char> package)
        {
            Header = ProcessHeader(package);
            GetField(nameof(IdentifierData)).Size = Header.Length - Header.DefaultSize;
            ProcessDataFields(package);
            return this;
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            IdentifierData
        }
    }
}
