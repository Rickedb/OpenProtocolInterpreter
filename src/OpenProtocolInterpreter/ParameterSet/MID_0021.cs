namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Lock at batch done subscribe
    /// Description: 
    ///     A subscription for the Lock at batch done relay status.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error
    /// Message: MID 0022 relay status immediately after MID 0005 Command accepted
    /// </summary>
    public class MID_0021 : Mid, IParameterSet
    {
        private const int LAST_REVISION = 1;
        public const int MID = 21;

        public MID_0021(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) { }

        internal MID_0021(IMid nextTemplate) : base(MID, LAST_REVISION)
        {
            NextTemplate = nextTemplate;
        }
    }
}
