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
    public class MID_0423 : Mid, IOpenProtocolCommandsDisabled
    {
        private const int LAST_REVISION = 1;
        public const int MID = 423;

        public MID_0423() : base(MID, LAST_REVISION) { }

        internal MID_0423(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
