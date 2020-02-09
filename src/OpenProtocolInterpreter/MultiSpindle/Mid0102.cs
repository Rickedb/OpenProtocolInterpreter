namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Multi-spindle result acknowledge
    /// Description:
    ///     Multi-spindle result acknowledge.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0102 : Mid, IMultiSpindle, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 102;

        public Mid0102() : base(MID, LAST_REVISION) { }

    }
}
