namespace OpenProtocolInterpreter.Time
{
    /// <summary>
    /// MID: Read time upload request
    /// Description: 
    ///     Read time request.
    /// 
    /// Message sent by: Integrator
    /// Answer: MID 0081 Read time upload reply
    /// </summary>
    public class Mid0080 : Mid, ITime, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 80;

        public Mid0080() : base(MID, LAST_REVISION)
        {

        }
    }
}
