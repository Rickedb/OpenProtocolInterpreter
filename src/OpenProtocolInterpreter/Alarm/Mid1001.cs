namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm status acknowledge
    /// <para>Acknowledge for  <see cref="Mid1000"/> Alarm</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer : None</para>
    /// </summary>
    public class Mid1001 : Mid, IAlarm, IIntegrator, IAcknowledge
    {
        public const int MID = 1001;

        public Mid1001() : base(MID, DEFAULT_REVISION)
        {

        }

        public Mid1001(Header header) : base(header)
        {

        }
    }
}
