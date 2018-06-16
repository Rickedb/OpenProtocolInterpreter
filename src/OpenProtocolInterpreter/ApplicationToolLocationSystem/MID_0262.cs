using System.Collections.Generic;

namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// MID: Tool tag ID
    /// Description:
    ///     Used by the controller to send a Tool tag ID to the integrator.
    /// Message sent by: Controller
    /// Answer: MID 0263 Tool tag ID acknowledge
    /// </summary>
    public class MID_0262 : Mid, IApplicationToolLocationSystem
    {
        private const int LAST_REVISION = 1;
        public const int MID = 262;

        public string ToolTagId
        {
            get => GetField(1,(int)DataFields.TOOL_TAG_ID).Value;
            set => GetField(1,(int)DataFields.TOOL_TAG_ID).SetValue(value);
        }

        public MID_0262(int? noAckFlag = 0) : base(MID, LAST_REVISION, noAckFlag) {  }

        internal MID_0262(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.TOOL_TAG_ID, 20, 8)
                    }
                }
            };
        }

        public enum DataFields
        {
            TOOL_TAG_ID
        }
    }
}
