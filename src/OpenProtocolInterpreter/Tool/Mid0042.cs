namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// MID: Disable tool
    /// Description: 
    ///     Disable tool.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class Mid0042 : Mid, ITool
    {
        private const int LAST_REVISION = 1;
        public const int MID = 42;

        public Mid0042() : base(MID, LAST_REVISION)
        {
        }

        internal Mid0042(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
