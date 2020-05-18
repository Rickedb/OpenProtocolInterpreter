using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Lock at batch done upload
    /// <para>This message gives the relay status for Lock at batch done.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0023"/> Lock at batch done upload Ack</para>
    /// </summary>
    public class Mid0022 : Mid, IParameterSet, IController
    {
        private readonly IValueConverter<bool> _boolConverter;
        public const int MID = 22;
        private const int LAST_REVISION = 1;

        public bool RelayStatus
        {
            get => GetField(1, (int)DataFields.RELAY_STATUS).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.RELAY_STATUS).SetValue(_boolConverter.Convert, value);
        }

        public Mid0022() : this(0)
        {

        }

        public Mid0022(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag)
        {
            _boolConverter = new BoolConverter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="relayStatus">Relay Status</param>
        /// <param name="ackFlag">0=Ack needed, 1=No Ack needed (Default = 1)</param>
        public Mid0022(bool relayStatus, int? noAckFlag = 0) : this(noAckFlag)
        {
            RelayStatus = relayStatus;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.RELAY_STATUS, 20, 1, false)
                            }
                }
            };
        }

        public enum DataFields
        {
            RELAY_STATUS
        }
    }
}
