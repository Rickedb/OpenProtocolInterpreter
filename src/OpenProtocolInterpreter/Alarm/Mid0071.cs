using System;
using System.Collections.Generic;

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

        [StringDataFieldDefinition(field: 0, revision: 1, Size = 4, PaddingOrientation = PaddingOrientation.LeftPadded)]
        public string ErrorCode { get; set; }

        [BooleanDataFieldDefinition(field: 1, revision: 1)]
        public bool ControllerReadyStatus { get; set; }
        [BooleanDataFieldDefinition(field: 2, revision: 1)]
        public bool ToolReadyStatus { get; set; }
        [TimestampDataFieldDefinition(field: 3, revision: 1)]
        public DateTime Time { get; set; }

        [StringDataFieldDefinition(field: 4, revision: 2, Index = 54, Size = 50)] //Always has index 54 due to error code field size change
        public string AlarmText { get; set; }

        public Mid0071() : this(DEFAULT_REVISION)
        {

        }

        public Mid0071(Header header) : base(header)
        {
            HandleRevision();
        }

        public Mid0071(int revision) : this(new Header()
        {
            Revision = revision,
            Mid = MID
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
            var errorCodeField = GetField(revision: 1, field: 0);
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
            ErrorCode,
            ControllerReadyStatus,
            ToolReadyStatus,
            Time,
            //Rev 2
            AlarmText
        }
    }
}
