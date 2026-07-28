using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Tool data upload reply
    /// <para>Upload of tool data from the controller.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0041 : Mid, ITool, IController
    {
        public const int MID = 41;

        [StringDataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 14)]
        public string ToolSerialNumber { get; set; }

        [Int64DataFieldDefinition(revision: 1, field: 2, Index = 36, Size = 10)]
        public long ToolNumberOfTightenings { get; set; }

        [TimestampDataFieldDefinition(revision: 1, field: 3, Index = 48)]
        public DateTime LastCalibrationDate { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 4, Index = 69, Size = 10)]
        public string ControllerSerialNumber { get; set; }

        //Rev 2
        [TruncatedDecimalDataFieldDefinition(revision: 2, field: 5, Index = 81, Size = 6)]
        public decimal CalibrationValue { get; set; }

        [TimestampDataFieldDefinition(revision: 2, field: 6, Index = 89)]
        public DateTime LastServiceDate { get; set; }

        [Int64DataFieldDefinition(revision: 2, field: 7, Index = 110, Size = 10)]
        public long TighteningsSinceService { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 8, Index = 122, Size = 2)]
        public ToolType ToolType { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 9, Index = 126, Size = 2)]
        public int MotorSize { get; set; }

        [OpenEndDataDefinition(revision: 2, field: 10, Index = 130, Size = 3)]
        public OpenEndData OpenEndData { get; set; }

        [StringDataFieldDefinition(revision: 2, field: 11, Index = 135, Size = 19)]
        public string ControllerSoftwareVersion { get; set; }

        //Rev 3
        [TruncatedDecimalDataFieldDefinition(revision: 3, field: 12, Index = 156, Size = 6)]
        public decimal ToolMaxTorque { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 3, field: 13, Index = 164, Size = 6)]
        public decimal GearRatio { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 3, field: 14, Index = 172, Size = 6)]
        public decimal ToolFullSpeed { get; set; }

        //Rev 4
        [Int32DataFieldDefinition(revision: 4, field: 15, Index = 180, Size = 2)]
        public PrimaryTool PrimaryTool { get; set; }

        //Rev 5
        [StringDataFieldDefinition(revision: 5, field: 16, Index = 184, Size = 12)]
        public string ToolModel { get; set; }

        //Rev 6
        /// <summary>
        /// The number of the tool. It is the same number as the tool numbers sent in <see cref="Mid0701"/> Tool List Upload.
        /// <para>In systems with only 1 tool the number sent will always be 0001</para>
        /// </summary>
        [Int32DataFieldDefinition(revision: 6, field: 17, Index = 198, Size = 4)]
        public int ToolNumber { get; set; }

        [StringDataFieldDefinition(revision: 6, field: 18, Index = 204, Size = 30)]
        public string ToolArticleNumber { get; set; }

        //Rev 7
        [TruncatedDecimalDataFieldDefinition(revision: 7, field: 19, Index = 236, Size = 6)]
        public decimal RundownMinSpeed { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 7, field: 20, Index = 244, Size = 6)]
        public decimal DownshiftMaxSpeed { get; set; }

        [TruncatedDecimalDataFieldDefinition(revision: 7, field: 21, Index = 252, Size = 6)]
        public decimal DownshiftMinSpeed { get; set; }

        public Mid0041() : this(DEFAULT_REVISION)
        {

        }

        public Mid0041(Header header) : base(header)
        {
        }

        public Mid0041(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }
    }
}
