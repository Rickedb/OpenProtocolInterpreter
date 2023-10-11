using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tightening
{
    /// <summary>
    /// Number of offline results
    /// <para>Number of results when offline</para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0066 : Mid, ITightening, IController
    {
        public const int MID = 66;

        public int NumberOfOfflineResults
        {
            get => GetField(1, (int)DataFields.NumberOfOfflineResults).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, (int)DataFields.NumberOfOfflineResults).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0066() : this(new Header()
        {
            Mid = MID, 
            Revision = DEFAULT_REVISION
        })
        {
        }

        public Mid0066(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new((int)DataFields.NumberOfOfflineResults, 20, 2, '0', PaddingOrientation.LeftPadded, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            NumberOfOfflineResults
        }
    }
}
