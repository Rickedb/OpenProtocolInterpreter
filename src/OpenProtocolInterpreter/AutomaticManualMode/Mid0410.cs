namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// MID: AutoDisable settings request
    /// Description: 
    ///     Request for AutoDisable settings. This request is intended to be used while 
    ///     running single parameter sets with batch and does not provide batch information while running Job.
    /// Message sent by: Integrator
    /// Answer: MID 0411 AutoDisable settings reply
    /// </summary>
    public class Mid0410 : Mid, IAutomaticManualMode
    {
        private const int LAST_REVISION = 1;
        public const int MID = 410;

        public Mid0410() : base(MID, LAST_REVISION) { }

        internal Mid0410(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
        
    }
}
