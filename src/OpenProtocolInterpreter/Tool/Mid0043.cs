namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// MID: Enable tool
    /// Description: 
    ///     Enable tool.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class Mid0043 : Mid, ITool
    {
        private const int LAST_REVISION = 1;
        public const int MID = 43;

        public Mid0043() : base(MID, LAST_REVISION)
        {

        }

        internal Mid0043(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
