using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.LinkCommunication
{
    /// <summary>
    /// Communication acknowledge
    /// <para>This message is used in conjunction with the use of header sequence number.</para>
    /// <para>Message sent by: Controller and Integrator:</para>
    /// <para>
    ///     Is sent immediately after the message is received on application link level and if the check of the
    ///     header is found to be ok.
    /// </para>
    /// <para>
    /// The acknowledge substitute the use of NoAck flag and all subscription data special acknowledging.
    /// </para>
    /// </summary>
    public class Mid9997 : Mid, ILinkCommunication, IIntegrator, IController
    {
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 9997;

        public int MidNumber
        {
            get => GetField(1, (int)DataFields.MID_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.MID_NUMBER).SetValue(_intConverter.Convert, value);
        }

        public Mid9997(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        public Mid9997() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.MID_NUMBER, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                            }
                }
            };
        }

        public enum DataFields
        {
            MID_NUMBER
        }
    }
}
