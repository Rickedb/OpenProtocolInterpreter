namespace OpenProtocolInterpreter.MotorTuning
{
    /// <summary>
    /// MID: Motor tuning result data acknowledge
    /// Description: 
    ///     Acknowledgement of motor tuning result data.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0502 : Mid, IMotorTuning
    {
        private const int LAST_REVISION = 1;
        public const int MID = 502;

        public Mid0502() : base(MID, LAST_REVISION) { }

        internal Mid0502(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
