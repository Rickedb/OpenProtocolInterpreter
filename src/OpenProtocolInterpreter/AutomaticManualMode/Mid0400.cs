namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// MID: Automatic/Manual mode subscribe
    /// Description: 
    ///     A subscription for Automatic/Manual mode. When the mode changes the MID 0401 Automatic/Manual mode 
    ///     upload is sent to the integrator.
    ///     After a successful subscription the message MID 0401 Automatic/Manual mode upload with the 
    ///     current mode status is sent to the integrator.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Automatic/Manual mode subscribe already exists
    /// </summary>
    public class Mid0400 : Mid, IAutomaticManualMode
    {
        private const int LAST_REVISION = 1;
        public const int MID = 400;

        public Mid0400(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) { }

        internal Mid0400(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
