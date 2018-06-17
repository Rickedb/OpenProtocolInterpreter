namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// MID: Multi-spindle status subscribe
    /// Description:
    ///     A subscription for the multi-spindle status. For Power Focus, the subscription must be addressed to the sync Master.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, 
    ///         Controller is not a sync master/station controller, 
    ///         or Multi-spindle status subscription already exists
    /// </summary>
    public class Mid0090 : Mid, IMultiSpindle
    {
        private const int LAST_REVISION = 1;
        public const int MID = 90;

        public Mid0090(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag)
        {

        }

        internal Mid0090(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
