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
        public const int MID = 215;

        public int IODeviceId
        {
            get => GetField(Header.Revision, (int)DataFields.IODeviceId).GetValue(OpenProtocolConvert.ToInt32);
            set => GetField(Header.Revision, (int)DataFields.IODeviceId).SetValue(OpenProtocolConvert.ToString, value);
        }
        public List<Relay> Relays { get; set; }
        public List<DigitalInput> DigitalInputs { get; set; }
        //rev 2
        public int NumberOfRelays
        {
            get => GetField(2, (int)DataFields.NumberOfRelays).GetValue(OpenProtocolConvert.ToInt32);
            private set => GetField(2, (int)DataFields.NumberOfRelays).SetValue(OpenProtocolConvert.ToString, value);
        }
        public int NumberOfDigitalInputs
        {
            get => GetField(2, (int)DataFields.NumberOfDigitalInputs).GetValue(OpenProtocolConvert.ToInt32);
            private set => GetField(2, (int)DataFields.NumberOfDigitalInputs).SetValue(OpenProtocolConvert.ToString, value);
        }

        public Mid0215() : this(DEFAULT_REVISION)
        {

        }

        public Mid0215(Header header) : base(header)
        {
            Relays = new List<Relay>();
            DigitalInputs = new List<DigitalInput>();
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

                var relayListField = GetField(2, (int)DataFields.RelayList);
                relayListField.Size = NumberOfRelays * 4;
                relayListField.Value = PackRelays();
                GetField(2, (int)DataFields.NumberOfDigitalInputs).Index = relayListField.Index + relayListField.Size;

                GetField(2, (int)DataFields.DigitalInputList).Index = GetField(2, (int)DataFields.NumberOfDigitalInputs).Index + 2;
                GetField(2, (int)DataFields.DigitalInputList).Size = NumberOfDigitalInputs * 4;
                GetField(2, (int)DataFields.DigitalInputList).Value = PackDigitalInputs();
            }
            else
            {
                Header.Revision = 1;
                GetField(1, (int)DataFields.RelayList).Value = PackRelays();
                GetField(1, (int)DataFields.DigitalInputList).Value = PackDigitalInputs();
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

            var revision = Header.Revision > 1 ? 2 : 1;

            var relayListField = GetField(revision, (int)DataFields.RelayList);
            var digitalListField = GetField(revision, (int)DataFields.DigitalInputList);
            if (revision > 1)
            {
                int numberOfRelays = OpenProtocolConvert.ToInt32(GetValue(GetField(2, (int)DataFields.NumberOfRelays), package));
                relayListField.Size = numberOfRelays * 4;

                var numberOfDigitalInputsField = GetField(2, (int)DataFields.NumberOfDigitalInputs);
                numberOfDigitalInputsField.Index = relayListField.Index + 2 + relayListField.Size;

                digitalListField.Index = numberOfDigitalInputsField.Index + 2 + numberOfDigitalInputsField.Size;
                digitalListField.Size = Header.Length - 2 - digitalListField.Index;
            }

            ProcessDataFields(package);

            Relays = Relay.ParseAll(relayListField.Value).ToList();
            DigitalInputs =DigitalInput.ParseAll(digitalListField.Value).ToList();
            return this;
        }

        protected virtual string PackRelays()
        {
            string pack = string.Empty;
            foreach (var relay in Relays)
                pack += relay.Pack();

            return pack;
        }

        protected virtual string PackDigitalInputs()
        {
            string pack = string.Empty;
            foreach (var digitalInput in DigitalInputs)
                pack += digitalInput.Pack();

            return pack;
        }

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    1, new List<DataField>()
                            {
                                new DataField((int)DataFields.IODeviceId, 20, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.RelayList, 24, 32),
                                new DataField((int)DataFields.DigitalInputList, 58, 32)
                            }
                },
                {
                    2, new List<DataField>()
                            {
                                new DataField((int)DataFields.IODeviceId, 20, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.NumberOfRelays, 24, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.RelayList, 28, 0),
                                new DataField((int)DataFields.NumberOfDigitalInputs, 0, 2, '0', DataField.PaddingOrientations.LeftPadded),
                                new DataField((int)DataFields.DigitalInputList, 0, 0)
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
