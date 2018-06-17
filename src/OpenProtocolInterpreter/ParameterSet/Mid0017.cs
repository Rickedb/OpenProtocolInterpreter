namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Parameter set selected unsubscribe
    /// Description: 
    ///     Reset the subscription for the parameter set selection.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, Parameter set subscription does not exist
    /// </summary>
    public class Mid0017 : Mid, IParameterSet
    {
        private const int LAST_REVISION = 1;
        public const int MID = 17;

        public Mid0017() : base(MID, LAST_REVISION) { }

        internal Mid0017(IMid nextTemplate) : this()
        {
            NextTemplate = nextTemplate;
        }
    }
}
