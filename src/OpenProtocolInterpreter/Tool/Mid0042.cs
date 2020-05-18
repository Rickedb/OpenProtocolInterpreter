namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Disable tool
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0042 : Mid, ITool, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 42;

        public Mid0042() : base(MID, LAST_REVISION)
        {
        }
    }
}
