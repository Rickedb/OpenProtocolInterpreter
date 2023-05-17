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
            get => GetField(2, (int)DataFields.ToolNumber).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.ToolNumber).SetValue(_intConverter.Convert, value);
        }
        public DisableType DisableType
        {
            get => (DisableType)GetField(2, (int)DataFields.DisableType).GetValue(_intConverter.Convert);
            set => GetField(2, (int)DataFields.DisableType).SetValue(_intConverter.Convert, (int)value);
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
                                new DataField((int)DataFields.ToolNumber, 20, 4, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.DisableType, 26, 2, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                },
            };
        }

        protected enum DataFields
        {
            ToolNumber,
            DisableType
        }
    }

}
