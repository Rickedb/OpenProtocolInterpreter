using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// Last PowerMACS tightening result Station data
    /// <para>
    ///    This MID contains the station part and some of the Bolt data of the last result data. After this message
    ///    has been sent the integrator selects if it also wants to have the Bolt and step data.If this data is
    ///    requested, then the integrator sends the message <see cref="Mid0108"/> Last PowerMACS tightening result data
    ///    acknowledge, with the parameter Bolt Data set to TRUE. If only the station data is wanted the
    ///    parameter Bolt Data is set to FALSE.
    /// </para>
    /// <para>
    ///    This telegram is also used for Power MACS systems running a Press. The layout of the telegram is
    ///    exactly the same but some of the fields have slightly different definitions. The fields for Torque are
    ///    used for Force values and the fields for Angle are used for Stroke values. Press systems also use
    ///    different identifiers for the optional data on bolt and step level. A press system always use revision 4
    ///    or higher of the telegram
    /// </para>
    /// <para>
    ///    Note: All values that are undefined in the results will be sent as all spaces (ASCII 0x20). This will for
    ///    instance happen with the Torque Status if no measuring value for Bolt T was available for the
    ///    tightening.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0108"/> Last Power MACS tightening result data acknowledge</para>
    /// </summary>
    public class Mid0106 : Mid, IPowerMACS, IController, IAcknowledgeable<Mid0108>
    {
        public const int MID = 106;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 2)]
        public int TotalNumberOfMessages { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 24, Size = 2)]
        public int MessageNumber { get; set; }

        [Int64DataFieldDefinition(revision: 1, field: 3, Index = 28, Size = 10)]
        public long DataNumberSystem { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 4, Index = 40, Size = 2)]
        public int StationNumber { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 5, Index = 44, Size = 20)]
        public string StationName { get; set; }

        [TimestampDataFieldDefinition(revision: 1, field: 6, Index = 66)]
        public DateTime Time { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 7, Index = 87, Size = 2)]
        public int ModeNumber { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 8, Index = 91, Size = 20)]
        public string ModeName { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 9, Index = 113)]
        public bool SimpleStatus { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 10, Index = 116, Size = 1)]
        public PowerMacsStatus PMStatus { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 11, Index = 119, Size = 40)]
        public string WpId { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 12, Index = 161, Size = 2)]
        public int NumberOfBolts { get; set; }

        [BoltDataCollectionDefinition(revision: 1, field: 13, Index = 165, HasPrefix = false)]
        public List<BoltData> BoltsData { get; set; }

        //Total Special values has a weird pattern of being attached to the list of special values instead of being a separate field.
        //So we do process is in a separate way with special values and set its value and have to do it together with list because each special value
        //has a dynamic size, due to that, we cannot make the same processing as Bolt data list that has fixed length of 67 bytes for each bolt data.
        public int TotalSpecialValues { get; set; }

        [SpecialValueCollectionDefinition(revision: 1, field: 23, Index = 0, Size = 67)]
        public List<SpecialValue> SpecialValues { get; set; }

        [Int32DataFieldDefinition(revision: 4, field: 24, Index = 0, Size = 3)]
        public SystemSubType SystemSubType { get; set; }

        public Mid0106() : this(DEFAULT_REVISION)
        {

        }

        public Mid0106(Header header) : base(header)
        {
            BoltsData ??= [];
            SpecialValues ??= [];
        }

        public Mid0106(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
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
            NumberOfBolts = BoltsData.Count;
            TotalSpecialValues = SpecialValues.Count;
            GetField(nameof(BoltsData)).Size = NumberOfBolts * 67;
            GetField(nameof(SpecialValues)).Size = 2 + SpecialValues.Sum(x => x.TotalFieldLength);
            return base.Pack();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 23)
            {
                if (Header.Revision > 3)
                    dataField.Size = Header.Length - GetField(revision: 4, field: 4).TotalSize - 2;
                else
                    dataField.Size = Header.Length - dataField.Index - 2;

                base.ProcessDataField(dataField, package);
                TotalSpecialValues = SpecialValues.Count;
                return;
            }

            if (dataField.Field == 13)
            {
                dataField.Size = NumberOfBolts * 67;
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
