using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Parameter set selected
    /// <para>
    ///     A new parameter set is selected in the controller.
    ///     The message includes the ID of the parameter set selected as well as the date and time of the
    ///     last change in the parameter set settings. This message is also sent as an immediate response to <see cref="Mid0014"/>
    ///     Parameter set selected subscribe.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0016"/> New parameter set selected acknowledge</para>
    /// </summary>
    public class Mid0015 : Mid, IParameterSet, IController, IAcknowledgeable<Mid0016>
    {
        public const int MID = 15;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        [Int32DataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 3)]
        [Int32DataFieldDefinition(revision: 3, field: 1, Index = 20, Size = 3)]
        public int ParameterSetId { get; set; }

        [TimestampDataFieldDefinition(revision: 1, field: 2, Index = 23, HasPrefix = false)]
        [TimestampDataFieldDefinition(revision: 2, field: 3, Index = 52)]
        [TimestampDataFieldDefinition(revision: 3, field: 3, Index = 52)]
        public DateTime LastChangeInParameterSet { get; set; }

        //Rev 2
        [StringDataFieldDefinition(revision: 2, field: 2, Index = 25, Size = 25)]
        [StringDataFieldDefinition(revision: 3, field: 2, Index = 25, Size = 25)]
        public string ParameterSetName { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 4, Index = 73, Size = 1)]
        [Int32DataFieldDefinition(revision: 3, field: 4, Index = 73, Size = 1)]
        public RotationDirection RotationDirection { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 5, Index = 76, Size = 2)]
        [Int32DataFieldDefinition(revision: 3, field: 5, Index = 76, Size = 2)]
        public int BatchSize { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 6, Index = 80, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(revision: 3, field: 6, Index = 80, Size = 6)]
        public decimal MinTorque { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 7, Index = 88, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(revision: 3, field: 7, Index = 88, Size = 6)]
        public decimal MaxTorque { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 8, Index = 96, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(revision: 3, field: 8, Index = 96, Size = 6)]
        public decimal TorqueFinalTarget { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 9, Index = 104, Size = 5)]
        [Int32DataFieldDefinition(revision: 3, field: 9, Index = 104, Size = 5)]
        public int MinAngle { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 10, Index = 111, Size = 5)]
        [Int32DataFieldDefinition(revision: 3, field: 10, Index = 111, Size = 5)]
        public int MaxAngle { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 11, Index = 118, Size = 5)]
        [Int32DataFieldDefinition(revision: 3, field: 11, Index = 118, Size = 5)]
        public int AngleFinalTarget { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 12, Index = 125, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(revision: 3, field: 12, Index = 125, Size = 6)]
        public decimal FirstTarget { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 13, Index = 133, Size = 6)]
        [TruncatedDecimalDataFieldDefinition(revision: 3, field: 13, Index = 133, Size = 6)]
        public decimal StartFinalAngle { get; set; }

        [Int32DataFieldDefinition(revision: 3, field: 14, Index = 141, Size = 4)]
        public int SelectedIdentifierNumber { get; set; }

        [StringDataFieldDefinition(revision: 3, field: 15, Index = 147, Size = 25)]
        public string JointId { get; set; }

        public Mid0015() : this(DEFAULT_REVISION)
        {

        }

        public Mid0015(Header header) : base(header)
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="revision">Range: 000-002</param>
        public Mid0015(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        protected override string BuildHeader()
        {
            Header.Length = Header.DefaultSize;
            if (RevisionsByFields.Any())
            {
                var fields = DataFieldsByRevision();
                Header.Length += fields.Sum(x => x.TotalSize);
            }

            return Header.ToString();
        }


        public override string Pack()
        {
            var builder = new StringBuilder();
            var fields = DataFieldsByRevision().OrderBy(f => f.Field).ToList();

            builder.Append(BuildHeader());
            builder.Append(Pack(fields));

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
            foreach (var dataField in RevisionsByFields[Header.StandardizedRevision].OrderBy(x => x.Field))
                yield return dataField;
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            ParameterSetId,
            LastChangeInParameterSet,
            //Rev 2
            ParameterSetName,
            RotationDirection,
            BatchSize,
            TorqueMin,
            TorqueMax,
            TorqueFinalTarget,
            AngleMin,
            AngleMax,
            FinalAngleTarget,
            FirstTarget,
            StartFinalAngle,
            SelectedIdentifierNumber,
            JointId
        }
    }
}
