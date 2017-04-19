using System;

namespace OpenProtocolInterpreter.MIDs.Time
{
    /// <summary>
    /// MID: Set Time
    /// Description: 
    ///     Set the time in the controller.
    /// 
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0082 : MID, ITime
    {
        private const int length = 39;
        private const int mid = 81;
        private const int revision = 1;

        public DateTime Time { get; set; }

        public MID_0082() : base(length, mid, revision)
        {

        }

        public MID_0082(IMID nextTemplate) : base(length, mid, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            string package = base.buildHeader();
            package += this.Time.ToString("yyyy-MM-dd:HH:mm:ss");
            return base.buildPackage();
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                base.processHeader(package);
                this.RegisteredDataFields[(int)DataFields.TIME].Value = package.Substring(this.RegisteredDataFields[(int)DataFields.TIME].Index, this.RegisteredDataFields[(int)DataFields.TIME].Size);
                this.Time = this.RegisteredDataFields[(int)DataFields.TIME].ToDateTime();
                return this;
            }

            throw new NotImplementedException("MID not implemented or doesn't exists");
        }

        protected override void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.TIME, 20, 19));
        }

        public enum DataFields
        {
            TIME
        }
    }
}
