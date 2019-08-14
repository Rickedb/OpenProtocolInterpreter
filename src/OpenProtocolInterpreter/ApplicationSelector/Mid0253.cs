namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// MID: Selector socket info unsubscribe
    /// Description:
    ///     Unsubscribe for the selector socket info. The subscription is reset for all selector devices.  
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    /// MID 0004 Command error, The selector socket info subscription does not exist
    /// </summary>
    public class Mid0253 : Mid, IApplicationSelector, IIntegrator
    {
        public const int MID = 253;
        private const int LAST_REVISION = 1;

        public Mid0253() : base(MID, LAST_REVISION) { }
    }
}
