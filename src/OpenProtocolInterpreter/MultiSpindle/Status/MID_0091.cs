using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultiSpindle.Status
{
    /// <summary>
    /// MID: Multi-spindle status
    /// Description: 
    ///      The multi-spindle status is sent after each sync tightening. The multiple status contains the common
    ///      status of the multiple as well as the individual status of each spindle.
    /// Message sent by: Controller
    /// Answer : MID 0092 Multi-spindle status acknowledge
    /// </summary>
    public class MID_0091 : MID, IMultiSpindle
    {
        public const int MID = 91;

        private const int length = 53;
        private const int revision = 1;

        public MultiSpindlesData MultiSpindleData { get; set; }

        public MID_0091() : base(length, MID, revision)
        {

        }

        internal MID_0091(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                this.MultiSpindleData = new MultiSpindlesData().getMultiSpindleFromPackage(package);
                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.MULTI_SPINDLE_DATA, 20, 33));
        }

        public enum DataFields
        {
            MULTI_SPINDLE_DATA
        }

        public class MultiSpindlesData
        {
            private List<DataField> fields;
            public int NumberOfSpindles { get; set; }
            public int SyncTighteningId { get; set; }
            public DateTime Time { get; set; }
            public bool SyncOverallStatus { get; set; }
            public List<SpindleStatuses> SpindleStatus { get; set; }

            public MultiSpindlesData() { this.registerFields(); }

            public MultiSpindlesData getMultiSpindleFromPackage(string package)
            {
                this.processFields(package);
                MultiSpindlesData obj = new MultiSpindlesData();

                obj.NumberOfSpindles = this.fields[(int)Fields.NUMBER_OF_SPINDLES].ToInt32();
                obj.SyncTighteningId = this.fields[(int)Fields.SYNC_TIGHTENING_ID].ToInt32();
                obj.Time = this.fields[(int)Fields.TIME].ToDateTime();
                obj.SyncOverallStatus = this.fields[(int)Fields.SYNC_OVERALL_STATUS].ToBoolean();
                obj.SpindleStatus = new SpindleStatuses().getSpindleStatuses(package.Substring(this.fields[(int)Fields.SPINDLE_STATUS].Index));

                return obj;
            }

            public override string ToString()
            {
                string package = string.Empty;

                return base.ToString();
            }

            private void processFields(string package)
            {
                foreach (var field in this.fields)
                    field.Value = package.Substring(2 + field.Index, field.Size);
            }

            private void registerFields()
            {
                this.fields = new List<DataField>();
                this.fields.AddRange(new DataField[] {
                        new DataField((int)Fields.NUMBER_OF_SPINDLES, 20, 2),
                        new DataField((int)Fields.SYNC_TIGHTENING_ID, 24, 5),
                        new DataField((int)Fields.TIME, 31, 19),
                        new DataField((int)Fields.SYNC_OVERALL_STATUS, 52, 1),
                        new DataField((int)Fields.SPINDLE_STATUS, 55, 5)
                 });
            }

            public enum Fields
            {
                NUMBER_OF_SPINDLES,
                SYNC_TIGHTENING_ID,
                TIME,
                SYNC_OVERALL_STATUS,
                SPINDLE_STATUS
            }

            public class SpindleStatuses
            {
                private List<DataField> fields;

                public int SpindleNumber { get; set; }
                public int ChannelId { get; set; }
                public bool SpindleStatus { get; set; }

                public SpindleStatuses() { this.registerFields(); }

                public List<SpindleStatuses> getSpindleStatuses(string package)
                {
                    List<SpindleStatuses> obj = new List<SpindleStatuses>();
                    int totalSpindles = package.Length / 5;

                    for(int i = 0; i < totalSpindles; i++)
                        obj.Add(new SpindleStatuses()
                        {
                            SpindleNumber = Convert.ToInt32(package.Substring(0 + (i * 5), this.fields[(int)Fields.SPINDLE_NUMBER].Size)),
                            ChannelId = Convert.ToInt32(package.Substring(2 + (i * 5), this.fields[(int)Fields.CHANNEL_ID].Size)),
                            SpindleStatus = Convert.ToBoolean(Convert.ToInt32(package.Substring(4 + (i * 5), this.fields[(int)Fields.SPINDLE_STATUS].Size)))
                        });

                    return obj;
                }

                private void registerFields()
                {
                    this.fields = new List<DataField>();
                    this.fields.AddRange(new DataField[] {
                        new DataField((int)Fields.SPINDLE_NUMBER, 57, 2),
                        new DataField((int)Fields.CHANNEL_ID, 59, 2),
                        new DataField((int)Fields.SPINDLE_STATUS, 61, 1)
                 });
                }

                public enum Fields
                {
                    SPINDLE_NUMBER,
                    CHANNEL_ID,
                    SPINDLE_STATUS
                }
            }
        }
    }
}
