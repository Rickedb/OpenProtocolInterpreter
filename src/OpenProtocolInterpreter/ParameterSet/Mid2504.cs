using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Select Parameter set, Dynamic Job Included
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error, Dynamic Job cannot be created, non-existing pset
    /// </para>
    /// </summary>
    public class Mid2504 : Mid, IParameterSet, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 2504;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.ParameterSetIdNotPresent };

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        public int ParameterSetId { get; set; }

        public Mid2504() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid2504(Header header) : base(header)
        {
        }
    }
}
