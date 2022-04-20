namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Job line control done
    /// <para>This message tells the integrator that the Job has been completed before the alert level 2 was reached.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0125"/> Job line control info acknowledged</para>
    /// </summary>
    public class Mid0124 : Mid, IAdvancedJob, IController
    {
        private const int LAST_REVISION = 1;
        public const int MID = 124;

        public Mid0124() : base(MID, LAST_REVISION)
        {

        }

        public Mid0124(Header header) : base(header)
        {
        }
    }
}
