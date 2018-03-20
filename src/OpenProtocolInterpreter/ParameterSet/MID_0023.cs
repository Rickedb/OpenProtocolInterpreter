namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Lock at batch done upload Acknowledge
    /// Description: 
    ///     This message is an acknowledge to MID 0022.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0023 : MID, IParameterSet
    {
        private const int LAST_REVISION = 1;
        public const int MID = 23;

        public MID_0023() : base(MID, LAST_REVISION) { }

        internal MID_0023(IMID nextTemplate) : base(MID, LAST_REVISION)
        {
            NextTemplate = nextTemplate;
        }
    }
}
