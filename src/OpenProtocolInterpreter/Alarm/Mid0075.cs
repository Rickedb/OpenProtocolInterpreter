namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm acknowledged on controller acknowledge
    /// <para>Acknowledgement of MID 0074 Alarm acknowledged on controller.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer : None</para>
    /// </summary>
    public class Mid0075 : Mid, IAlarm, IIntegrator, IAcknowledge
    {
        private const int LAST_REVISION = 2;
        public const int MID = 75;

        public Mid0075() : this(LAST_REVISION)
        {

        }

        public Mid0075(int revision = LAST_REVISION) : base(MID, revision)
        {

        }

        public Mid0075(Header header) : base(header)
        {

        }
    }
}
