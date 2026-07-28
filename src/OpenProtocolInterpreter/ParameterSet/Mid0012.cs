using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Parameter set data upload request
    /// <para>Request to upload parameter set data from the controller.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    /// Answer: <see cref="Mid0013"/> Parameter set data upload reply, or
    ///         <see cref="Communication.Mid0004"/> Command error, Parameter set not present
    /// </para>
    /// </summary>
    public class Mid0012 : Mid, IParameterSet, IIntegrator, IAnswerableBy<Mid0013>, IDeclinableCommand
    {
        public const int MID = 12;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.ParameterSetIdNotPresent };

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        public int ParameterSetId { get; set; }
        [Int32DataFieldDefinition(revision: 3, field: 3, Index = 23, Size = 8, HasPrefix = false)]
        public int ParameterSetFileVersion { get; set; }

        public Mid0012() : this(DEFAULT_REVISION)
        {

        }

        public Mid0012(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        public Mid0012(Header header) : base(header)
        {
        }
    }
}
