namespace OpenProtocolInterpreter.PLCUserData
{
    /// <summary>
    /// MID: User data subscribe
    /// Description: 
    ///     Subscribe for user data. This command will activate the MID 0242 User data message to be sent when a
    ///     change in the user data output has been detected.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, Subscription already exists, or
    ///         Controller is not a sync master/station controller
    /// </summary>
    public class Mid0241 : Mid, IPLCUserData, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 241;

        public Mid0241() : this(0)
        {

        }

        public Mid0241(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) { }
    }
}