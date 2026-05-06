namespace OpenProtocolInterpreter.Battery
{
    /// <summary>
    /// Battery level request
    /// <para>Request the current battery level from the controller.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Mid0801"/> Battery level response</para>
    /// </summary>
    public class Mid0800 : Mid, IBattery, IIntegrator, IAnswerableBy<Mid0801>
    {
        public const int MID = 800;

        public Mid0800() : this(DEFAULT_REVISION) { }

        public Mid0800(Header header) : base(header) { }

        public Mid0800(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }
    }
}
