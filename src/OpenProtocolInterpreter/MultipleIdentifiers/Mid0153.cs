namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: Multiple identifiers and result parts acknowledge
    /// Description: 
    ///    Acknowledgement of multiple identifiers and result parts upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0153 : Mid, IMultipleIdentifier, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 153;

        public Mid0153() : base(MID, LAST_REVISION)
        {

        }
    }
}
