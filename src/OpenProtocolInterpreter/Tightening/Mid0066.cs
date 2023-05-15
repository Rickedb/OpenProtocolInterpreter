using OpenProtocolInterpreter.Converters;
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
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 66;

        public int NumberOfOfflineResults
        {
            get => GetField(1, (int)DataFields.NUMBER_OF_OFFLINE_RESULTS).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.NUMBER_OF_OFFLINE_RESULTS).SetValue(_intConverter.Convert, value);
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
            _intConverter = new Int32Converter();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.NUMBER_OF_OFFLINE_RESULTS, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED, false)
                            }
                }
            };
        }

        protected enum DataFields
        {
            NUMBER_OF_OFFLINE_RESULTS
        }
    }
}
