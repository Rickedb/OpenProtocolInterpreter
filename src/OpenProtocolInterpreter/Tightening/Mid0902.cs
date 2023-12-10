using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Tightening Result DB Info Upload
    /// <para>This message contains information concerning the tightening result database on the controller.</para>
    /// <para><see cref="Communication.Mid0006"/> Application Data Message Request shall be used for fetching this message</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0902 : Mid, ITightening, IController
    {
        public const int MID = 902;

        public long Capacity
        {
            get => GetField(1, DataFields.Capacity).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Capacity).SetValue(OpenProtocolConvert.ToString, value);
        }
        public long OldestSequenceNumber
        {
            get => GetField(1, DataFields.OldestSequenceNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.OldestSequenceNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime OldestTime
        {
            get => GetField(1, DataFields.OldestTime).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, DataFields.OldestTime).SetValue(OpenProtocolConvert.ToString, value);
        }
        public long NewestSequenceNumber
        {
            get => GetField(1, DataFields.NewestSequenceNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.NewestTime).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime NewestTime
        {
            get => GetField(1, DataFields.NewestTime).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, DataFields.NewestTime).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int NumberOfPIDs
        {
            get => GetField(1, DataFields.NumberOfPIDs).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.NumberOfPIDs).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<VariableDataField> VariableDataFields { get; set; }

        public Mid0902() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0902(Header header) : base(header)
        {
        }

        public override string Pack()
        {
            var revision = Header.StandardizedRevision;
            GetField(revision, DataFields.VariableDataFields).SetValue(OpenProtocolConvert.ToString(VariableDataFields));

            var index = 1;
            return string.Concat(BuildHeader(), base.Pack(revision, ref index));
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);

            var field = GetField(1, DataFields.VariableDataFields);
            field.Size = Header.Length - field.Index;
            base.Parse(package);
            VariableDataFields = VariableDataField.ParseAll(field.Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Number(DataFields.Capacity, 20, 10, false),
                                DataField.Number(DataFields.OldestSequenceNumber, 30, 10, false),
                                DataField.Timestamp(DataFields.OldestTime, 40, false),
                                DataField.Number(DataFields.NewestSequenceNumber, 59, 10, false),
                                DataField.Timestamp(DataFields.NewestTime, 69, false),
                                DataField.Number(DataFields.NumberOfPIDs, 88, 3, false),
                                DataField.Volatile(DataFields.VariableDataFields, 91, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            Capacity,
            OldestSequenceNumber,
            OldestTime,
            NewestSequenceNumber,
            NewestTime,
            NumberOfPIDs,
            VariableDataFields
        }
    }
}
