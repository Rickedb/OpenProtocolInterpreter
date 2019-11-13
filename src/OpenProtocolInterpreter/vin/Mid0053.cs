namespace OpenProtocolInterpreter.Vin
{
    /// <summary>
    /// MID: Vehicle ID Number acknowledge
    /// Description: 
    ///     Vehicle ID Number acknowledge.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0053 : Mid, IVin, IIntegrator
    {
        private const int LAST_REVISION = 2;
        public const int MID = 53;

        public Mid0053() : this(LAST_REVISION)
        {

        }

        public Mid0053(int revision = LAST_REVISION) : base(MID, revision)
        {

        }
    }
}
