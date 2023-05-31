namespace OpenProtocolInterpreter.Time
{
    /// <summary>
    /// Read time upload request
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Mid0081"/> Read time upload reply</para>
    /// </summary>
    public class Mid0080 : Mid, ITime, IIntegrator, IAnswerableBy<Mid0081>
    {
        public const int MID = 80;

        public Mid0080() : base(MID, DEFAULT_REVISION)
        {

        }

        public Mid0080(Header header) : base(header)
        {
        }
    }
}
