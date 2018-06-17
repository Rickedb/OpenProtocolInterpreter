namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// MID: Selector socket info acknowledge
    /// Description:
    ///     Acknowledgement of the MID 0251 Selector socket info.   
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0252 : Mid, IApplicationSelector
    {
        private const int LAST_REVISION = 1;
        public const int MID = 252;
        
        public Mid0252() : base(MID, LAST_REVISION) { }

        internal Mid0252(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
