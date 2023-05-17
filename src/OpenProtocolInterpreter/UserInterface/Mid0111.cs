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
            get => GetField(1,(int)DataFields.TextDuration).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.TextDuration).SetValue(_intConverter.Convert, value);
        }
        public RemovalCondition RemovalCondition
        {
            get => (RemovalCondition)GetField(1,(int)DataFields.RemovalCondition).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.RemovalCondition).SetValue(_intConverter.Convert, (int)value);
        }
        public string Line1
        {
            get => GetField(1,(int)DataFields.Line1Header).Value;
            set => GetField(1,(int)DataFields.Line1Header).SetValue(value);
        }
        public string Line2
        {
            get => GetField(1,(int)DataFields.Line2).Value;
            set => GetField(1,(int)DataFields.Line2).SetValue(value);
        }
        public string Line3
        {
            get => GetField(1,(int)DataFields.Line3).Value;
            set => GetField(1,(int)DataFields.Line3).SetValue(value);
        }
        public string Line4
        {
            get => GetField(1,(int)DataFields.Line4).Value;
            set => GetField(1,(int)DataFields.Line4).SetValue(value);
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
                                new DataField((int)DataFields.TextDuration, 20, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.RemovalCondition, 26, 1),
                                new DataField((int)DataFields.Line1Header, 29, 25, ' '),
                                new DataField((int)DataFields.Line2, 56, 25, ' '),
                                new DataField((int)DataFields.Line3, 83, 25, ' '),
                                new DataField((int)DataFields.Line4, 110, 25, ' ')
                            }
                }
            };
        }

        protected enum DataFields
        {
            TextDuration,
            RemovalCondition,
            Line1Header,
            Line2,
            Line3,
            Line4
        }
    }
}
