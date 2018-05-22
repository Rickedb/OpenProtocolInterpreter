namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// MID: Automatic/Manual mode unsubscribe
    /// Description: 
    ///     Reset the subscription for the automatic/manual mode.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, Automatic/Manual mode subscribe does not exist
    /// </summary>
    public class MID_0403 : Mid, IAutomaticManualMode
    {
        private const int LAST_REVISION = 1;
        public const int MID = 403;

        public MID_0403() : base(MID, LAST_REVISION) { }

        internal MID_0403(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
