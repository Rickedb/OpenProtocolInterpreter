using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.PowerMACS
{
    /// <summary>
    /// MID: Last Power MACS tightening result data acknowledge
    /// Description: 
    ///    If Bolt Data is set to TRUE the next telegram with Bolt data is sent (if there are any left for this
    ///    tightening). Otherwise no more Bolt data is sent for this tightening.
    ///    If only the station data is wanted Bolt Data must be set to FALSE in the acknowledgement of MID 0106
    ///    Last Power MACS tightening result Station data.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0108 : Mid, IPowerMACS
    {
        private readonly IValueConverter<bool> _boolConverter;
        private const int LAST_REVISION = 4;
        public const int MID = 108;

        public bool BoltData
        {
            get => RevisionsByFields[1][(int)DataFields.BOLT_DATA].GetValue(_boolConverter.Convert);
            set => RevisionsByFields[1][(int)DataFields.BOLT_DATA].SetValue(_boolConverter.Convert, value);
        }

        public MID_0108(int revision = LAST_REVISION) : base(MID, revision)
        {
            _boolConverter = new BoolConverter();
        }

        internal MID_0108(IMid nextTemplate) : this() => NextTemplate = nextTemplate;

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.BOLT_DATA, 20, 1, false),
                            }
                }
            };
        }

        public enum DataFields
        {
            BOLT_DATA
        }
    }
}
