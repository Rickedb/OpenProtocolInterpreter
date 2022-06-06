namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// AutoDisable settings request
    /// <para>
    ///     Request for AutoDisable settings. This request is intended to be used while 
    ///     running single parameter sets with batch and does not provide batch information while running Job.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Mid0411"/> AutoDisable settings reply</para>
    /// </summary>
    public class Mid0410 : Mid, IAutomaticManualMode, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 410;

        public Mid0410() : base(MID, LAST_REVISION) { }

        public Mid0410(Header header) : base(header)
        {

        }
    }
}
