namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Parameter set selected acknowledge
    /// Description: 
    ///     Acknowledgement for a new parameter set selected.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid0016 : Mid, IParameterSet
    {
        private const int LAST_REVISION = 1;
        public const int MID = 16;

        public Mid0016() : base(MID, LAST_REVISION) { }

        internal Mid0016(IMid nextTemplate) : this()
        {
            NextTemplate = nextTemplate;
        }
    }
}
