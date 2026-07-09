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

        [Int32DataFieldDefinition(field: 1, revision: 1, Size = 4)]
        public int CellId { get; set; }

        [Int32DataFieldDefinition(field: 2, revision: 1, Size = 2)]
        public int ChannelId { get; set; }

        [StringDataFieldDefinition(field: 3, revision: 1, Size = 25)]
        public string ControllerName { get; set; }

        //Rev 2
        [StringDataFieldDefinition(field: 4, revision: 2, Size = 3)]
        public string SupplierCode { get; set; }

        //Rev 3
        [StringDataFieldDefinition(field: 5, revision: 3, Size = 19)]
        public string OpenProtocolVersion { get; set; }

        [StringDataFieldDefinition(field: 6, revision: 3, Size = 19)]
        public string ControllerSoftwareVersion { get; set; }

        [StringDataFieldDefinition(field: 7, revision: 3, Size = 19)]
        public string ToolSoftwareVersion { get; set; }

        //Rev 4
        [StringDataFieldDefinition(field: 8, revision: 4, Size = 24)]
        public string RBUType { get; set; }

        [StringDataFieldDefinition(field: 9, revision: 4, Size = 10)]
        public string ControllerSerialNumber { get; set; }

        //Rev 5
        [Int32DataFieldDefinition(field: 10, revision: 5, Size = 3)]
        public SystemType SystemType { get; set; }

        /// <summary>
        /// <para>If no subtype exists it will be set to 000</para>
        /// <para>For a Power Focus 4000 and PF 6000 system the valid subtypes are:</para>
        /// <para>001 = a normal tightening system</para>
        /// <para>For a Power MACS 4000 system the valid subtypes are:</para>
        /// <para>001 = a normal tightening system </para>
        /// <para>002 = a system running presses instead of spindles.</para>
        /// </summary>

        [Int32DataFieldDefinition(field: 11, revision: 5, Size = 3)]
        public SystemSubType SystemSubType { get; set; }

        //Rev 6
        [BooleanDataFieldDefinition(field: 12, revision: 6)]
        public bool SequenceNumberSupport { get; set; }

        [BooleanDataFieldDefinition(field: 13, revision: 6)]
        public bool LinkingHandlingSupport { get; set; }

        /// <summary>
        /// <para>Station ID for PF6000</para>
        /// <para>Cell ID for PF4000</para>
        /// </summary>
        [Int64DataFieldDefinition(field: 14, revision: 6, Size = 10)]
        public long StationCellId { get; set; }

        /// <summary>
        /// <para>Station ID for PF6000</para>
        /// <para>Cell ID for PF4000</para>
        /// </summary>
        [StringDataFieldDefinition(field: 15, revision: 6, Size = 25)]
        public string StationCellName { get; set; }

        [StringDataFieldDefinition(field: 16, revision: 6, Size = 1)]
        public string ClientId { get; set; }

        //Rev 7
        /// <summary>
        /// <para>False = Use Keep alive (Keep alive is mandatory)</para>
        /// <para>True = Ignore Keep alive (Keep alive is optional)</para>
        /// </summary>
        [BooleanDataFieldDefinition(field: 17, revision: 7)]
        public bool OptionalKeepAlive { get; set; }

        [BooleanDataFieldDefinition(field: 18, revision: 8)]
        public bool OptionalToolLockAtDisconnection { get; set; }

        [DecimalDataFieldDefinition(field: 19, revision: 8, Size = 1)]
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

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            //Rev 1
            CellId,
            ChannelId,
            ControllerName,
            //Rev 2
            SupplierCode,
            //Rev 3
            OpenProtocolVersion,
            ControllerSoftwareVersion,
            ToolSoftwareVersion,
            //Rev 4
            RBUType,
            ControllerSerialNumber,
            //Rev 5
            SystemType,
            SystemSubtype,
            //Rev 6
            SequenceNumberSupport,
            LinkingHandlingSupport,
            StationCellId,
            StationCellName,
            ClientId,
            //Rev 7
            OptionalKeepAlive,
            //Rev 8
            OptionalToolLockAtDisconnection,
            OptionalEarlyLock
        }
    }
}
