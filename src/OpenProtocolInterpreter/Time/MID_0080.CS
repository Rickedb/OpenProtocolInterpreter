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
    public class MID_0080 : Mid, ITime
    {
        private const int LAST_REVISION = 1;
        public const int MID = 80;

        public MID_0080() : base(MID, LAST_REVISION)
        {

        }

        internal MID_0080(IMid nextTemplate) : this() => NextTemplate = nextTemplate;
    }
}
