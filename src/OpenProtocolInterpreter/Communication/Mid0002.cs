using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// Application Communication start acknowledge
    /// <para>
    ///     When accepting the communication start the controller sends as reply,
    ///     a Communication start acknowledge. This message contains some basic information about the
    ///     controller, such as cell ID, channel ID, and name.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0002 : Mid, ICommunication, IController
    {
        public const int MID = 2;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 4)]
        public int CellId { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 26, Size = 2)]
        public int ChannelId { get; set; }

        [StringDataFieldDefinition(revision: 1, field: 3, Index = 30, Size = 25)]
        public string ControllerName { get; set; }

        //Rev 2
        [StringDataFieldDefinition(revision: 2, field: 4, Index = 57, Size = 3)]
        public string SupplierCode { get; set; }

        //Rev 3
        [StringDataFieldDefinition(revision: 3, field: 5, Index = 62, Size = 19)]
        public string OpenProtocolVersion { get; set; }

        [StringDataFieldDefinition(revision: 3, field: 6, Index = 83, Size = 19)]
        public string ControllerSoftwareVersion { get; set; }

        [StringDataFieldDefinition(revision: 3, field: 7, Index = 104, Size = 19)]
        public string ToolSoftwareVersion { get; set; }

        //Rev 4
        [StringDataFieldDefinition(revision: 4, field: 8, Index = 125, Size = 24)]
        public string RBUType { get; set; }

        [StringDataFieldDefinition(revision: 4, field: 9, Index = 151, Size = 10)]
        public string ControllerSerialNumber { get; set; }

        //Rev 5
        [Int32DataFieldDefinition(revision: 5, field: 10, Index = 163, Size = 3)]
        public SystemType SystemType { get; set; }

        /// <summary>
        /// <para>If no subtype exists it will be set to 000</para>
        /// <para>For a Power Focus 4000 and PF 6000 system the valid subtypes are:</para>
        /// <para>001 = a normal tightening system</para>
        /// <para>For a Power MACS 4000 system the valid subtypes are:</para>
        /// <para>001 = a normal tightening system </para>
        /// <para>002 = a system running presses instead of spindles.</para>
        /// </summary>

        [Int32DataFieldDefinition(revision: 5, field: 11, Index = 168, Size = 3)]
        public SystemSubType SystemSubType { get; set; }

        //Rev 6
        [BooleanDataFieldDefinition(revision: 6, field: 12, Index = 173)]
        public bool SequenceNumberSupport { get; set; }

        [BooleanDataFieldDefinition(revision: 6, field: 13, Index = 176)]
        public bool LinkingHandlingSupport { get; set; }

        /// <summary>
        /// <para>Station ID for PF6000</para>
        /// <para>Cell ID for PF4000</para>
        /// </summary>
        [Int64DataFieldDefinition(revision: 6, field: 14, Index = 179, Size = 10)]
        public long StationCellId { get; set; }

        /// <summary>
        /// <para>Station ID for PF6000</para>
        /// <para>Cell ID for PF4000</para>
        /// </summary>
        [StringDataFieldDefinition(revision: 6, field: 15, Index = 191, Size = 25)]
        public string StationCellName { get; set; }

        [StringDataFieldDefinition(revision: 6, field: 16, Index = 218, Size = 1)]
        public string ClientId { get; set; }

        //Rev 7
        /// <summary>
        /// <para>False = Use Keep alive (Keep alive is mandatory)</para>
        /// <para>True = Ignore Keep alive (Keep alive is optional)</para>
        /// </summary>
        [BooleanDataFieldDefinition(revision: 7, field: 17, Index = 221)]
        public bool OptionalKeepAlive { get; set; }

        [BooleanDataFieldDefinition(revision: 8, field: 18, Index = 224)]
        public bool OptionalToolLockAtDisconnection { get; set; }

        [DecimalDataFieldDefinition(revision: 8, field: 19, Index = 227, Size = 1)]
        public decimal OptionalEarlyLock { get; set; }

        public Mid0002() : this(DEFAULT_REVISION)
        {

        }

        public Mid0002(Header header) : base(header)
        {

        }

        public Mid0002(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }
    }
}
