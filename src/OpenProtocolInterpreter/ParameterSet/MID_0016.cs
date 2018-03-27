namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Parameter set selected acknowledge
    /// Description: 
    ///     Acknowledgement for a new parameter set selected.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0016 : MID, IParameterSet
    {
        private const int LAST_REVISION = 1;
        public const int MID = 16;

        public MID_0016() : base(MID, LAST_REVISION) { }

        internal MID_0016(IMID nextTemplate) : this()
        {
            NextTemplate = nextTemplate;
        }
    }
}
