using System.Collections.Generic;

namespace OpenProtocolInterpreter.UserInterface
{
    /// <summary>
    /// MID: Display user text on compact
    /// Description: 
    ///     By sending this message the integrator can display a text on the compact display. The text must be maximum 4 bytes long.
    ///     The characters that can be displayed are limited due to the hardware of the compact display.
    ///     Each character must fit into seven segments. This means for example that it is not possible to display an M on the compact display.
    ///     The text will be displayed until next tightening, new parameter set or Job selection, or alarm code.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or 
    ///         MID 0004 Command error, User text could not be displayed
    /// </summary>
    public class MID_0110 : Mid, IUserInterface
    {
        private const int LAST_REVISION = 1;
        public const int MID = 110;

        public string UserText
        {
            get => RevisionsByFields[2][(int)DataFields.USER_TEXT].Value;
            set => RevisionsByFields[2][(int)DataFields.USER_TEXT].SetValue(value);
        }

        public MID_0110() : base(MID, LAST_REVISION)
        {

        }

        public MID_0110(string userText) : this()
        {
            UserText = userText;
        }

        internal MID_0110(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

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
