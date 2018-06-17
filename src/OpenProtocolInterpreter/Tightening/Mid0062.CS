namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// MID: Last tightening result data acknowledge
    /// Description: Acknowledgement of last tightening result data.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0062 : Mid, ITightening
    {
        private const int LAST_REVISION = 6;
        public const int MID = 62;

        public Mid0062(int revision = LAST_REVISION) : base(MID, revision)
        {

        }

        internal Mid0062(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        
    }
}
