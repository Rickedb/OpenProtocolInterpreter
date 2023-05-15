namespace OpenProtocolInterpreter.Vin
{
    /// <summary>
    /// Vehicle ID Number acknowledge
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0053 : Mid, IVin, IIntegrator, IAcknowledge
    {
        public const int MID = 53;

        public Mid0053() : this(DEFAULT_REVISION)
        {

        }

        public Mid0053(int revision) : base(MID, revision)
        {

        }

        public Mid0053(Header header) : base(header)
        {
        }
    }
}
