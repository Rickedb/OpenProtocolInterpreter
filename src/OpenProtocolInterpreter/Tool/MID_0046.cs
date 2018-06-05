using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// MID: Set primary tool request
    /// Description: 
    ///     This message is sent by the integrator in order to set tool data.
    ///     Warning 1: this MID requires programming control (see 4.4 Programming control).
    ///     Warning 2: the new configuration will not be active until the next controller reboot!
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or MID 0004 Command error, 
    ///         Programming control not granted or Invalid data (value not supported by controller)
    /// </summary>
    public class MID_0046 : Mid, ITool
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 46;

        public PrimaryTool PrimaryTool
        {
            get => (PrimaryTool)GetField(1,(int)DataFields.PRIMARY_TOOL).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.PRIMARY_TOOL).SetValue(_intConverter.Convert, (int)value);
        }

        public MID_0046() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
        }

        /// <summary>
        /// Revision 1 Constructor
        /// </summary>
        /// <param name="primaryTool">Primary tool. The primary tool is two byte-long and specified by two ASCII digits.</param>
        public MID_0046(PrimaryTool primaryTool) : this()
        {
            PrimaryTool = primaryTool;
        }

        internal MID_0046(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.PRIMARY_TOOL, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                }
            };
        }

        public enum DataFields
        {
            PRIMARY_TOOL
        }
    }
}
