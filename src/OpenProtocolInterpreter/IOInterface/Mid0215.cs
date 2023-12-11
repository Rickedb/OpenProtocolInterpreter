using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public const int MID = 215;

        public int IODeviceId
        {
            get => GetField(Header.StandardizedRevision, DataFields.IODeviceId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.StandardizedRevision, DataFields.IODeviceId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<Relay> Relays { get; set; }
        public List<DigitalInput> DigitalInputs { get; set; }
        //rev 2
        public int NumberOfRelays
        {
            get => GetField(2, DataFields.NumberOfRelays).GetValue(OpenProtocolConvert.ToInt32);
            private set => GetField(2, DataFields.NumberOfRelays).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int NumberOfDigitalInputs
        {
            get => GetField(2, DataFields.NumberOfDigitalInputs).GetValue(OpenProtocolConvert.ToInt32);
            private set => GetField(2, DataFields.NumberOfDigitalInputs).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0215() : this(DEFAULT_REVISION)
        {

        }

        public Mid0215(Header header) : base(header)
        {
            Relays = [];
            DigitalInputs = [];
        }

        public Mid0215(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {

        }

        protected override string BuildHeader()
        {
            if (RevisionsByFields.Any())
            {
                Header.Length = 20;
                var revision = Header.StandardizedRevision;
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

                var relayListField = GetField(2, DataFields.RelayList);
                relayListField.Size = NumberOfRelays * 4;
                relayListField.Value = PackRelays();
                GetField(2, DataFields.NumberOfDigitalInputs).Index = relayListField.Index + relayListField.Size;

                GetField(2, DataFields.DigitalInputList).Index = GetField(2, DataFields.NumberOfDigitalInputs).Index + 2;
                GetField(2, DataFields.DigitalInputList).Size = NumberOfDigitalInputs * 4;
                GetField(2, DataFields.DigitalInputList).Value = PackDigitalInputs();
            }
            else
            {
                GetField(1, DataFields.RelayList).Value = PackRelays();
                GetField(1, DataFields.DigitalInputList).Value = PackDigitalInputs();
            }

            var builder = new StringBuilder(BuildHeader());
            int prefixIndex = 1;
            foreach (var field in RevisionsByFields[Header.StandardizedRevision])
            {
                builder.Append(string.Concat(prefixIndex.ToString("D2"), field.Value));
                prefixIndex++;
            }
            return builder.ToString();
        }

        public override Mid Parse(string package)
        {
            Header = ProcessHeader(package);

            var revision = Header.StandardizedRevision;

            var relayListField = GetField(revision, DataFields.RelayList);
            var digitalListField = GetField(revision, DataFields.DigitalInputList);
            if (revision > 1)
            {
                int numberOfRelays = OpenProtocolConvert.ToInt32(GetValue(GetField(2, DataFields.NumberOfRelays), package));
                relayListField.Size = numberOfRelays * 4;

                var numberOfDigitalInputsField = GetField(2, DataFields.NumberOfDigitalInputs);
                numberOfDigitalInputsField.Index = relayListField.Index + 2 + relayListField.Size;

                digitalListField.Index = numberOfDigitalInputsField.Index + 2 + numberOfDigitalInputsField.Size;
                digitalListField.Size = Header.Length - 2 - digitalListField.Index;
            }

            ProcessDataFields(package);

            Relays = Relay.ParseAll(relayListField.Value).ToList();
            DigitalInputs = DigitalInput.ParseAll(digitalListField.Value).ToList();
            return this;
        }

        protected virtual string PackRelays()
        {
            var value = new StringBuilder();
            foreach (var relay in Relays)
                value.Append(relay.Pack());

            return value.ToString();
        }

        protected virtual string PackDigitalInputs()
        {
            var value = new StringBuilder();
            foreach (var digitalInput in DigitalInputs)
                value.Append(digitalInput.Pack());

            return value.ToString();
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                DataField.Number(DataFields.IODeviceId, 20, 2),
                                new(DataFields.RelayList, 24, 32),
                                new(DataFields.DigitalInputList, 58, 32)
                            }
                },
                {
                    2, new List<DataField>()
                            {
                                DataField.Number(DataFields.IODeviceId, 20, 2),
                                DataField.Number(DataFields.NumberOfRelays, 24, 2),
                                DataField.Volatile(DataFields.RelayList, 28),
                                new(DataFields.NumberOfDigitalInputs, 0, 2, '0', PaddingOrientation.LeftPadded),
                                DataField.Volatile(DataFields.DigitalInputList)
                            }
                }
            };
        }

        protected enum DataFields
        {
            IODeviceId,
            RelayList,
            DigitalInputList,
            //rev2 
            NumberOfRelays,
            NumberOfDigitalInputs
        }
    }
}
