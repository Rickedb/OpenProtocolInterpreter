using System.Collections.Generic;

namespace OpenProtocolInterpreter.Battery
{
    /// <summary>
    /// Battery level changes upload
    /// <para>
    ///     The controller reports the current battery level when it changes.
    ///     Same data format as <see cref="Mid0801"/>.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0803 : Mid, IBattery, IController
    {
        public const int MID = 803;

        /// <summary>
        /// Battery pack capacity in percent (000-100).
        /// </summary>
        public int Capacity
        {
            get => GetField(1, DataFields.Capacity).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.Capacity).SetValue(OpenProtocolConvert.ToString, value);
        }

        /// <summary>
        /// State of the battery pack:
        /// <para>0 = Battery pack not inserted</para>
        /// <para>1 = Battery level critical (system shutdown)</para>
        /// <para>2 = Battery insufficient for tightening</para>
        /// <para>3 = Battery level okay</para>
        /// <para>4 = Battery reinserted (checking charge)</para>
        /// <para>5 = Battery warning level reached</para>
        /// </summary>
        public int State
        {
            get => GetField(1, DataFields.State).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.State).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0803() : this(DEFAULT_REVISION) { }

        public Mid0803(Header header) : base(header) { }

        public Mid0803(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        DataField.Number(DataFields.Capacity, 20, 3),
                        DataField.Number(DataFields.State, 25, 1)
                    }
                }
            };
        }

        protected enum DataFields
        {
            Capacity,
            State
        }
    }
}
