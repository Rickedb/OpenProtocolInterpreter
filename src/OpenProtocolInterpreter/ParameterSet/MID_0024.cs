namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Lock at batch done unsubscribe
    /// Description: 
    ///     Reset the subscription for Lock at batch done.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error
    /// </summary>
    public class MID_0024 : MID, IParameterSet
    {
        private const int LAST_REVISION = 1;
        public const int MID = 24;

        public MID_0024() : base(MID, LAST_REVISION) { }

        internal MID_0024(IMID nextTemplate) : base(MID, LAST_REVISION)
        {
            NextTemplate = nextTemplate;
        }
    }
}
