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
            get => GetField(1, (int)DataFields.CellId).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.CellId).SetValue(_intConverter.Convert, value);
        }

        public int ChannelId
        {
            get => GetField(1, (int)DataFields.ChannelId).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.ChannelId).SetValue(_intConverter.Convert, value);
        }
        public string ControllerName
        {
            get => GetField(1, (int)DataFields.ControllerName).Value;
            set => GetField(1, (int)DataFields.ControllerName).SetValue(value);
        }

        //Rev 2
        public string SupplierCode
        {
            get => GetField(2, (int)DataFields.SupplierCode).Value;
            set => GetField(2, (int)DataFields.SupplierCode).SetValue(value);
        }

        //Rev 3
        public string OpenProtocolVersion
        {
            get => GetField(3, (int)DataFields.OpenProtocolVersion).Value;
            set => GetField(3, (int)DataFields.OpenProtocolVersion).SetValue(value);
        }

        public string ControllerSoftwareVersion
        {
            get => GetField(3, (int)DataFields.ControllerSoftwareVersion).Value;
            set => GetField(3, (int)DataFields.ControllerSoftwareVersion).SetValue(value);
        }

        public string ToolSoftwareVersion
        {
            get => GetField(3, (int)DataFields.ToolSoftwareVersion).Value;
            set => GetField(3, (int)DataFields.ToolSoftwareVersion).SetValue(value);
        }

        //Rev 4
        public string RBUType
        {
            get => GetField(4, (int)DataFields.RBUType).Value;
            set => GetField(4, (int)DataFields.RBUType).SetValue(value);
        }

        public string ControllerSerialNumber
        {
            get => GetField(4, (int)DataFields.ControllerSerialNumber).Value;
            set => GetField(4, (int)DataFields.ControllerSerialNumber).SetValue(value);
        }

        //Rev 5 
        public SystemType SystemType
        {
            get => (SystemType)GetField(5, (int)DataFields.SystemType).GetValue(_intConverter.Convert);
            set => GetField(5, (int)DataFields.SystemType).SetValue(_intConverter.Convert, (int)value);
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
            get => (SystemSubType)GetField(5, (int)DataFields.SystemSubtype).GetValue(_intConverter.Convert);
            set => GetField(5, (int)DataFields.SystemSubtype).SetValue(_intConverter.Convert, (int)value);
        }

        //Rev 6
        public bool SequenceNumberSupport
        {
            get => GetField(6, (int)DataFields.SequenceNumberSupport).GetValue(_boolConverter.Convert);
            set => GetField(6, (int)DataFields.SequenceNumberSupport).SetValue(_boolConverter.Convert, value);
        }

        public bool LinkingHandlingSupport
        {
            get => GetField(6, (int)DataFields.LinkingHandlingSupport).GetValue(_boolConverter.Convert);
            set => GetField(6, (int)DataFields.LinkingHandlingSupport).SetValue(_boolConverter.Convert, value);
        }

        /// <summary>
        /// <para>Station ID for PF6000</para>
        /// <para>Cell ID for PF4000</para>
        /// </summary>
        public long StationCellId 
        {
            get => GetField(6, (int)DataFields.StationCellId).GetValue(_longConverter.Convert);
            set => GetField(6, (int)DataFields.StationCellId).SetValue(_longConverter.Convert, value);
        }

        /// <summary>
        /// <para>Station ID for PF6000</para>
        /// <para>Cell ID for PF4000</para>
        /// </summary>
        public string StationCellName
        {
            get => GetField(6, (int)DataFields.StationCellName).Value;
            set => GetField(6, (int)DataFields.StationCellName).SetValue(value);
        }

        public string ClientId
        {
            get => GetField(6, (int)DataFields.ClientId).Value;
            set => GetField(6, (int)DataFields.ClientId).SetValue(value);
        }

        //Rev 7
        /// <summary>
        /// <para>False = Use Keep alive (Keep alive is mandatory)</para> 
        /// <para>True = Ignore Keep alive (Keep alive is optional)</para>
        /// </summary>
        public bool OptionalKeepAlive 
        {
            get => GetField(7, (int)DataFields.OptionalKeepAlive).GetValue(_boolConverter.Convert);
            set => GetField(7, (int)DataFields.OptionalKeepAlive).SetValue(_boolConverter.Convert, value);
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
                                new DataField((int)DataFields.CellId, 20, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ChannelId, 26, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.ControllerName, 30, 25, ' ')
                            }
                },
                {
                    2, new  List<DataField>()
                            {
                                new DataField((int)DataFields.SupplierCode, 57, 3, ' ')
                            }
                },
                {
                    3, new  List<DataField>()
                            {
                                new DataField((int)DataFields.OpenProtocolVersion, 62, 19, ' '),
                                new DataField((int)DataFields.ControllerSoftwareVersion, 83, 19, ' '),
                                new DataField((int)DataFields.ToolSoftwareVersion, 104, 19, ' ')
                            }
                },
                {
                    4, new  List<DataField>()
                            {
                                new DataField((int)DataFields.RBUType, 125, 24, ' '),
                                new DataField((int)DataFields.ControllerSerialNumber, 151, 10, ' ')
                            }
                },
                {
                    5, new  List<DataField>()
                            {
                                new DataField((int)DataFields.SystemType, 163, 3, '0'),
                                new DataField((int)DataFields.SystemSubtype, 168, 3, '0')
                            }
                },
                {
                    6, new  List<DataField>()
                            {
                                new DataField((int)DataFields.SequenceNumberSupport, 173, 1),
                                new DataField((int)DataFields.LinkingHandlingSupport, 176, 1),
                                new DataField((int)DataFields.StationCellId, 179, 10, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.StationCellName, 191, 25),
                                new DataField((int)DataFields.ClientId, 218, 1)
                            }
                },
                {
                    7, new  List<DataField>()
                            {
                                new DataField((int)DataFields.OptionalKeepAlive, 221, 1)
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
