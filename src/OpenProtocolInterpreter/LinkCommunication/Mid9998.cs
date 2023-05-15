using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.LinkCommunication
{
    /// <summary>
    /// Communication acknowledge error
    /// <para>This message is used in conjunction with the use of header sequence number.</para>
    /// <para>Message sent by: Controller and Integrator:</para>
    /// <para>
    ///     This message is sent immediately after the message is received on application link level and if the check of the header is found to be wrong in any way.
    ///     The acknowledge substitute the use of NoAck flag and all subscription data special acknowledging.
    /// </para>
    /// <para>
    /// The acknowledge substitute the use of NoAck flag and all subscription data special acknowledging.
    /// </para>
    /// </summary>
    public class Mid9998 : Mid, ILinkCommunication, IController, IIntegrator
    {
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 9998;

        public int MidNumber
        {
            get => GetField(1, (int)DataFields.MID_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.MID_NUMBER).SetValue(_intConverter.Convert, value);
        }
        public LinkCommunicationError ErrorCode
        {
            get => (LinkCommunicationError)GetField(1, (int)DataFields.ERROR_CODE).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.ERROR_CODE).SetValue(_intConverter.Convert, (int)value);
        }

        public Mid9998() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
            
        }

        public Mid9998(Header header) : base(header)
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
                                new DataField((int)DataFields.MID_NUMBER, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false),
                                new DataField((int)DataFields.ERROR_CODE, 24, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            MID_NUMBER,
            ERROR_CODE
        }
    }
}
