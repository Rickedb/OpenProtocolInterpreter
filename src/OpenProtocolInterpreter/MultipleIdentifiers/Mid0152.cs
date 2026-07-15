using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// Multiple identifier and result parts
    /// <para>
    ///    Transmission of the work order status, optional identifier and identifier result parts
    ///    by the controller to the subscriber.
    /// </para>
    /// <para>
    ///    The identifier contains the status of the maximum four identifier result parts that could
    ///    be extracted from one or more valid identifiers.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0153"/> Multiple identifiers and result parts acknowledge</para>
    /// </summary>
    public class Mid0152 : Mid, IMultipleIdentifier, IController, IAcknowledgeable<Mid0153>
    {
        public const int MID = 152;

        [IdentifierStatusDefinition(revision: 1, field: 1, Index = 20, Size = 30)]
        public IdentifierStatus FirstIdentifierStatus { get; set; }
        [IdentifierStatusDefinition(revision: 1, field: 2, Index = 52, Size = 30)]
        public IdentifierStatus SecondIdentifierStatus { get; set; }
        [IdentifierStatusDefinition(revision: 1, field: 3, Index = 84, Size = 30)]
        public IdentifierStatus ThirdIdentifierStatus { get; set; }
        [IdentifierStatusDefinition(revision: 1, field: 4, Index = 116, Size = 30)]
        public IdentifierStatus FourthIdentifierStatus { get; set; }

        public Mid0152() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0152(Header header) : base(header)
        {

        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            FirstIdentifierStatus,
            SecondIdentifierStatus,
            ThirdIdentifierStatus,
            FourthIdentifierStatus
        }
    }
}
