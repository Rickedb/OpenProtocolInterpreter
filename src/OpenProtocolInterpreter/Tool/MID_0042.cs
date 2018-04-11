namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// MID: Disable tool
    /// Description: 
    ///     Disable tool.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class MID_0042 : MID, ITool
    {
        private const int LAST_REVISION = 1;
        public const int MID = 42;

        public MID_0042() : base(MID, LAST_REVISION)
        {
        }

        internal MID_0042(IMID nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
