using System;

namespace OpenProtocolInterpreter.MIDs.Tool
{
    /// <summary>
    /// MID: Tool Pairing status
    /// Description: 
    ///     This message is sent by the controller in order to report the current status of the tool pairing.
    /// Message sent by: Controller
    /// Answer: N/A
    /// </summary>
    public class MID_0048 : MID, ITool
    {
        private const int length = 45;
        private const int mid = 48;
        private const int revision = 1;

        public PairingStatuses PairingStatus { get; set; }
        public DateTime TimeStamp { get; set; }

        public MID_0048() : base(length, mid, revision) { }

        public MID_0048(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            this.RegisteredDataFields[(int)DataFields.PAIRING_STATUS].Value = (int)this.PairingStatus;
            this.RegisteredDataFields[(int)DataFields.TIMESTAMP].Value = this.TimeStamp.ToString("yyyy-MM-dd:HH:mm:ss");

            return base.buildPackage();
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processPackage(package);

                this.PairingStatus = (PairingStatuses)this.RegisteredDataFields[(int)DataFields.PAIRING_STATUS].ToInt32();
                this.TimeStamp = this.RegisteredDataFields[(int)DataFields.TIMESTAMP].ToDateTime();

                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields()
        {
            this.RegisteredDataFields.AddRange(new DataField[] {
                new DataField((int)DataFields.PAIRING_STATUS, 20, 2),
                new DataField((int)DataFields.TIMESTAMP, 24, 19),
            });

        }

        public enum PairingStatuses
        {
            /// <summary>
            /// Tool not mounted yet
            /// </summary>
            UNDEFINED,
            /// <summary>
            /// Pairing allowed and started
            /// </summary>
            ACCEPTED,
            /// <summary>
            /// Normal pairing sequence as OK
            /// </summary>
            INQUIRY,
            /// <summary>
            /// Normal pairing sequence as OK
            /// </summary>
            SENDPIN,
            /// <summary>
            /// Normal pairing sequence as OK
            /// </summary>
            PINOK,
            /// <summary>
            /// Normal pairing sequence as OK
            /// </summary>
            READY,
            /// <summary>
            /// Ongoing Pairing Aborted
            /// </summary>
            ABORTED,
            /// <summary>
            /// Pairing not allowed. Program control.
            /// </summary>
            DENIED,
            /// <summary>
            /// Pairing attempt failed
            /// </summary>
            FAILED,
            /// <summary>
            /// Pairing never done before or disconnected
            /// </summary>
            UNREADY
        }

        public enum DataFields
        {
            PAIRING_STATUS,
            TIMESTAMP
        }
    }
}
