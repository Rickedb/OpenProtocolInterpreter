using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MotorTuning
{
    /// <summary>
    /// Motor tuning result data
    /// <para>Upload the last motor tuning result.</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0502"/> Motor tuning result data acknowledge</para>
    /// </summary>
    public class Mid0501 : Mid, IMotorTuning, IController, IAcknowledgeable<Mid0502>
    {
        public const int MID = 501;

        /// <summary>
        /// <para>Motor Tune Failed = false (0)</para>
        /// <para>Motor Tune Success = true (1)</para>
        /// </summary>
        [BooleanDataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 1)]
        public bool MotorTuneResult { get; set; }

        public Mid0501() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0501(Header header) : base(header)
        {
        }
    }
}
