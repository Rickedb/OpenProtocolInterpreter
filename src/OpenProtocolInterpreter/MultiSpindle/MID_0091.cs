using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// MID: Multi-spindle status
    /// Description: 
    ///      The multi-spindle status is sent after each sync tightening. The multiple status contains the common
    ///      status of the multiple as well as the individual status of each spindle.
    /// Message sent by: Controller
    /// Answer : MID 0092 Multi-spindle status acknowledge
    /// </summary>
    public class MID_0091 : Mid, IMultiSpindle
    {
        private const int LAST_REVISION = 1;
        public const int MID = 91;

        public int NumberOfSpindles { get; set; }
        public int SyncTighteningId { get; set; }
        public DateTime Time { get; set; }
        public bool SyncOverallStatus { get; set; }
        public SpindleStatus SpindleStatus { get; set; }

        public MID_0091(int revision = LAST_REVISION, int? ackFlag = 1) : base(MID, revision, ackFlag)
        {

        }

        internal MID_0091(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                MultiSpindleData = new MultiSpindlesData().getMultiSpindleFromPackage(package);
                return this;
            }

            return NextTemplate.ProcessPackage(package);
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.NUMBER_OF_SPINDLES, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.SYNC_TIGHTENING_ID, 24, 5, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.TIME, 31, 19),
                                new DataField((int)DataFields.SYNC_OVERALL_STATUS, 52, 1),
                                new DataField((int)DataFields.SPINDLE_STATUS, 55, 5)
                            }
                }
            };
        }

        public enum DataFields
        {
            NUMBER_OF_SPINDLES,
            SYNC_TIGHTENING_ID,
            TIME,
            SYNC_OVERALL_STATUS,
            SPINDLE_STATUS
        }

        public class MultiSpindlesData
        {
            private List<DataField> fields;
            public int NumberOfSpindles { get; set; }
            public int SyncTighteningId { get; set; }
            public DateTime Time { get; set; }
            public bool SyncOverallStatus { get; set; }
            public List<SpindleStatuses> SpindleStatus { get; set; }

            public MultiSpindlesData() { registerFields(); }

            public MultiSpindlesData getMultiSpindleFromPackage(string package)
            {
                processFields(package);
                MultiSpindlesData obj = new MultiSpindlesData();

                obj.NumberOfSpindles = fields[(int)Fields.NUMBER_OF_SPINDLES].ToInt32();
                obj.SyncTighteningId = fields[(int)Fields.SYNC_TIGHTENING_ID].ToInt32();
                obj.Time = fields[(int)Fields.TIME].ToDateTime();
                obj.SyncOverallStatus = fields[(int)Fields.SYNC_OVERALL_STATUS].ToBoolean();
                obj.SpindleStatus = new SpindleStatuses().getSpindleStatuses(package.Substring(fields[(int)Fields.SPINDLE_STATUS].Index));

                return obj;
            }

            public override string ToString()
            {
                string package = string.Empty;

                return base.ToString();
            }

            private void processFields(string package)
            {
                foreach (var field in fields)
                    field.Value = package.Substring(2 + field.Index, field.Size);
            }

            private void registerFields()
            {
                fields = new List<DataField>();
                fields.AddRange(new DataField[] {
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

                public SpindleStatuses() { registerFields(); }

                public List<SpindleStatuses> getSpindleStatuses(string package)
                {
                    List<SpindleStatuses> obj = new List<SpindleStatuses>();
                    int totalSpindles = package.Length / 5;

                    for(int i = 0; i < totalSpindles; i++)
                        obj.Add(new SpindleStatuses()
                        {
                            SpindleNumber = Convert.ToInt32(package.Substring(0 + (i * 5), fields[(int)Fields.SPINDLE_NUMBER].Size)),
                            ChannelId = Convert.ToInt32(package.Substring(2 + (i * 5), fields[(int)Fields.CHANNEL_ID].Size)),
                            SpindleStatus = Convert.ToBoolean(Convert.ToInt32(package.Substring(4 + (i * 5), fields[(int)Fields.SPINDLE_STATUS].Size)))
                        });

                    return obj;
                }

                private void registerFields()
                {
                    fields = new List<DataField>();
                    fields.AddRange(new DataField[] {
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
