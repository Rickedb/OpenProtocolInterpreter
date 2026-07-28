using System;
using System.Collections.Generic;
using System.Text;

namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm status
    /// <para>The alarm status is sent after an accepted subscription of the controller alarms.
    /// This message is used to inform the integrator that an alarm is active on the controller at subscription time.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0077"/> Alarm status acknowledge</para>
    /// </summary>
    public class Mid0076 : Mid, IAlarm, IController, IAcknowledgeable<Mid0077>
    {
        public const int MID = 76;

        [BooleanDataFieldDefinition(revision: 1, field: 1, Index = 20)]
        [BooleanDataFieldDefinition(revision: 2, field: 1, Index = 20)]
        [BooleanDataFieldDefinition(revision: 3, field: 1, Index = 20)]
        public bool AlarmStatus { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 2, Index = 23, Size = 4, PaddingOrientation = PaddingOrientation.LeftPadded)]
        [StringDataFieldDefinition(revision: 2, field: 2, Index = 23, Size = 5, PaddingOrientation = PaddingOrientation.LeftPadded)]
        [StringDataFieldDefinition(revision: 3, field: 2, Index = 23, Size = 5, PaddingOrientation = PaddingOrientation.LeftPadded)]
        public string ErrorCode { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 3, Index = 29)]
        [BooleanDataFieldDefinition(revision: 2, field: 3, Index = 30)]
        [BooleanDataFieldDefinition(revision: 3, field: 3, Index = 30)]
        public bool ControllerReadyStatus { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 4, Index = 32)]
        [BooleanDataFieldDefinition(revision: 2, field: 4, Index = 33)]
        [BooleanDataFieldDefinition(revision: 3, field: 4, Index = 33)]
        public bool ToolReadyStatus { get; set; }

        [TimestampDataFieldDefinition(revision: 1, field: 5, Index = 35)]
        [TimestampDataFieldDefinition(revision: 2, field: 5, Index = 36)]
        [TimestampDataFieldDefinition(revision: 3, field: 5, Index = 36)]
        public DateTime Time { get; set; }

        [Int32DataFieldDefinition(revision: 3, field: 6, Index = 57, Size = 1)]
        public ToolHealth ToolHealth { get; set; }

        public Mid0076() : this(DEFAULT_REVISION)
        {

        }

        public Mid0076(Header header) : base(header)
        {

        }

        public Mid0076(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }

        protected override string BuildHeader()
        {
            Header.Length = Header.DefaultSize;
            foreach (var field in RevisionsByFields[Header.StandardizedRevision])
            {
                Header.Length += field.TotalSize;
            }

            return Header.ToString();
        }

        public override string Pack()
        {
            var header = BuildHeader();
            var builder = new StringBuilder(Header.Length);
            builder.Append(header);
            builder.Append(base.Pack(DataFieldsByRevision()));
            return builder.ToString();
        }

        protected override void ProcessDataFields(ReadOnlySpan<char> package)
        {
            foreach (var field in DataFieldsByRevision())
            {
                ProcessDataField(field, package);
            }
        }

        private IEnumerable<DataField> DataFieldsByRevision()
        {
            foreach (var field in RevisionsByFields[Header.StandardizedRevision])
                yield return field;
        }
    }
}
