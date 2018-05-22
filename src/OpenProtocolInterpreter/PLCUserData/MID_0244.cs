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
    public class MID_0244 : Mid, IPLCUserData
    {
        private const int LAST_REVISION = 1;
        public const int MID = 244;

        public MID_0244() : base(MID, LAST_REVISION) { }

        internal MID_0244(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        
    }
}
