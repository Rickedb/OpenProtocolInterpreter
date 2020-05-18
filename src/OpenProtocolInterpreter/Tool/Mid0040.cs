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
    public class Mid0040 : Mid, ITool, IIntegrator
    {
        private const int LAST_REVISION = 5;
        public const int MID = 40;

        public Mid0040() : base(MID, LAST_REVISION) { }
    }
}
