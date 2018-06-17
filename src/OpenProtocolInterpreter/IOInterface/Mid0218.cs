namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Relay function acknowledge
    /// Description: 
    ///     Acknowledgement of relay function upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0218 : Mid, IIOInterface
    {
        private const int LAST_REVISION = 1;
        public const int MID = 218;

        public Mid0218() : base(MID, LAST_REVISION) { }

        internal Mid0218(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        
    }
}
