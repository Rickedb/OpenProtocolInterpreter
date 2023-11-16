using System.Collections.Generic;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// Set externally controlled relays
    /// <para>
    ///     By using this message the integrator can control 10 relays (externally control relays). The station can
    ///     set, reset the relays or make them flashing.
    /// </para>
    /// <para>Message sent by: Integrator</para>
    /// <para>Answer: <see cref="Communication.Mid0005"/> Command accepted</para>
    /// </summary>
    public class Mid0200 : Mid, IIOInterface, IIntegrator, IAcceptableCommand
    {
        public const int MID = 200;

        public RelayStatus StatusRelayOne
        {
            get => (RelayStatus)GetField(1, DataFields.StatusRelay1).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.StatusRelay1).SetValue(OpenProtocolConvert.ToString, value);
        }
        public RelayStatus StatusRelayTwo
        {
            get => (RelayStatus)GetField(1, DataFields.StatusRelay2).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.StatusRelay2).SetValue(OpenProtocolConvert.ToString, value);
        }
        public RelayStatus StatusRelayThree
        {
            get => (RelayStatus)GetField(1, DataFields.StatusRelay3).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.StatusRelay3).SetValue(OpenProtocolConvert.ToString, value);
        }
        public RelayStatus StatusRelayFour
        {
            get => (RelayStatus)GetField(1, DataFields.StatusRelay4).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.StatusRelay4).SetValue(OpenProtocolConvert.ToString, value);
        }
        public RelayStatus StatusRelayFive
        {
            get => (RelayStatus)GetField(1, DataFields.StatusRelay5).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.StatusRelay5).SetValue(OpenProtocolConvert.ToString, value);
        }
        public RelayStatus StatusRelaySix
        {
            get => (RelayStatus)GetField(1, DataFields.StatusRelay6).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.StatusRelay6).SetValue(OpenProtocolConvert.ToString, value);
        }
        public RelayStatus StatusRelaySeven
        {
            get => (RelayStatus)GetField(1, DataFields.StatusRelay7).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.StatusRelay7).SetValue(OpenProtocolConvert.ToString, value);
        }
        public RelayStatus StatusRelayEight
        {
            get => (RelayStatus)GetField(1, DataFields.StatusRelay8).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.StatusRelay8).SetValue(OpenProtocolConvert.ToString, value);
        }
        public RelayStatus StatusRelayNine
        {
            get => (RelayStatus)GetField(1, DataFields.StatusRelay9).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.StatusRelay9).SetValue(OpenProtocolConvert.ToString, value);
        }
        public RelayStatus StatusRelayTen
        {
            get => (RelayStatus)GetField(1, DataFields.StatusRelay10).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(1, DataFields.StatusRelay10).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0200() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0200(Header header) : base(header)
        {
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        DataField.Number(DataFields.StatusRelay1, 20, 1, false),
                        DataField.Number(DataFields.StatusRelay2, 21, 1, false),
                        DataField.Number(DataFields.StatusRelay3, 22, 1, false),
                        DataField.Number(DataFields.StatusRelay4, 23, 1, false),
                        DataField.Number(DataFields.StatusRelay5, 24, 1, false),
                        DataField.Number(DataFields.StatusRelay6, 25, 1, false),
                        DataField.Number(DataFields.StatusRelay7, 26, 1, false),
                        DataField.Number(DataFields.StatusRelay8, 27, 1, false),
                        DataField.Number(DataFields.StatusRelay9, 28, 1, false),
                        DataField.Number(DataFields.StatusRelay10, 29, 1, false)
                    }
                }
            };
        }

        protected enum DataFields
        {
            StatusRelay1,
            StatusRelay2,
            StatusRelay3,
            StatusRelay4,
            StatusRelay5,
            StatusRelay6,
            StatusRelay7,
            StatusRelay8,
            StatusRelay9,
            StatusRelay10
        }
    }
}
