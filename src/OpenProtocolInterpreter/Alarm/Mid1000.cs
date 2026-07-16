using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm
    /// <para>An alarm has appeared in the controller. The current alarm is uploaded from the controller to the integrator.
    /// This MID replace the old alarm MID 0071.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0071"/> Alarm status acknowledge</para>
    /// </summary>
    public class Mid1000 : Mid, IAlarm, IController, IAcknowledgeable<Mid1001>
    {
        public const int MID = 1000;

        [StringDataFieldDefinition(field: 0, revision: 1, Size = 5, HasPrefix = false, PaddingOrientation = PaddingOrientation.LeftPadded)]
        public string AlarmCode { get; set; }
        [TimestampDataFieldDefinition(field: 1, revision: 1, HasPrefix = false)]
        public DateTime Time { get; set; }
        [Int32DataFieldDefinition(field: 2, revision: 1, Size = 3, HasPrefix = false)]
        public int NumberOfDataFields { get; set; }
        [VariableDataFieldCollectionDefinition(field: 3, revision: 1, HasPrefix = false)]
        public List<VariableDataField> AlarmDataFields { get; set; }

        public Mid1000() : this(DEFAULT_REVISION)
        {

        }

        public Mid1000(Header header) : base(header)
        {
            AlarmDataFields = [];
        }

        public Mid1000(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }

        public override string Pack()
        {
            NumberOfDataFields = AlarmDataFields?.Count ?? 0; //Enforce list size even if modified
            GetField(revision: 1, field: 3).Size = AlarmDataFields?.Sum(x => x.TotalSize) ?? 0; //Enforce size of variable data fields
            return base.Pack();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 3) //AlarmDataFields
            {
                dataField.Size = Header.Length - dataField.Index;
            }
            base.ProcessDataField(dataField, package);
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            AlarmCode,
            Time,
            NumberOfDataFields,
            EachAlarmDataField
        }
    }
}
