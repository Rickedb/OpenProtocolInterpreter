using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// MID: Application Communication start acknowledge
    /// Description:
    ///     When accepting the communication start the controller sends as reply, 
    ///     a Communication start acknowledge. This message contains some basic information about the
    ///     controller, such as cell ID, channel ID, and name.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0002 : MID, ICommunication
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private const int LAST_REVISION = 6;
        public const int MID = 2;

        public int CellID
        {
            get => RevisionsByFields[1][(int)DataFields.CELL_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.CELL_ID].SetValue(_intConverter.Convert, value);
        }
        public int ChannelId
        {
            get => RevisionsByFields[1][(int)DataFields.CHANNEL_ID].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.CHANNEL_ID].SetValue(_intConverter.Convert, value);
        }
        public string ControllerName
        {
            get => RevisionsByFields[1][(int)DataFields.CONTROLLER_NAME].Value;
            set => RevisionsByFields[1][(int)DataFields.CONTROLLER_NAME].SetValue(value);
        }
        //Rev 2
        public string SupplierCode
        {
            get => RevisionsByFields[2][(int)DataFields.SUPPLIER_CODE].Value;
            set => RevisionsByFields[2][(int)DataFields.SUPPLIER_CODE].SetValue(value);
        }
        //Rev 3
        public string OpenProtocolVersion
        {
            get => RevisionsByFields[3][(int)DataFields.OPEN_PROTOCOL_VERSION].Value;
            set => RevisionsByFields[3][(int)DataFields.OPEN_PROTOCOL_VERSION].SetValue(value);
        }
        public string ControllerSoftwareVersion
        {
            get => RevisionsByFields[3][(int)DataFields.CONTROLLER_SOFTWARE_VERSION].Value;
            set => RevisionsByFields[3][(int)DataFields.CONTROLLER_SOFTWARE_VERSION].SetValue(value);
        }
        public string ToolSoftwareVersion
        {
            get => RevisionsByFields[3][(int)DataFields.TOOL_SOFTWARE_VERSION].Value;
            set => RevisionsByFields[3][(int)DataFields.TOOL_SOFTWARE_VERSION].SetValue(value);
        }
        //Rev 4
        public string RBUType
        {
            get => RevisionsByFields[4][(int)DataFields.RBU_TYPE].Value;
            set => RevisionsByFields[4][(int)DataFields.RBU_TYPE].SetValue(value);
        }
        public string ControllerSerialNumber
        {
            get => RevisionsByFields[4][(int)DataFields.CONTROLLER_SERIAL_NUMBER].Value;
            set => RevisionsByFields[4][(int)DataFields.CONTROLLER_SERIAL_NUMBER].SetValue(value);
        }
        //Rev 5 
        public SystemTypes SystemType
        {
            get => (SystemTypes)RevisionsByFields[5][(int)DataFields.SYSTEM_TYPE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[5][(int)DataFields.SYSTEM_TYPE].SetValue(_intConverter.Convert, (int)value);
        }
        /// <summary>
        /// <para>If no subtype exists it will be set to 000</para>
        /// <para>For a Power Focus 4000 and PF 6000 system the valid subtypes are:</para>
        /// <para>001 = a normal tightening system</para>
        /// <para>For a Power MACS 4000 system the valid subtypes are:</para>
        /// <para>001 = a normal tightening system </para>
        /// <para>002 = a system running presses instead of spindles.</para>
        /// </summary>
        public SystemSubTypes SystemSubType
        {
            get => (SystemSubTypes)RevisionsByFields[5][(int)DataFields.SYSTEM_SUBTYPE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[5][(int)DataFields.SYSTEM_SUBTYPE].SetValue(_intConverter.Convert, (int)value);
        }
        //Rev 6
        public bool SequenceNumberSupport
        {
            get => RevisionsByFields[6][(int)DataFields.SEQUENCE_NUMBER_SUPPORT].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[6][(int)DataFields.SEQUENCE_NUMBER_SUPPORT].SetValue(_boolConverter.Convert, value);
        }
        public bool LinkingHandlingSupport
        {
            get => RevisionsByFields[6][(int)DataFields.LINKING_HANDLING_SUPPORT].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[6][(int)DataFields.LINKING_HANDLING_SUPPORT].SetValue(_boolConverter.Convert, value);
        }

        public MID_0002(int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="cellId">The cell ID is four bytes long specified by four ASCII digits. Range: 0000-9999.</param>
        /// <param name="channelId">The channel ID is two bytes long specified by two ASCII digits. Range: 00-20.</param>
        /// <param name="controllerName">The controller name is 25 bytes long and specified by 25 ASCII characters.</param>
        /// <param name="revision">Revision number (default = 1)</param>
        public MID_0002(int cellId, int channelId, string controllerName, int revision = 1) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
            SetRevision1(cellId, channelId, controllerName);
        }

        /// <summary>
        /// Revision 2 Constructor
        /// </summary>
        /// <param name="cellId">The cell ID is four bytes long specified by four ASCII digits. Range: 0000-9999.</param>
        /// <param name="channelId">The channel ID is two bytes long specified by two ASCII digits. Range: 00-20.</param>
        /// <param name="controllerName">The controller name is 25 bytes long and specified by 25 ASCII characters.</param>
        /// <param name="supplierCode">ACT (supplier code for Atlas Copco Tools) specified by three ASCII characters.</param>
        /// <param name="revision">Revision number (default = 2)</param>
        public MID_0002(int cellId, int channelId, string controllerName, string supplierCode, int revision = 2) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
            SetRevision1(cellId, channelId, controllerName);
            SetRevision2(supplierCode);
        }

        /// <summary>
        /// Revision 3 Constructor
        /// </summary>
        /// <param name="cellId">The cell ID is four bytes long specified by four ASCII digits. Range: 0000-9999.</param>
        /// <param name="channelId">The channel ID is two bytes long specified by two ASCII digits. Range: 00-20.</param>
        /// <param name="controllerName">The controller name is 25 bytes long and specified by 25 ASCII characters.</param>
        /// <param name="supplierCode">ACT (supplier code for Atlas Copco Tools) specified by three ASCII characters.</param>
        /// <param name="openProtocolVersion">Open Protocol version. 19 ASCII characters. This version mirrors the IMPLEMENTED version of the Open Protocol and is hence not the same as the version of the specification.This is caused by, for instance, the possibility of implementation done of only a subset of the protocol.</param>
        /// <param name="controllerSoftwareVersion">The controller software version. 19 ASCII characters.</param>
        /// <param name="toolSoftwareVersion">The tool software version. 19 ASCII characters.</param>
        /// <param name="revision">Revision number (default = 3)</param>
        public MID_0002(int cellId, int channelId, string controllerName, string supplierCode, string openProtocolVersion, string controllerSoftwareVersion, string toolSoftwareVersion, int revision = 3) 
            : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
            SetRevision1(cellId, channelId, controllerName);
            SetRevision2(supplierCode);
            SetRevision3(openProtocolVersion, controllerSoftwareVersion, toolSoftwareVersion);
        }

        /// <summary>
        /// Revision 4 Constructor
        /// </summary>
        /// <param name="cellId">The cell ID is four bytes long specified by four ASCII digits. Range: 0000-9999.</param>
        /// <param name="channelId">The channel ID is two bytes long specified by two ASCII digits. Range: 00-20.</param>
        /// <param name="controllerName">The controller name is 25 bytes long and specified by 25 ASCII characters.</param>
        /// <param name="supplierCode">ACT (supplier code for Atlas Copco Tools) specified by three ASCII characters.</param>
        /// <param name="openProtocolVersion">Open Protocol version. 19 ASCII characters. This version mirrors the IMPLEMENTED version of the Open Protocol and is hence not the same as the version of the specification.This is caused by, for instance, the possibility of implementation done of only a subset of the protocol.</param>
        /// <param name="controllerSoftwareVersion">The controller software version. 19 ASCII characters.</param>
        /// <param name="toolSoftwareVersion">The tool software version. 19 ASCII characters.</param>
        /// <param name="rbuType">The RBU Type. 24 ASCII characters.</param>
        /// <param name="controllerSerialNumber">The Controller Serial Number. 10 ASCII characters.</param>
        /// <param name="revision">Revision number (default = 4)</param>
        public MID_0002(int cellId, int channelId, string controllerName, string supplierCode, string openProtocolVersion, string controllerSoftwareVersion, string toolSoftwareVersion, string rbuType, 
            string controllerSerialNumber, int revision = 4) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
            SetRevision1(cellId, channelId, controllerName);
            SetRevision2(supplierCode);
            SetRevision3(openProtocolVersion, controllerSoftwareVersion, toolSoftwareVersion);
            SetRevision4(rbuType, controllerSerialNumber);
        }

        /// <summary>
        /// Revision 5 Constructor
        /// </summary>
        /// <param name="cellId">The cell ID is four bytes long specified by four ASCII digits. Range: 0000-9999.</param>
        /// <param name="channelId">The channel ID is two bytes long specified by two ASCII digits. Range: 00-20.</param>
        /// <param name="controllerName">The controller name is 25 bytes long and specified by 25 ASCII characters.</param>
        /// <param name="supplierCode">ACT (supplier code for Atlas Copco Tools) specified by three ASCII characters.</param>
        /// <param name="openProtocolVersion">Open Protocol version. 19 ASCII characters. This version mirrors the IMPLEMENTED version of the Open Protocol and is hence not the same as the version of the specification.This is caused by, for instance, the possibility of implementation done of only a subset of the protocol.</param>
        /// <param name="controllerSoftwareVersion">The controller software version. 19 ASCII characters.</param>
        /// <param name="toolSoftwareVersion">The tool software version. 19 ASCII characters.</param>
        /// <param name="rbuType">The RBU Type. 24 ASCII characters.</param>
        /// <param name="controllerSerialNumber">The Controller Serial Number. 10 ASCII characters.</param>
        /// <param name="systemType">The system type of the controller. 3 ASCII digits</param>
        /// <param name="systemSubType">The system subtype. 3 ASCII digits</param>
        /// <param name="revision">Revision number (default = 5)</param>
        public MID_0002(int cellId, int channelId, string controllerName, string supplierCode, string openProtocolVersion, string controllerSoftwareVersion, string toolSoftwareVersion, string rbuType,
            string controllerSerialNumber, SystemTypes systemType, SystemSubTypes systemSubType, int revision = 5) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
            SetRevision1(cellId, channelId, controllerName);
            SetRevision2(supplierCode);
            SetRevision3(openProtocolVersion, controllerSoftwareVersion, toolSoftwareVersion);
            SetRevision4(rbuType, controllerSerialNumber);
            SetRevision5(systemType, systemSubType);
        }

        /// <summary>
        /// Revision 6 Constructor
        /// </summary>
        /// <param name="cellId">The cell ID is four bytes long specified by four ASCII digits. Range: 0000-9999.</param>
        /// <param name="channelId">The channel ID is two bytes long specified by two ASCII digits. Range: 00-20.</param>
        /// <param name="controllerName">The controller name is 25 bytes long and specified by 25 ASCII characters.</param>
        /// <param name="supplierCode">ACT (supplier code for Atlas Copco Tools) specified by three ASCII characters.</param>
        /// <param name="openProtocolVersion">Open Protocol version. 19 ASCII characters. This version mirrors the IMPLEMENTED version of the Open Protocol and is hence not the same as the version of the specification.This is caused by, for instance, the possibility of implementation done of only a subset of the protocol.</param>
        /// <param name="controllerSoftwareVersion">The controller software version. 19 ASCII characters.</param>
        /// <param name="toolSoftwareVersion">The tool software version. 19 ASCII characters.</param>
        /// <param name="rbuType">The RBU Type. 24 ASCII characters.</param>
        /// <param name="controllerSerialNumber">The Controller Serial Number. 10 ASCII characters.</param>
        /// <param name="systemType">The system type of the controller. 3 ASCII digits</param>
        /// <param name="systemSubType">The system subtype. 3 ASCII digits</param>
        /// <param name="sequenceNumberSupport">Flag sequence number handling supported if = 1</param>
        /// <param name="linkHandlingSupport">Flag linking functionality handling supported if = 1.</param>
        /// <param name="revision">Revision number (default = 6)</param>
        public MID_0002(int cellId, int channelId, string controllerName, string supplierCode, string openProtocolVersion, string controllerSoftwareVersion, string toolSoftwareVersion, string rbuType,
            string controllerSerialNumber, SystemTypes systemType, SystemSubTypes systemSubType, bool sequenceNumberSupport, bool linkingHandlingSupport, int revision = 6) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
            SetRevision1(cellId, channelId, controllerName);
            SetRevision2(supplierCode);
            SetRevision3(openProtocolVersion, controllerSoftwareVersion, toolSoftwareVersion);
            SetRevision4(rbuType, controllerSerialNumber);
            SetRevision5(systemType, systemSubType);
            SetRevision6(sequenceNumberSupport, linkingHandlingSupport);
        }

        internal MID_0002(IMID nextTemplate) : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
            NextTemplate = nextTemplate;
        }

        /// <summary>
        /// Revision 1 Setter
        /// </summary>
        /// <param name="cellId">The cell ID is four bytes long specified by four ASCII digits. Range: 0000-9999.</param>
        /// <param name="channelId">The channel ID is two bytes long specified by two ASCII digits. Range: 00-20.</param>
        /// <param name="controllerName">The controller name is 25 bytes long and specified by 25 ASCII characters.</param>
        public void SetRevision1(int cellId, int channelId, string controllerName)
        {
            CellID = cellId;
            ChannelId = channelId;
            ControllerName = controllerName;
        }

        /// <summary>
        /// Revision 2 Setter
        /// </summary>
        /// <param name="supplierCode">ACT (supplier code for Atlas Copco Tools) specified by three ASCII characters.</param>
        public void SetRevision2(string supplierCode) => SupplierCode = supplierCode;

        /// <summary>
        /// Revision 3 Setter
        /// </summary>
        /// <param name="openProtocolVersion">Open Protocol version. 19 ASCII characters. This version mirrors the IMPLEMENTED version of the Open Protocol and is hence not the same as the version of the specification.This is caused by, for instance, the possibility of implementation done of only a subset of the protocol.</param>
        /// <param name="controllerSoftwareVersion">The controller software version. 19 ASCII characters.</param>
        /// <param name="toolSoftwareVersion">The tool software version. 19 ASCII characters.</param>
        public void SetRevision3(string openProtocolVersion, string controllerSoftwareVersion, string toolSoftwareVersion)
        {
            OpenProtocolVersion = openProtocolVersion;
            ControllerSoftwareVersion = controllerSoftwareVersion;
            ToolSoftwareVersion = toolSoftwareVersion;
        }

        /// <summary>
        /// Revision 4 Setter
        /// </summary>
        /// <param name="rbuType"></param>
        /// <param name="controllerSerialNumber"></param>
        public void SetRevision4(string rbuType, string controllerSerialNumber)
        {
            RBUType = rbuType;
            ControllerSerialNumber = controllerSerialNumber;
        }

        /// <summary>
        /// Revision 5 Setter
        /// </summary>
        /// <param name="systemType">The system type of the controller. 3 ASCII digits</param>
        /// <param name="systemSubType">The system subtype. 3 ASCII digits</param>
        public void SetRevision5(SystemTypes systemType, SystemSubTypes systemSubType)
        {
            SystemType = systemType;
            SystemSubType = systemSubType;
        }

        /// <summary>
        /// Revision 6 Setter
        /// </summary>
        /// <param name="sequenceNumberSupport">Flag sequence number handling supported if = 1</param>
        /// <param name="linkHandlingSupport">Flag linking functionality handling supported if = 1.</param>
        public void SetRevision6(bool sequenceNumberSupport, bool linkingHandlingSupport)
        {
            SequenceNumberSupport = sequenceNumberSupport;
            LinkingHandlingSupport = linkingHandlingSupport;
        }

        /// <summary>
        /// Validate all fields size
        /// </summary>
        public bool Validate(out IEnumerable<string> errors)
        {
            List<string> failed = new List<string>();
            //Rev 1
            if (CellID < 0 || CellID > 9999)
                failed.Add(new ArgumentOutOfRangeException(nameof(CellID), "Range: 0000-9999").Message);
            if (ChannelId < 0 || ChannelId > 20)
                failed.Add(new ArgumentOutOfRangeException(nameof(ChannelId), "Range: 00-20").Message);
            if (ControllerName.Length > 25)
                failed.Add(new ArgumentOutOfRangeException(nameof(ControllerName), "Max of 20 characters").Message);
            //Rev 2
            if (SupplierCode.Length > 3)
                failed.Add(new ArgumentOutOfRangeException(nameof(SupplierCode), "Max of 3 characters").Message);
            //Rev 3
            if (OpenProtocolVersion.Length > 19)
                failed.Add(new ArgumentOutOfRangeException(nameof(OpenProtocolVersion), "Max of 19 characters").Message);
            if (ControllerSoftwareVersion.Length > 19)
                failed.Add(new ArgumentOutOfRangeException(nameof(ControllerSoftwareVersion), "Max of 19 characters").Message);
            if (ToolSoftwareVersion.Length > 19)
                failed.Add(new ArgumentOutOfRangeException(nameof(ToolSoftwareVersion), "Max of 19 characters").Message);
            //Rev 4
            if (RBUType.Length > 24)
                failed.Add(new ArgumentOutOfRangeException(nameof(RBUType), "Max of 24 characters").Message);
            if (ControllerSerialNumber.Length > 10)
                failed.Add(new ArgumentOutOfRangeException(nameof(ControllerSerialNumber), "Max of 10 characters").Message);

            errors = failed;
            return errors.Any();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.CELL_ID, 20, 4, '0'),
                                new DataField((int)DataFields.CHANNEL_ID, 26, 2, '0'),
                                new DataField((int)DataFields.CONTROLLER_NAME, 30, 25, ' ')
                            }
                },
                {
                    2, new  List<DataField>()
                            {
                                new DataField((int)DataFields.SUPPLIER_CODE, 57, 3, ' ')
                            }
                },
                {
                    3, new  List<DataField>()
                            {
                                new DataField((int)DataFields.OPEN_PROTOCOL_VERSION, 62, 19, ' '),
                                new DataField((int)DataFields.CONTROLLER_SOFTWARE_VERSION, 83, 19, ' '),
                                new DataField((int)DataFields.TOOL_SOFTWARE_VERSION, 104, 19, ' ')
                            }
                },
                {
                    4, new  List<DataField>()
                            {
                                new DataField((int)DataFields.RBU_TYPE, 125, 24, ' '),
                                new DataField((int)DataFields.CONTROLLER_SERIAL_NUMBER, 151, 10, ' ')
                            }
                },
                {
                    5, new  List<DataField>()
                            {
                                new DataField((int)DataFields.SYSTEM_TYPE, 163, 3, '0'),
                                new DataField((int)DataFields.SYSTEM_SUBTYPE, 168, 3, '0')
                            }
                },
                {
                    6, new  List<DataField>()
                            {
                                new DataField((int)DataFields.SEQUENCE_NUMBER_SUPPORT, 173, 1),
                                new DataField((int)DataFields.LINKING_HANDLING_SUPPORT, 176, 1)
                            }
                }
            };
        }

        /// <summary>
        /// The system type of the controller.
        /// <para>Possible values are:</para>
        /// <para>000 = System type not set </para>
        /// <para>001 = Power Focus 4000 </para>
        /// <para>002 = Power MACS 4000 </para>
        /// <para>003 = Power Focus 6000</para>
        /// </summary>
        public enum SystemTypes
        {
            SYSTEM_TYPE_NOT_SET = 0,
            POWER_FOCUS_4000 = 1,
            POWER_MACS_4000 = 2,
            POWER_FOCUS_6000 = 3
        }

        /// <summary>
        /// If no subtype exists it will be set to 000
        /// <para>For a Power Focus 4000 and PF 6000 system the valid subtypes are: </para>
        /// <para>001 = a normal tightening system</para>
        /// For a Power MACS 4000 system the valid subtypes are: 
        /// <para>001 = a normal tightening system</para>
        /// <para>002 = a system running presses instead of spindles.</para>
        /// </summary>
        public enum SystemSubTypes
        {
            NO_SUBTYPE_EXISTS = 0,
            NORMAL_TIGHTENING_SYSTEM = 1,
            SYSTEM_RUNNING_PRESSES = 2
        }

        public enum DataFields
        {
            //Rev 1
            CELL_ID,
            CHANNEL_ID,
            CONTROLLER_NAME,
            //Rev 2
            SUPPLIER_CODE,
            //Rev 3
            OPEN_PROTOCOL_VERSION,
            CONTROLLER_SOFTWARE_VERSION,
            TOOL_SOFTWARE_VERSION,
            //Rev 4
            RBU_TYPE,
            CONTROLLER_SERIAL_NUMBER,
            //Rev 5
            SYSTEM_TYPE,
            SYSTEM_SUBTYPE,
            //Rev 6
            SEQUENCE_NUMBER_SUPPORT,
            LINKING_HANDLING_SUPPORT
        }
    }
}
