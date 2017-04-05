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
    public class MID_0002 : MID
    {
        private readonly IMID nextTemplate;

        private const int length = 20;
        private const int mid = 2;
        private const int revision = 1;

        public int CellID { get; set; }

        public int ChannelID { get; set; }

        public string ControllerName { get; set; }

        public MID_0002() : base(length, mid, revision) { }

        public MID_0002(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processPackage(package);

                this.CellID = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.CELL_ID].Value);
                this.ChannelID = Convert.ToInt32(base.RegisteredDataFields[(int)DataFields.CHANNEL_ID].Value);
                this.ControllerName = base.RegisteredDataFields[(int)DataFields.CONTROLLER_NAME].Value.ToString();

                return this;
            }
                
            return this.nextTemplate.processPackage(package);
        }

        private void registerDatafields()
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
