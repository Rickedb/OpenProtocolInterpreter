namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Lock at batch done upload Acknowledge
    /// <para>This message is an acknowledge to <see cref="Mid0022"/>.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0023 : Mid, IParameterSet, IIntegrator, IAcknowledge, IAcceptableCommand
    {
        public const int MID = 23;

        public Mid0023() : base(MID, DEFAULT_REVISION) { }

        public Mid0023(Header header) : base(header)
        {
        }
    }
}
