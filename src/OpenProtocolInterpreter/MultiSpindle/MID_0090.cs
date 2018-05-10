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
    public class MID_0090 : Mid, IMultiSpindle
    {
        private const int LAST_REVISION = 1;
        public const int MID = 90;

        public MID_0090(int revision = LAST_REVISION, int? ackFlag = 1) : base(MID, revision, ackFlag)
        {

        }

        internal MID_0090(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
