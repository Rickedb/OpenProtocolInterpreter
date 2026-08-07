using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Tool Data status reply with generic data
    /// <para>
    ///     Upload requested parameters from given tool.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>
    ///     Answer: None
    /// </para>
    /// <para>
    ///     The list will contain requested parameters from the tool.
    /// </para>
    /// </summary>
    public class Mid0704 : Mid, ITool, IController
    {
        public const int MID = 704;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        public int NumberOfDataFields { get; set; }

        [VariableDataFieldCollectionDefinition(revision: 1, field: 2, Index = 23, Size = 0, HasPrefix = false)]
        public List<VariableDataField> VariableDataFields { get; set; } = new List<VariableDataField>();

        public Mid0704() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0704(Header header) : base(header)
        {
            VariableDataFields ??= [];
        }

        public override string Pack()
        {
            NumberOfDataFields = VariableDataFields?.Count ?? 0; //Enforce list size even if modified
            GetField(revision: 1, field: 2).Size = VariableDataFields?.Sum(x => x.TotalSize) ?? 0; //Enforce size of variable data fields
            return base.Pack();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 2) //VariableDataFields
            {
                dataField.Size = Header.Length - dataField.Index;
            }
            base.ProcessDataField(dataField, package);
        }
    }

    /// <summary>
    /// Use <see cref="Communication.Mid0006"/> to request for <see cref="Mid0704"/> uploads.
    /// </summary>
    public class Mid0704ExtraDataRequest : ExtraData, IExtraDataRequest
    {
        private const int PID_SIZE = 6;

        public override int Mid => Mid0704.MID;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 0, Size = 4, HasPrefix = false)]
        public int ToolNumber { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 4, Size = 3, HasPrefix = false)]
        public int TotalRequestedPIDs { get; set; }

        [Int32CollectionDefinition(revision: 1, field: 3, Index = 7, Size = 0, HasPrefix = false, EachFieldSize = PID_SIZE)]
        public List<int> RequestedPIDs { get; set; } = new List<int>();

        public Mid0704ExtraDataRequest()
        {

        }

        public Mid0704ExtraDataRequest(int revision) : base(revision)
        {

        }

        public override string Pack()
        {
            TotalRequestedPIDs = RequestedPIDs?.Count ?? 0; //Enforce list size even if modified
            GetField(revision: 1, field: 3).Size = TotalRequestedPIDs * PID_SIZE; //Enforce size of requested pids
            return base.Pack();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 3) //RequestedPIDs
            {
                dataField.Size = package.Length - dataField.Index;
            }
            base.ProcessDataField(dataField, package);
        }
    }

    /// <summary>
    ///Use <see cref="Communication.Mid0008"/> for subscription of <see cref="Mid0704"/> uploads at versioning.
    /// <para>
    /// As the restriction is given as an UI the value may be casted to the type for the requested
    /// parameter. For a string parameter only 000 is allowed. For time parameters the restriction is
    /// given in seconds.
    /// </para>
    /// <para>
    /// <strong>Example:</strong> A request for temperature with a restriction of 5 will initiate a transmission of MID 0704 whenever the temperature has changed 5 degrees or more.
    /// </para>
    /// </summary>
    public class Mid0704ExtraDataSubscription : ExtraData, IExtraDataSubscription
    {
        public override int Mid => Mid0704.MID;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 0, Size = 4, HasPrefix = false)]
        public int ToolNumber { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 4, Size = 3, HasPrefix = false)]
        public int NumberOfPIDs { get; set; }

        [PIDRestrictionCollectionDefinition(revision: 1, field: 3, Index = 7, Size = 0, HasPrefix = false)]
        public List<PIDRestriction> PIDRestrictions { get; set; } = new List<PIDRestriction>();

        public Mid0704ExtraDataSubscription()
        {

        }

        public Mid0704ExtraDataSubscription(int revision) : base(revision)
        {

        }

        public override string Pack()
        {
            NumberOfPIDs = PIDRestrictions?.Count ?? 0; //Enforce list size even if modified
            GetField(revision: 1, field: 3).Size = NumberOfPIDs * PIDRestriction.PackedSize; //Enforce size of variable data fields
            return base.Pack();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 3) //CalibrationParameters
            {
                dataField.Size = package.Length - dataField.Index;
            }
            base.ProcessDataField(dataField, package);
        }
    }

    /// <summary>
    /// Use <see cref="Communication.Mid0009"/> to unsubscribe a <see cref="Mid0704"/>.
    /// </summary>
    public class Mid0704ExtraDataUnsubscription : ExtraData, IExtraDataUnsubscription
    {
        public override int Mid => Mid0704.MID;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 0, Size = 4, HasPrefix = false)]
        public int ToolNumber { get; set; }

        public Mid0704ExtraDataUnsubscription()
        {

        }

        public Mid0704ExtraDataUnsubscription(int revision) : base(revision)
        {

        }
    }
}
