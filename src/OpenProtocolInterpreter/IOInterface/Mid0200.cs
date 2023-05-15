using OpenProtocolInterpreter.Converters;
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
        private readonly IValueConverter<int> _intConverter;
        public const int MID = 200;

        public RelayStatus StatusRelayOne
        {
            get => (RelayStatus)GetField(1,(int)DataFields.STATUS_RELAY_1).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_RELAY_1).SetValue(_intConverter.Convert, (int)value);
        }
        public RelayStatus StatusRelayTwo
        {
            get => (RelayStatus)GetField(1,(int)DataFields.STATUS_RELAY_2).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_RELAY_2).SetValue(_intConverter.Convert, (int)value);
        }
        public RelayStatus StatusRelayThree
        {
            get => (RelayStatus)GetField(1,(int)DataFields.STATUS_RELAY_3).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_RELAY_3).SetValue(_intConverter.Convert, (int)value);
        }
        public RelayStatus StatusRelayFour
        {
            get => (RelayStatus)GetField(1,(int)DataFields.STATUS_RELAY_4).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_RELAY_4).SetValue(_intConverter.Convert, (int)value);
        }
        public RelayStatus StatusRelayFive
        {
            get => (RelayStatus)GetField(1,(int)DataFields.STATUS_RELAY_5).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_RELAY_5).SetValue(_intConverter.Convert, (int)value);
        }
        public RelayStatus StatusRelaySix
        {
            get => (RelayStatus)GetField(1,(int)DataFields.STATUS_RELAY_6).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_RELAY_6).SetValue(_intConverter.Convert, (int)value);
        }
        public RelayStatus StatusRelaySeven
        {
            get => (RelayStatus)GetField(1,(int)DataFields.STATUS_RELAY_7).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_RELAY_7).SetValue(_intConverter.Convert, (int)value);
        }
        public RelayStatus StatusRelayEight
        {
            get => (RelayStatus)GetField(1,(int)DataFields.STATUS_RELAY_8).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_RELAY_8).SetValue(_intConverter.Convert, (int)value);
        }
        public RelayStatus StatusRelayNine
        {
            get => (RelayStatus)GetField(1,(int)DataFields.STATUS_RELAY_9).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_RELAY_9).SetValue(_intConverter.Convert, (int)value);
        }
        public RelayStatus StatusRelayTen
        {
            get => (RelayStatus)GetField(1,(int)DataFields.STATUS_RELAY_10).GetValue(_intConverter.Convert);
            set => GetField(1,(int)DataFields.STATUS_RELAY_10).SetValue(_intConverter.Convert, (int)value);
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
            _intConverter = new Int32Converter();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                    {
                        new DataField((int)DataFields.STATUS_RELAY_1, 20, 1, false),
                        new DataField((int)DataFields.STATUS_RELAY_2, 21, 1, false),
                        new DataField((int)DataFields.STATUS_RELAY_3, 22, 1, false),
                        new DataField((int)DataFields.STATUS_RELAY_4, 23, 1, false),
                        new DataField((int)DataFields.STATUS_RELAY_5, 24, 1, false),
                        new DataField((int)DataFields.STATUS_RELAY_6, 25, 1, false),
                        new DataField((int)DataFields.STATUS_RELAY_7, 26, 1, false),
                        new DataField((int)DataFields.STATUS_RELAY_8, 27, 1, false),
                        new DataField((int)DataFields.STATUS_RELAY_9, 28, 1, false),
                        new DataField((int)DataFields.STATUS_RELAY_10, 29, 1, false)
                    }
                }
            };
        }

        protected enum DataFields
        {
            STATUS_RELAY_1,
            STATUS_RELAY_2,
            STATUS_RELAY_3,
            STATUS_RELAY_4,
            STATUS_RELAY_5,
            STATUS_RELAY_6,
            STATUS_RELAY_7,
            STATUS_RELAY_8,
            STATUS_RELAY_9,
            STATUS_RELAY_10
        }
    }
}
