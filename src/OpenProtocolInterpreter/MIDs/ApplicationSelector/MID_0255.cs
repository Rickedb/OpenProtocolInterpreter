using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MIDs.ApplicationSelector
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
    public class MID_0255 : MID, IApplicationSelector
    {
        private const int length = 34;
        public const int MID = 255;
        private const int revision = 1;

        public int DeviceID { get; set; }
        public List<RedLightCommand> RedLights { get; set; }

        public MID_0255() : base(length, MID, revision) { this.RedLights = new List<RedLightCommand>(); }

        internal MID_0255(IMID nextTemplate) : base(length, MID, revision)
        {
            this.RedLights = new List<RedLightCommand>();
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            if (this.DeviceID > 99)
                throw new ArgumentException("Device ID must be in 00-99 range!!");

            this.RegisteredDataFields[(int)DataFields.DEVICE_ID].Value = this.DeviceID.ToString().PadLeft(this.RegisteredDataFields[(int)DataFields.DEVICE_ID].Size, '0');
            string statuses = string.Empty;
            this.RedLights.ForEach(x => statuses += ((int)x).ToString());
            this.RegisteredDataFields[(int)DataFields.RED_LIGHT_COMMAND].Value = statuses;
            return base.buildPackage();
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processPackage(package);
                this.DeviceID = this.RegisteredDataFields[(int)DataFields.DEVICE_ID].ToInt32();
                this.RedLights = this.getGreenLightCommands(package.Substring(this.RegisteredDataFields[(int)DataFields.RED_LIGHT_COMMAND].Index));
                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        private List<RedLightCommand> getGreenLightCommands(string package)
        {
            List<RedLightCommand> statuses = new List<RedLightCommand>();
            foreach (var status in package)
                statuses.Add((RedLightCommand)Convert.ToInt32(status));

            return statuses;
        }

        protected override void registerDatafields()
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
