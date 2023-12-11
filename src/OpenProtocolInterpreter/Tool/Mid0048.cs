using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Tool Pairing status
    /// <para>This message is sent by the controller in order to report the current status of the tool pairing.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0048 : Mid, ITool, IController
    {
        public const int MID = 48;

        public PairingStatus PairingStatus
        {
            get => (PairingStatus)GetField(1, DataFields.PairingStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.PairingStatus).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DateTime TimeStamp
        {
            get => GetField(1, DataFields.Timestamp).GetValue(OpenProtocolConvert.ToDateTime);
            set => GetField(1, DataFields.Timestamp).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0048() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0048(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Number(DataFields.PairingStatus, 20, 2),
                                DataField.Timestamp(DataFields.Timestamp, 24)
                            }
                }
            };
        }

        protected enum DataFields
        {
            PairingStatus,
            Timestamp
        }
    }
}
