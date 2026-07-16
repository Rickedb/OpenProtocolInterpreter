using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Select Parameter set
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error, Parameter set can not be set
    /// </para>
    /// </summary>
    public class Mid0018 : Mid, IParameterSet, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 18;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.ParameterSetCannotBeSet };

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        public int ParameterSetId { get; set; }

        public Mid0018() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0018(Header header) : base(header)
        {
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            ParameterSetId
        }
    }
}
