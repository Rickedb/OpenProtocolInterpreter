using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Select Parameter set dynamically.
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or
    ///     <see cref="Communication.Mid0004"/> Command error, Dynamic Pset cannot be created, non-existing pset
    /// </para>
    /// <para>
    /// A dynamic pset is created from a preexisting Pset in the Controller and selected for tightenings.
    /// The message can substitute Pset selection, Set Identifier, Reset All Identifier, Reset Latest Identifier, Set Batch Size, Disable Tool and Enable Tool.
    /// </para>
    /// </summary>
    public class Mid2505 : Mid, IParameterSet, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 2505;

        public IEnumerable<Error> DocumentedPossibleErrors => Enumerable.Empty<Error>();

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        public int ParameterSetId { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 23, Size = 3, HasPrefix = false)]
        public int NumberOfParameterDataFields { get; set; }

        [VariableDataFieldCollectionDefinition(revision: 1, field: 3, Index = 26, HasPrefix = false)]
        public List<VariableDataField> VariableDataFields { get; set; }

        public Mid2505() : this(DEFAULT_REVISION)
        {

        }

        public Mid2505(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        public Mid2505(Header header) : base(header)
        {
            VariableDataFields = [];
        }

        public override string Pack()
        {
            NumberOfParameterDataFields = VariableDataFields?.Count ?? 0; //Enforce list size even if modified
            GetField(revision: 1, field: 3).Size = VariableDataFields?.Sum(x => x.TotalSize) ?? 0; //Enforce size of variable data fields
            return base.Pack();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 3) //VariableDataFields
            {
                dataField.Size = Header.Length - dataField.Index;
            }
            base.ProcessDataField(dataField, package);
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
        protected enum DataFields
        {
            ParameterSetId,
            NumberOfParameterDataFields,
            DataFields
        }
    }
}
