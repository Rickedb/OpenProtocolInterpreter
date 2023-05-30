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
        public const int MID = 42;

        public int ToolNumber
        {
            get => GetField(2, (int)DataFields.ToolNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.ToolNumber).SetValue(OpenProtocolConvert.ToString, value);
        }
        public DisableType DisableType
        {
            get => (DisableType)GetField(2, (int)DataFields.DisableType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, (int)DataFields.DisableType).SetValue(OpenProtocolConvert.ToString, (int)value);
        }

        public Mid0042() : this(DEFAULT_REVISION)
        {
        }

        public Mid0042(Header header) : base(header)
        {
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
                                new DataField((int)DataFields.ToolNumber, 20, 4, '0', PaddingOrientation.LeftPadded),
                                new DataField((int)DataFields.DisableType, 26, 2, '0', PaddingOrientation.LeftPadded)
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
