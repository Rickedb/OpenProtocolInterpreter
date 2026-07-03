using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Alarm
{
    /// <summary>
    /// Alarm acknowledged on controller
    /// <para>The message is sent by the controller to inform the integrator that the current alarm has been acknowledged.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0075"/> Alarm acknowledged on controller acknowledge</para>
    /// </summary>
    public class Mid0074 : Mid, IAlarm, IController, IAcknowledgeable<Mid0075>
    {
        public const int MID = 74;

        [StringDataFieldDefinition(field: 0, revision: 1, Size = 4, HasPrefix = false, PaddingOrientation = PaddingOrientation.LeftPadded)]
        public string ErrorCode { get; set; }

        public Mid0074() : this(DEFAULT_REVISION)
        {

        }

        public Mid0074(Header header) : base(header)
        {

        }

        public Mid0074(int revision) : base(MID, revision)
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
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            ErrorCode
        }
    }
}
