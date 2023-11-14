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

        public int TotalNumberOfMessages
        {
            get => GetField(Header.StandardizedRevision, (int)DataFields.TotalMessages).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, (int)DataFields.TotalMessages).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int MessageNumber
        {
            get => GetField(Header.StandardizedRevision, (int)DataFields.MessageNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, (int)DataFields.MessageNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int ResultDataIdentifier
        {
            get => GetField(Header.StandardizedRevision, (int)DataFields.ResultDataIdentifier).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, (int)DataFields.ResultDataIdentifier).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime Time
        {
            get => GetField(Header.StandardizedRevision, (int)DataFields.Time).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(Header.StandardizedRevision, (int)DataFields.Time).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool ResultStatus
        {
            get => GetField(Header.StandardizedRevision, (int)DataFields.ResultStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(Header.StandardizedRevision, (int)DataFields.ResultStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public OperationType OperationType
        {
            get => (OperationType)GetField(Header.StandardizedRevision, (int)DataFields.OperationType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, (int)DataFields.OperationType).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public int RequestMid
        {
            get => GetField(Header.StandardizedRevision, (int)DataFields.RequestMid).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, (int)DataFields.RequestMid).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int NumberOfObjects
        {
            get => GetField(Header.StandardizedRevision, (int)DataFields.NumberOfObjects).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, (int)DataFields.NumberOfObjects).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int NumberOfDataFields
        {
            get => GetField(Header.StandardizedRevision, (int)DataFields.NumberOfDataFields).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, (int)DataFields.NumberOfDataFields).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<ObjectData> ObjectDataList { get; set; }
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
            Header.Length = 20 + RevisionsByFields[Header.StandardizedRevision].Sum(x => x.Size + (x.HasPrefix ? 2 : 0));
            return Header.ToString();
        }

        public override string Pack()
        {
            NumberOfObjects = ObjectDataList.Count;
            NumberOfDataFields = VariableDataFields.Count;
            var revision = Header.StandardizedRevision;
            GetField(revision, (int)DataFields.ObjectData).SetValue(PackObjectDataList());
            GetField(revision, (int)DataFields.DataFieldList).SetValue(OpenProtocolConvert.ToString(VariableDataFields));

            var index = 1;
            return string.Concat(BuildHeader(), base.Pack(revision, ref index));
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);

            var revision = Header.StandardizedRevision;
            var rawTotalObjectData = GetValue(GetField(revision, (int)DataFields.NumberOfObjects), package);
            int totalObjectData = OpenProtocolConvert.ToInt32(rawTotalObjectData);

            var objectDataField = GetField(revision, (int)DataFields.ObjectData);
            objectDataField.Size = totalObjectData * ObjectData.Size(Header.Revision);

            var totalNumberDataField = GetField(revision, (int)DataFields.NumberOfDataFields);
            totalNumberDataField.Index = objectDataField.Index + objectDataField.Size;

            var dataFieldListField = GetField(revision, (int)DataFields.DataFieldList);
            dataFieldListField.Index = totalNumberDataField.Index + totalNumberDataField.Size;
            dataFieldListField.Size = Header.Length - dataFieldListField.Index;

            ProcessDataFields(revision, package);
            ObjectDataList = ObjectData.ParseAll(objectDataField.Value).ToList();
            VariableDataFields = VariableDataField.ParseAll(dataFieldListField.Value).ToList();
            return this;
        }

        protected virtual string PackObjectDataList()
        {
            var builder = new StringBuilder();
            foreach (var v in ObjectDataList)
            {
                builder.Append(v.Pack());
            }

            return builder.ToString();
        }


        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new((int)DataFields.TotalMessages, 20, 3, '0', PaddingOrientation.LeftPadded, false),
                        new((int)DataFields.MessageNumber, 23, 3, '0', PaddingOrientation.LeftPadded, false),
                        new((int)DataFields.ResultDataIdentifier, 26, 10, '0', PaddingOrientation.LeftPadded, false),
                        new((int)DataFields.Time, 36, 19, '0', PaddingOrientation.LeftPadded, false),
                        new((int)DataFields.ResultStatus, 55, 1, false),
                        new((int)DataFields.OperationType, 56, 2, '0', PaddingOrientation.LeftPadded, false),
                        new((int)DataFields.NumberOfObjects, 58, 3, '0', PaddingOrientation.LeftPadded, false),
                        new((int)DataFields.ObjectData, 61, 0, false),
                        new((int)DataFields.NumberOfDataFields, 0, 3, '0', PaddingOrientation.LeftPadded, false),
                        new((int)DataFields.DataFieldList, 0, 0, false)
                    }
                },
                {
                    2, new List<DataField>()
                    {
                        new((int)DataFields.TotalMessages, 20, 3, '0', PaddingOrientation.LeftPadded, false),
                        new((int)DataFields.MessageNumber, 23, 3, '0', PaddingOrientation.LeftPadded, false),
                        new((int)DataFields.ResultDataIdentifier, 26, 10, '0', PaddingOrientation.LeftPadded, false),
                        new((int)DataFields.Time, 36, 19, '0', PaddingOrientation.LeftPadded, false),
                        new((int)DataFields.ResultStatus, 55, 1, false),
                        new((int)DataFields.OperationType, 56, 2, '0', PaddingOrientation.LeftPadded, false),
                        new((int)DataFields.RequestMid, 58, 4, '0', PaddingOrientation.LeftPadded, false),
                        new((int)DataFields.NumberOfObjects, 62, 3, '0', PaddingOrientation.LeftPadded, false),
                        new((int)DataFields.ObjectData, 65, 0, false),
                        new((int)DataFields.NumberOfDataFields, 0, 3, '0', PaddingOrientation.LeftPadded, false),
                        new((int)DataFields.DataFieldList, 0, 0, false)
                    }
                }
            };
        }

        protected enum DataFields
        {
            TotalMessages,
            MessageNumber,
            ResultDataIdentifier,
            Time,
            ResultStatus,
            OperationType,
            RequestMid,
            NumberOfObjects,
            ObjectData,  // list of data
            NumberOfDataFields,
            DataFieldList
        }
    }
}

