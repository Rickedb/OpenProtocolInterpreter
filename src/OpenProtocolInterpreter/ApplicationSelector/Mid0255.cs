using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// Selector control red lights
    /// <para>
    ///     This message controls the selector red lights. 
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
    public class Mid0255 : Mid, IApplicationSelector, IIntegrator
    {
        private readonly IValueConverter<IEnumerable<LightCommand>> _lightsConverter;
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 255;

        public int DeviceId
        {
            get => GetField(1, (int)DataFields.DEVICE_ID).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.DEVICE_ID).SetValue(_intConverter.Convert, value);
        }
        public List<LightCommand> RedLights { get; set; }

        public Mid0255() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
            _lightsConverter = new LightCommandListConverter(_intConverter);
            if (RedLights == null)
                RedLights = new List<LightCommand>();
        }

        public Mid0255(int deviceId, IEnumerable<LightCommand> redLights) : this()
        {
            DeviceId = deviceId;
            RedLights = redLights.ToList();
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.RED_LIGHT_COMMAND).Value = _lightsConverter.Convert(RedLights);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            base.Parse(package);
            RedLights = _lightsConverter.Convert(GetField(1, (int)DataFields.RED_LIGHT_COMMAND).Value).ToList();
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
                                new DataField((int)DataFields.RED_LIGHT_COMMAND, 24, 8)
                            }
                }
            };
        }

        public enum DataFields
        {
            DEVICE_ID,
            RED_LIGHT_COMMAND
        }
    }
}
