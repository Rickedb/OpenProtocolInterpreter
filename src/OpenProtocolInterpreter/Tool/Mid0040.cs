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
    public class Mid0040 : Mid, ITool, IIntegrator, IAnswerableBy<Mid0041>
    {
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 40;

        public int ToolNumber
        {
            get => GetField(6, (int)DataFields.ToolNumber).GetValue(_intConverter.Convert);
            set => GetField(6, (int)DataFields.ToolNumber).SetValue(_intConverter.Convert, value);
        }

        public Mid0040() : this(DEFAULT_REVISION)
        {

        }

        public Mid0040(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        public Mid0040(int revision) : this(new Header()
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
                    6, new List<DataField>()
                            {
                                new DataField((int)DataFields.ToolNumber, 20, 4, '0', DataField.PaddingOrientations.LeftPadded)
                            }
                },
            };
        }

        protected enum DataFields
        {
            ToolNumber
        }
    }
}
