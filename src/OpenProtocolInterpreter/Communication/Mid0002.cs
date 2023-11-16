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

        public int CellId
        {
            get => GetField(1, DataFields.CellId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.CellId).SetValue(OpenProtocolConvert.ToString, value);
        }

        public int ChannelId
        {
            get => GetField(1, DataFields.ChannelId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.ChannelId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string ControllerName
        {
            get => GetField(1, DataFields.ControllerName).Value;
            set => GetField(1, DataFields.ControllerName).SetValue(value);
        }

        //Rev 2
        public string SupplierCode
        {
            get => GetField(2, DataFields.SupplierCode).Value;
            set => GetField(2, DataFields.SupplierCode).SetValue(value);
        }

        //Rev 3
        public string OpenProtocolVersion
        {
            get => GetField(3, DataFields.OpenProtocolVersion).Value;
            set => GetField(3, DataFields.OpenProtocolVersion).SetValue(value);
        }

        public string ControllerSoftwareVersion
        {
            get => GetField(3, DataFields.ControllerSoftwareVersion).Value;
            set => GetField(3, DataFields.ControllerSoftwareVersion).SetValue(value);
        }

        public string ToolSoftwareVersion
        {
            get => GetField(3, DataFields.ToolSoftwareVersion).Value;
            set => GetField(3, DataFields.ToolSoftwareVersion).SetValue(value);
        }

        //Rev 4
        public string RBUType
        {
            get => GetField(4, DataFields.RBUType).Value;
            set => GetField(4, DataFields.RBUType).SetValue(value);
        }

        public string ControllerSerialNumber
        {
            get => GetField(4, DataFields.ControllerSerialNumber).Value;
            set => GetField(4, DataFields.ControllerSerialNumber).SetValue(value);
        }

        //Rev 5 
        public SystemType SystemType
        {
            get => (SystemType)GetField(5, DataFields.SystemType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(5, DataFields.SystemType).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>
        /// <para>If no subtype exists it will be set to 000</para>
        /// <para>For a Power Focus 4000 and PF 6000 system the valid subtypes are:</para>
        /// <para>001 = a normal tightening system</para>
        /// <para>For a Power MACS 4000 system the valid subtypes are:</para>
        /// <para>001 = a normal tightening system </para>
        /// <para>002 = a system running presses instead of spindles.</para>
        /// </summary>
        public SystemSubType SystemSubType
        {
            get => (SystemSubType)GetField(5, DataFields.SystemSubtype).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(5, DataFields.SystemSubtype).SetValue(OpenProtocolConvert.ToString, value);
        }

        //Rev 6
        public bool SequenceNumberSupport
        {
            get => GetField(6, DataFields.SequenceNumberSupport).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(6, DataFields.SequenceNumberSupport).SetValue(OpenProtocolConvert.ToString, value);
        }

        public bool LinkingHandlingSupport
        {
            get => GetField(6, DataFields.LinkingHandlingSupport).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(6, DataFields.LinkingHandlingSupport).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>
        /// <para>Station ID for PF6000</para>
        /// <para>Cell ID for PF4000</para>
        /// </summary>
        public long StationCellId 
        {
            get => GetField(6, DataFields.StationCellId).GetValue(OpenProtocolConvert.ToInt64);
            set => GetField(6, DataFields.StationCellId).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>
        /// <para>Station ID for PF6000</para>
        /// <para>Cell ID for PF4000</para>
        /// </summary>
        public string StationCellName
        {
            get => GetField(6, DataFields.StationCellName).Value;
            set => GetField(6, DataFields.StationCellName).SetValue(value);
        }

        public string ClientId
        {
            get => GetField(6, DataFields.ClientId).Value;
            set => GetField(6, DataFields.ClientId).SetValue(value);
        }

        //Rev 7
        /// <summary>
        /// <para>False = Use Keep alive (Keep alive is mandatory)</para> 
        /// <para>True = Ignore Keep alive (Keep alive is optional)</para>
        /// </summary>
        public bool OptionalKeepAlive 
        {
            get => GetField(7, DataFields.OptionalKeepAlive).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(7, DataFields.OptionalKeepAlive).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0002() : this(DEFAULT_REVISION)
        {

        }

        public Mid0002(Header header) : base(header)
        {

        }

        public Mid0002(int revision) : this(new Header()
        {
            Mid= MID, 
            Revision = revision
        })
        {
            
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Number(DataFields.CellId, 20, 4),
                                DataField.Number(DataFields.ChannelId, 26, 2),
                                DataField.String(DataFields.ControllerName, 30, 25)
                            }
                },
                {
                    2, new  List<DataField>()
                            {
                                DataField.String(DataFields.SupplierCode, 57, 3)
                            }
                },
                {
                    3, new  List<DataField>()
                            {
                                DataField.String(DataFields.OpenProtocolVersion, 62, 19),
                                DataField.String(DataFields.ControllerSoftwareVersion, 83, 19),
                                DataField.String(DataFields.ToolSoftwareVersion, 104, 19)
                            }
                },
                {
                    4, new  List<DataField>()
                            {
                                DataField.String(DataFields.RBUType, 125, 24),
                                DataField.String(DataFields.ControllerSerialNumber, 151, 10)
                            }
                },
                {
                    5, new  List<DataField>()
                            {
                                DataField.Number(DataFields.SystemType, 163, 3),
                                DataField.Number(DataFields.SystemSubtype, 168, 3)
                            }
                },
                {
                    6, new  List<DataField>()
                            {
                                DataField.Boolean(DataFields.SequenceNumberSupport, 173),
                                DataField.Boolean(DataFields.LinkingHandlingSupport, 176),
                                DataField.Number(DataFields.StationCellId, 179, 10),
                                DataField.String(DataFields.StationCellName, 191, 25),
                                DataField.String(DataFields.ClientId, 218, 1)
                            }
                },
                {
                    7, new  List<DataField>()
                            {
                                DataField.Boolean(DataFields.OptionalKeepAlive, 221)
                            }
                }
            };
        }

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
            OptionalKeepAlive
        }
    }
}
