namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// MID: Multiple identifiers and result parts acknowledge
    /// Description: 
    ///    Acknowledgement of multiple identifiers and result parts upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0153 : Mid, IMultipleIdentifier
    {
        private const int LAST_REVISION = 1;
        public const int MID = 153;

        public MID_0153() : base(MID, LAST_REVISION)
        {

        }

        internal MID_0153(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
