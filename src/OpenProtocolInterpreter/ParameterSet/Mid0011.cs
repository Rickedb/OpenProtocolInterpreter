using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace OpenProtocolInterpreter.ParameterSet
{
    /// <summary>
    /// Parameter set ID upload reply
    /// <para>
    ///     The transmission of all the valid parameter set IDs of the controller. In the revision 000-001 the data
    ///     field contains the number of valid parameter sets currently present in the controller, and the ID of each
    ///     parameter set present.In revision 2 is the number of stages on each Pset/Mset added.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0011 : Mid, IParameterSet, IController
    {
        public const int MID = 11;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 3, HasPrefix = false)]
        public int TotalParameterSets { get; set; }

        [Int32CollectionDefinition(revision: 1, field: 2, Index = 23, EachFieldSize = 3, HasPrefix = false)]
        public List<int> ParameterSets { get; set; }

        public Mid0011() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0011(Header header) : base(header)
        {
            ParameterSets ??= [];
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 2) //ParameterSets
            {
                dataField.Size = TotalParameterSets * 3;
            }
            base.ProcessDataField(dataField, package);
        }
        public override string Pack()
        {
            TotalParameterSets = ParameterSets?.Count ?? 0; //Enforce the number of parameter sets to match the list count
            GetField(nameof(ParameterSets)).Size = TotalParameterSets * 3;
            return base.Pack();
        }
    }
}
