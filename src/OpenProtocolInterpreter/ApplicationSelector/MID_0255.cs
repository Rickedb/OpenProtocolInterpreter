using System;
using System.Collections.Generic;

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
        private const int length = 34;
        public const int MID = 255;
        private const int revision = 1;

        public int DeviceID { get; set; }
        public List<RedLightCommand> RedLights { get; set; }

        public MID_0255() : base(length, MID, revision) { RedLights = new List<RedLightCommand>(); }

        internal MID_0255(IMid nextTemplate) : base(length, MID, revision)
        {
            RedLights = new List<RedLightCommand>();
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            if (DeviceID > 99)
                throw new ArgumentException("Device ID must be in 00-99 range!!");

            this.RegisteredDataFields[(int)DataFields.DEVICE_ID].Value = DeviceID.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.DEVICE_ID].Size, '0');
            string statuses = string.Empty;
            RedLights.ForEach(x => statuses += ((int)x).ToString());
            this.RegisteredDataFields[(int)DataFields.RED_LIGHT_COMMAND].Value = statuses;
            return base.BuildPackage();
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.Parse(package);
                DeviceID = this.RegisteredDataFields[(int)DataFields.DEVICE_ID].ToInt32();
                RedLights = getGreenLightCommands(package.Substring(this.RegisteredDataFields[(int)DataFields.RED_LIGHT_COMMAND].Index));
                return this;
            }

            return NextTemplate.Parse(package);
        }

        private List<RedLightCommand> getGreenLightCommands(string package)
        {
            List<RedLightCommand> statuses = new List<RedLightCommand>();
            foreach (var status in package)
                statuses.Add((RedLightCommand)Convert.ToInt32(status));

            return statuses;
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.AddRange(
                new DataField[]
                {
                    new DataField((int)DataFields.DEVICE_ID, 20, 2),
                    new DataField((int)DataFields.RED_LIGHT_COMMAND, 24, 2)
                });
        }

        public enum RedLightCommand
        {
            OFF = 0,
            STEADY = 1,
            FLASHING = 2
        }

        public enum DataFields
        {
            DEVICE_ID,
            RED_LIGHT_COMMAND
        }
    }
}
