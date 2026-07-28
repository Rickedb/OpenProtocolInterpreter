namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Disable tool
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0042 : Mid, ITool, IIntegrator, IAcceptableCommand
    {
        public const int MID = 42;

        [Int32DataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 4)]
        public int ToolNumber { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 2, Index = 26, Size = 2)]
        public DisableType DisableType { get; set; }

        public Mid0042() : this(DEFAULT_REVISION)
        {
        }

        public Mid0042(Header header) : base(header)
        {
        }

        public Mid0042(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }
    }
}
