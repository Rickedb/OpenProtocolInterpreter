namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Parameter set selected acknowledge
    /// <para>Acknowledgement for a new parameter set selected.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0016 : Mid, IParameterSet, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 16;

        public Mid0016() : base(MID, LAST_REVISION) { }

        public Mid0016(Header header) : base(header)
        {
        }
    }
}
