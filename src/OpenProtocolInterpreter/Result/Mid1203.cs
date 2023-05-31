namespace OpenProtocolInterpreter.Result
{
    /// <summary>
    /// Operation result data acknowledge
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid1203 : Mid, IResult, IIntegrator, IAcknowledge
    {
        public const int MID = 1203;

        public Mid1203() : base(MID, DEFAULT_REVISION)
        {
        }

        public Mid1203(Header header) : base(header)
        {
        }
    }
}
