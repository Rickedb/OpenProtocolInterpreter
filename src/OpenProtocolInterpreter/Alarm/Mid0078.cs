namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Acknowledge alarm remotely on controller
    /// <para>The integrator can remotely acknowledge the current alarm on the controller by sending <see cref="Mid0078"/>. 
    /// If no alarm is currently active when the controller receives the command, the command will be rejected.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer : <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, No alarm present or Invalid data</para>
    /// </summary>
    public class Mid0078 : Mid, IAlarm, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 78;

        public Mid0078() : base(MID, LAST_REVISION)
        {

        }

        public Mid0078(Header header) : base(header)
        {

        }
    }
}
