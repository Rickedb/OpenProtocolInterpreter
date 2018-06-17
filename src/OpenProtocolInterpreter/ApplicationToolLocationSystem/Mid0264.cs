namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: Tool tag ID unsubscribe
    /// Description:
    ///     Used by the integrator to send a Tool tag ID unsubscription to the controller.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Tool tag ID subscription does not exist or MID revision unsupported.
    /// </summary>
    public class Mid0264 : Mid, IApplicationToolLocationSystem
    {
        private const int LAST_REVISION = 1;
        public const int MID = 264;

        public Mid0264() : base(MID, LAST_REVISION) { }

        internal Mid0264(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
