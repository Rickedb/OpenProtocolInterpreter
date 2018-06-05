using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// MID: Selector control green lights
    /// Description:
    ///     This message controls the selector green lights. 
    ///     The green light can be set (steady), reset (off) or flash. 
    ///     A command must be sent for each one of the selector positions (1-8).
    ///     
    ///     Note: This MID only works when the selector is put in external controlled mode and 
    ///     this is only possible when the selector is loaded with software 1.20 or later.  
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, Faulty IO device ID
    /// </summary>
    public class MID_0254 : Mid, IApplicationSelector
    {
        private readonly IValueConverter<IEnumerable<LightCommand>> _lightsConverter;
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 254;

        public int DeviceId
        {
            get => GetField(1,(int)DataFields.DEVICE_ID).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.DEVICE_ID).SetValue(_intConverter.Convert, value);
        }
        public List<LightCommand> GreenLights { get; set; }

        public MID_0254() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
            _lightsConverter = new LightCommandListConverter();
            if (GreenLights == null)
                GreenLights = new List<LightCommand>();
        }

        public MID_0254(int deviceId, IEnumerable<LightCommand> greenLights) : this()
        {
            DeviceId = deviceId;
            GreenLights = greenLights.ToList();
        }

        internal MID_0254(IMid nextTemplate) : base(MID, LAST_REVISION) => NextTemplate = nextTemplate;

        public override string Pack()
        {
            GetField(1,(int)DataFields.GREEN_LIGHT_COMMAND).Value = _lightsConverter.Convert(GreenLights);
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            if (IsCorrectType(package))
            {
                base.Parse(package);
                GreenLights = _lightsConverter.Convert(GetField(1,(int)DataFields.GREEN_LIGHT_COMMAND).Value).ToList();
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
                                new DataField((int)DataFields.GREEN_LIGHT_COMMAND, 24, 8)
                            }
                }
            };
        }

        public enum DataFields
        {
            DEVICE_ID,
            GREEN_LIGHT_COMMAND
        }
    }
}
