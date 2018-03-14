using System;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// MID: Status externally monitored inputs
    /// Description: 
    ///    Status for the eight externally monitored digital inputs. This message is sent to the subscriber every
    ///    time the status of at least one of the inputs has changed.
    /// Message sent by: Controller
    /// Answer: MID 0212 Status externally monitored inputs acknowledge
    /// </summary>
    public class MID_0211 : MID, IIOInterface
    {
        public const int MID = 200;
        private const int length = 30;
        private const int revision = 1;

        public bool StatusDigInOne { get; set; }
        public bool StatusDigInTwo { get; set; }
        public bool StatusDigInThree { get; set; }
        public bool StatusDigInFour { get; set; }
        public bool StatusDigInFive { get; set; }
        public bool StatusDigInSix { get; set; }
        public bool StatusDigInSeven { get; set; }
        public bool StatusDigInEight { get; set; }

        public MID_0211() : base(length, MID, revision)
        {

        }

        internal MID_0211(IMID nextTemplate) : base(length, MID, revision)
        {
            this.NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {
            string package = base.BuildHeader();
            package += $"{Convert.ToInt32(StatusDigInOne)}{Convert.ToInt32(StatusDigInTwo)}{Convert.ToInt32(StatusDigInThree)}{Convert.ToInt32(StatusDigInFour)}";
            package += $"{Convert.ToInt32(StatusDigInFive)}{Convert.ToInt32(StatusDigInSix)}{Convert.ToInt32(StatusDigInSeven)}{Convert.ToInt32(StatusDigInEight)}";
            return package;
        }

        public override MID ProcessPackage(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.HeaderData = base.ProcessHeader(package);

                foreach (var field in base.RegisteredDataFields)
                    field.Value = package.Substring(field.Index, field.Size);

                this.StatusDigInOne = base.RegisteredDataFields[(int)DataFields.STATUS_DIG_IN_1].ToBoolean();
                this.StatusDigInTwo = base.RegisteredDataFields[(int)DataFields.STATUS_DIG_IN_2].ToBoolean();
                this.StatusDigInThree = base.RegisteredDataFields[(int)DataFields.STATUS_DIG_IN_3].ToBoolean();
                this.StatusDigInFour = base.RegisteredDataFields[(int)DataFields.STATUS_DIG_IN_4].ToBoolean();
                this.StatusDigInFive = base.RegisteredDataFields[(int)DataFields.STATUS_DIG_IN_5].ToBoolean();
                this.StatusDigInSix = base.RegisteredDataFields[(int)DataFields.STATUS_DIG_IN_6].ToBoolean();
                this.StatusDigInSeven = base.RegisteredDataFields[(int)DataFields.STATUS_DIG_IN_7].ToBoolean();
                this.StatusDigInEight = base.RegisteredDataFields[(int)DataFields.STATUS_DIG_IN_8].ToBoolean();

                return this;
            }

            return this.NextTemplate.ProcessPackage(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.AddRange(
                new DataField[]
                {
                    new DataField((int)DataFields.STATUS_DIG_IN_1, 20, 1),
                    new DataField((int)DataFields.STATUS_DIG_IN_2, 21, 1),
                    new DataField((int)DataFields.STATUS_DIG_IN_3, 22, 1),
                    new DataField((int)DataFields.STATUS_DIG_IN_4, 23, 1),
                    new DataField((int)DataFields.STATUS_DIG_IN_5, 24, 1),
                    new DataField((int)DataFields.STATUS_DIG_IN_6, 25, 1),
                    new DataField((int)DataFields.STATUS_DIG_IN_7, 26, 1),
                    new DataField((int)DataFields.STATUS_DIG_IN_8, 27, 1)
                });
        }

        public enum DataFields
        {
            STATUS_DIG_IN_1,
            STATUS_DIG_IN_2,
            STATUS_DIG_IN_3,
            STATUS_DIG_IN_4,
            STATUS_DIG_IN_5,
            STATUS_DIG_IN_6,
            STATUS_DIG_IN_7,
            STATUS_DIG_IN_8
        }
    }
}
