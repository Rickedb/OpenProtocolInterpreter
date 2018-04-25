namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// MID: Application Communication start
    /// Description:
    ///     This message enables the communication. The controller does not respond to any other command
    ///     before this
    /// Message sent by: Integrator
    /// Answer: MID 0002 Communication start acknowledge or MID 0004 Command error, 
    ///         Client already connected or MID revision unsupported
    /// </summary>
    public class MID_0001 : Mid, ICommunication
    {
        private const int LAST_REVISION = 5;
        public const int MID = 1;
        
        public MID_0001(int revision = LAST_REVISION) : base(MID, revision) { }

        internal MID_0001(IMid nextTemplate) : base(MID, LAST_REVISION) => NextTemplate = nextTemplate;
    }
}
