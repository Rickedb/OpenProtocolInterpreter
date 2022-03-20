using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Disable tool
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0042 : Mid, ITool, IIntegrator
    {
        private readonly IValueConverter<int> _intConverter;

        private const int LAST_REVISION = 2;
        public const int MID = 42;

        public int ToolNumber
        {
            get => GetField(2, (int)DataFields.TOOL_NUMBER).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.TOOL_NUMBER).SetValue(_intConverter.Convert, value);
        }
        public DisableType DisableType
        {
            get => (DisableType)GetField(2, (int)DataFields.DISABLE_TYPE).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.DISABLE_TYPE).SetValue(_intConverter.Convert, (int)value);
        }

        public Mid0042() : this(LAST_REVISION)
        {
        }

        public Mid0042(int revision = LAST_REVISION) : base(MID, revision)
        {
            _intConverter = new Int32Converter();
        }

        /// <summary>
        /// Revision 2 constructor
        /// </summary>
        /// <param name="toolNumber">The number of the tool to disable. It is the same number as the tool numbers sent in <see cref="Mid0701"/> (Tool List Upload)</param>
        /// <param name="disableType">
        ///     The type of disable:
        ///     <para>00 = Disable(lock)</para>
        ///     <para>01 = Inhibit NOK</para>
        ///     <para>02 = Inhibit OK</para>
        ///     <para>03 = Inhibit No result</para>
        /// </param>
        /// <param name="revision">Revision</param>
        public Mid0042(int toolNumber, DisableType disableType, int revision = 2) : this(revision)
        {
            ToolNumber = toolNumber;
            DisableType = disableType;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    2, new List<DataField>()
                            {
                                new DataField((int)DataFields.TOOL_NUMBER, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.DISABLE_TYPE, 26, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
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
