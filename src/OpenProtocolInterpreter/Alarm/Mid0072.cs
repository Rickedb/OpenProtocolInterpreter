namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm acknowledge
    /// <para>Acknowledgement for <see cref="Mid0071"/> Alarm.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0072 : Mid, IAlarm, IIntegrator, IAcknowledge
    {
        public const int MID = 72;

        public Mid0072() : this(DEFAULT_REVISION)
        {

        }

        public Mid0072(Header header) : base(header)
        {

        }

        public Mid0072(int revision = DEFAULT_REVISION) : base(MID, revision)
        {

        }

    }
}
