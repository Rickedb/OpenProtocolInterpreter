using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// MID: Selector control red lights
    /// Description:
    ///     This message controls the selector red lights. 
    ///     The green light can be set (steady), reset (off) or flash. 
    ///     A command must be sent for each one of the selector positions (1-8).
    ///     
    ///     Note: This MID only works when the selector is put in external controlled mode and 
    ///     this is only possible when the selector is loaded with software 1.20 or later.  
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Faulty IO device ID
    /// </summary>
    public class MID_0255 : Mid, IApplicationSelector
    {
        private readonly IValueConverter<IEnumerable<LightCommand>> _lightsConverter;
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 255;

        public int DeviceId
        {
            get => GetField(1,(int)DataFields.DEVICE_ID).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.DEVICE_ID).SetValue(_intConverter.Convert, value);
        }
        public List<LightCommand> RedLights { get; set; }

        public MID_0255() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
            _lightsConverter = new LightCommandListConverter();
            if (RedLights == null)
                RedLights = new List<LightCommand>();
        }

        public MID_0255(int deviceId, IEnumerable<LightCommand> redLights) : this()
        {
            DeviceId = deviceId;
            RedLights = redLights.ToList();
        }

        internal MID_0255(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        public override string Pack()
        {
            GetField(1,(int)DataFields.RED_LIGHT_COMMAND).Value = _lightsConverter.Convert(RedLights);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                base.Parse(package);
                RedLights = _lightsConverter.Convert(GetField(1,(int)DataFields.RED_LIGHT_COMMAND).Value).ToList();
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
