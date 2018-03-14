using System;

namespace OpenProtocolInterpreter.Alarm
{

    /// <summary>
    /// MID: Alarm acknowledged on controller
    /// Description: 
    ///      The message is sent by the controller to inform the integrator that the current alarm has been
    ///      acknowledged.
    /// Message sent by: Controller
    /// Answer: MID 0075 Alarm acknowledged on controller acknowledge
    /// </summary>
    public class MID_0074 : MID, IAlarm
    {
        public const int MID = 74;
        private const int length = 24;
        private const int revision = 1;

        public string ErrorCode { get; set; }

        public MID_0074() : base(length, MID, revision) { }

        public MID_0074(string errorCode) : base(length, MID, revision)
        {
            this.ErrorCode = errorCode;
        }

        internal MID_0074(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            if (string.IsNullOrEmpty(this.ErrorCode) || this.ErrorCode.Length != 4)
                throw new ArgumentNullException("ErrorCode cannot be null and should have 4 characters");

            return base.BuildHeader() + this.ErrorCode.ToString();
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                this.HeaderData = this.ProcessHeader(package);
                var dataField = base.RegisteredDataFields[(int)DataFields.ERROR_CODE];
                this.ErrorCode = package.Substring(dataField.Index, dataField.Size);
                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.ERROR_CODE, 20, 4));
        }

        public enum DataFields
        {
            ERROR_CODE
        }
    }
}
