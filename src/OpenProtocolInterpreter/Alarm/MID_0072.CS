namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// MID: Alarm acknowledge
    /// Description: 
    ///      Acknowledgement for MID 0071 Alarm.
    /// 
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0072 : Mid, IAlarm
    {
        private const int LAST_REVISION = 2;
        public const int MID = 72;

        public MID_0072(int revision = LAST_REVISION) : base(MID, revision)
        {

        }

        internal MID_0072(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
