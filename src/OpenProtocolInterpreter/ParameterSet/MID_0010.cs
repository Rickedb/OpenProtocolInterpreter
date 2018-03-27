namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Parameter set ID upload request
    /// Description: 
    ///     A request to get the valid parameter set IDs from the controller.
    /// Message sent by: Integrator
    /// Answer: MID 0011 Parameter set ID upload reply
    /// </summary>
    public class MID_0010 : MID, IParameterSet
    {
        private const int LAST_REVISION = 3;
        public const int MID = 10;

        public MID_0010(int revision = LAST_REVISION) : base(MID, revision) { }

        internal MID_0010(IMID nextTemplate) : this()
        {
            NextTemplate = nextTemplate;
        }
    }
}
