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
        public const int MID = 111;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { };

        public int TextDuration
        {
            get => GetField(1, DataFields.TextDuration).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.TextDuration).SetValue(OpenProtocolConvert.ToString, value);
        }
        public RemovalCondition RemovalCondition
        {
            get => (RemovalCondition)GetField(1, DataFields.RemovalCondition).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.RemovalCondition).SetValue(OpenProtocolConvert.ToString, value);
        }
        public string Line1
        {
            get => GetField(1, DataFields.Line1Header).Value;
            set => GetField(1, DataFields.Line1Header).SetValue(value);
        }
        public string Line2
        {
            get => GetField(1, DataFields.Line2).Value;
            set => GetField(1, DataFields.Line2).SetValue(value);
        }
        public string Line3
        {
            get => GetField(1, DataFields.Line3).Value;
            set => GetField(1, DataFields.Line3).SetValue(value);
        }
        public string Line4
        {
            get => GetField(1, DataFields.Line4).Value;
            set => GetField(1, DataFields.Line4).SetValue(value);
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
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Number(DataFields.TextDuration, 20, 4),
                                DataField.Number(DataFields.RemovalCondition, 26, 1),
                                DataField.String(DataFields.Line1Header, 29, 25),
                                DataField.String(DataFields.Line2, 56, 25),
                                DataField.String(DataFields.Line3, 83, 25),
                                DataField.String(DataFields.Line4, 110, 25)
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
