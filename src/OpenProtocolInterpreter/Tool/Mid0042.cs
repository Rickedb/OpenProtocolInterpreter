using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Disable tool
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0042 : Mid, ITool, IIntegrator, IAcceptableCommand
    {
        private readonly IValueConverter<int> _intConverter;

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

        public Mid0042() : this(DEFAULT_REVISION)
        {
        }

        public Mid0042(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        public Mid0042(int revision) : this(new Header()
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
                    2, new List<DataField>()
                            {
                                new DataField((int)DataFields.TOOL_NUMBER, 20, 4, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.DISABLE_TYPE, 26, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
                            }
                },
            };
        }

        protected enum DataFields
        {
            TOOL_NUMBER,
            DISABLE_TYPE
        }
    }

}
