using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Tool data upload request
    /// <para>
    ///     A request for some of the data stored in the tool. The result of this command 
    ///     is the transmission of the tool data.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Mid0041"/> Tool data upload reply</para>
    /// </summary>
    public class Mid0040 : Mid, ITool, IIntegrator
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 7;
        public const int MID = 40;

        public int ToolNumber
        {
            get => GetField(6, (int)DataFields.TOOL_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(6, (int)DataFields.TOOL_NUMBER).SetValue(_intConverter.Convert, value);
        }

        public Mid0040() : this(LAST_REVISION)
        {

        }

        public Mid0040(int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
        }

        /// <summary>
        /// Revision 6 and 7 constructor
        /// </summary>
        /// <param name="toolNumber">The number of the tool to send tool data for. It is the same number as the tool numbers sent in <see cref="Mid0701"/> (Tool List Upload)</param>
        /// <param name="revision">Revision</param>
        public Mid0040(int toolNumber, int revision = LAST_REVISION) : this(revision)
        {
            ToolNumber = toolNumber;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    6, new List<DataField>()
                            {
                                new DataField((int)DataFields.TOOL_NUMBER, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                },
            };
        }

        public enum DataFields
        {
            TOOL_NUMBER
        }
    }
}
