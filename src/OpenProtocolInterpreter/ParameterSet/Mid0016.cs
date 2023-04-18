namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Parameter set selected acknowledge
    /// <para>Acknowledgement for a new parameter set selected.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0016 : Mid, IParameterSet, IIntegrator, IAcknowledge
    {
        public const int MID = 16;

        public Mid0016() : base(MID, DEFAULT_REVISION) { }

        public Mid0016(Header header) : base(header)
        {
        }
        public Mid0016(int revision = DEFAULT_REVISION) : base(MID, revision) { }
    }
}
