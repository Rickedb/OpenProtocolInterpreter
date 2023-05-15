using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.UserInterface
{
    /// <summary>
    /// Display user text on graph
    /// <para>
    ///     By sending this message the integrator can display a text on the graphic display. 
    ///     The user can furthermore set the time for the text to be displayed and if the text 
    ///     should be acknowledged by the operator or not.
    /// </para>
    /// <para>
    ///     The text is divided into four lines with 25 ASCII characters each.If a line is shorter 
    ///     than 25 characters it must be right padded with blanks(SPC 0x20).
    /// </para>
    /// <para>The first line is the text header and is in upper character.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///             <see cref="Communication.Mid0004"/> Command error, User text could not be displayed
    /// </para>
    /// </summary>
    public class Mid0111 : Mid, IUserInterface, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 111;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { };

        public int TextDuration
        {
            get => GetField(1,(int)DataFields.TEXT_DURATION).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.TEXT_DURATION).SetValue(_intConverter.Convert, value);
        }
        public RemovalCondition RemovalCondition
        {
            get => (RemovalCondition)GetField(1,(int)DataFields.REMOVAL_CONDITION).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.REMOVAL_CONDITION).SetValue(_intConverter.Convert, (int)value);
        }
        public string Line1
        {
            get => GetField(1,(int)DataFields.LINE_1_HEADER).Value;
            set => GetField(1,(int)DataFields.LINE_1_HEADER).SetValue(value);
        }
        public string Line2
        {
            get => GetField(1,(int)DataFields.LINE_2).Value;
            set => GetField(1,(int)DataFields.LINE_2).SetValue(value);
        }
        public string Line3
        {
            get => GetField(1,(int)DataFields.LINE_3).Value;
            set => GetField(1,(int)DataFields.LINE_3).SetValue(value);
        }
        public string Line4
        {
            get => GetField(1,(int)DataFields.LINE_4).Value;
            set => GetField(1,(int)DataFields.LINE_4).SetValue(value);
        }

        public Mid0111() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0111(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

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

        protected enum DataFields
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
