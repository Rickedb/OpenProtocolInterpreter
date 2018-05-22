namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// MID: Alarm status acknowledge
    /// Description: 
    ///      Acknowledgement of MID 0076 Alarm Status.
    /// Message sent by: Integrator
    /// Answer : None
    /// </summary>
    public class MID_0077 : Mid, IAlarm
    {
        private const int LAST_REVISION = 1;
        public const int MID = 77;

        public MID_0077() : base(MID, LAST_REVISION)
        {

        }

        internal MID_0077(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
