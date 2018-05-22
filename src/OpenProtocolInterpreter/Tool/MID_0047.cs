using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// MID: Tool Pairing handling
    /// Description: 
    ///     This message is sent by the integrator in order to Pair tools, to abort ongoing pairing, 
    ///     to Abort/Disconnect established connection and request for pairing status of the IRC-B or IRC-W tool types.
    ///     At pairing handling type, Start Pairing and Pairing Abort or Disconnect the controller must take program control 
    ///     and release when finished. MID 0048 will be uploaded during the pairing process at each change of the pairing stage.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted at pairing status ACCEPTED
    ///         MID 0004 Command error. See error codes. 
    ///         MID 0048 Pairing status during the pairing process
    /// </summary>
    public class MID_0047 : Mid, ITool
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 47;
        
        public PairingHandlingType PairingHandlingType
        {
            get => (PairingHandlingType)RevisionsByFields[1][(int)DataFields.PAIRING_HANDLING_TYPE].GetValue(_intConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.PAIRING_HANDLING_TYPE].SetValue(_intConverter.Convert, (int)value);
        }

        public MID_0047() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
        }

        internal MID_0047(IMid nextTemplate) : base(MID, LAST_REVISION) => NextTemplate = nextTemplate;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.PAIRING_HANDLING_TYPE, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                }
            };
        }

        public enum DataFields
        {
            PAIRING_HANDLING_TYPE
        }
    }
}
