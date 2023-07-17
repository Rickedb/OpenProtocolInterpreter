namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Multi-spindle result acknowledge
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0102 : Mid, IMultiSpindle, IIntegrator, IAcknowledge
    {
        public const int MID = 102;

        public Mid0102() : base(MID, DEFAULT_REVISION) { }

        public Mid0102(Header header) : base(header)
        {
        }
    }
}
