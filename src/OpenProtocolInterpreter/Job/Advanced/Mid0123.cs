namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Job line control alert 2
    /// <para>This message tells the integrator that the Job line control alert 2 is set in the controller.</para>
    /// <para>Only available when a job has been selected.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0125"/> Job line control info acknowledged</para>
    /// </summary>
    public class Mid0123 : Mid, IAdvancedJob, IController, IAcknowledgeable
    {
        private const int LAST_REVISION = 1;
        public const int MID = 123;

        public Mid0123() : base(MID, LAST_REVISION)
        {

        }

        public Mid0123(Header header) : base(header)
        {
        }

        public Mid GetAcknowledge() => new Mid0125();
    }
}
