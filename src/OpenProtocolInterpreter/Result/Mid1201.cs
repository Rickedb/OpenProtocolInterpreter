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
            get => GetField(Header.StandardizedRevision, DataFields.TotalMessages).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.TotalMessages).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int MessageNumber
        {
            get => GetField(Header.StandardizedRevision, DataFields.MessageNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.MessageNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int ResultDataIdentifier
        {
            get => GetField(Header.StandardizedRevision, DataFields.ResultDataIdentifier).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.ResultDataIdentifier).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime Time
        {
            get => GetField(Header.StandardizedRevision, DataFields.Time).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(Header.StandardizedRevision, DataFields.Time).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool ResultStatus
        {
            get => GetField(Header.StandardizedRevision, DataFields.ResultStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(Header.StandardizedRevision, DataFields.ResultStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public OperationType OperationType
        {
            get => (OperationType)GetField(Header.StandardizedRevision, DataFields.OperationType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.OperationType).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int RequestMid
        {
            get => GetField(Header.StandardizedRevision, DataFields.RequestMid).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.RequestMid).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int NumberOfObjects
        {
            get => GetField(Header.StandardizedRevision, DataFields.NumberOfObjects).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.NumberOfObjects).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int NumberOfDataFields
        {
            get => GetField(Header.StandardizedRevision, DataFields.NumberOfDataFields).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.NumberOfDataFields).SetValue(OpenProtocolConvert.ToString, value);
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
            GetField(revision, DataFields.ObjectData).SetValue(PackObjectDataList());
            GetField(revision, DataFields.DataFieldList).SetValue(OpenProtocolConvert.ToString(VariableDataFields));

            var index = 1;
            return string.Concat(BuildHeader(), base.Pack(revision, ref index));
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);

            var revision = Header.StandardizedRevision;
            var rawTotalObjectData = GetValue(GetField(revision, DataFields.NumberOfObjects), package);
            int totalObjectData = OpenProtocolConvert.ToInt32(rawTotalObjectData);

            var objectDataField = GetField(revision, DataFields.ObjectData);
            objectDataField.Size = totalObjectData * ObjectData.Size(Header.Revision);

            var totalNumberDataField = GetField(revision, DataFields.NumberOfDataFields);
            totalNumberDataField.Index = objectDataField.Index + objectDataField.Size;

            var dataFieldListField = GetField(revision, DataFields.DataFieldList);
            dataFieldListField.Index = totalNumberDataField.Index + totalNumberDataField.Size;
            dataFieldListField.Size = Header.Length - dataFieldListField.Index;

            ProcessDataFields(revision, package);
            ObjectDataList = ObjectData.ParseAll(revision, objectDataField.Value).ToList();
            VariableDataFields = VariableDataField.ParseAll(dataFieldListField.Value).ToList();
            return this;
        }

        protected virtual string PackObjectDataList()
        {
            var builder = new StringBuilder();
            foreach (var v in ObjectDataList)
            {
                builder.Append(v.Pack(Header.StandardizedRevision));
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
                        DataField.Number(DataFields.TotalMessages, 20, 3, false),
                        DataField.Number(DataFields.MessageNumber, 23, 3, false),
                        DataField.Number(DataFields.ResultDataIdentifier, 26, 10, false),
                        DataField.Timestamp(DataFields.Time, 36, false),
                        DataField.Boolean(DataFields.ResultStatus, 55, false),
                        DataField.Number(DataFields.OperationType, 56, 2, false),
                        DataField.Number(DataFields.NumberOfObjects, 58, 3, false),
                        DataField.Volatile(DataFields.ObjectData, 61, false),
                        DataField.Number(DataFields.NumberOfDataFields, 0, 3, false),
                        DataField.Volatile(DataFields.DataFieldList, 0, false)
                    }
                },
                {
                    2, new List<DataField>()
                    {
                        DataField.Number(DataFields.TotalMessages, 20, 3, false),
                        DataField.Number(DataFields.MessageNumber, 23, 3, false),
                        DataField.Number(DataFields.ResultDataIdentifier, 26, 10, false),
                        DataField.Timestamp(DataFields.Time, 36, false),
                        DataField.Boolean(DataFields.ResultStatus, 55, false),
                        DataField.Number(DataFields.OperationType, 56, 2, false),
                        DataField.Number(DataFields.RequestMid, 58, 4, false),
                        DataField.Number(DataFields.NumberOfObjects, 62, 3, false),
                        DataField.Volatile(DataFields.ObjectData, 65, false),
                        DataField.Number(DataFields.NumberOfDataFields, 0, 3, false),
                        DataField.Volatile(DataFields.DataFieldList, 0, false)
                    }
                },
                {
                    3, new List<DataField>()
                    {
                        DataField.Number(DataFields.TotalMessages, 20, 3, false),
                        DataField.Number(DataFields.MessageNumber, 23, 3, false),
                        DataField.Number(DataFields.ResultDataIdentifier, 26, 10, false),
                        DataField.Timestamp(DataFields.Time, 36, false),
                        DataField.Boolean(DataFields.ResultStatus, 55, false),
                        DataField.Number(DataFields.OperationType, 56, 2, false),
                        DataField.Number(DataFields.RequestMid, 58, 4, false),
                        DataField.Number(DataFields.NumberOfObjects, 62, 3, false),
                        DataField.Volatile(DataFields.ObjectData, 65, false),
                        DataField.Number(DataFields.NumberOfDataFields, 0, 3, false),
                        DataField.Volatile(DataFields.DataFieldList, 0, false)
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

