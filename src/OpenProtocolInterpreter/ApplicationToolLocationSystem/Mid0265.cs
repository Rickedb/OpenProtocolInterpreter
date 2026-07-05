using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// External Tool tag ID and status
    /// <para>Used by the controller to detect a Tool tag ID with its status from the integrator.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, MID revision unsupported.</para>
    /// </summary>
    public class Mid0265 : Mid, IApplicationToolLocationSystem, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 265;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.MidRevisionUnsupported };

        [StringDataFieldDefinition(field: 0, revision: 1, Size = 8)]
        public string ToolTagId { get; set; }

        [Int32DataFieldDefinition(field: 1, revision: 1, Size = 2)]
        public ToolStatus ToolStatus { get; set; }

        public Mid0265() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0265(Header header) : base(header)
        {

        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            ToolTagId,
            ToolStatus
        }
    }
}
