namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: Tool tag ID acknowledge
    /// Description:
    ///     Acknowledgement of MID 0262 Tool tag ID.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0263 : Mid, IApplicationToolLocationSystem, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 263;

        public Mid0263() : base(MID, LAST_REVISION) { }
    }
}
