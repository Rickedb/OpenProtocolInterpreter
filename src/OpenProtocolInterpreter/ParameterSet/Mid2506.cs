using System;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Tightening Program Delete
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error
    /// </para>
    /// <para> This message deletes one or all programs in controller. </para>
    /// <para> <b>Note</b>: If a running program is included in MID 2506 deletion the program shall finish before deletion. </para>
    /// <para> <b>Note</b>: Deleting programs included in other nodes may give unwanted behaviour. It will behave identical to a manual delete of the program. </para>
    /// </summary>
    public class Mid2506 : Mid, IParameterSet, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 2506;

        public IEnumerable<Error> DocumentedPossibleErrors => [];

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 4, HasPrefix = false)]
        public int ProgramId { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 24, Size = 3, HasPrefix = false)]
        public NodeType NodeType { get; set; }

        public Mid2506() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid2506(Header header) : base(header)
        {

        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            ProgramId,
            NodeType
        }
    }
}
