using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.UserInterface
{
    /// <summary>
    /// MID: Display user text on graph
    /// Description: 
    ///     By sending this message the integrator can display a text on the graphic display. 
    ///     The user can furthermore set the time for the text to be displayed and if the text 
    ///     should be acknowledged by the operator or not.
    ///     The text is divided into four lines with 25 ASCII characters each.If a line is shorter 
    ///     than 25 characters it must be right padded with blanks(SPC 0x20).
    ///     The first line is the text header and is in upper character.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, User text could not be displayed
    /// </summary>
    public class MID_0111 : Mid, IUserInterface
    {
        private const int length = 137;
        public const int MID = 111;
        private const int revision = 1;

        public int TextDuration { get; set; }
        public RemovalConditions RemovalCondition { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Line4 { get; set; }

        public MID_0111() : base(length, MID, revision)
        {

        }

        internal MID_0111(IMid nextTemplate) : base(length, MID, revision)
        {
            NextTemplate = nextTemplate;
        }

        public override string BuildPackage()
        {

            base.RegisteredDataFields[(int)DataFields.TEXT_DURATION].Value = TextDuration;
            base.RegisteredDataFields[(int)DataFields.REMOVAL_CONDITION].Value = (int)RemovalCondition;
            base.RegisteredDataFields[(int)DataFields.LINE_1_HEADER].Value = Line1.PadLeft(25, ' ');
            base.RegisteredDataFields[(int)DataFields.LINE_2].Value = Line2.PadLeft(25, ' ');
            base.RegisteredDataFields[(int)DataFields.LINE_3].Value = Line3.PadLeft(25, ' ');
            base.RegisteredDataFields[(int)DataFields.LINE_4].Value = Line4.PadLeft(25, ' ');

            return base.BuildPackage();
        }

        public override Mid Parse(string package)
        {
            if (base.IsCorrectType(package))
            {
                base.Parse(package);

                TextDuration = base.RegisteredDataFields[(int)DataFields.TEXT_DURATION].ToInt32();
                RemovalCondition = (RemovalConditions)base.RegisteredDataFields[(int)DataFields.REMOVAL_CONDITION].ToInt32();
                Line1 = base.RegisteredDataFields[(int)DataFields.LINE_1_HEADER].Value.ToString();
                Line2 = base.RegisteredDataFields[(int)DataFields.LINE_2].Value.ToString();
                Line3 = base.RegisteredDataFields[(int)DataFields.LINE_3].Value.ToString();
                Line4 = base.RegisteredDataFields[(int)DataFields.LINE_4].Value.ToString();

                return this;
            }

            return NextTemplate.Parse(package);
        }

        protected override void RegisterDatafields()
        {
            this.RegisteredDataFields.AddRange(
                    new DataField[]
                    {
                            new DataField((int)DataFields.TEXT_DURATION, 20, 4),
                            new DataField((int)DataFields.REMOVAL_CONDITION, 26, 1),
                            new DataField((int)DataFields.LINE_1_HEADER, 29, 25),
                            new DataField((int)DataFields.LINE_2, 56, 25),
                            new DataField((int)DataFields.LINE_3, 83, 25),
                            new DataField((int)DataFields.LINE_4, 110, 25)
                    });
        }

        public enum RemovalConditions
        {
            ACKNOWLEDGE_OR_WAIT_EXPIRATION_TIME = 0,
            ACKNOWLEDGE = 1
        }

        public enum DataFields
        {
            TEXT_DURATION,
            REMOVAL_CONDITION,
            LINE_1_HEADER,
            LINE_2,
            LINE_3,
            LINE_4
        }
    }
}
