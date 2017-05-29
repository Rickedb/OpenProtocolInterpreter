using System;

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
        private const int length = 20;
        public const int MID = 2;
        private const int revision = 1;

        public int CellID { get; set; }

        public int ChannelID { get; set; }

        public string ControllerName { get; set; }

        public MID_0002() : base(length, MID, revision) {  }

        internal MID_0002(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processPackage(package);

                int cellId = 0;
                int channelId = 0;
                int.TryParse(base.RegisteredDataFields[(int)DataFields.CELL_ID].Value.ToString(), out cellId);
                int.TryParse(base.RegisteredDataFields[(int)DataFields.CHANNEL_ID].Value.ToString(), out channelId);

                this.CellID = cellId;
                this.ChannelID = channelId;
                this.ControllerName = base.RegisteredDataFields[(int)DataFields.CONTROLLER_NAME].Value.ToString();

                return this;
            }
                
            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() 
        {
            this.RegisteredDataFields.AddRange(
                new DataField[]
                {
                    new DataField((int)DataFields.CELL_ID, 20, 4),
                    new DataField((int)DataFields.CHANNEL_ID, 26, 2),
                    new DataField((int)DataFields.CONTROLLER_NAME, 30, 25)
                });
        }

        public enum DataFields
        {
            CELL_ID,
            CHANNEL_ID,
            CONTROLLER_NAME
        }
    }
}
