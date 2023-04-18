using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// IO device status request
    /// <para>
    ///     Request for the status of the relays and digital inputs at a device, e.g. an I/O expander. 
    ///     The device is specified by a device number.
    /// </para>    
    /// <para>Message sent by: Integrator</para>
    /// <para>
    /// Answer: <see cref="Mid0215"/> IO device status or
    ///         <see cref="Communication.Mid0004"/> Command error, Faulty IO device ID, or IO device not connected
    /// </para>
    /// </summary>
    public class Mid0214 : Mid, IIOInterface, IIntegrator, IAnswerableBy<Mid0215>, IDeclinableCommand
    {
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 214;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.FAULTY_IO_DEVICE_ID, Error.IO_DEVICE_NOT_CONNECTED };

        public int DeviceNumber
        {
            get => GetField(1,(int)DataFields.DEVICE_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.DEVICE_NUMBER).SetValue(_intConverter.Convert, value);
        }

        public Mid0214() : this(DEFAULT_REVISION)
        {
        }

        public Mid0214(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        public Mid0214(int revision = DEFAULT_REVISION) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        public Mid0214(int deviceNumber, int revision = DEFAULT_REVISION) : this(revision)
        {
            DeviceNumber = deviceNumber;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.DEVICE_NUMBER, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                    }
                }
            };
        }

        public enum DataFields
        {
            DEVICE_NUMBER
        }
    }
}
