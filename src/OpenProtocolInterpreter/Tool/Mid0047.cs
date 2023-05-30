using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Tool Pairing handling
    /// <para>
    ///     This message is sent by the integrator in order to Pair tools, to abort ongoing pairing, 
    ///     to Abort/Disconnect established connection and request for pairing status of the IRC-B or IRC-W tool types.
    ///     At pairing handling type, Start Pairing and Pairing Abort or Disconnect the controller must take program control 
    ///     and release when finished. MID 0048 will be uploaded during the pairing process at each change of the pairing stage.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: </para>
    /// <para><see cref="Communication.Mid0005"/> Command accepted at pairing status ACCEPTED</para>
    /// <para><see cref="Communication.Mid0004"/> Command error. See error codes. </para>
    /// <para><see cref="Mid0048"/> Pairing status during the pairing process</para>
    /// </summary>
    public class Mid0047 : Mid, ITool, IIntegrator, IAcceptableCommand, IDeclinableCommand, IAnswerableBy<Mid0048>
    {
        public const int MID = 47;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { };

        public PairingHandlingType PairingHandlingType
        {
            get => (PairingHandlingType)GetField(1,(int)DataFields.PairingHandlingType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.PairingHandlingType).SetValue(OpenProtocolConvert.ToString, (int)value);
        }

        public Mid0047() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0047(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.PairingHandlingType, 20, 2, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                }
            };
        }

        protected enum DataFields
        {
            PairingHandlingType
        }
    }
}
