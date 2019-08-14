namespace OpenProtocolInterpreter.Vin
{
    /// <summary>
    /// MID: Vehicle ID Number unsubscribe
    /// Description: 
    ///     Reset the subscription for the current tightening identifiers.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, VIN subscription does not exist
    /// </summary>
    public class Mid0054 : Mid, IVin, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 54;

        public Mid0054() : this(LAST_REVISION)
        {

        }

        public Mid0054(int revision = LAST_REVISION) : base(MID, revision)
        {

        }
    }
}
