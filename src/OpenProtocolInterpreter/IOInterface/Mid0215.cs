using OpenProtocolInterpreter.Converters;
using System.Collections.Generic;
using System.Linq;

namespace OpenProtocolInterpreter.IOInterface
{
    /// <summary>
    /// IO device status reply
    /// <para>
    ///     This message is sent as an answer to the <see cref="Mid0214"/> IO device status request.
    ///     <see cref="Mid0215"/> revision 1 should only be used to get the status of IO devices with max 8 relays/digital
    ///     inputs.
    ///     For external I/O devices each list contain up to 8 relays/digital inputs. For the internal device the lists
    ///     contain up to 4 relays/digital inputs and the remaining 4 will be empty.
    ///     <see cref="Mid0215"/> revision 2 can be used to get the status of all types of IO devices with up to 48 relays/digital
    ///     inputs.
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: None</para>
    /// </summary>
    public class Mid0215 : Mid, IIOInterface, IController
    {
        private readonly IValueConverter<int> _intConverter;
        private readonly IValueConverter<IEnumerable<Relay>> _relayListConverter;
        private readonly IValueConverter<IEnumerable<DigitalInput>> _digitalInputListConverter;
        private const int LAST_REVISION = 2;
        public const int MID = 215;

        public int IODeviceId
        {
            get => GetField(Header.Revision, (int)DataFields.IO_DEVICE_ID).GetValue(_intConverter.Convert);
            set => GetField(Header.Revision, (int)DataFields.IO_DEVICE_ID).SetValue(_intConverter.Convert, value);
        }
        public List<Relay> Relays { get; set; }
        public List<DigitalInput> DigitalInputs { get; set; }
        //rev 2
        public int NumberOfRelays
        {
            get => GetField(2, (int)DataFields.NUMBER_OF_RELAYS).GetValue(_intConverter.Convert);
            private set => GetField(2, (int)DataFields.NUMBER_OF_RELAYS).SetValue(_intConverter.Convert, value);
        }
        public int NumberOfDigitalInputs
        {
            get => GetField(2, (int)DataFields.NUMBER_OF_DIGITAL_INPUTS).GetValue(_intConverter.Convert);
            private set => GetField(2, (int)DataFields.NUMBER_OF_DIGITAL_INPUTS).SetValue(_intConverter.Convert, value);
        }

        public Mid0215() : this(LAST_REVISION)
        {

        }

        public Mid0215(int revision = LAST_REVISION) : base(MID, revision)
        {
            var boolConverter = new BoolConverter();
            _intConverter = new Int32Converter();
            _relayListConverter = new RelayListConverter(_intConverter, boolConverter);
            _digitalInputListConverter = new DigitalInputListConverter(_intConverter, boolConverter);
            Relays = new List<Relay>();
            DigitalInputs = new List<DigitalInput>();
        }

        protected override string BuildHeader()
        {
            if (RevisionsByFields.Any())
            {
                Header.Length = 20;
                var revision = Header.Revision > 0 ? Header.Revision : 1;
                foreach (var dataField in RevisionsByFields[revision])
                    Header.Length += (dataField.HasPrefix ? 2 : 0) + dataField.Size;
            }
            return Header.ToString();
        }

        public override string Pack()
        {
            if (Header.Revision > 1)
            {
                NumberOfRelays = Relays.Count;
                NumberOfDigitalInputs = DigitalInputs.Count;

                var relayListField = GetField(2, (int)DataFields.RELAY_LIST);
                relayListField.Size = NumberOfRelays * 4;
                relayListField.Value = _relayListConverter.Convert(Relays);
                GetField(2, (int)DataFields.NUMBER_OF_DIGITAL_INPUTS).Index = relayListField.Index + relayListField.Size;

                GetField(2, (int)DataFields.DIGITAL_INPUT_LIST).Index = GetField(2, (int)DataFields.NUMBER_OF_DIGITAL_INPUTS).Index + 2;
                GetField(2, (int)DataFields.DIGITAL_INPUT_LIST).Size = NumberOfDigitalInputs * 4;
                GetField(2, (int)DataFields.DIGITAL_INPUT_LIST).Value = _digitalInputListConverter.Convert(DigitalInputs);
            }
            else
            {
                Header.Revision = 1;
                GetField(1, (int)DataFields.RELAY_LIST).Value = _relayListConverter.Convert(Relays);
                GetField(1, (int)DataFields.DIGITAL_INPUT_LIST).Value = _digitalInputListConverter.Convert(DigitalInputs);
            }

            string pkg = BuildHeader();
            int prefixIndex = 1;
            foreach (var field in RevisionsByFields[Header.Revision])
            {
                pkg += prefixIndex.ToString().PadLeft(2, '0') + field.Value;
                prefixIndex++;
            }
            return pkg;
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);
            DataField relayListField;
            DataField digitalListField;

            if (Header.Revision > 1)
            {
                relayListField = GetField(2, (int)DataFields.RELAY_LIST);
                digitalListField = GetField(2, (int)DataFields.DIGITAL_INPUT_LIST);
                int numberOfRelays = _intConverter.Convert(GetValue(GetField(2, (int)DataFields.NUMBER_OF_RELAYS), package));
                relayListField.Size = numberOfRelays * 4;

                var numberOfDigitalInputsField = GetField(2, (int)DataFields.NUMBER_OF_DIGITAL_INPUTS);
                numberOfDigitalInputsField.Index = relayListField.Index + 2 + relayListField.Size;

                digitalListField.Index = numberOfDigitalInputsField.Index + 2 + numberOfDigitalInputsField.Size;
                digitalListField.Size = package.Length - 2 - digitalListField.Index;
            }
            else
            {
                relayListField = GetField(1, (int)DataFields.RELAY_LIST);
                digitalListField = GetField(1, (int)DataFields.DIGITAL_INPUT_LIST);
            }

            ProcessDataFields(package);

            Relays = _relayListConverter.Convert(relayListField.Value).ToList();
            DigitalInputs = _digitalInputListConverter.Convert(digitalListField.Value).ToList();
            return this;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.IO_DEVICE_ID, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.RELAY_LIST, 24, 32),
                                new DataField((int)DataFields.DIGITAL_INPUT_LIST, 58, 32)
                            }
                },
                {
                    2, new List<DataField>()
                            {
                                new DataField((int)DataFields.IO_DEVICE_ID, 20, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.NUMBER_OF_RELAYS, 24, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.RELAY_LIST, 28, 0),
                                new DataField((int)DataFields.NUMBER_OF_DIGITAL_INPUTS, 0, 2, '0', DataField.PaddingOrientations.LEFT_PADDED),
                                new DataField((int)DataFields.DIGITAL_INPUT_LIST, 0, 0)
                            }
                }
            };
        }

        public enum DataFields
        {
            IO_DEVICE_ID,
            RELAY_LIST,
            DIGITAL_INPUT_LIST,
            //rev2 
            NUMBER_OF_RELAYS,
            NUMBER_OF_DIGITAL_INPUTS
        }
    }
}
