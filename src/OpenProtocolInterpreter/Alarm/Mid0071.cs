using System;
using System.Collections.Generic;
using System.Text;

namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm
    /// <para>An alarm has appeared in the controller. The current alarm is uploaded from the controller to the integrator.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0072"/> Alarm acknowledge</para>
    /// </summary>
    public class Mid0071 : Mid, IAlarm, IController, IAcknowledgeable<Mid0072>
    {
        public const int MID = 71;

        [StringDataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 4, PaddingOrientation = PaddingOrientation.LeftPadded)]
        [StringDataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 5, PaddingOrientation = PaddingOrientation.LeftPadded)]
        [StringDataFieldDefinition(revision: 3, field: 1, Index = 20, Size = 5, PaddingOrientation = PaddingOrientation.LeftPadded)]
        public string ErrorCode { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 2, Index = 26)]
        [BooleanDataFieldDefinition(revision: 2, field: 2, Index = 27)]
        [BooleanDataFieldDefinition(revision: 3, field: 2, Index = 27)]
        public bool ControllerReadyStatus { get; set; }

        [BooleanDataFieldDefinition(revision: 1, field: 3, Index = 29)]
        [BooleanDataFieldDefinition(revision: 2, field: 3, Index = 30)]
        [BooleanDataFieldDefinition(revision: 3, field: 3, Index = 30)]
        public bool ToolReadyStatus { get; set; }

        [TimestampDataFieldDefinition(revision: 1, field: 4, Index = 32)]
        [TimestampDataFieldDefinition(revision: 2, field: 4, Index = 33)]
        [TimestampDataFieldDefinition(revision: 3, field: 4, Index = 33)]
        public DateTime Time { get; set; }

        [Int32DataFieldDefinition(revision: 3, field: 5, Index = 54, Size = 1)]
        public ToolHealth ToolHealth { get; set; }

        [StringDataFieldDefinition(revision: 3, field: 6, Index = 57, Size = 50)]
        public string AlarmText { get; set; }

        public Mid0071() : this(DEFAULT_REVISION)
        {

        }

        public Mid0071(Header header) : base(header)
        {
        }

        public Mid0071(int revision) : this(new Header()
        {
            Revision = revision,
            Mid = MID
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
