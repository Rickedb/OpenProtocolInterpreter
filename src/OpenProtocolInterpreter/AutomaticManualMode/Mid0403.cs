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
    public class Mid0403 : Mid, IAutomaticManualMode, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 403;

        public Mid0403() : base(MID, LAST_REVISION) { }
    }
}
