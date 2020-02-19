namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm subscribe
    /// <para>A subscription for the alarms that can appear in the controller.</para>
    /// <para>Message sent by Integrator</para>
    /// <para>Answers: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Alarm subscription already exists</para>
    /// </summary>
    public class Mid0070 : Mid, IAlarm, IIntegrator
    {
        private const int LAST_REVISION = 2;
        public const int MID = 70;

        public Mid0070() : this(LAST_REVISION)
        {

        }

        public Mid0070(int revision = LAST_REVISION, int? noAckFlag = 0) : base(MID, revision, noAckFlag)
        {

        }
    }
}
