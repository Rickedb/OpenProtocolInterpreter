using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Result
{

    /// <summary>
    /// Operation result Overall data
    /// <para>
    ///     This MID contains the overall result data and some of the object data of the last tightening.
    ///     In the subscription of this message it can be chosen to also start subscription of <see cref="Mid1202"/> Operation result object data.
    ///     The user defined values is preconfigured in the controller via the configuration tool.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>
    ///     Answer: <see cref="Mid1203"/> Operation result data acknowledge or
    ///             <see cref="Communication.Mid0005"/> with <see cref="Mid1201"/> in the data field.
    /// </para>
    /// <para>If the sequence number acknowledge functionality is used there is no need for these acknowledges.</para>
    /// </summary>
    public class Mid1201 : Mid, IResult, IController, IAcknowledgeable<Mid1203>, IAcceptableCommand
    {
        public const int MID = 1201;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 3, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        public int TotalNumberOfMessages { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 23, Size = 3, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 2, field: 2, Index = 23, Size = 3, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 3, field: 2, Index = 23, Size = 3, HasPrefix = false)]
        public int MessageNumber { get; set; }

        [Int64DataFieldDefinition(revision: 1, field: 3, Index = 26, Size = 10, HasPrefix = false)]
        [Int64DataFieldDefinition(revision: 2, field: 3, Index = 26, Size = 10, HasPrefix = false)]
        [Int64DataFieldDefinition(revision: 3, field: 3, Index = 26, Size = 10, HasPrefix = false)]
        public long ResultDataIdentifier { get; set; }

        [TimestampDataFieldDefinition(revision: 1, field: 4, Index = 36, HasPrefix = false)]
        [TimestampDataFieldDefinition(revision: 2, field: 4, Index = 36, HasPrefix = false)]
        [TimestampDataFieldDefinition(revision: 3, field: 4, Index = 36, HasPrefix = false)]
        public DateTime Time { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 5, Index = 55, Size = 1, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 2, field: 5, Index = 55, Size = 1, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 3, field: 5, Index = 55, Size = 1, HasPrefix = false)]
        public int ResultStatus { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 6, Index = 56, Size = 2, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 2, field: 6, Index = 56, Size = 2, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 3, field: 6, Index = 56, Size = 2, HasPrefix = false)]
        public OperationType OperationType { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 7, Index = 58, Size = 4, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 3, field: 7, Index = 58, Size = 4, HasPrefix = false)]
        public int RequestMid { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 7, Index = 58, Size = 3, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 2, field: 8, Index = 62, Size = 3, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 3, field: 8, Index = 62, Size = 3, HasPrefix = false)]
        public int NumberOfObjects { get; set; }

        [ObjectDataCollectionDefinition(revision: 1, field: 8, Index = 61, Size = 0, HasPrefix = false)]
        [ObjectDataCollectionDefinition(revision: 2, field: 9, Index = 65, Size = 0, HasPrefix = false)]
        [ObjectDataCollectionDefinition(revision: 3, field: 9, Index = 65, Size = 0, HasPrefix = false)]
        public List<ObjectData> ObjectDataList { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 9, Index = 0, Size = 3, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 2, field: 10, Index = 0, Size = 3, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 3, field: 10, Index = 0, Size = 3, HasPrefix = false)]
        public int NumberOfDataFields { get; set; }

        [VariableDataFieldCollectionDefinition(revision: 1, field: 10, Index = 0, Size = 0, HasPrefix = false)]
        [VariableDataFieldCollectionDefinition(revision: 2, field: 11, Index = 0, Size = 0, HasPrefix = false)]
        [VariableDataFieldCollectionDefinition(revision: 3, field: 11, Index = 0, Size = 0, HasPrefix = false)]
        public List<VariableDataField> VariableDataFields { get; set; }

        public Mid1201() : this(DEFAULT_REVISION)
        {

        }

        public Mid1201(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        public Mid1201(Header header) : base(header)
        {
            ObjectDataList = [];
            VariableDataFields = [];
        }

        protected override string BuildHeader()
        {
            var fields = DataFieldsByRevision();
            Header.Length = Header.DefaultSize + fields.Sum(x => x.TotalSize);
            return Header.ToString();
        }

        public override string Pack()
        {
            NumberOfObjects = ObjectDataList?.Count ?? 0;
            NumberOfDataFields = VariableDataFields?.Count ?? 0;
            if (Header.StandardizedRevision == 1)
            {
                GetField(revision: Header.StandardizedRevision, field: 8).Size = NumberOfObjects * ObjectData.Size(Header.StandardizedRevision);
                GetField(revision: Header.StandardizedRevision, field: 10).Size = VariableDataFields.Sum(x => x.TotalSize);
            }
            else
            {
                GetField(revision: Header.StandardizedRevision, field: 9).Size = NumberOfObjects * ObjectData.Size(Header.StandardizedRevision);
                GetField(revision: Header.StandardizedRevision, field: 11).Size = VariableDataFields.Sum(x => x.TotalSize);
            }

            var builder = new StringBuilder();
            builder.Append(BuildHeader());
            builder.Append(Pack(DataFieldsByRevision()));
            return builder.ToString();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            switch (dataField.Field)
            {
                case 8 when dataField is DataField<List<ObjectData>>:
                case 9 when dataField is DataField<List<ObjectData>>:
                    dataField.Size = NumberOfObjects * ObjectData.Size(Header.StandardizedRevision);
                    break;
                case 10 when dataField is DataField<List<VariableDataField>>: //StepResults
                case 11 when dataField is DataField<List<VariableDataField>>:
                    dataField.Size = Header.Length - dataField.Index;
                    break;
            }

            base.ProcessDataField(dataField, package);
        }

        protected override void ProcessDataFields(ReadOnlySpan<char> package)
        {
            foreach (var field in DataFieldsByRevision())
                ProcessDataField(field, package);
        }

        private IEnumerable<DataField> DataFieldsByRevision()
        {
            var previousField = default(DataField);
            foreach (var dataField in RevisionsByFields[Header.StandardizedRevision])
            {
                if (previousField != null && dataField.Index == 0)
                {
                    dataField.Index = previousField.Index + previousField.TotalSize;
                }

                previousField = dataField;
                yield return dataField;
            }
        }
    }

    public class Mid1201ExtraDataRequest : ExtraData, IExtraDataRequest
    {
        public override int Mid => Mid1201.MID;

        [Int64DataFieldDefinition(revision: 1, field: 1, Index = 0, Size = 10, HasPrefix = false)]
        public long Index { get; set; }

        public Mid1201ExtraDataRequest() : this(2)
        {

        }

        public Mid1201ExtraDataRequest(int revision) : base(revision)
        {
        }
    }

    public class Mid1201ExtraDataSubscription : ExtraData, IExtraDataSubscription
    {
        public override int Mid => Mid1201.MID;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 0, Size = 10, HasPrefix = false)]
        public int SendAlternatives { get; set; }

        [TimestampDataFieldDefinition(revision: 1, field: 2, Index = 10, HasPrefix = false)]
        public DateTime DataIdentifierTimestamp { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 4, Index = 29, HasPrefix = false)]
        public bool SendObjectData { get; set; }

        public Mid1201ExtraDataSubscription() : this(1)
        {

        }

        public Mid1201ExtraDataSubscription(int revision) : base(revision)
        {
        }
    }

    public class Mid1201SecondAlternativeExtraDataSubscription : ExtraData, IExtraDataSubscription
    {
        public override int Mid => Mid1201.MID;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 0, Size = 10, HasPrefix = false)]
        public int SendAlternatives { get; set; }

        [UnixTimestampDataFieldDefinition(revision: 1, field: 2, Index = 10, HasPrefix = false)]
        public DateTimeOffset DataIdentifierTimestamp { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 4, Index = 20, HasPrefix = false)]
        public bool SendObjectData { get; set; }

        public Mid1201SecondAlternativeExtraDataSubscription() : this(1)
        {

        }

        public Mid1201SecondAlternativeExtraDataSubscription(int revision) : base(revision)
        {
        }
    }

    public class Mid1201ThirdAlternativeExtraDataSubscription : ExtraData, IExtraDataSubscription
    {
        public override int Mid => Mid1201.MID;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 0, Size = 1, HasPrefix = false)]
        public int SendAlternatives { get; set; } = 3;

        [Int64DataFieldDefinition(revision: 1, field: 2, Index = 1, Size = 10, HasPrefix = false)]
        public long DataIdentifierFirstIndex { get; set; }

        [Int64DataFieldDefinition(revision: 1, field: 3, Index = 11, Size = 10, HasPrefix = false)]
        public long DataIdentifierLastIndex { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 4, Index = 21, HasPrefix = false)]
        public bool SendObjectData { get; set; }

        public Mid1201ThirdAlternativeExtraDataSubscription() : this(1)
        {

        }

        public Mid1201ThirdAlternativeExtraDataSubscription(int revision) : base(revision)
        {
        }
    }

    public class Mid1201FourthAlternativeExtraDataSubscription : ExtraData, IExtraDataSubscription
    {
        public override int Mid => Mid1201.MID;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 0, Size = 1, HasPrefix = false)]
        public int SendAlternatives { get; set; } = 3;

        [UnixTimestampDataFieldDefinition(revision: 1, field: 2, Index = 1, Size = 10, HasPrefix = false)]
        public DateTimeOffset DataIdentifierFirstIndex { get; set; }

        [UnixTimestampDataFieldDefinition(revision: 1, field: 3, Index = 11, Size = 10, HasPrefix = false)]
        public DateTimeOffset DataIdentifierLastIndex { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 4, Index = 21, HasPrefix = false)]
        public bool SendObjectData { get; set; }

        public Mid1201FourthAlternativeExtraDataSubscription() : this(1)
        {

        }

        public Mid1201FourthAlternativeExtraDataSubscription(int revision) : base(revision)
        {
        }
    }
}
