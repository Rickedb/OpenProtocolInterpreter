namespace OpenProtocolInterpreter.MotorTuning
{
    /// <summary>
    /// MID: Motor tuning request
    /// Description: 
    ///     Request the start of the motor tuning.
    ///     
    ///     Warning !: This command must be implemented during hard restrictions and 
    ///     customer dependent requirements.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Tool motor tuning failed
    /// </summary>
    public class MID_0504 : Mid, IMotorTuning
    {
        private const int LAST_REVISION = 1;
        public const int MID = 504;

        public MID_0504() : base(MID, LAST_REVISION) { }

        internal MID_0504(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
