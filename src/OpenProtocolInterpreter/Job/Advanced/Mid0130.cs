using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Job off
    /// <para>Set the controller in Job off mode or reset the Job off mode.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0130 : Mid, IAdvancedJob, IIntegrator, IAcceptableCommand
    {
        public const int MID = 130;

        /// <summary>
        /// <para>False => Set Job Off</para>
        /// <para>True => Reset Job Off</para>
        /// </summary>
        [BooleanDataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 1, HasPrefix = false)]
        public bool JobOffStatus { get; set; }

        public Mid0130() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0130(Header header) : base(header)
        {
        }
    }
}
