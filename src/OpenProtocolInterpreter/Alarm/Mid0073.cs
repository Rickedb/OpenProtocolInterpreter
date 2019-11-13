namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// MID: Alarm unsubscribe
    /// Description: 
    ///      Reset the subscription for the controller alarms.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Alarm subscription does not exist
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
