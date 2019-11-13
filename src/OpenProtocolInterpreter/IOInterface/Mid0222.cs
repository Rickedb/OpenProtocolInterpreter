namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Digital input function acknowledge
    /// Description: 
    ///     Acknowledgement of the digital input function upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0222 : Mid, IIOInterface, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 222;

        public Mid0222() : base(MID, LAST_REVISION) { }
    }
}
