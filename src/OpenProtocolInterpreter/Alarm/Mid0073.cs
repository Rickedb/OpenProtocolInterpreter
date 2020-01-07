namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm unsubscribe
    /// <para>Reset the subscription for the controller alarms.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Alarm subscription does not exist</para>
    /// </summary>
    public class Mid0073 : Mid, IAlarm, IIntegrator
    {
        private const int LAST_REVISION = 2;
        public const int MID = 73;

        public Mid0073() : this(LAST_REVISION)
        {

        }

        public Mid0073(int revision = LAST_REVISION) : base(MID, revision)
        {

        }
    }
}
