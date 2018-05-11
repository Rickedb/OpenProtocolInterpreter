using OpenProtocolInterpreter.Converters;
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
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 111;
        
        public int TextDuration
        {
            get => RevisionsByFields[1][(int)DataFields.TEXT_DURATION].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.TEXT_DURATION].SetValue(_intConverter.Convert, value);
        }
        public RemovalCondition RemovalCondition
        {
            get => (RemovalCondition)RevisionsByFields[1][(int)DataFields.REMOVAL_CONDITION].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.REMOVAL_CONDITION].SetValue(_intConverter.Convert, (int)value);
        }
        public string Line1
        {
            get => RevisionsByFields[1][(int)DataFields.LINE_1_HEADER].Value;
            set => RevisionsByFields[1][(int)DataFields.LINE_1_HEADER].SetValue(value);
        }
        public string Line2
        {
            get => RevisionsByFields[1][(int)DataFields.LINE_2].Value;
            set => RevisionsByFields[1][(int)DataFields.LINE_2].SetValue(value);
        }
        public string Line3
        {
            get => RevisionsByFields[1][(int)DataFields.LINE_3].Value;
            set => RevisionsByFields[1][(int)DataFields.LINE_3].SetValue(value);
        }
        public string Line4
        {
            get => RevisionsByFields[1][(int)DataFields.LINE_4].Value;
            set => RevisionsByFields[1][(int)DataFields.LINE_4].SetValue(value);
        }

        public MID_0111() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
        }

        public MID_0111(int textDuration, RemovalCondition removalCondition, string line1, string line2, string line3, string line4) : this()
        {
            TextDuration = textDuration;
            RemovalCondition = removalCondition;
            Line1 = line1;
            Line2 = line2;
            Line3 = line3;
            Line4 = line4;
        }

        internal MID_0111(IMid nextTemplate) : this() => NextTemplate = nextTemplate;


        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.TEXT_DURATION, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.REMOVAL_CONDITION, 26, 1),
                                new DataField((int)DataFields.LINE_1_HEADER, 29, 25, ' '),
                                new DataField((int)DataFields.LINE_2, 56, 25, ' '),
                                new DataField((int)DataFields.LINE_3, 83, 25, ' '),
                                new DataField((int)DataFields.LINE_4, 110, 25, ' ')
                            }
                }
            };
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
