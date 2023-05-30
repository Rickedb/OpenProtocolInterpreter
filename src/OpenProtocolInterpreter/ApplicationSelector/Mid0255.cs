using System.Collections.Generic;

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
    public class Mid0255 : Mid, IApplicationSelector, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 255;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.FaultyIODeviceId };

        public int DeviceId
        {
            get => GetField(1, (int)DataFields.DeviceId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.DeviceId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<LightCommand> RedLights { get; set; }

        public Mid0255() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
           
        }

        public Mid0255(Header header) : base(header)
        {
            if (RedLights == null)
                RedLights = new List<LightCommand>();
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.RedLightCommand).Value = PackRedLights();
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            base.Parse(package);
            RedLights = ParseRedLights(GetField(1, (int)DataFields.RedLightCommand).Value);
            return this;
        }

        protected virtual string PackRedLights()
        {
            string pack = string.Empty;
            foreach (var e in RedLights)
                pack += OpenProtocolConvert.ToString((int)e);

            return pack;
        }

        protected virtual List<LightCommand> ParseRedLights(string value)
        {
            var list = new List<LightCommand>();
            foreach (var c in value)
                list.Add((LightCommand)OpenProtocolConvert.ToInt32(c.ToString()));

            return list;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.DeviceId, 20, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.RedLightCommand, 24, 8)
                            }
                }
            };
        }

        protected enum DataFields
        {
            DeviceId,
            RedLightCommand
        }
    }
}
