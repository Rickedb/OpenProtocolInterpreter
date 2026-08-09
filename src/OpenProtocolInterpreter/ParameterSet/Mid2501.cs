namespace OpenProtocolInterpreter.ParameterSet
{
    public class Mid2501ExtraDataRequest : ExtraData, IExtraDataRequest, IExtraDataSubscription, IExtraDataUnsubscription
    {
        public override int Mid => Mid2501.MID;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 0, Size = 4, HasPrefix = false)]
        public int ProgramId { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 4, Size = 3, HasPrefix = false)]
        public NodeType NodeType { get; set; }

        public Mid2501ExtraDataRequest()
        {

        }

        public Mid2501ExtraDataRequest(int revision) : base(revision)
        {

        }
    }

    /// <summary>
    /// MID: Tightening Program Message Upload
    /// Description:
    ///     Reset the subscription for Lock at batch done.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error
    /// </summary>
    public class Mid2501 : Mid, IParameterSet, IIntegrator
    {
        public const int MID = 2501;

        public Mid2501() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid2501(Header header) : base(header)
        {
        }
    }
}
