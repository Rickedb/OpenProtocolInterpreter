namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Enable tool
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0043 : Mid, ITool, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 43;

        public Mid0043() : base(MID, LAST_REVISION)
        {

        }
    }
}
