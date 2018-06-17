using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// MID: Selector socket info
    /// Description:
    ///     This message is sent each time a socket is lifted or put back in position. 
    ///     This MID contains the device ID of the selector the information is coming from, 
    ///     the number of sockets of the selector device, and the current status of each socket 
    ///     (lifted or not lifted).
    /// Message sent by: Controller
    /// Answer: MID 0252, Selector socket info acknowledge
    /// </summary>
    public class Mid0251 : Mid, IApplicationSelector
    {
        private readonly IValueConverter<int> _intConverter;
        private IValueConverter<IEnumerable<bool>> _boolListConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 251;

        public int DeviceId
        {
            get => GetField(1,(int)DataFields.DEVICE_ID).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.DEVICE_ID).SetValue(_intConverter.Convert, value);
        }
        public int NumberOfSockets
        {
            get => GetField(1,(int)DataFields.NUMBER_OF_SOCKETS).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.NUMBER_OF_SOCKETS).SetValue(_intConverter.Convert, value);
        }
        public List<bool> SocketStatus { get; set; }

        public Mid0251(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag)
        {
            _intConverter = new Int32Converter();
            _boolListConverter = new SocketStatusConverter();
            if (SocketStatus == null)
                SocketStatus = new List<bool>();
        }

        public Mid0251(int deviceId, int numberOfSockets, IEnumerable<bool> socketStatus, int? noAckFlag = 0) : this(noAckFlag)
        {
            DeviceId = deviceId;
            NumberOfSockets = numberOfSockets;
            SocketStatus = socketStatus.ToList();
        }

        internal Mid0251(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string Pack()
        {
            GetField(1,(int)DataFields.SOCKET_STATUS).Size = NumberOfSockets;
            GetField(1,(int)DataFields.SOCKET_STATUS).Value = _boolListConverter.Convert(SocketStatus);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);

                GetField(1,(int)DataFields.SOCKET_STATUS).Size = package.Length - 30;
                ProcessDataFields(package);
                SocketStatus = _boolListConverter.Convert(GetField(1,(int)DataFields.SOCKET_STATUS).Value).ToList();
                return this;
            }

            return NextTemplate.Parse(package);
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.DEVICE_ID, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.NUMBER_OF_SOCKETS, 24, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.SOCKET_STATUS, 28, 0)
                            }
                }
            };
        }

        public enum DataFields
        {
            DEVICE_ID,
            NUMBER_OF_SOCKETS,
            SOCKET_STATUS
        }
    }
}
