namespace OpenProtocolInterpreter.MotorTuning
{
    /// <summary>
    /// MID: Motor tuning result data unsubscribe
    /// Description: 
    ///     Reset the motor tuning result subscription.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Motor Tuning result subscription does not exist
    /// </summary>
    public class MID_0503 : Mid, IMotorTuning
    {
        private const int LAST_REVISION = 1;
        public const int MID = 503;

        public MID_0503() : base(MID, LAST_REVISION) { }

        internal MID_0503(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
