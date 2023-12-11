using System.Collections.Generic;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// Application Communication positive acknowledge
    /// <para>
    ///     This message is used by the controller to confirm that the latest command, request or subscription sent
    ///     by the integrator was accepted.The data field contains the MID of the request accepted if the special
    ///     MIDs for request or subscription are used.
    /// </para>
    /// <para>
    ///     It can also be used by the integrator to acknowledge received subscribed data/events upload and will
    ///     then do all the special subscription data acknowledges obsolete.
    /// </para>
    /// <para>
    ///     When using the communication acknowledgement of MID 9997 and MID 9998 together with
    ///     sequence numbering this is an application level message only.
    ///     When using the GENERIC subscription MIDs <see cref="Mid0008"/> and 0009 the data field contains the MID of
    ///     the subscribed MID.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0005 : Mid, ICommunication, IController
    {
        public const int MID = 5;

        public int MidAccepted
        {
            get => GetField(1, DataFields.MidAccepted).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.MidAccepted).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0005() : this(DEFAULT_REVISION)
        {

        }

        public Mid0005(Header header) : base(header)
        {
        }

        public Mid0005(int revision) : this(new Header()
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
                                DataField.Number(DataFields.MidAccepted, 20, 4, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            MidAccepted
        }
    }
}
