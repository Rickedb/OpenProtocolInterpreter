using System;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// Application data message request
    /// <para>
    ///     Do a request for data. This message is used for ALL request handling.
    ///     When used it substitutes the use of all MID special request messages.
    /// </para>
    /// <para>
    ///     NOTE! The Header Revision field is the revision of the <see cref="Mid0006"/> itself NOT
    ///     the revision of the data MID that is wanted to be uploaded.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: MID Requested for or <see cref="Mid0004"/> Command error. Error described at each MID description.</para>
    /// </summary>
    public class Mid0006 : Mid, ICommunication, IIntegrator, IExtraDataContainer
    {
        public const int MID = 6;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 4, HasPrefix = false)]
        public int RequestedMid { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 24, Size = 3, HasPrefix = false)]
        public int WantedRevision { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 3, Index = 27, Size = 2, HasPrefix = false)]
        public int ExtraDataLength { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 4, Index = 29, Size = 0, HasPrefix = false)]
        public string ExtraData { get; set; }

        public Mid0006() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0006(Header header) : base(header)
        {
        }

        public override string Pack()
        {
            ExtraDataLength = ExtraData?.Length ?? 0;
            HandleExtraDataFieldSize();
            return base.Pack();
        }

        public void SetExtraData<TExtraData>(TExtraData extraData) where TExtraData : ExtraData, IExtraDataRequest
        {
            RequestedMid = extraData.Mid;
            WantedRevision = extraData.Revision;
            ExtraData = extraData.Pack();
            ExtraDataLength = ExtraData?.Length ?? 0;
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            base.ProcessDataField(dataField, package);
            if (dataField.Field == 3)
            {
                HandleExtraDataFieldSize();
            }
        }

        private void HandleExtraDataFieldSize()
        {
            GetField(nameof(ExtraData)).Size = ExtraDataLength;
        }
    }
}
