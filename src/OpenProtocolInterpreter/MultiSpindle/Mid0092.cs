namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Multi-spindle status acknowledge
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer : None</para>
    /// </summary>
    public class Mid0092 : Mid, IMultiSpindle, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 92;

        public Mid0092() : base(MID, LAST_REVISION) { }

        public Mid0092(Header header) : base(header)
        {
        }
    }
}
