namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// MID: Application Communication stop
    /// Description:
    ///     This message disables the communication. The controller will stop to respond to any commands
    ///     except for MID 0001 Communication start after receiving this command.
    /// Message sent by: Controller
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class Mid0003 : Mid, ICommunication
    {
        private const int LAST_REVISION = 1;
        public const int MID = 3;

        public Mid0003() : base(MID, LAST_REVISION) { }

        internal Mid0003(IMid nextTemplate) : base(MID, LAST_REVISION) => NextTemplate = nextTemplate;
    }
}
