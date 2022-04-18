using System.Collections.Generic;

namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// Tool tag ID
    /// <para>Used by the controller to send a Tool tag ID to the integrator.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0263"/> Tool tag ID acknowledge</para>
    /// </summary>
    public class Mid0262 : Mid, IApplicationToolLocationSystem, IController
    {
        private const int LAST_REVISION = 1;
        public const int MID = 262;

        public string ToolTagId
        {
            get => GetField(1,(int)DataFields.TOOL_TAG_ID).Value;
            set => GetField(1,(int)DataFields.TOOL_TAG_ID).SetValue(value);
        }

        public Mid0262() : base(MID, LAST_REVISION)
        {

        }

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
