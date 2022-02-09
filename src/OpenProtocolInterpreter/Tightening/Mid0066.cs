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
        private const int LAST_REVISION = 1;
        public const int MID = 66;

        public int NumberOfOfflineResults
        {
            get => GetField(1, (int)DataFields.NUMBER_OF_OFFLINE_RESULTS).GetValue(_intConverter.Convert);
            set => GetField(1, (int)DataFields.NUMBER_OF_OFFLINE_RESULTS).SetValue(_intConverter.Convert, value);
        }

        public Mid0066() : base(MID, LAST_REVISION)
        {
            _intConverter = new Int32Converter();
        }

        /// <summary>
        /// Revision 1 constructor
        /// </summary>
        /// <param name="numberOfOfflineResults">2 ASCII digits. Max 99</param>
        public Mid0066(int numberOfOfflineResults) : this()
        {
            NumberOfOfflineResults = numberOfOfflineResults;
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

        public enum DataFields
        {
            NUMBER_OF_OFFLINE_RESULTS
        }
    }
}
