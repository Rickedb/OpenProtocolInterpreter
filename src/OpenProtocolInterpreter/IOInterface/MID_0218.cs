namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Relay function acknowledge
    /// Description: 
    ///     Acknowledgement of relay function upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0218 : Mid, IIOInterface
    {
        private const int LAST_REVISION = 1;
        public const int MID = 218;

        public MID_0218() : base(MID, LAST_REVISION) { }

        internal MID_0218(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        
    }
}
