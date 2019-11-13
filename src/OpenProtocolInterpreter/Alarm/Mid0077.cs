namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// MID: Alarm status acknowledge
    /// Description: 
    ///      Acknowledgement of MID 0076 Alarm Status.
    /// Message sent by: Integrator
    /// Answer : None
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
