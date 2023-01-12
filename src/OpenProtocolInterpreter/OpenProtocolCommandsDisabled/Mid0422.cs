namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// Open Protocol commands disabled acknowledge
    /// <para>Acknowledgement of Open Protocol commands disabled upload.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0422 : Mid, IOpenProtocolCommandsDisabled, IIntegrator, IAcknowledge
    {
        private const int LAST_REVISION = 1;
        public const int MID = 422;

        public Mid0422() : base(MID, LAST_REVISION) { }

        public Mid0422(Header header) : base(header)
        {
        }
    }
}
