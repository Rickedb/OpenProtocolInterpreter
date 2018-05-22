namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// MID: Acknowledge alarm remotely on controller
    /// Description: 
    ///      The integrator can remotely acknowledge the current alarm on the controller by sending MID 0078. 
    ///      If no alarm is currently active when the controller receives the command, the command will be rejected.
    /// Message sent by: Integrator
    /// Answer : MID 0005 Command accepted or MID 0004 Command error, No alarm present or Invalid data
    /// </summary>
    public class MID_0078 : Mid, IAlarm
    {
        private const int LAST_REVISION = 1;
        public const int MID = 78;

        public MID_0078() : base(MID, LAST_REVISION)
        {

        }

        internal MID_0078(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
