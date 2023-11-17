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

        public int ProgramId
        {
            get => GetField(1, DataFields.ProgramId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.ProgramId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public NodeType NodeType
        {
            get => (NodeType)GetField(1, DataFields.NodeType).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.NodeType).SetValue(OpenProtocolConvert.ToString, value);
        }

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

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Number(DataFields.ProgramId, 20, 4, false),
                                DataField.Number(DataFields.NodeType, 24, 3, false),
                            }
                }
            };
        }

        protected enum DataFields
        {
            ProgramId,
            NodeType
        }
    }
}
