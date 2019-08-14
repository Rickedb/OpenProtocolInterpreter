namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// MID: Tool data upload request
    /// Description: 
    ///     A request for some of the data stored in the tool. The result of this command is the transmission of the
    ///     tool data.
    /// Message sent by: Integrator
    /// Answer: MID 0041 Tool data upload reply
    /// </summary>
    public class Mid0040 : Mid, ITool, IIntegrator
    {
        private const int LAST_REVISION = 5;
        public const int MID = 40;

        public Mid0040() : base(MID, LAST_REVISION) { }
    }
}
