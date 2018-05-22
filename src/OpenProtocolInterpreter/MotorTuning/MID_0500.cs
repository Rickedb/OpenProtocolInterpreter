namespace OpenProtocolInterpreter.MotorTuning
{
    /// <summary>
    /// MID: Motor tuning result data subscribe
    /// Description: 
    ///     Sets the subscription for the motor tuning result. 
    ///     The result of this command will be the transmission of the motor 
    ///     tuning result after the motor tuning is performed. The MID revision in 
    ///     the header is used to subscribe to different revisions of MID 0501 Motor 
    ///     tuning result data upload reply.
    /// Message sent by: Integrator
    /// Answer: MID 0004 Command error, Motor Tuning subscription already exists or MID revision not supported
    /// </summary>
    public class MID_0500 : Mid, IMotorTuning
    {
        private const int LAST_REVISION = 1;
        public const int MID = 500;

        public MID_0500() : base(MID, LAST_REVISION) { }

        internal MID_0500(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        
    }
}
