using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Tool data upload request
    /// <para>
    ///     A request for some of the data stored in the tool. The result of this command
    ///     is the transmission of the tool data.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Mid0041"/> Tool data upload reply</para>
    /// </summary>
    public class Mid0040 : Mid, ITool, IIntegrator, IAnswerableBy<Mid0041>
    {
        public const int MID = 40;

        [Int32DataFieldDefinition(revision: 6, field: 1, Index = 20, Size = 4)]
        public int ToolNumber { get; set; }

        public Mid0040() : this(DEFAULT_REVISION)
        {

        }

        public Mid0040(Header header) : base(header)
        {
        }

        public Mid0040(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }
    }
}
