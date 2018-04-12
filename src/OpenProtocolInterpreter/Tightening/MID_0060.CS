namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// MID: Last tightening result data subscribe
    /// Description: 
    ///     Set the subscription for the result tightenings. The result of this command will be the transmission of
    ///     the tightening result after the tightening is performed(push function). The MID revision in the header
    ///     is used to subscribe to different revisions of MID 0061 Last tightening result data upload reply.
    /// 
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Last tightening subscription already 
    ///         exists or MID revision not supported
    /// </summary>
    public class MID_0060 : MID, ITightening
    {
        private const int LAST_REVISION = 7;
        public const int MID = 60;

        public MID_0060(int? ackFlag = 1, int revision = LAST_REVISION) : base(MID, revision)
        {

        }

        internal MID_0060(IMID nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
