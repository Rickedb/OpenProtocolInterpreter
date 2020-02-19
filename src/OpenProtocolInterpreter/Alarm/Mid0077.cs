namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm status acknowledge
    /// <para>Acknowledgement of <see cref="Mid0076"/> Alarm Status.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer : None</para>
    /// </summary>
    public class Mid0077 : Mid, IAlarm, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 77;

        public Mid0077() : base(MID, LAST_REVISION)
        {

        }
    }
}
