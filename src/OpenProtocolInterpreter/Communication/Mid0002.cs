using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<long> _longConverter;
        private readonly IValueConverter<bool> _boolConverter;
        public const int MID = 2;

        public int CellId
        {
            get => GetField(1, (int)DataFields.CELL_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.CELL_ID).SetValue(_intConverter.Convert, value);
        }

        public int ChannelId
        {
            get => GetField(1, (int)DataFields.CHANNEL_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.CHANNEL_ID).SetValue(_intConverter.Convert, value);
        }
        public string ControllerName
        {
            get => GetField(1, (int)DataFields.CONTROLLER_NAME).Value;
            set => GetField(1, (int)DataFields.CONTROLLER_NAME).SetValue(value);
        }

        //Rev 2
        public string SupplierCode
        {
            get => GetField(2, (int)DataFields.SUPPLIER_CODE).Value;
            set => GetField(2, (int)DataFields.SUPPLIER_CODE).SetValue(value);
        }

        //Rev 3
        public string OpenProtocolVersion
        {
            get => GetField(3, (int)DataFields.OPEN_PROTOCOL_VERSION).Value;
            set => GetField(3, (int)DataFields.OPEN_PROTOCOL_VERSION).SetValue(value);
        }

        public string ControllerSoftwareVersion
        {
            get => GetField(3, (int)DataFields.CONTROLLER_SOFTWARE_VERSION).Value;
            set => GetField(3, (int)DataFields.CONTROLLER_SOFTWARE_VERSION).SetValue(value);
        }

        public string ToolSoftwareVersion
        {
            get => GetField(3, (int)DataFields.TOOL_SOFTWARE_VERSION).Value;
            set => GetField(3, (int)DataFields.TOOL_SOFTWARE_VERSION).SetValue(value);
        }

        //Rev 4
        public string RBUType
        {
            get => GetField(4, (int)DataFields.RBU_TYPE).Value;
            set => GetField(4, (int)DataFields.RBU_TYPE).SetValue(value);
        }

        public string ControllerSerialNumber
        {
            get => GetField(4, (int)DataFields.CONTROLLER_SERIAL_NUMBER).Value;
            set => GetField(4, (int)DataFields.CONTROLLER_SERIAL_NUMBER).SetValue(value);
        }

        //Rev 5 
        public SystemType SystemType
        {
            get => (SystemType)GetField(5, (int)DataFields.SYSTEM_TYPE).GetValue(_intConverter.Convert);
            set => GetField(5, (int)DataFields.SYSTEM_TYPE).SetValue(_intConverter.Convert, (int)value);
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
            get => (SystemSubType)GetField(5, (int)DataFields.SYSTEM_SUBTYPE).GetValue(_intConverter.Convert);
            set => GetField(5, (int)DataFields.SYSTEM_SUBTYPE).SetValue(_intConverter.Convert, (int)value);
        }

        //Rev 6
        public bool SequenceNumberSupport
        {
            get => GetField(6, (int)DataFields.SEQUENCE_NUMBER_SUPPORT).GetValue(_boolConverter.Convert);
            set => GetField(6, (int)DataFields.SEQUENCE_NUMBER_SUPPORT).SetValue(_boolConverter.Convert, value);
        }

        public bool LinkingHandlingSupport
        {
            get => GetField(6, (int)DataFields.LINKING_HANDLING_SUPPORT).GetValue(_boolConverter.Convert);
            set => GetField(6, (int)DataFields.LINKING_HANDLING_SUPPORT).SetValue(_boolConverter.Convert, value);
        }

        /// <summary>
        /// <para>Station ID for PF6000</para>
        /// <para>Cell ID for PF4000</para>
        /// </summary>
        public long StationCellId 
        {
            get => GetField(6, (int)DataFields.STATION_CELL_ID).GetValue(_longConverter.Convert);
            set => GetField(6, (int)DataFields.STATION_CELL_ID).SetValue(_longConverter.Convert, value);
        }

        /// <summary>
        /// <para>Station ID for PF6000</para>
        /// <para>Cell ID for PF4000</para>
        /// </summary>
        public string StationCellName
        {
            get => GetField(6, (int)DataFields.STATION_CELL_NAME).Value;
            set => GetField(6, (int)DataFields.STATION_CELL_NAME).SetValue(value);
        }

        public string ClientId
        {
            get => GetField(6, (int)DataFields.CLIENT_ID).Value;
            set => GetField(6, (int)DataFields.CLIENT_ID).SetValue(value);
        }

        //Rev 7
        /// <summary>
        /// <para>False = Use Keep alive (Keep alive is mandatory)</para> 
        /// <para>True = Ignore Keep alive (Keep alive is optional)</para>
        /// </summary>
        public bool OptionalKeepAlive 
        {
            get => GetField(7, (int)DataFields.OPTIONAL_KEEP_ALIVE).GetValue(_boolConverter.Convert);
            set => GetField(7, (int)DataFields.OPTIONAL_KEEP_ALIVE).SetValue(_boolConverter.Convert, value);
        }

        public Mid0002() : this(DEFAULT_REVISION)
        {

        }

        public Mid0002(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            _longConverter = new Int64Converter();
            _boolConverter = new BoolConverter();
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
                                new DataField((int)DataFields.CELL_ID, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.CHANNEL_ID, 26, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
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
                                new DataField((int)DataFields.LINKING_HANDLING_SUPPORT, 176, 1),
                                new DataField((int)DataFields.STATION_CELL_ID, 179, 10, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.STATION_CELL_NAME, 191, 25),
                                new DataField((int)DataFields.CLIENT_ID, 218, 1)
                            }
                },
                {
                    7, new  List<DataField>()
                            {
                                new DataField((int)DataFields.OPTIONAL_KEEP_ALIVE, 221, 1)
                            }
                }
            };
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
            LINKING_HANDLING_SUPPORT,
            STATION_CELL_ID,
            STATION_CELL_NAME,
            CLIENT_ID,
            //Rev 7
            OPTIONAL_KEEP_ALIVE
        }
    }
}
