namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Status externally monitored inputs acknowledge
    /// Description: 
    ///     Acknowledgement for the message status externally monitored inputs upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0212 : Mid, IIOInterface, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 212;

        public Mid0212() : base(MID, LAST_REVISION) { }
    }
}
