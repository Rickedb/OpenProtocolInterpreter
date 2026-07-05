using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.AutomaticManualMode
{
    /// <summary>
    /// Automatic/Manual mode
    /// <para>
    ///     The operation mode in the controller has changed.
    ///     The message includes the new operational mode of the controller.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0402"/> Automatic/Manual mode acknowledge</para>
    /// </summary>
    public class Mid0401 : Mid, IAutomaticManualMode, IController, IAcknowledgeable<Mid0402>
    {
        public const int MID = 401;

        /// <summary>
        /// <para>Automatic Mode = false (0)</para>
        /// <para>Manual Mode = true (1)</para>
        /// </summary>
        [BooleanDataFieldDefinition(field: 0, revision: 1, HasPrefix = false)]
        public bool ManualAutomaticMode { get; set; }

        public Mid0401() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION,
        })
        {

        }

        public Mid0401(Header header) : base(header)
        {
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            ManualAutomaticMode
        }
    }
}
