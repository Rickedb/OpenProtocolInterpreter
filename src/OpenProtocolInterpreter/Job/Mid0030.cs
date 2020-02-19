namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Job ID upload request
    /// <para>
    ///     This is a request for a transmission of all the valid Job IDs of the controller.
    ///     The result of this command is a transmission of all the valid Job IDs.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Mid0031"/> Job ID upload reply</para>
    /// </summary>
    public class Mid0030 : Mid, IJob, IIntegrator
    {
        private const int LAST_REVISION = 2;
        public const int MID = 30;

        public Mid0030() : this(LAST_REVISION)
        {

        }

        public Mid0030(int revision = LAST_REVISION) : base(MID, revision) { }
    }
}
