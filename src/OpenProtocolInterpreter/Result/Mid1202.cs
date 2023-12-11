using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Result
{
    /// <summary>
    /// Operation result object data
    /// <para>
    ///     This message contains the cycle data for one object, both data for the whole process and data related to 
    ///     the different steps in the process.The user defined values are preconfigured in the controller via the 
    ///     configuration tool. The message uses the Variable Parameter pattern for transmission of the values.
    /// </para>
    /// <para>
    ///     Note: Only values that exist in the result will be sent.So the actual data received may vary between 
    ///     the cycles if the settings differ between different programs.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>
    ///     Answer: <see cref="Mid1203"/> Operation result data acknowledge or 
    ///             <see cref="Communication.Mid0005"/> with <see cref="Mid1202"/> in the data field.
    /// </para>
    ///         
    ///         If the sequence number acknowledge functionality is used there is no need for these acknowledges.
    /// </summary>
    public class Mid1202 : Mid, IResult, IController, IAcknowledgeable<Mid1203>, IAcceptableCommand
    {
        public const int MID = 1202;

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
        public long ResultDataIdentifier
        {
            get => GetField(Header.StandardizedRevision, DataFields.ResultDataIdentifier).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.ResultDataIdentifier).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int ObjectId
        {
            get => GetField(Header.StandardizedRevision, DataFields.ObjectId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.ObjectId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string NodeGuid
        {
            get => GetField(Header.StandardizedRevision, DataFields.NodeGuid).Value;
            set => GetField(Header.StandardizedRevision, DataFields.NodeGuid).SetValue(value);
        }
        public int NumberOfDataFields
        {
            get => GetField(Header.StandardizedRevision, DataFields.NumberOfDataFields).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.NumberOfDataFields).SetValue(OpenProtocolConvert.ToString, value);
        }

        public List<VariableDataField> VariableDataFields { get; set; }

        public Mid1202() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid1202(Header header) : base(header)
        {
            VariableDataFields = [];
        }
        protected override string BuildHeader()
        {
            Header.Length = 20 + RevisionsByFields[Header.StandardizedRevision].Sum(x => x.TotalSize);
            return Header.ToString();
        }

        public override string Pack()
        {
            NumberOfDataFields = VariableDataFields.Count;
            var revision = Header.StandardizedRevision;
            GetField(revision, DataFields.VariableDataFields).SetValue(OpenProtocolConvert.ToString(VariableDataFields));
            int prefixIndex = 0;
            return string.Concat(BuildHeader(), base.Pack(revision, ref prefixIndex));
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            var revision = Header.StandardizedRevision;
            var variableDataField = GetField(revision, DataFields.VariableDataFields);
            variableDataField.Size = Header.Length - variableDataField.Index;
            ProcessDataFields(revision, package);

            VariableDataFields = VariableDataField.ParseAll(variableDataField.Value).ToList();
            return this;
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
                        DataField.Number(DataFields.ObjectId, 36, 4, false),
                        DataField.Number(DataFields.NumberOfDataFields, 40, 3, false),
                        DataField.Volatile(DataFields.VariableDataFields, 43, false) //defined at runtime
                    }
                },
                {
                    2, new List<DataField>()
                    {
                        DataField.Number(DataFields.TotalMessages, 20, 3, false),
                        DataField.Number(DataFields.MessageNumber, 23, 3, false),
                        DataField.Number(DataFields.ResultDataIdentifier, 26, 10, false),
                        DataField.Number(DataFields.ObjectId, 36, 4, false),
                        DataField.String(DataFields.NodeGuid, 40, 36, false),
                        DataField.Number(DataFields.NumberOfDataFields, 76, 3, false),
                        DataField.Volatile(DataFields.VariableDataFields, 79, false) //defined at runtime
                    }
                }
            };
        }

        protected enum DataFields
        {
            TotalMessages,
            MessageNumber,
            ResultDataIdentifier,
            ObjectId,
            NodeGuid,
            NumberOfDataFields,
            VariableDataFields
        }
    }
}
