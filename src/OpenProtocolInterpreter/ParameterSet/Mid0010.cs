namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Parameter set ID upload request
    /// <para>A request to get the valid parameter set IDs from the controller.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Mid0011"/> Parameter set ID upload reply</para>
    /// </summary>
    public class Mid0010 : Mid, IParameterSet, IIntegrator, IAnswerableBy<Mid0011>
    {
        private const int LAST_REVISION = 3;
        public const int MID = 10;

        public Mid0010() : this(LAST_REVISION)
        {

        }

        public Mid0010(int revision = LAST_REVISION) : base(MID, revision) { }

        public Mid0010(Header header) : base(header)
        {
        }
    }
}
