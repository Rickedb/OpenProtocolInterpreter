using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

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
    public class MID_0251 : Mid, IApplicationSelector
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<bool> _boolConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 251;

        public int DeviceID { get; set; }
        public int NumberOfSockets { get; set; }
        public List<bool> SocketStatuses { get; set; }

        public MID_0251(int? noAckFlag = 1) : base(MID, LAST_REVISION, noAckFlag)
        {
            SocketStatuses = new List<bool>();
            _intConverter = new Int32Converter();
            _boolConverter = new BoolConverter();
        }

        internal MID_0251(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string Pack()
        {
            if (DeviceID > 99)
                throw new ArgumentException("Device ID must be in 00-99 range!!");

            this.RegisteredDataFields[(int)DataFields.DEVICE_ID].Value = DeviceID.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.DEVICE_ID].Size, '0');
            this.RegisteredDataFields[(int)DataFields.NUMBER_OF_SOCKETS].Value = NumberOfSockets.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.NUMBER_OF_SOCKETS].Size, '0');
            string statuses = string.Empty;
            SocketStatuses.ForEach(x => statuses += Convert.ToInt32(x).ToString());
            this.RegisteredDataFields[(int)DataFields.SOCKET_STATUS].Value = statuses;
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.Parse(package);
                DeviceID = this.RegisteredDataFields[(int)DataFields.DEVICE_ID].ToInt32();
                NumberOfSockets = this.RegisteredDataFields[(int)DataFields.NUMBER_OF_SOCKETS].ToInt32();
                SocketStatuses = getSocketStatus(package.Substring(this.RegisteredDataFields[(int)DataFields.NUMBER_OF_SOCKETS].Index));
                return this;
            }

            return NextTemplate.Parse(package);
        }

        private List<bool> getSocketStatus(string package)
        {
            List<bool> statuses = new List<bool>();
            foreach(var status in package)
                statuses.Add(status == '1');

            return statuses;
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.AddRange(
                new DataField[]
                {
                    new DataField((int)DataFields.DEVICE_ID, 20, 2),
                    new DataField((int)DataFields.NUMBER_OF_SOCKETS, 24, 2),
                    new DataField((int)DataFields.SOCKET_STATUS, 28, 0)
                });
        }

        public enum DataFields
        {
            DEVICE_ID,
            NUMBER_OF_SOCKETS,
            SOCKET_STATUS
        }
    }
}
