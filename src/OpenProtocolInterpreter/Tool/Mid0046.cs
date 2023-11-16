using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tool
{
    /// <summary>
    /// Set primary tool request
    /// <para>This message is sent by the integrator in order to set tool data.</para>
    /// <para>Warning 1: this MID requires programming control (see 4.4 Programming control).</para>
    /// <para>Warning 2: the new configuration will not be active until the next controller reboot!</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    ///     Answer: <see cref="Communication.Mid0005"/> Command accepted or 
    ///             <see cref="Communication.Mid0004"/> Command error, Programming control not granted or 
    ///                                                 Invalid data (value not supported by controller)
    /// </para>
    /// </summary>
    public class Mid0046 : Mid, ITool, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 46;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.ProgrammingControlNotGranted, Error.InvalidData };

        public PrimaryTool PrimaryTool
        {
            get => (PrimaryTool)GetField(1, DataFields.PrimaryTool).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.PrimaryTool).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0046() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0046(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Number(DataFields.PrimaryTool, 20, 2)
                            }
                }
            };
        }

        protected enum DataFields
        {
            PrimaryTool
        }
    }
}
