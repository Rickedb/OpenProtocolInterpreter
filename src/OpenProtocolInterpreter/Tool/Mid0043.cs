using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Enable tool
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0043 : Mid, ITool, IIntegrator, IAcceptableCommand
    {
        public const int MID = 43;

        public int ToolNumber
        {
            get => GetField(2, DataFields.ToolNumber).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(2, DataFields.ToolNumber).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0043() : this(DEFAULT_REVISION)
        {

        }

        public Mid0043(Header header) : base(header)
        {
        }

        public Mid0043(int revision) : this(new Header()
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
                                DataField.Number(DataFields.ToolNumber, 20, 4),
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
