namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// MID: Last tightening result data acknowledge
    /// Description: Acknowledgement of last tightening result data.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0062 : Mid, ITightening, IIntegrator
    {
        private const int LAST_REVISION = 6;
        public const int MID = 62;

        public Mid0062() : this(LAST_REVISION)
        {

        }

        public Mid0062(int revision = LAST_REVISION) : base(MID, revision)
        {

        }
    }
}
