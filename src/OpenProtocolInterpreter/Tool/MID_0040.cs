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
    public class MID_0040 : MID, ITool
    {
        private const int LAST_REVISION = 5;
        public const int MID = 40;

        public MID_0040() : base(MID, LAST_REVISION) { }

        internal MID_0040(IMID nextTemplate) : this() => NextTemplate = nextTemplate;

    }
}
