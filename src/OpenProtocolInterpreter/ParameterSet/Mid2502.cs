namespace OpenProtocolInterpreter.ParameterSet
{
    public class Mid2502 : Mid, IController, IParameterSet
    {
        public const int MID = 2502;

        public Mid2502() : this(DEFAULT_REVISION)
        {
        }

        public Mid2502(Header header) : base(header)
        {
        }

        public Mid2502(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }
    }
}
