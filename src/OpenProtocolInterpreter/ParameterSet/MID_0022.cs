using OpenProtocolInterpreter.Converters;
using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// MID: Lock at batch done upload
    /// Description: 
    ///     This message gives the relay status for Lock at batch done.
    /// Message sent by: Controller
    /// Answer: MID 0023 Lock at batch done upload Ack
    /// </summary>
    public class MID_0022 : Mid, IParameterSet
    {
        private readonly IValueConverter<bool> _boolConverter;
        public const int MID = 22;
        private const int LAST_REVISION = 1;

        public bool RelayStatus
        {
            get => GetField(1, (int)DataFields.RELAY_STATUS).GetValue(_boolConverter.Convert);
            set => GetField(1, (int)DataFields.RELAY_STATUS).SetValue(_boolConverter.Convert, value);
        }

        public MID_0022(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag)
        {
            _boolConverter = new BoolConverter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="relayStatus">Relay Status</param>
        /// <param name="ackFlag">0=Ack needed, 1=No Ack needed (Default = 1)</param>
        public MID_0022(bool relayStatus, int? noAckFlag = 0) : this(noAckFlag)
        {
            RelayStatus = relayStatus;
        }

        internal MID_0022(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

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
