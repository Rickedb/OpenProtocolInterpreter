using OpenProtocolInterpreter.Helpers;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MIDs.Communication
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
        private readonly Dictionary<int, Action> revisionsActions;
        private const int length = 20;
        private const int lastRevision = 6;
        public const int MID = 2;

        public int CellID { get; set; }
        public int ChannelID { get; set; }
        public string ControllerName { get; set; }
        public string SupplierCode { get; set; }
        public string OpenProtocolVersion { get; set; }
        public string ControllerSoftwareVersion { get; set; }
        public string ToolSoftwareVersion { get; set; }
        public string RBUType { get; set; }
        public string ControllerSerialNumber { get; set; }
        public SystemTypes SystemType { get; set; }
        /// <summary>
        /// <para>If no subtype exists it will be set to 000</para>
        /// <para>For a Power Focus 4000 and PF 6000 system the valid subtypes are:</para>
        /// <para>001 = a normal tightening system</para>
        /// <para>For a Power MACS 4000 system the valid subtypes are:</para>
        /// <para>001 = a normal tightening system </para>
        /// <para>002 = a system running presses instead of spindles.</para>
        /// </summary>
        public int SystemSubType { get; set; }
        public bool SequenceNumberSupport { get; set; }
        public bool LinkingHandlingSupport { get; set; }

        public MID_0002() : base(MID, lastRevision)
        {
            this.revisionsActions = new Dictionary<int, Action>()
            {
                { 1, this.storeRevision1 },
                { 2, this.storeRevision2 },
                { 3, this.storeRevision3 },
                { 4, this.storeRevision4 },
                { 5, this.storeRevision5 },
                { 6, this.storeRevision6 }
            };
        }

        public MID_0002(int revision) : base(MID, revision)
        {
            this.revisionsActions = new Dictionary<int, Action>()
            {
                { 1, this.storeRevision1 },
                { 2, this.storeRevision2 },
                { 3, this.storeRevision3 },
                { 4, this.storeRevision4 },
                { 5, this.storeRevision5 },
                { 6, this.storeRevision6 }
            };
        }

        internal MID_0002(IMID nextTemplate) : base(length, MID, lastRevision)
        {
            this.nextTemplate = nextTemplate;
            this.revisionsActions = new Dictionary<int, Action>()
            {
                { 1, this.processRevision1 },
                { 2, this.processRevision2 },
                { 3, this.processRevision3 },
                { 4, this.processRevision4 },
                { 5, this.processRevision5 },
                { 6, this.processRevision6 }
            };
        }

        public override string buildPackage()
        {
            for (int i = 1; i <= this.HeaderData.Revision; i++)
                this.revisionsActions[i]();
            return base.buildPackage();
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                this.updateRevisionFromPackage(package);
                base.processPackage(package);
                for (int i = 1; i <= this.HeaderData.Revision; i++)
                    this.revisionsActions[i]();
                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        protected override void loadRevisionsFields()
        {
            base.RevisionsByFields = new Dictionary<int, IEnumerable<DataField>>()
            {
                {
                    1, new DataField[]
                            {
                                new DataField((int)DataFields.CELL_ID, 20, 4, '0'),
                                new DataField((int)DataFields.CHANNEL_ID, 26, 2, '0'),
                                new DataField((int)DataFields.CONTROLLER_NAME, 30, 25, ' ')
                            }
                },
                {
                    2, new DataField []
                            {
                                new DataField((int)DataFields.SUPPLIER_CODE, 57, 3, ' ')
                            }
                },
                {
                    3, new DataField []
                            {
                                new DataField((int)DataFields.OPEN_PROTOCOL_VERSION, 62, 19, ' '),
                                new DataField((int)DataFields.CONTROLLER_SOFTWARE_VERSION, 83, 19, ' '),
                                new DataField((int)DataFields.TOOL_SOFTWARE_VERSION, 104, 19, ' ')
                            }
                },
                {
                    4, new DataField []
                            {
                                new DataField((int)DataFields.RBU_TYPE, 125, 24, ' '),
                                new DataField((int)DataFields.CONTROLLER_SERIAL_NUMBER, 151, 10, ' ')
                            }
                },
                {
                    5, new DataField []
                            {
                                new DataField((int)DataFields.SYSTEM_TYPE, 163, 3, '0'),
                                new DataField((int)DataFields.SYSTEM_SUBTYPE, 168, 3, '0')
                            }
                },
                {
                    6, new DataField []
                            {
                                new DataField((int)DataFields.SEQUENCE_NUMBER_SUPPORT, 173, 1),
                                new DataField((int)DataFields.LINKING_HANDLING_SUPPORT, 177, 1)
                            }
                }
            };
        }
        
        private void processRevision1()
        {
            this.CellID = base.RegisteredDataFields.getDataField((int)DataFields.CELL_ID).ToInt32();
            this.ChannelID = base.RegisteredDataFields.getDataField((int)DataFields.CHANNEL_ID).ToInt32();
            this.ControllerName = base.RegisteredDataFields.getDataField((int)DataFields.CONTROLLER_NAME).ToString();
        }

        private void processRevision2()
        {
            this.SupplierCode = base.RegisteredDataFields.getDataField((int)DataFields.SUPPLIER_CODE).ToString();
        }

        private void processRevision3()
        {
            this.OpenProtocolVersion = base.RegisteredDataFields.getDataField((int)DataFields.OPEN_PROTOCOL_VERSION).ToString();
            this.ControllerSoftwareVersion = base.RegisteredDataFields.getDataField((int)DataFields.CONTROLLER_SOFTWARE_VERSION).ToString();
            this.ToolSoftwareVersion = base.RegisteredDataFields.getDataField((int)DataFields.TOOL_SOFTWARE_VERSION).ToString();
        }

        private void processRevision4()
        {
            this.RBUType = base.RegisteredDataFields.getDataField((int)DataFields.RBU_TYPE).ToString();
            this.ControllerSerialNumber = base.RegisteredDataFields.getDataField((int)DataFields.CONTROLLER_SERIAL_NUMBER).ToString();
        }

        private void processRevision5()
        {
            this.SystemType = (SystemTypes)base.RegisteredDataFields.getDataField((int)DataFields.SYSTEM_TYPE).ToInt32();
            this.SystemSubType = base.RegisteredDataFields.getDataField((int)DataFields.SYSTEM_SUBTYPE).ToInt32();
        }

        private void processRevision6()
        {
            this.SequenceNumberSupport = base.RegisteredDataFields.getDataField((int)DataFields.SEQUENCE_NUMBER_SUPPORT).ToBoolean();
            this.LinkingHandlingSupport = base.RegisteredDataFields.getDataField((int)DataFields.LINKING_HANDLING_SUPPORT).ToBoolean();
        }

        private void storeRevision1()
        {
            base.RegisteredDataFields.getDataField((int)DataFields.CELL_ID).setPaddedLeftValue(this.CellID);
            base.RegisteredDataFields.getDataField((int)DataFields.CHANNEL_ID).setPaddedLeftValue(this.ChannelID);
            base.RegisteredDataFields.getDataField((int)DataFields.CONTROLLER_NAME).setPaddedRightValue(this.ControllerName);
        }

        private void storeRevision2()
        {
            base.RegisteredDataFields.getDataField((int)DataFields.SUPPLIER_CODE).setPaddedRightValue(this.SupplierCode);
        }

        private void storeRevision3()
        {
            base.RegisteredDataFields.getDataField((int)DataFields.OPEN_PROTOCOL_VERSION).setPaddedRightValue(this.OpenProtocolVersion);
            base.RegisteredDataFields.getDataField((int)DataFields.CONTROLLER_SOFTWARE_VERSION).setPaddedRightValue(this.ControllerSoftwareVersion);
            base.RegisteredDataFields.getDataField((int)DataFields.TOOL_SOFTWARE_VERSION).setPaddedRightValue(this.ToolSoftwareVersion);
        }

        private void storeRevision4()
        {
            base.RegisteredDataFields.getDataField((int)DataFields.RBU_TYPE).setPaddedRightValue(this.RBUType);
            base.RegisteredDataFields.getDataField((int)DataFields.CONTROLLER_SERIAL_NUMBER).setPaddedRightValue(this.ControllerSerialNumber);
        }

        private void storeRevision5()
        {
            base.RegisteredDataFields.getDataField((int)DataFields.SYSTEM_TYPE).setPaddedLeftValue((int)this.SystemType);
            base.RegisteredDataFields.getDataField((int)DataFields.SYSTEM_SUBTYPE).setPaddedLeftValue(this.SystemSubType);
        }

        private void storeRevision6()
        {
            base.RegisteredDataFields.getDataField((int)DataFields.SEQUENCE_NUMBER_SUPPORT).setBoolean(this.SequenceNumberSupport);
            base.RegisteredDataFields.getDataField((int)DataFields.LINKING_HANDLING_SUPPORT).setBoolean(this.LinkingHandlingSupport);
        }

        /// <summary>
        /// Added at revision 5
        /// </summary>
        public enum SystemTypes
        {
            SYSTEM_TYPE_NOT_SET = 0,
            POWER_FOCUS_4000 = 1,
            POWER_MACS_4000 = 2,
            POWER_FOCUS_6000 = 3
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
