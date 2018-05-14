namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: Tool tag ID subscribe
    /// Description:
    ///     Used by the integrator to order a Tool tag ID subscription from the controller.
    /// Message sent by: Controller
    /// Answer: MID 0262 Tool tag ID or
    ///         MID 0004 Command error, Tool tag ID unknown , Tool tag ID subscription already exist or MID revision unsupported.
    /// </summary>
    public class MID_0261 : Mid, IApplicationToolLocationSystem
    {
        private const int LAST_REVISION = 1;
        public const int MID = 261;

        public MID_0261(int? noAckFlag = 1) : base(MID, LAST_REVISION, noAckFlag) { }

        internal MID_0261(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
