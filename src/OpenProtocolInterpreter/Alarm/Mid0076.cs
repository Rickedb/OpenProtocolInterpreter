using System;
using System.Collections.Generic;

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

        [BooleanDataFieldDefinition(field: 0, revision: 1)]
        public bool AlarmStatus { get; set; }
        [StringDataFieldDefinition(field: 1, revision: 1, Size = 4, PaddingOrientation = PaddingOrientation.LeftPadded)]
        public string ErrorCode { get; set; }
        [BooleanDataFieldDefinition(field: 2, revision: 1)]
        public bool ControllerReadyStatus { get; set; }
        [BooleanDataFieldDefinition(field: 3, revision: 1)]
        public bool ToolReadyStatus { get; set; }
        [TimestampDataFieldDefinition(field: 4, revision: 1)]
        public DateTime Time { get; set; }
        [Int32DataFieldDefinition(field: 5, revision: 3, Index = 57, Size = 1)]
        public ToolHealth ToolHealth { get; set; }

        public Mid0076() : this(DEFAULT_REVISION)
        {

        }

        public Mid0076(Header header) : base(header)
        {
            HandleRevision();
        }

        public Mid0076(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }

        public override string Pack()
        {
            HandleRevision();
            return base.Pack();
        }

        protected override void ProcessDataFields(ReadOnlySpan<char> package)
        {
            HandleRevision();
            base.ProcessDataFields(package);
        }

        private void HandleRevision()
        {
            var errorCodeField = GetField(revision: 1, field: 1);
            errorCodeField.Size = Header.Revision > 1 ? 5 : 4;

            int index = errorCodeField.Index + errorCodeField.Size;
            for (int fieldIndex = errorCodeField.Field + 1; fieldIndex < RevisionsByFields[1].Count; fieldIndex++)
            {
                var field = GetField(revision: 1, field: fieldIndex);
                field.Index = 2 + index;
                index = field.Index + field.Size;
            }
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            AlarmStatus,
            ErrorCode,
            ControllerReadyStatus,
            ToolReadyStatus,
            Time,
            ToolHealth
        }
    }
}
