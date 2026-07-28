using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// Last Power MACS tightening result Bolt data
    /// <para>
    ///    This message contains the cycle data for one Bolt, both Bolt data and step data. It is only sent if
    ///    the acknowledgement of the message <see cref="Mid0106"/> Last PowerMACS tightening result station data had the parameter
    ///    Bolt Data set to TRUE. The next Bolt data is sent if the acknowledgement has the parameter Bolt Data set to TRUE.
    ///    This telegram is also used for Power MACS systems running a Press.The layout of the telegram is exactly the
    ///    same but some of the fields have slightly different definitions. The fields for Torque are used for Force values
    ///    and the fields for Angle are used for Stroke values. Press systems also use different identifiers for the optional
    ///    data on bolt and step level. Press systems always use revision 4 or higher of the telegram.Values in the fixed part
    ///    that are undefined in the results will be sent as all spaces (ASCII 0x20).
    /// </para>
    /// <para>
    ///    This can happen with the Customer Error Code if this function is not activated.
    /// </para>
    /// <para>
    ///    Note 2: The Bolt results and step results are only sent when the value exists in the result. This means,
    ///    for example, that if no high limit is programmed for Peak T, then the value Peak T + will not be sent
    ///    even if limits for Peak T are defined in the reporter.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0108"/> Last PowerMACS tightening result data acknowledge</para>
    /// </summary>
    public class Mid0107 : Mid, IPowerMACS, IController, IAcknowledgeable<Mid0108>
    {
        public const int MID = 107;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 2)]
        public int TotalNumberOfMessages { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 24, Size = 2)]
        public int MessageNumber { get; set; }

        [Int64DataFieldDefinition(revision: 1, field: 3, Index = 28, Size = 10)]
        public long DataNumberSystem { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 4, Index = 40, Size = 2)]
        public int StationNumber { get; set; }

        [TimestampDataFieldDefinition(revision: 1, field: 5, Index = 44)]
        public DateTime Time { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 6, Index = 65, Size = 4)]
        public int BoltNumber { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 7, Index = 71, Size = 20)]
        public string BoltName { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 8, Index = 93, Size = 20)]
        public string ProgramName { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 9, Index = 115, Size = 1)]
        public PowerMacsStatus PowerMacsStatus { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 10, Index = 118, Size = 50)]
        public string Errors { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 11, Index = 170, Size = 4)]
        public string CustomerErrorCode { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 12, Index = 176, Size = 2)]
        public int NumberOfBoltResults { get; set; }

        [BoltResultCollectionDefinition(revision: 1, field: 12, Index = 180, Size = 0, HasPrefix = false)]
        public List<BoltResult> BoltResults { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 13, Index = 0, Size = 3)]
        public int NumberOfStepResults { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 14, Index = 0, Size = 1)]
        public bool AllStepDataSent { get; set; }

        [StepResultCollectionDefinition(revision: 1, field: 14, Index = 0, Size = 0, HasPrefix = false)]
        public List<StepResult> StepResults { get; set; }

        //Total Special values has a weird pattern of being attached to the list of special values instead of being a separate field.
        //So we do process is in a separate way with special values and set its value and have to do it together with list because each special value
        //has a dynamic size, due to that, we cannot make the same processing as Bolt result list that has fixed length of 31 bytes for each bolt result.
        public int NumberOfSpecialValues { get; set; }

        [SpecialValueCollectionDefinition(revision: 1, field: 15, Index = 0, UseStepNumber = true)]
        public List<SpecialValue> SpecialValues { get; set; }

        [Int32DataFieldDefinition(revision: 4, field: 16, Index = 0, Size = 3)]
        public SystemSubType SystemSubType { get; set; }

        public Mid0107() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0107(Header header) : base(header)
        {
            BoltResults ??= [];
            StepResults ??= [];
            SpecialValues ??= [];
        }

        protected override string BuildHeader()
        {
            Header.Length = Header.DefaultSize;
            var fields = DataFieldsByRevision();
            Header.Length += fields.Sum(x => x.TotalSize);
            return Header.ToString();
        }

        public override string Pack()
        {
            NumberOfBoltResults = BoltResults.Count;
            NumberOfStepResults = StepResults.Count;
            NumberOfSpecialValues = SpecialValues.Count;

            GetField<List<BoltResult>>(revision: 1, field: 12).Size = NumberOfBoltResults * 29;
            GetField<List<StepResult>>(revision: 1, field: 14).Size = NumberOfStepResults * 31;
            GetField<List<SpecialValue>>(revision: 1, field: 15).Size = 2 + SpecialValues.Sum(x => x.TotalFieldLength);

            var header = BuildHeader();
            var builder = new StringBuilder(Header.Length);
            builder.Append(header);

            var fields = DataFieldsByRevision();
            builder.Append(base.Pack(fields));
            return builder.ToString();
        }

        protected override void ProcessDataFields(ReadOnlySpan<char> package)
        {
            foreach (var field in DataFieldsByRevision())
                ProcessDataField(field, package);
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            switch (dataField.Field)
            {
                case 12 when dataField is DataField<List<BoltResult>>: //BoltResults
                    dataField.Size = NumberOfBoltResults * 29;
                    break;
                case 14 when dataField is DataField<List<StepResult>>: //StepResults
                    dataField.Size = NumberOfStepResults * 31;
                    break;
                case 15 when dataField is DataField<List<SpecialValue>>: //SpecialValues
                    if (Header.Revision > 3)
                        dataField.Size = Header.Length - GetField(revision: 4, field: 16).TotalSize - 2;
                    else
                        dataField.Size = Header.Length - dataField.Index - 2;

                    base.ProcessDataField(dataField, package);
                    NumberOfSpecialValues = SpecialValues.Count;
                    return;
            }

            base.ProcessDataField(dataField, package);
        }

        private IEnumerable<DataField> DataFieldsByRevision()
        {
            var previousField = default(DataField);
            for (int i = 1; i <= Header.StandardizedRevision; i++)
            {
                foreach (var dataField in RevisionsByFields[i])
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
    }
}
