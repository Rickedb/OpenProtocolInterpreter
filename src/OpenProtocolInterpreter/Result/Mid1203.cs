namespace OpenProtocolInterpreter.Result
{
    /// <summary>
    /// MID: Operation result data acknowledge
    /// Description: 
    ///     Only Header is sent with no data fields.
    /// 
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class Mid1203 : Mid, IResult, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 1203;

        public Mid1203() : base(MID, LAST_REVISION)
        {

        }
    }
}
