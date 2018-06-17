namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// MID: Automatic/Manual mode acknowledge
    /// Description: 
    ///     Acknowledgement of automatic/manual mode upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0402 : Mid, IAutomaticManualMode
    {
        private const int LAST_REVISION = 1;
        public const int MID = 402;

        public Mid0402() : base(MID, LAST_REVISION) { }

        internal Mid0402(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
