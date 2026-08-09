namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Enable tool
    /// <para>
    ///     Enable the tool in revision 0-1. For revision 2, will release the inhibit / disable value set with <see cref="Mid0042"/> Disable tool.
    /// </para>
    /// <para>
    ///     The number of the tool to release is specified in the telegram. If the tool number is set to 9999 all tools connected to the controller or station will be released.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0043 : Mid, ITool, IIntegrator, IAcceptableCommand
    {
        public const int MID = 43;

        /// <summary>
        /// The number of the tool to enable. It is the same number as the tool numbers sent in <see cref="Mid0701"/> Tool List Upload
        /// </summary>
        [Int32DataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 4)]
        public int ToolNumber { get; set; }

        public Mid0043() : this(DEFAULT_REVISION)
        {

        }

        public Mid0043(Header header) : base(header)
        {
        }

        public Mid0043(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }
    }
}
