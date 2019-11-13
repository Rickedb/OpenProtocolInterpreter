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
    public class Mid0261 : Mid, IApplicationToolLocationSystem, IController
    {
        private const int LAST_REVISION = 1;
        public const int MID = 261;

        public Mid0261() : this(0)
        {

        }

        public Mid0261(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) { }
    }
}
