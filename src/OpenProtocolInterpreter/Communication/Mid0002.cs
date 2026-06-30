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

        [Int32DataFieldDefinition(id: 0, revision: 1, Size = 4)]
        public int CellId { get; set; }

        [Int32DataFieldDefinition(id: 1, revision: 1, Size = 2)]
        public int ChannelId { get; set; }

        [StringDataFieldDefinition(id: 2, revision: 1, Size = 25)]
        public string ControllerName { get; set; }

        //Rev 2
        [StringDataFieldDefinition(id: 3, revision: 2, Size = 3)]
        public string SupplierCode { get; set; }

        //Rev 3
        [StringDataFieldDefinition(id: 4, revision: 3, Size = 19)]
        public string OpenProtocolVersion { get; set; }

        [StringDataFieldDefinition(id: 5, revision: 3, Size = 19)]
        public string ControllerSoftwareVersion { get; set; }

        [StringDataFieldDefinition(id: 6, revision: 3, Size = 19)]
        public string ToolSoftwareVersion { get; set; }

        //Rev 4
        [StringDataFieldDefinition(id: 7, revision: 4, Size = 24)]
        public string RBUType { get; set; }

        [StringDataFieldDefinition(id: 8, revision: 4, Size = 10)]
        public string ControllerSerialNumber { get; set; }

        //Rev 5 
        [Int32DataFieldDefinition(id: 9, revision: 5, Size = 3)]
        public SystemType SystemType { get; set; }

        /// <summary>
        /// <para>If no subtype exists it will be set to 000</para>
        /// <para>For a Power Focus 4000 and PF 6000 system the valid subtypes are:</para>
        /// <para>001 = a normal tightening system</para>
        /// <para>For a Power MACS 4000 system the valid subtypes are:</para>
        /// <para>001 = a normal tightening system </para>
        /// <para>002 = a system running presses instead of spindles.</para>
        /// </summary>

        [Int32DataFieldDefinition(id: 10, revision: 5, Size = 3)]
        public SystemSubType SystemSubType { get; set; }

        //Rev 6
        [BooleanDataFieldDefinition(id: 11, revision: 6)]
        public bool SequenceNumberSupport { get; set; }

        [BooleanDataFieldDefinition(id: 12, revision: 6)]
        public bool LinkingHandlingSupport { get; set; }

        /// <summary>
        /// <para>Station ID for PF6000</para>
        /// <para>Cell ID for PF4000</para>
        /// </summary>
        [Int64DataFieldDefinition(id: 13, revision: 6, Size = 10)]
        public long StationCellId { get; set; }

        /// <summary>
        /// <para>Station ID for PF6000</para>
        /// <para>Cell ID for PF4000</para>
        /// </summary>
        [StringDataFieldDefinition(id: 14, revision: 6, Size = 25)]
        public string StationCellName { get; set; }

        [StringDataFieldDefinition(id: 15, revision: 6, Size = 1)]
        public string ClientId { get; set; }

        //Rev 7
        /// <summary>
        /// <para>False = Use Keep alive (Keep alive is mandatory)</para> 
        /// <para>True = Ignore Keep alive (Keep alive is optional)</para>
        /// </summary>
        [BooleanDataFieldDefinition(id: 16, revision: 7)]
        public bool OptionalKeepAlive { get; set; }

        [BooleanDataFieldDefinition(id: 17, revision: 8)]
        public bool OptionalToolLockAtDisconnection { get; set; }

        [DecimalDataFieldDefinition(id: 18, revision: 8, Size = 1)]
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

        // protected override Dictionary<int, List<DataField>> RegisterDatafields()
        // {
        //     return new Dictionary<int, List<DataField>>()
        //     {
        //         {
        //             1, new List<DataField>()
        //                     {
        //                         DataField.Number(DataFields.CellId, 20, 4),
        //                         DataField.Number(DataFields.ChannelId, 26, 2),
        //                         DataField.String(DataFields.ControllerName, 30, 25)
        //                     }
        //         },
        //         {
        //             2, new  List<DataField>()
        //                     {
        //                         DataField.String(DataFields.SupplierCode, 57, 3)
        //                     }
        //         },
        //         {
        //             3, new  List<DataField>()
        //                     {
        //                         DataField.String(DataFields.OpenProtocolVersion, 62, 19),
        //                         DataField.String(DataFields.ControllerSoftwareVersion, 83, 19),
        //                         DataField.String(DataFields.ToolSoftwareVersion, 104, 19)
        //                     }
        //         },
        //         {
        //             4, new  List<DataField>()
        //                     {
        //                         DataField.String(DataFields.RBUType, 125, 24),
        //                         DataField.String(DataFields.ControllerSerialNumber, 151, 10)
        //                     }
        //         },
        //         {
        //             5, new  List<DataField>()
        //                     {
        //                         DataField.Number(DataFields.SystemType, 163, 3),
        //                         DataField.Number(DataFields.SystemSubtype, 168, 3)
        //                     }
        //         },
        //         {
        //             6, new  List<DataField>()
        //                     {
        //                         DataField.Boolean(DataFields.SequenceNumberSupport, 173),
        //                         DataField.Boolean(DataFields.LinkingHandlingSupport, 176),
        //                         DataField.Number(DataFields.StationCellId, 179, 10),
        //                         DataField.String(DataFields.StationCellName, 191, 25),
        //                         DataField.String(DataFields.ClientId, 218, 1)
        //                     }
        //         },
        //         {
        //             7, new  List<DataField>()
        //                     {
        //                         DataField.Boolean(DataFields.OptionalKeepAlive, 221)
        //                     }
        //         },
        //         {
        //             8, new List<DataField>()
        //                     {
        //                         DataField.Boolean(DataFields.OptionalToolLockAtDisconnection, 224),
        //                         DataField.Number(DataFields.OptionalEarlyLock, 227, 4)
        //                     }
        //         }
        //     };
        // }

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
