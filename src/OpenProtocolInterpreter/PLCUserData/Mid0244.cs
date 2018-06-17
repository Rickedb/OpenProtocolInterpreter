namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// MID: User data unsubscribe
    /// Description: 
    ///     Unsubscribe for the user data.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Subscription already exists
    /// </summary>
    public class Mid0244 : Mid, IPLCUserData
    {
        private const int LAST_REVISION = 1;
        public const int MID = 244;

        public Mid0244() : base(MID, LAST_REVISION) { }

        internal Mid0244(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        
    }
}
