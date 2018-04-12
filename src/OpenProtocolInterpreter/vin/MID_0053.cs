namespace OpenProtocolInterpreter.VIN
{
    /// <summary>
    /// MID: Vehicle ID Number acknowledge
    /// Description: 
    ///     Vehicle ID Number acknowledge.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0053 : MID, IVIN
    {
        private const int LAST_REVISION = 2;
        public const int MID = 53;
        
        public MID_0053(int revision = LAST_REVISION) : base(MID, revision)
        {

        }

        internal MID_0053(IMID nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
