namespace OpenProtocolInterpreter.Wifi
{
    /// <summary>
    /// Reception quality request
    /// <para>Request the current WiFi reception quality from the controller.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Mid0806"/> Reception quality response</para>
    /// </summary>
    public class Mid0805 : Mid, IWifi, IIntegrator, IAnswerableBy<Mid0806>
    {
        public const int MID = 805;

        public Mid0805() : this(DEFAULT_REVISION) { }

        public Mid0805(Header header) : base(header) { }

        public Mid0805(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }
    }
}
