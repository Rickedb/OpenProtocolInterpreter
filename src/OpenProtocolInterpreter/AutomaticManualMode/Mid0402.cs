namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// Automatic/Manual mode acknowledge
    /// <para>Acknowledgement of automatic/manual mode upload.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0402 : Mid, IAutomaticManualMode, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 402;

        public Mid0402() : base(MID, LAST_REVISION) { }
    }
}
