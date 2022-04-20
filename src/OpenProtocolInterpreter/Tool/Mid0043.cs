using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Enable tool
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0043 : Mid, ITool, IIntegrator
    {
        private readonly IValueConverter<int> _intConverter;

        private const int LAST_REVISION = 2;
        public const int MID = 43;

        public int ToolNumber
        {
            get => GetField(2, (int)DataFields.TOOL_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.TOOL_NUMBER).SetValue(_intConverter.Convert, value);
        }

        public Mid0043() : this(LAST_REVISION)
        {

        }

        public Mid0043(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        public Mid0043(int revision = LAST_REVISION) : this(new Header()
        {
            Mid = MID, 
            Revision = revision
        })
        {
        }

        /// <summary>
        /// Revision 2 constructor
        /// </summary>
        /// <param name="toolNumber">The number of the tool to disable. It is the same number as the tool numbers sent in <see cref="Mid0701"/> (Tool List Upload)</param>
        /// <param name="revision">Revision</param>
        public Mid0043(int toolNumber, int revision = LAST_REVISION) : this(revision)
        {
            ToolNumber = toolNumber;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    2, new List<DataField>()
                            {
                                new DataField((int)DataFields.TOOL_NUMBER, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                            }
                },
            };
        }

        public enum DataFields
        {
            TOOL_NUMBER,
            DISABLE_TYPE
        }
    }
}
