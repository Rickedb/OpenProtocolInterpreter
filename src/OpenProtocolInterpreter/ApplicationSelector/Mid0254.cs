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
        public const int MID = 254;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.FaultyIODeviceId };

        public int DeviceId
        {
            get => GetField(1, (int)DataFields.DeviceId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.DeviceId).SetValue(OpenProtocolConvert.ToString, value);
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
            if (GreenLights == null)
                GreenLights = new List<LightCommand>();
        }

        public override string Pack()
        {
            GetField(1, (int)DataFields.GreenLightCommand).Value = PackGreenLights();
            return base.Pack();
        }

        public override Mid Parse(string package)
        {
            base.Parse(package);
            GreenLights = ParseGreenLights(GetField(1, (int)DataFields.GreenLightCommand).Value).ToList();
            return this;
        }

        protected virtual string PackGreenLights()
        {
            string pack = string.Empty;
            foreach (var e in GreenLights)
                pack += OpenProtocolConvert.ToString((int)e);

            return pack;
        }

        protected virtual List<LightCommand> ParseGreenLights(string value)
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
                                new DataField((int)DataFields.GreenLightCommand, 24, 8)
                            }
                }
            };
        }

        protected enum DataFields
        {
            DeviceId,
            GreenLightCommand
        }
    }
}
