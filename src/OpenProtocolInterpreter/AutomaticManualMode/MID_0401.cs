using System;

namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// MID: Automatic/Manual mode
    /// Description: 
    ///     The operation mode in the controller has changed. 
    ///     The message includes the new operational mode of the controller.
    /// Message sent by: Controller
    /// Answer: MID 0402 Automatic/Manual mode acknowledge
    /// </summary>
    public class MID_0401 : MID, IAutomaticManualMode
    {
        public const int MID = 401;
        private const int length = 21;
        private const int revision = 1;

        /// <summary>
        /// <para>Automatic Mode = false (0)</para>
        /// <para>Manual Mode = true (1)</para>
        /// </summary>
        public bool ManualAutomaticMode{ get; set; }

        public MID_0401() : base(length, MID, revision) { }

        public MID_0401(bool manualAutomaticMode) : base(length, MID, revision)
        {
            this.ManualAutomaticMode = manualAutomaticMode;
        }

        internal MID_0401(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            return base.BuildHeader() + Convert.ToInt32(this.ManualAutomaticMode).ToString();
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                this.HeaderData = this.ProcessHeader(package);
                var dataField = base.RegisteredDataFields[(int)DataFields.MANUAL_AUTOMATIC_MODE];
                dataField.Value = package.Substring(dataField.Index, dataField.Size);
                this.ManualAutomaticMode = dataField.ToBoolean();
                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.MANUAL_AUTOMATIC_MODE, 20, 1));
        }



        public enum DataFields
        {
            MANUAL_AUTOMATIC_MODE
        }
    }
}
