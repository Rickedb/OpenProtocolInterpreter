using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// Selector control green lights
    /// <para>    
    ///     This message controls the selector green lights. 
    ///     The green light can be set (steady), reset (off) or flash. 
    ///     A command must be sent for each one of the selector positions (1-8).
    /// </para>
    /// <para>
    ///     Note: This MID only works when the selector is put in external controlled mode and 
    ///     this is only possible when the selector is loaded with software 1.20 or later.  
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, Faulty IO device ID</para>
    /// </summary>
    public class Mid0254 : Mid, IApplicationSelector, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        private readonly IValueConverter<IEnumerable<LightCommand>> _lightsConverter;
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 254;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.FAULTY_IO_DEVICE_ID };

        public int DeviceId
        {
            get => GetField(1, (int)DataFields.DEVICE_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.DEVICE_ID).SetValue(_intConverter.Convert, value);
        }
        public List<LightCommand> GreenLights { get; set; }

        public Mid0254() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0254(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
            _lightsConverter = new LightCommandListConverter(_intConverter);
            if (GreenLights == null)
                GreenLights = new List<LightCommand>();
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.GREEN_LIGHT_COMMAND).Value = _lightsConverter.Convert(GreenLights);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            base.Parse(package);
            GreenLights = _lightsConverter.Convert(GetField(1, (int)DataFields.GREEN_LIGHT_COMMAND).Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.DEVICE_ID, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.GREEN_LIGHT_COMMAND, 24, 8)
                            }
                }
            };
        }

        protected enum DataFields
        {
            DEVICE_ID,
            GREEN_LIGHT_COMMAND
        }
    }
}
