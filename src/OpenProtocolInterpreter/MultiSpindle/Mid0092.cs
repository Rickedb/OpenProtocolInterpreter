namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// MID: Multi-spindle status acknowledge
    /// Description: 
    ///      Multi-spindle status acknowledge.
    /// Message sent by: Integrator
    /// Answer : None
    /// </summary>
    public class Mid0092 : Mid, IMultiSpindle, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 92;

        public Mid0092() : base(MID, LAST_REVISION) { }
    }
}
