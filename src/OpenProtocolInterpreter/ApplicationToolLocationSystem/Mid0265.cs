using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: External Tool tag ID and status
    /// Description:
    ///     Used by the controller to detect a Tool tag ID with its status from the integrator.
    /// Message sent by: Integrator
    /// Answer: MID 0005 Command accepted or
    ///         MID 0004 Command error, MID revision unsupported.
    /// </summary>
    public class Mid0265 : Mid, IApplicationToolLocationSystem
    {
        private readonly IValueConverter<int> _intConverter;
        private const int LAST_REVISION = 1;
        public const int MID = 265;

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

        public Mid0265() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
        }

        public Mid0265(string toolTagId, ToolStatus toolStatus) : this()
        {
            ToolTagId = toolTagId;
            ToolStatus = toolStatus;
        }

        internal Mid0265(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

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
