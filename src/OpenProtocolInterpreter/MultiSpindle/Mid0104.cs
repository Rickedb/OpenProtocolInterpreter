using System;
using System.Collections.Generic;
using System.Text;

namespace OpenProtocolInterpreter.MultiSpindle
{
    /// <summary>
    /// Old Multi spindle result request
    /// <para>Request for an old multi spindle result.</para>
    /// <para>Note: MID 0104 can’t be used if there is an active subscription for multiple spindle results.</para>
    /// <para>Message sent by: Integrator</para>
    /// <para>
    /// Answer: <see cref="Mid0101"/> Command accepted or 
    /// <see cref="Communication.Mid0004"/> Command error, Multi spindle result subscription already exists
    /// </para>
    /// </summary>
    public class Mid0104 : Mid, IMultiSpindle, IIntegrator, IAnswerableBy<Mid0101>, IDeclinableCommand
    {
        public const int MID = 104;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.MultiSpindleResultSubscriptionAlreadyExists };

        public long RequestedResultIndex
        {
            get => GetField(1, DataFields.RequestedResultIndex).GetValue(OpenProtocolConvert.ToInt64);
            set => GetField(1, DataFields.RequestedResultIndex).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0104() : base(MID, DEFAULT_REVISION) { }

        public Mid0104(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Number(DataFields.RequestedResultIndex, 20, 10),
                            }
                }
            };
        }

        protected enum DataFields
        {
            RequestedResultIndex
        }
    }
}
