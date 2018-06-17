namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// MID: Multi-spindle status acknowledge
    /// Description: 
    ///      Multi-spindle status acknowledge.
    /// Message sent by: Integrator
    /// Answer : None
    /// </summary>
    public class Mid0093 : Mid, IMultiSpindle
    {
        private const int LAST_REVISION = 1;
        public const int MID = 93;

        public Mid0093() : base(MID, LAST_REVISION)
        {

        }

        internal Mid0093(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
