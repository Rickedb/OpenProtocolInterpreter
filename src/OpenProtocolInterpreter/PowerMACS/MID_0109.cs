namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// MID: Last Power MACS tightening result data unsubscribe
    /// Description: 
    ///    Reset the last Power MACS tightening result subscription for the rundowns result.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Subscription does not exist
    /// </summary>
    public class MID_0109 : Mid, IPowerMACS
    {
        private const int LAST_REVISION = 1;
        public const int MID = 109;

        public MID_0109(int revision = LAST_REVISION) : base(MID, revision) { }

        internal MID_0109(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

    }
}
