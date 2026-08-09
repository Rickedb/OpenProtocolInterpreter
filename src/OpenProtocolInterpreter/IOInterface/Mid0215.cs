using System;
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

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 2)]
        [Int32DataFieldDefinition(revision: 2, field: 1, Index = 20, Size = 2)]
        public int IODeviceId { get; set; }

        [RelayCollectionDefinition(revision: 1, field: 2, Index = 24, Size = 4 * 8)]
        [RelayCollectionDefinition(revision: 2, field: 3, Index = 28, Size = 4 * 8)]
        public List<Relay> Relays { get; set; } = new List<Relay>();

        [DigitalInputCollectionDefinition(revision: 1, field: 3, Index = 58, Size = 4 * 8)]
        [DigitalInputCollectionDefinition(revision: 2, field: 5, Index = 0, Size = 4 * 8)]
        public List<DigitalInput> DigitalInputs { get; set; } = new List<DigitalInput>();

        //At revision 2 number of relays/digital inputs comes before their lists
        [Int32DataFieldDefinition(revision: 2, field: 2, Index = 24, Size = 2)]
        public int NumberOfRelays { get; set; }

        [Int32DataFieldDefinition(revision: 2, field: 4, Index = 26, Size = 2)]
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

                var relaysField = GetField(revision: 2, field: 3);
                relaysField.Size = NumberOfRelays * 4;

                var numberOfDigitalInputsField = GetField(revision: 2, field: 4);
                numberOfDigitalInputsField.Index = relaysField.Index + relaysField.TotalSize;

                var digitalInputsField = GetField(revision: 2, field: 5);
                digitalInputsField.Index = numberOfDigitalInputsField.Index + numberOfDigitalInputsField.TotalSize;
                digitalInputsField.Size = NumberOfDigitalInputs * 4;

                var builder = new StringBuilder(BuildHeader());

                var fields = RevisionsByFields[Header.StandardizedRevision].OrderBy(x => x.Field);
                builder.Append(base.Pack(fields));
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

            var fields = RevisionsByFields[Header.StandardizedRevision].OrderBy(x => x.Field);
            var enumerator = fields.GetEnumerator();

            while (enumerator.MoveNext())
            {
                var field = enumerator.Current;
                base.ProcessDataField(field, package);
                if (Header.StandardizedRevision <= 1)
                    continue;

                if (field.Field == 2)
                {
                    var relays = GetField(revision: 2, field: 3);
                    relays.Index = field.Index + field.TotalSize;
                    relays.Size = NumberOfRelays * 4;
                }
                else if (field.Field == 3)
                {
                    var numberOfDigitalInputs = GetField(revision: 2, field: 4);
                    numberOfDigitalInputs.Index = field.Index + field.TotalSize;
                }
                else if (field.Field == 4)
                {
                    var digitalInputs = GetField(revision: 2, field: 5);
                    digitalInputs.Index = field.Index + field.TotalSize;
                    digitalInputs.Size = NumberOfDigitalInputs * 4;
                }
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
    }
}
