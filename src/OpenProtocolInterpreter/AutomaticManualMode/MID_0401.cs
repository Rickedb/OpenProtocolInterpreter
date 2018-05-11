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
    public class MID_0401 : Mid, IAutomaticManualMode
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
            ManualAutomaticMode = manualAutomaticMode;
        }

        internal MID_0401(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            return base.BuildHeader() + Convert.ToInt32(ManualAutomaticMode).ToString();
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
            {
                HeaderData = ProcessHeader(package);
                var dataField = base.RegisteredDataFields[(int)DataFields.MANUAL_AUTOMATIC_MODE];
                dataField.Value = package.Substring(dataField.Index, dataField.Size);
                ManualAutomaticMode = dataField.ToBoolean();
                return this;
            }

            return NextTemplate.Parse(package);
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
