namespace OpenProtocolInterpreter.VIN
{
    /// <summary>
    /// MID: Vehicle ID Number unsubscribe
    /// Description: 
    ///     Reset the subscription for the current tightening identifiers.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, VIN subscription does not exist
    /// </summary>
    public class MID_0054 : MID, IVIN
    {
        private const int LAST_REVISION = 1;
        public const int MID = 54;

        public MID_0054(int revision = LAST_REVISION) : base(MID, revision)
        {

        }

        internal MID_0054(IMID nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
