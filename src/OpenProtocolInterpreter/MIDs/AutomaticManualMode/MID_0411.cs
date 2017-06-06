using System;

namespace OpenProtocolInterpreter.MIDs.AutomaticManualMode
{
    /// <summary>
    /// MID: AutoDisable settings reply
    /// Description: 
    ///     Information about the setting of AutoDisable tightening in the controller. Also contains information about the currently running batch.
    ///     The settings are reserved for single parameter sets with batch and are not available while running Job.
    ///     Power Macs use:
    ///     “OKs to disable station” is a parameter in Tools Talk PowerMACS and specifies the number of cycles with status OK or OKR that may be run while in Automatic mode before the station is automatically disabled. It is sent as two ASCII digits, a 0 means the function is not in use.
    ///     “Current Batch” is two ASCII digits representing the number of OK cycles that have been run in the current batch.If the value is 0 no batch is running at the moment.
    ///     Power Focus use:
    ///     The “Current Batch” contains at which batch counter value/tightening the parameter set batch was
    ///     locked/finished if “batch count” and “lock at batch ok” parameters in Tools Talk PF was used,
    ///     otherwise it will contain 0 indicating function not used.If “lock at batch ok” parameter was not used
    ///     the “Current Batch” is just current.
    ///     The “Auto Disable” contains the parameter sets batch size if “batch count” and “lock at batch ok”
    ///     parameters was used indicating that Auto Disable function is used.If “batch count” or “lock at batch
    ///     ok” was not used the “Auto Disable” is 0.
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0411 : MID, IAutomaticManualMode
    {
        public const int MID = 411;
        private const int length = 21;
        private const int revision = 1;

        public int AutoDisableSetting { get; set; }
        public int CurrentBatch { get; set; }

        public MID_0411() : base(length, MID, revision) { }

        internal MID_0411(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            return base.buildHeader() + 
                this.AutoDisableSetting.ToString().PadLeft(base.RegisteredDataFields[(int)DataFields.AUTO_DISABLE_SETTING].Size, '0') + 
                this.CurrentBatch.ToString().PadLeft(base.RegisteredDataFields[(int)DataFields.CURRENT_BATCH].Size, '0');
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                this.HeaderData = this.processHeader(package);
                this.AutoDisableSetting = Convert.ToInt32(package.Substring(base.RegisteredDataFields[(int)DataFields.AUTO_DISABLE_SETTING].Index, base.RegisteredDataFields[(int)DataFields.AUTO_DISABLE_SETTING].Size));
                this.CurrentBatch = Convert.ToInt32(package.Substring(base.RegisteredDataFields[(int)DataFields.CURRENT_BATCH].Index, base.RegisteredDataFields[(int)DataFields.CURRENT_BATCH].Size));
                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.AUTO_DISABLE_SETTING, 20, 2));
            this.RegisteredDataFields.Add(new DataField((int)DataFields.CURRENT_BATCH, 22, 2));
        }

        public enum DataFields
        {
            AUTO_DISABLE_SETTING,
            CURRENT_BATCH
        }
    }
}
