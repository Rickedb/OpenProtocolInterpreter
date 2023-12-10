using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.Tightening
{
    public class Mid0902 : Mid, ITightening, IIntegrator
    {
        public const int Mid = 902;

        public long Capacity { get; set; }
        public long OldestSequenceNumber { get; set; }
        public DateTime OldestTime { get; set; }
        public long NewestSequenceNumber { get; set; }
        public DateTime NewestTime { get; set; }
        public int NumberOfPIDs { get; set; }
        public List<TighteningResultDataField> TighteningDataFields { get; set; }

        public Mid0902() : this(new Header()
        {
            Mid = Mid,
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
            GetField(revision, DataFields.DataFields).SetValue(OpenProtocolConvert.ToString(TighteningDataFields));

            var index = 1;
            return string.Concat(BuildHeader(), base.Pack(revision, ref index));
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);

            var field = GetField(1, DataFields.DataFields);
            field.Size = Header.Length - field.Index;
            base.Parse(package);
            TighteningDataFields = TighteningResultDataField.ParseAll(field.Value).ToList();
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
                                DataField.Number(DataFields.NumberOfPIDs, 88, 10, false),
                                DataField.Volatile(DataFields.DataFields, 98, false)
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
            DataFields
        }
    }
}
