namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// MID: User data acknowledge
    /// Description: 
    ///     Acknowledgement of user data.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0243 : Mid, IPLCUserData, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 243;

        public Mid0243() : base(MID, LAST_REVISION) { }
    }
}
