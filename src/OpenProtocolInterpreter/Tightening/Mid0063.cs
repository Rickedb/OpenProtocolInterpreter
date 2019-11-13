namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// MID: Last tightening result data unsubscribe
    /// Description: Reset the last tightening result subscription.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Last tightening result subscription does not exist
    /// </summary>
    public class Mid0063 : Mid, ITightening, IIntegrator
    {
        private const int LAST_REVISION = 6;
        public const int MID = 63;

        public Mid0063() : this(LAST_REVISION)
        {

        }

        public Mid0063(int revision = LAST_REVISION) : base(MID, revision)
        {

        }
    }
}
