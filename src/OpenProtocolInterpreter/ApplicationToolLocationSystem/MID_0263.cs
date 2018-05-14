namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: Tool tag ID acknowledge
    /// Description:
    ///     Acknowledgement of MID 0262 Tool tag ID.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0263 : Mid, IApplicationToolLocationSystem
    {
        private const int LAST_REVISION = 1;
        public const int MID = 263;

        public MID_0263() : base(MID, LAST_REVISION) { }

        internal MID_0263(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
