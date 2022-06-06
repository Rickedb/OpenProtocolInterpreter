using System.Collections.Generic;

namespace OpenProtocolInterpreter.UserInterface
{
    /// <summary>
    /// Display user text on compact
    /// <para>
    ///     By sending this message the integrator can display a text on the compact display. The text must be maximum 4 bytes long.
    ///     The characters that can be displayed are limited due to the hardware of the compact display.
    /// </para>
    /// <para>
    ///     Each character must fit into seven segments. This means for example that it is not possible to display an M on the compact display.
    ///     The text will be displayed until next tightening, new parameter set or Job selection, or alarm code.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///             <see cref="Communication.Mid0004"/> Command error, User text could not be displayed
    /// </para>
    /// </summary>
    public class Mid0110 : Mid, IUserInterface, IIntegrator
    {
        private const int LAST_REVISION = 1;
        public const int MID = 110;

        public string UserText
        {
            get => GetField(1,(int)DataFields.USER_TEXT).Value;
            set => GetField(1,(int)DataFields.USER_TEXT).SetValue(value);
        }

        public Mid0110() : base(MID, LAST_REVISION)
        {

        }

        public Mid0110(Header header) : base(header)
        {
        }

        public Mid0110(string userText) : this()
        {
            UserText = userText;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.USER_TEXT, 20, 4, ' ', DataField.PaddingOrientations.RIGHT_PADDED, false),
                            }
                }
            };
        }

        public enum DataFields
        {
            USER_TEXT
        }
    }
}
