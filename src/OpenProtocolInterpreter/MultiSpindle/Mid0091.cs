using System;
using System.Collections.Generic;
using System.Text;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Multi-spindle status
    /// <para>
    ///      The multi-spindle status is sent after each sync tightening. The multiple status contains the common
    ///      status of the multiple as well as the individual status of each spindle.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0092"/> Multi-spindle status acknowledge</para>
    /// </summary>
    public class Mid0091 : Mid, IMultiSpindle, IController, IAcknowledgeable<Mid0092>
    {
        public const int MID = 91;

        public int NumberOfSpindles
        {
            get => GetField(1, DataFields.NumberOfSpindles).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.NumberOfSpindles).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int SyncTighteningId
        {
            get => GetField(1, DataFields.SyncTighteningId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.SyncTighteningId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime Time
        {
            get => GetField(1, DataFields.Time).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, DataFields.Time).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool SyncOverallStatus
        {
            get => GetField(1, DataFields.SyncOverallStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, DataFields.SyncOverallStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<SpindleStatus> SpindlesStatus { get; set; }

        public Mid0091() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0091(Header header) : base(header)
        {
            SpindlesStatus ??= [];
        }

        public override string Pack()
        {
            GetField(1, DataFields.SpindleStatus).Value = PackSpindlesStatus();
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            var spindleField = GetField(1, DataFields.SpindleStatus);
            spindleField.Size = Header.Length - spindleField.Index - 2;
            base.Parse(package);
            SpindlesStatus = ParseSpindlesStatus(spindleField.Value);
            return this;
        }

        //TODO: move to SpindleStatus class
        protected virtual string PackSpindlesStatus()
        {
            var builder = new StringBuilder();
            foreach (var spindle in SpindlesStatus)
                builder.Append(OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, spindle.SpindleNumber) +
                                OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, spindle.ChannelId) +
                                OpenProtocolConvert.ToString(spindle.SyncOverallStatus));

            return builder.ToString();
        }

        protected virtual List<SpindleStatus> ParseSpindlesStatus(string section)
        {
            var list = new List<SpindleStatus>();
            for (int i = 0; i < section.Length; i += 5)
            {
                var obj = new SpindleStatus()
                {
                    SpindleNumber = OpenProtocolConvert.ToInt32(section.Substring(i, 2)),
                    ChannelId = OpenProtocolConvert.ToInt32(section.Substring(i + 2, 2)),
                    SyncOverallStatus = OpenProtocolConvert.ToBoolean(section.Substring(i + 4, 1))
                };

                list.Add(obj);
            }

            return list;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Number(DataFields.NumberOfSpindles, 20, 2),
                                DataField.Number(DataFields.SyncTighteningId, 24, 5),
                                DataField.Timestamp(DataFields.Time, 31),
                                DataField.Boolean(DataFields.SyncOverallStatus, 52),
                                new(DataFields.SpindleStatus, 55, 5)
                            }
                }
            };
        }

        protected enum DataFields
        {
            NumberOfSpindles,
            SyncTighteningId,
            Time,
            SyncOverallStatus,
            SpindleStatus
        }
    }
}
