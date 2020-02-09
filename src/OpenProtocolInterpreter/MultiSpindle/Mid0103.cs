namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Multi-spindle result unsubscribe
    /// Description:
    ///     Reset the subscription for the multi spindle result.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Multi spindle result subscription does not exist
    /// </summary>
    public class Mid0103 : Mid, IMultiSpindle, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 103;

        public Mid0103() : base(MID, LAST_REVISION) { }

    }
}
