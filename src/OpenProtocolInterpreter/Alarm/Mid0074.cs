using System;
using System.Collections.Generic;
using System.Text;

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

        [StringDataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 4, HasPrefix = false, PaddingOrientation = PaddingOrientation.LeftPadded)]
        [StringDataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 5, HasPrefix = false, PaddingOrientation = PaddingOrientation.LeftPadded)]
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
