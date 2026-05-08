using System.Collections.Generic;

namespace OpenProtocolInterpreter.Wifi
{
    /// <summary>
    /// Reception quality change upload
    /// <para>
    ///     The controller reports the current WiFi reception quality when it changes.
    ///     Same data format as <see cref="Mid0806"/>.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0808 : Mid, IWifi, IController
    {
        public const int MID = 808;

        /// <summary>
        /// Reception quality in dBm (typically -45 to -90), transmitted as 4 ASCII characters (e.g. "-080").
        /// </summary>
        public string ReceptionQuality
        {
            get => GetField(1, DataFields.ReceptionQuality).Value;
            set => GetField(1, DataFields.ReceptionQuality).SetValue(value);
        }

        public Mid0808() : this(DEFAULT_REVISION) { }

        public Mid0808(Header header) : base(header) { }

        public Mid0808(int revision) : this(new Header() { Mid = MID, Revision = revision }) { }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        DataField.String(DataFields.ReceptionQuality, 20, 4)
                    }
                }
            };
        }

        protected enum DataFields
        {
            ReceptionQuality
        }
    }
}
