using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// Application Communication negative acknowledge
    /// <para>
    ///     This message is used by the controller when a request, command or subscription for any reason has 
    ///     not been performed. 
    ///     The data field contains the message ID of the message request that failed as well as an error code.
    ///     It can also be used by the integrator to acknowledge received subscribed data/events upload and will
    ///     then do all the special subscription data acknowledges obsolete.
    /// </para>
    /// <para>
    ///     When using the communication acknowledgement of MID 0007 and <see cref="Mid0006"/> together with sequence 
    ///     numbering this is an application level message only.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0004 : Mid, ICommunication, IController
    {
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 4;

        public int FailedMid
        {
            get => GetField(1, (int)DataFields.Mid).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.Mid).SetValue(_intConverter.Convert, value);
        }
        public Error ErrorCode
        {
            get => (Error)GetField(1, (int)DataFields.ErrorCode).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.ErrorCode).SetValue(_intConverter.Convert, (int)value);
        }

        public Mid0004() : this(DEFAULT_REVISION)
        {

        }

        public Mid0004(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        public Mid0004(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
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
                                new DataField((int)DataFields.Mid, 20, 4, '0', DataField.PaddingOrientations.LeftPadded, false),
                                new DataField((int)DataFields.ErrorCode, 24, 2, '0', DataField.PaddingOrientations.LeftPadded, false)
                            }
                }
            };
        }


        protected enum DataFields
        {
            Mid,
            ErrorCode
        }
    }
}
