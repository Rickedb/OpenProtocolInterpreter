using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Digital input function
    /// <para>
    ///     Upload of one specific digital input function status. See Table 80.
    ///     For tracking event functions, <see cref="Mid0221"/> Digital input function, is sent each time the digital input
    ///     function’s status (state) is changed. For digital input functions which are not tracking events, the
    ///     upload is sent only when the digital input function is set high, 
    ///     i.e. the data field “Digital input function status” will always be 1 for such functions.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0222"/> Digital input function upload acknowledge</para>
    /// </summary>
    public class Mid0221 : Mid, IIOInterface, IController, IAcknowledgeable<Mid0222>
    {
        public const int MID = 221;

        public DigitalInputNumber DigitalInputNumber
        {
            get => (DigitalInputNumber)GetField(1,(int)DataFields.DigitalInputNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.DigitalInputNumber).SetValue(OpenProtocolConvert.ToString, (int)value);
        }
        public bool DigitalInputStatus
        {
            get => GetField(1,(int)DataFields.DigitalInputStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1,(int)DataFields.DigitalInputStatus).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0221() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0221(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.DigitalInputNumber, 20, 3, '0', PaddingOrientation.LeftPadded),
                        new DataField((int)DataFields.DigitalInputStatus, 25, 1)
                    }
                }
            };
        }

        protected enum DataFields
        {
            DigitalInputNumber,
            DigitalInputStatus
        }
    }
}
