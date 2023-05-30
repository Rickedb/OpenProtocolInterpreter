using System.Collections.Generic;

namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    /// <summary>
    /// External Tool tag ID and status
    /// <para>Used by the controller to detect a Tool tag ID with its status from the integrator.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted or <see cref="Communication.Mid0004"/> Command error, MID revision unsupported.</para>
    /// </summary>
    public class Mid0265 : Mid, IApplicationToolLocationSystem, IIntegrator, IAcceptableCommand, IDeclinableCommand
    {
        public const int MID = 265;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.MidRevisionUnsupported };

        public string ToolTagId
        {
            get => GetField(1,(int)DataFields.ToolTagId).Value;
            set => GetField(1,(int)DataFields.ToolTagId).SetValue(value);
        }
        public ToolStatus ToolStatus
        {
            get => (ToolStatus)GetField(1,(int)DataFields.ToolStatus).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1,(int)DataFields.ToolStatus).SetValue(OpenProtocolConvert.ToString, (int)value);
        }

        public Mid0265() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {
            
        }

        public Mid0265(Header header) : base(header)
        {

        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.ToolTagId, 20, 8),
                        new DataField((int)DataFields.ToolStatus, 30, 2, '0', DataField.PaddingOrientations.LeftPadded)
                    }
                }
            };
        }

        protected enum DataFields
        {
            ToolTagId,
            ToolStatus
        }
    }
}
