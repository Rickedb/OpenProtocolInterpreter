using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: IO device status request
    /// Description: 
    ///     Request for the status of the relays and digital inputs at a device, e.g. an I/O expander. 
    ///     The device is specified by a device number.
    /// Message sent by: Integrator
    /// Answer: MID 0215 IO device status or
    ///         MID 0004 Command error,
    ///         Faulty IO device ID, or IO device not connected
    /// </summary>
    public class Mid0214 : Mid, IIOInterface
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 2;
        public const int MID = 214;

        public int DeviceNumber
        {
            get => GetField(1,(int)DataFields.DEVICE_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.DEVICE_NUMBER).SetValue(_intConverter.Convert, value);
        }

        public Mid0214(int revision = LAST_REVISION) : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
        }

        public Mid0214(int deviceNumber, int revision = LAST_REVISION) : this(revision)
        {
            DeviceNumber = deviceNumber;
        }

        internal Mid0214(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.DEVICE_NUMBER, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                    }
                },
                { 2, new List<DataField>() }
            };
        }

        public enum DataFields
        {
            DEVICE_NUMBER
        }
    }
}
