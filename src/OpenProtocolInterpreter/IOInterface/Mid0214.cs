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
        public const int MID = 214;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.FaultyIODeviceId, Error.IODeviceNotConnected };

        [Int32DataFieldDefinition(field: 0, revision: 1, Size = 2, HasPrefix = false)]
        public int DeviceNumber
        {
            get => GetField(1, DataFields.DeviceNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.DeviceNumber).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0214() : this(DEFAULT_REVISION)
        {
        }

        public Mid0214(Header header) : base(header)
        {
        }

        public Mid0214(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        protected enum DataFields
        {
            DeviceNumber
        }
    }
}
