using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks.Dataflow;

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

        [Int32DataFieldDefinition(field: 1, revision: 1, Index = 20, Size = 2)]
        [Int32DataFieldDefinition(field: 1, revision: 2, Index = 20, Size = 2)]
        public int IODeviceId { get; set; }

        [RelayCollectionDefinition(field: 2, revision: 1, Index = 24, Size = 4 * 8)]
        [RelayCollectionDefinition(field: 2, revision: 2, Index = 28, Size = 4 * 8)]
        public List<Relay> Relays { get; set; }

        [DigitalInputCollectionDefinition(field: 3, revision: 1, Index = 58, Size = 4 * 8)]
        [DigitalInputCollectionDefinition(field: 3, revision: 2, Index = 0, Size = 4 * 8)]
        public List<DigitalInput> DigitalInputs { get; set; }

        //At revision 2 number of relays/digital inputs comes before their lists
        [Int32DataFieldDefinition(field: 4, revision: 2, Index = 24, Size = 2)]
        public int NumberOfRelays { get; set; }

        [Int32DataFieldDefinition(field: 5, revision: 2, Index = 0, Size = 2)]
        public int NumberOfDigitalInputs { get; set; }

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
            if (RevisionsByFields.TryGetValue(Header.StandardizedRevision, out var dataFields))
            {
                Header.Length = Header.DefaultSize + dataFields.Sum(x => x.TotalSize);
            }

            return Header.ToString();
        }

        public override string Pack()
        {
            if (Header.Revision > 1)
            {
                NumberOfRelays = Relays.Count;
                NumberOfDigitalInputs = DigitalInputs.Count;

                var relaysField = GetField(nameof(Relays));
                relaysField.Size = NumberOfRelays * 4;

                var numberOfDigitalInputsField = GetField(nameof(NumberOfDigitalInputs));
                numberOfDigitalInputsField.Index = relaysField.Index + relaysField.TotalSize;

                var digitalInputsField = GetField(nameof(DigitalInputs));
                digitalInputsField.Index = numberOfDigitalInputsField.Index + numberOfDigitalInputsField.TotalSize;
                digitalInputsField.Size = NumberOfDigitalInputs * 4;

                var builder = new StringBuilder(BuildHeader());
                int prefixIndex = 1;

                var fields = OrderedDataFieldsByRevision().ToList();
                builder.Append(base.Pack(fields, ref prefixIndex));
                return builder.ToString();
            }
            else
                EnsureEightRelaysAndDigitalInputs();

            return base.Pack();
        }

        protected override void ProcessDataFields(ReadOnlySpan<char> package)
        {
            if (Header.StandardizedRevision == 1)
            {
                EnsureEightRelaysAndDigitalInputs();
            }

            var fields = OrderedDataFieldsByRevision();
            var enumerator = fields.GetEnumerator();

            var index = 0;
            while (enumerator.MoveNext())
            {
                index++;
                var field = enumerator.Current;
                base.ProcessDataField(field, package);
                if (Header.StandardizedRevision <= 1)
                    continue;

                if (index == 2)
                {
                    var relays = GetField(nameof(Relays));
                    relays.Index = field.Index + field.TotalSize;
                    relays.Size = NumberOfRelays * 4;
                }
                else if (index == 3)
                {
                    var numberOfDigitalInputs = GetField(nameof(NumberOfDigitalInputs));
                    numberOfDigitalInputs.Index = field.Index + field.TotalSize;
                }
                else if (index == 4)
                {
                    var digitalInputs = GetField(nameof(DigitalInputs));
                    digitalInputs.Index = field.Index + field.TotalSize;
                    digitalInputs.Size = NumberOfDigitalInputs * 4;
                }
            }
        }

        private IEnumerable<DataField> OrderedDataFieldsByRevision()
        {
            if (Header.StandardizedRevision == 1)
            {
                yield return GetField(nameof(IODeviceId));
                yield return GetField(nameof(Relays));
                yield return GetField(nameof(DigitalInputs));
            }
            else
            {
                yield return GetField(nameof(IODeviceId));
                yield return GetField(nameof(NumberOfRelays));
                yield return GetField(nameof(Relays));
                yield return GetField(nameof(NumberOfDigitalInputs));
                yield return GetField(nameof(DigitalInputs));
            }
        }

        private void EnsureEightRelaysAndDigitalInputs()
        {
            if (Relays.Count > 8 || DigitalInputs.Count > 8)
                throw new InvalidOperationException("Revision 1 of MID 0215 can only have up to 8 relays and digital inputs.");

            GetField(nameof(Relays)).Size = 4 * 8;
            for (int i = Relays.Count; i < 8; i++)
                Relays.Add(new Relay(RelayNumber.Off, false));

            GetField(nameof(DigitalInputs)).Size = 4 * 8;
            for (int i = DigitalInputs.Count; i < 8; i++)
                DigitalInputs.Add(new DigitalInput(DigitalInputNumber.Off, false));
        }

        [Obsolete("Use DataFieldDefinition attributes instead")]
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
