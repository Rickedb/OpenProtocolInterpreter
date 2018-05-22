namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// MID: Open Protocol commands disabled acknowledge
    /// Description: 
    ///     Acknowledgement of Open Protocol commands disabled upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0422 : Mid, IOpenProtocolCommandsDisabled
    {
        private const int LAST_REVISION = 1;
        public const int MID = 422;

        public MID_0422() : base(MID, LAST_REVISION) { }

        internal MID_0422(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
