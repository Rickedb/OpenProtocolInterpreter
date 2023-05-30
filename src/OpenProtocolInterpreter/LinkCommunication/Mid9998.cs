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
        public const int MID = 9998;

        public int MidNumber
        {
            get => GetField(1, (int)DataFields.MidNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.MidNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public LinkCommunicationError ErrorCode
        {
            get => (LinkCommunicationError)GetField(1, (int)DataFields.ErrorCode).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.ErrorCode).SetValue(OpenProtocolConvert.ToString, (int)value);
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
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.MidNumber, 20, 4, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.ErrorCode, 24, 4, '0', DataField.PaddingOrientations.LeftPadded, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            MidNumber,
            ErrorCode
        }
    }
}
