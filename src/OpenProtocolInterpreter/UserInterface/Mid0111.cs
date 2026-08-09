using System.Collections.Generic;

namespace OpenProtocolInterpreter.UserInterface
{
    /// <summary>
    /// Display user text on graph
    /// <para>
    ///     By sending this message the integrator can display a text on the graphic display.
    ///     The user can furthermore set the time for the text to be displayed and if the text
    ///     should be acknowledged by the operator or not.
    /// </para>
    /// <para>
    ///     The text is divided into four lines with 25 ASCII characters each.If a line is shorter
    ///     than 25 characters it must be right padded with blanks(SPC 0x20).
    /// </para>
    /// <para>The first line is the text header and is in upper character.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///             <see cref="Communication.Mid0004"/> Command error, User text could not be displayed
    /// </para>
    /// </summary>
    public class Mid0111 : Mid, IUserInterface, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 111;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { };

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 4)]
        public int TextDuration { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 26, Size = 1)]
        public RemovalCondition RemovalCondition { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 3, Index = 29, Size = 25)]
        public string Line1 { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 4, Index = 56, Size = 25)]
        public string Line2 { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 5, Index = 83, Size = 25)]
        public string Line3 { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 6, Index = 110, Size = 25)]
        public string Line4 { get; set; }

        public Mid0111() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0111(Header header) : base(header)
        {
        }
    }
}
