using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Parameter set data upload reply
    /// <para>Upload of parameter set data reply.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0013 : Mid, IParameterSet, IController
    {
        public const int MID = 13;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 3)]
        public int ParameterSetId { get; set; }
        [StringDataFieldDefinition(revision: 1, field: 2, Index = 25, Size = 25)]
        public string ParameterSetName { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 3, Index = 52, Size = 1)]
        public RotationDirection RotationDirection { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 4, Index = 55, Size = 2)]
        public int BatchSize { get; set; }
        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 5, Index = 59, Size = 6)]
        public decimal MinTorque { get; set; }
        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 6, Index = 67, Size = 6)]
        public decimal MaxTorque { get; set; }
        [TruncatedDecimalDataFieldDefinition(revision: 1, field: 7, Index = 75, Size = 6)]
        public decimal TorqueFinalTarget { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 8, Index = 83, Size = 5)]
        public int MinAngle { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 9, Index = 90, Size = 5)]
        public int MaxAngle { get; set; }
        [Int32DataFieldDefinition(revision: 1, field: 10, Index = 97, Size = 5)]
        public int AngleFinalTarget { get; set; }
        //Rev 2
        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 1, Index = 104, Size = 6)]
        public decimal FirstTarget { get; set; }
        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 2, Index = 112, Size = 6)]
        public decimal StartFinalAngle { get; set; }
        //Rev 5
        [TimestampDataFieldDefinition(revision: 5, field: 1, Index = 120)]
        public DateTime LastChangeInParameterSet { get; set; }

        public Mid0013() : this(DEFAULT_REVISION)
        {

        }

        public Mid0013(Header header) : base(header)
        {

        }

        public Mid0013(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            ParameterSetId,
            ParameterSetName,
            RotationDirection,
            BatchSize,
            MinTorque,
            MaxTorque,
            TorqueFinalTarget,
            MinAngle,
            MaxAngle,
            AngleFinalTarget,
            //Rev 2
            FirstTarget,
            StartFinalTarget,
            //Rev 5
            LastChangeInParameterSet
        }
    }
}
