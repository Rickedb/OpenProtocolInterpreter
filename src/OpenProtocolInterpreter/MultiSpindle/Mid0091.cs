using System;
using System.Collections.Generic;

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
            get => GetField(1, (int)DataFields.NumberOfSpindles).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.NumberOfSpindles).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int SyncTighteningId
        {
            get => GetField(1, (int)DataFields.SyncTighteningId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.SyncTighteningId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime Time
        {
            get => GetField(1, (int)DataFields.Time).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, (int)DataFields.Time).SetValue(OpenProtocolConvert.ToString, value);
        }
        public bool SyncOverallStatus
        {
            get => GetField(1, (int)DataFields.SyncOverallStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, (int)DataFields.SyncOverallStatus).SetValue(OpenProtocolConvert.ToString, value);
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
            if (SpindlesStatus == null)
                SpindlesStatus = new List<SpindleStatus>();
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.SpindleStatus).Value = PackSpindlesStatus();
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            var spindleField = GetField(1, (int)DataFields.SpindleStatus);
            spindleField.Size = Header.Length - spindleField.Index - 2;
            base.Parse(package);
            SpindlesStatus = ParseSpindlesStatus(spindleField.Value);
            return this;
        }

        protected virtual string PackSpindlesStatus()
        {
            string pack = string.Empty;
            foreach (var spindle in SpindlesStatus)
                pack += OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, spindle.SpindleNumber) +
                           OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, spindle.ChannelId) +
                           OpenProtocolConvert.ToString(spindle.SyncOverallStatus);

            return pack;
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
                                new DataField((int)DataFields.NumberOfSpindles, 20, 2, '0', PaddingOrientation.LeftPadded),
                                new DataField((int)DataFields.SyncTighteningId, 24, 5, '0', PaddingOrientation.LeftPadded),
                                new DataField((int)DataFields.Time, 31, 19),
                                new DataField((int)DataFields.SyncOverallStatus, 52, 1),
                                new DataField((int)DataFields.SpindleStatus, 55, 5)
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
