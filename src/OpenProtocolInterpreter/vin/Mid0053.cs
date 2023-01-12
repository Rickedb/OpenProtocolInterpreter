namespace OpenProtocolInterpreter.Vin
{
    /// <summary>
    /// Vehicle ID Number acknowledge
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0053 : Mid, IVin, IIntegrator, IAcknowledge
    {
        private const int LAST_REVISION = 2;
        public const int MID = 53;

        public Mid0053() : this(LAST_REVISION)
        {

        }

        public Mid0053(int revision = LAST_REVISION) : base(MID, revision)
        {

        }

        public Mid0053(Header header) : base(header)
        {
        }
    }
}
