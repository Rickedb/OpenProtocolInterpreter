namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// MID: Open Protocol commands disabled unsubscribe
    /// Description: 
    ///     Reset the subscription for the Open Protocol commands disabled digital input.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, Open Protocol commands disabled
    ///         subscription does not exist
    /// </summary>
    public class Mid0423 : Mid, IOpenProtocolCommandsDisabled, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 423;

        public Mid0423() : base(MID, LAST_REVISION) { }
    }
}
