using System.Collections.Generic;

namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// Tool tag ID
    /// <para>Used by the controller to send a Tool tag ID to the integrator.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0263"/> Tool tag ID acknowledge</para>
    /// </summary>
    public class Mid0262 : Mid, IApplicationToolLocationSystem, IController, IAcknowledgeable<Mid0263>
    {
        public const int MID = 262;

        public string ToolTagId
        {
            get => GetField(1, DataFields.ToolTagId).Value;
            set => GetField(1, DataFields.ToolTagId).SetValue(value);
        }

        public Mid0262() : base(MID, DEFAULT_REVISION)
        {

        }

        public Mid0262(Header header) : base(header)
        {

        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        DataField.String(DataFields.ToolTagId, 20, 8)
                    }
                }
            };
        }

        protected enum DataFields
        {
            ToolTagId
        }
    }
}
