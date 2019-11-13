namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: Tool tag ID request
    /// Description:
    ///     Used by the integrator to request Tool tag ID information.
    /// Message sent by: Controller
    /// Answer: MID 0262 Tool tag ID or
    ///         MID 0004 Command error, Tool tag ID unknown or MID revision unsupported.
    /// </summary>
    public class Mid0260 : Mid, IApplicationToolLocationSystem, IController
    {
        private const int LAST_REVISION = 1;
        public const int MID = 260;

        public Mid0260() : base(MID, LAST_REVISION) { }

    }
}
