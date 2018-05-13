namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Digital input function acknowledge
    /// Description: 
    ///     Acknowledgement of the digital input function upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0222 : Mid, IIOInterface
    {
        private const int LAST_REVISION = 1;
        public const int MID = 222;

        public MID_0222() : base(MID, LAST_REVISION) { }

        internal MID_0222(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
