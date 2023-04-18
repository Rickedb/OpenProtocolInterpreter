namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Job line control started
    /// <para>This message tells the integrator that Job Line control start has been set in the controller.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0125"/> Job line control info acknowledged</para>
    /// </summary>
    public class Mid0121 : Mid, IAdvancedJob, IController, IAcknowledgeable<Mid0125>
    {
        public const int MID = 121;

        public Mid0121() : base(MID, DEFAULT_REVISION)
        {

        }

        public Mid0121(Header header) : base(header)
        {
        }
    }
}
