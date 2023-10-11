using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Lock at batch done upload
    /// <para>This message gives the relay status for Lock at batch done.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0023"/> Lock at batch done upload Ack</para>
    /// </summary>
    public class Mid0022 : Mid, IParameterSet, IController, IAcknowledgeable<Mid0023>
    {
        public const int MID = 22;

        public bool RelayStatus
        {
            get => GetField(1, (int)DataFields.RelayStatus).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, (int)DataFields.RelayStatus).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0022() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0022(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new((int)DataFields.RelayStatus, 20, 1, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            RelayStatus
        }
    }
}
