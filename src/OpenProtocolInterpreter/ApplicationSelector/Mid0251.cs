using System.Collections.Generic;
using System.Text;

namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// Selector socket info
    /// <para>
    ///     This message is sent each time a socket is lifted or put back in position. 
    ///     This MID contains the device ID of the selector the information is coming from, 
    ///     the number of sockets of the selector device, and the current status of each socket 
    ///     (lifted or not lifted).
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0252"/>, Selector socket info acknowledge</para>
    /// </summary>
    public class Mid0251 : Mid, IApplicationSelector, IController, IAcknowledgeable<Mid0252>
    {
        public const int MID = 251;

        public int DeviceId
        {
            get => GetField(1, DataFields.DeviceId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.DeviceId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int NumberOfSockets
        {
            get => GetField(1, DataFields.NumberOfSockets).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.NumberOfSockets).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<bool> SocketStatus { get; set; }

        public Mid0251() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0251(Header header) : base(header)
        {
            SocketStatus ??= [];
        }

        public override string Pack()
        {
            GetField(1, DataFields.SocketStatus).Size = NumberOfSockets;
            GetField(1, DataFields.SocketStatus).Value = PackSocketStatus();
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);

            GetField(1, DataFields.SocketStatus).Size = Header.Length - 30;
            ProcessDataFields(package);
            SocketStatus = ParseSocketStatus(GetField(1, DataFields.SocketStatus).Value);
            return this;
        }

        protected virtual string PackSocketStatus()
        {
            var builder = new StringBuilder(SocketStatus.Count);
            foreach (var v in SocketStatus)
                builder.Append(OpenProtocolConvert.ToString(v));

            return builder.ToString();
        }

        protected virtual List<bool> ParseSocketStatus(string section)
        {
            var list = new List<bool>();
            foreach (var c in section)
                list.Add(OpenProtocolConvert.ToBoolean(c.ToString()));

            return list;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Number(DataFields.DeviceId, 20, 2),
                                DataField.Number(DataFields.NumberOfSockets, 24, 2),
                                DataField.Volatile(DataFields.SocketStatus, 28)
                            }
                }
            };
        }

        protected enum DataFields
        {
            DeviceId,
            NumberOfSockets,
            SocketStatus
        }
    }
}
