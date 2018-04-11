namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// MID: Enable tool
    /// Description: 
    ///     Enable tool.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0043 : MID, ITool
    {
        private const int LAST_REVISION = 1;
        public const int MID = 43;

        public MID_0043() : base(MID, LAST_REVISION)
        {

        }

        internal MID_0043(IMID nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
