using System;

namespace OpenProtocolInterpreter.Time
{
    /// <summary>
    /// MID: Set Time
    /// Description: 
    ///     Set the time in the controller.
    /// 
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0082 : Mid, ITime
    {
        private const int length = 39;
        public const int MID = 82;
        private const int revision = 1;

        public DateTime Time { get; set; }

        public MID_0082() : base(length, MID, revision)
        {

        }

        internal MID_0082(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            string package = base.BuildHeader();
            package += Time.ToString("yyyy-MM-dd:HH:mm:ss");
            return package;
        }

        public override Mid ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.ProcessHeader(package);
                this.RegisteredDataFields[(int)DataFields.TIME].Value = package.Substring(this.RegisteredDataFields[(int)DataFields.TIME].Index, this.RegisteredDataFields[(int)DataFields.TIME].Size);
                Time = this.RegisteredDataFields[(int)DataFields.TIME].ToDateTime();
                return this;
            }

            return NextTemplate.ProcessPackage(package);
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
