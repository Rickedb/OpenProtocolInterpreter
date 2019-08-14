namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Lock at batch done upload Acknowledge
    /// Description: 
    ///     This message is an acknowledge to MID 0022.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted
    /// </summary>
    public class Mid0023 : Mid, IParameterSet, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 23;

        public Mid0023() : base(MID, LAST_REVISION) { }
    }
}
