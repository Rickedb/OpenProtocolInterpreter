using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// External Tool tag ID and status
    /// <para>Used by the controller to detect a Tool tag ID with its status from the integrator.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, MID revision unsupported.</para>
    /// </summary>
    public class Mid0265 : Mid, IApplicationToolLocationSystem, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 265;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.MID_REVISION_UNSUPPORTED };

        public string ToolTagId
        {
            get => GetField(1,(int)DataFields.TOOL_TAG_ID).Value;
            set => GetField(1,(int)DataFields.TOOL_TAG_ID).SetValue(value);
        }
        public ToolStatus ToolStatus
        {
            get => (ToolStatus)GetField(1,(int)DataFields.TOOL_STATUS).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.TOOL_STATUS).SetValue(_intConverter.Convert, (int)value);
        }

        public Mid0265() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
            
        }

        public Mid0265(Header header) : base(header)
        {
            _intConverter = new Int32Converter();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.TOOL_TAG_ID, 20, 8),
                        new DataField((int)DataFields.TOOL_STATUS, 30, 2, '0', DataField.PaddingOrientations.LEFT_PADDED)
                    }
                }
            };
        }

        public enum DataFields
        {
            TOOL_TAG_ID,
            TOOL_STATUS
        }
    }
}
