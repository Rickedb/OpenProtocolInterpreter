using System;

namespace OpenProtocolInterpreter.Time
{
    /// <summary>
    /// MID: Read time upload reply
    /// Description: 
    ///     Time upload reply from the controller.
    /// 
    /// Message sent by: Controller
    /// Answer: None
    /// </summary>
    public class MID_0081 : MID, ITime
    {
        private const int length = 39;
        public const int MID = 81;
        private const int revision = 1;

        public DateTime Time { get; set; }

        public MID_0081() : base(length, MID, revision) {  }

        internal MID_0081(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            string package = base.BuildHeader();
            package += this.Time.ToString("yyyy-MM-dd:HH:mm:ss");
            return base.BuildPackage();
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.ProcessHeader(package);
                this.RegisteredDataFields[(int)DataFields.TIME].Value = package.Substring(this.RegisteredDataFields[(int)DataFields.TIME].Index, this.RegisteredDataFields[(int)DataFields.TIME].Size);
                this.Time = this.RegisteredDataFields[(int)DataFields.TIME].ToDateTime();
                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }


        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.TIME, 20, 19));
        }

        public enum DataFields
        {
            TIME
        }
    }
}
