namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm status acknowledge
    /// <para>Acknowledgement of <see cref="Mid0076"/> Alarm Status.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer : None</para>
    /// </summary>
    public class Mid0077 : Mid, IAlarm, IIntegrator, IAcknowledge
    {
        public const int MID = 77;

        public Mid0077() : base(MID, DEFAULT_REVISION)
        {

        }

        public Mid0077(Header header) : base(header)
        {

        }
    }
}
