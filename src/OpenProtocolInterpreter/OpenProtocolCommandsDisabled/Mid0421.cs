using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    /// <summary>
    /// Open Protocol commands disabled
    /// <para>
    ///     Upload the status of the Open Protocol commands disable digital input.
    ///     The data upload consists of one byte delivering the digital input status.
    ///     The status is uploaded each time the “Open Protocol commands disable” digital
    ///     input changes (push function).
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0422"/> Open Protocol commands disabled acknowledge</para>
    /// </summary>
    public class Mid0421 : Mid, IOpenProtocolCommandsDisabled, IController, IAcknowledgeable<Mid0422>
    {
        public const int MID = 421;

        [BooleanDataFieldDefinition(revision: 1, field: 1, Index = 20, HasPrefix = false)]
        public bool DigitalInputStatus { get; set; }
        public Mid0421() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0421(Header header) : base(header)
        {
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            DigitalInputStatus
        }
    }
}
