using System.Collections.Generic;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// Last Power MACS tightening result data acknowledge
    /// <para>
    ///    If Bolt Data is set to TRUE the next telegram with Bolt data is sent (if there are any left for this
    ///    tightening). Otherwise no more Bolt data is sent for this tightening.
    /// </para>
    /// <para>
    ///    If only the station data is wanted Bolt Data must be set to FALSE in the acknowledgement of 
    ///    <see cref="Mid0106"/> Last Power MACS tightening result Station data.
    /// </para>   
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0108 : Mid, IPowerMACS, IIntegrator, IAcknowledge
    {
        public const int MID = 108;

        public bool BoltData
        {
            get => GetField(1, (int)DataFields.BoltData).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(1, (int)DataFields.BoltData).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0108() : this(DEFAULT_REVISION)
        {

        }

        public Mid0108(Header header) : base(header)
        {
        }

        public Mid0108(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.BoltData, 20, 1, false),
                            }
                },
            };
        }

        protected enum DataFields
        {
            BoltData
        }
    }
}
