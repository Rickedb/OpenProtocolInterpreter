using System;
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

        [StringDataFieldDefinition(field: 0, revision: 1, Size = 8)]
        public string ToolTagId { get; set; }

        public Mid0262() : base(MID, DEFAULT_REVISION)
        {

        }

        public Mid0262(Header header) : base(header)
        {

        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            ToolTagId
        }
    }
}
