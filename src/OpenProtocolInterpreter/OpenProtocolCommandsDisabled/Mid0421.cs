using System.Collections.Generic;

namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// Open Protocol commands disabled
    /// <para>
    ///     Upload the status of the Open Protocol commands disable digital input. 
    ///     The data upload consists of one byte delivering the digital input status. 
    ///     The status is uploaded each time the “Open Protocol commands disable” digital 
    ///     input changes (push function).
    /// </para>    
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0422"/> Open Protocol commands disabled acknowledge</para>
    /// </summary>
    public class Mid0421 : Mid, IOpenProtocolCommandsDisabled, IController, IAcknowledgeable<Mid0422>
    {
        public const int MID = 421;

        public bool DigitalInputStatus
        {
            get => GetField(1, DataFields.DigitalInputStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, DataFields.DigitalInputStatus).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0421() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0421(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Boolean(DataFields.DigitalInputStatus, 20, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            DigitalInputStatus
        }
    }
}
