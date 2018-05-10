namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// MID: Multi-spindle status acknowledge
    /// Description: 
    ///      Multi-spindle status acknowledge.
    /// Message sent by: Integrator
    /// Answer : None
    /// </summary>
    public class MID_0092 : Mid, IMultiSpindle
    {
        private const int LAST_REVISION = 1;
        public const int MID = 92;

        public MID_0092() : base(MID, LAST_REVISION) { }

        internal MID_0092(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

    }
}
