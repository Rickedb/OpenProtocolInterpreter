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

        [Int32DataFieldDefinition(field: 1, revision: 1, Size = 2)]
        public int IODeviceId { get; set; }
        [RelayCollectionDefinition(field: 2, revision: 1, Size = 4 * 8)]
        public List<Relay> Relays { get; set; }
        [DigitalInputCollectionDefinition(field: 3, revision: 1, Size = 4 * 8)]
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

        public override string Pack()
        {
            HandleRevision();
            if (Header.Revision > 1)
            {
                NumberOfRelays = Relays.Count;
                NumberOfDigitalInputs = DigitalInputs.Count;

                GetField(revision: 1, field: 2).Size = NumberOfRelays * 4;
                GetField(revision: 1, field: 3).Size = NumberOfDigitalInputs * 4;

                var builder = new StringBuilder(BuildHeader());
                int prefixIndex = 1;

                var fields = OrderedDataFieldsByRevision().ToList();
                builder.Append(base.Pack(fields, ref prefixIndex));
                return builder.ToString();
            }

            return base.Pack();
        }

        protected override void ProcessDataFields(ReadOnlySpan<char> package)
        {
            HandleRevision();
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
                    var relays = GetField(revision: 1, field: 2);
                    relays.Index = field.Index + field.TotalSize;
                    relays.Size = NumberOfRelays * 4;
                }
                else if (index == 3)
                {
                    var numberOfDigitalInputs = GetField(revision: 2, field: 5);
                    numberOfDigitalInputs.Index = field.Index + field.TotalSize;
                }
                else if (index == 4)
                {
                    var digitalInputs = GetField(revision: 1, field: 3);
                    digitalInputs.Index = field.Index + field.TotalSize;
                    digitalInputs.Size = NumberOfDigitalInputs * 4;
                }
            }
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            base.ProcessDataField(dataField, package);
            if (Header.StandardizedRevision <= 1)
                return;

            if (dataField.Field == 2)
            {
                var relays = GetField(revision: 1, field: 2);
                relays.Index = dataField.Index + dataField.TotalSize;
                relays.Size = NumberOfRelays * 4;

                var numberOfDigitalInputs = GetField(revision: 2, field: 4);
                numberOfDigitalInputs.Index = relays.Index + relays.TotalSize;
            }
            else if (dataField.Field == 4)
            {
                var digitalInputs = GetField(revision: 1, field: 3);
                digitalInputs.Index = dataField.Index + dataField.TotalSize;
                digitalInputs.Size = NumberOfDigitalInputs * 4;
            }
        }

        private void HandleRevision()
        {
            if (Header.StandardizedRevision == 1)
            {
                EnsureEightRelaysAndDigitalInputs();
            }
        }

        private IEnumerable<DataField> OrderedDataFieldsByRevision()
        {
            var revision = Header.StandardizedRevision;
            if (revision == 1)
            {
                yield return GetField(revision: 1, field: 1);
                yield return GetField(revision: 1, field: 2);
                yield return GetField(revision: 1, field: 3);
            }
            else
            {
                yield return GetField(revision: 1, field: 1);
                yield return GetField(revision: 2, field: 4);
                yield return GetField(revision: 1, field: 2);
                yield return GetField(revision: 2, field: 5);
                yield return GetField(revision: 1, field: 3);
            }
        }

        private void EnsureEightRelaysAndDigitalInputs()
        {
            GetField(revision: 1, field: 2).Size = 4 * 8;
            for (int i = Relays.Count; i < 8; i++)
                Relays.Add(new Relay(RelayNumber.Off, false));

            GetField(revision: 1, field: 3).Size = 4 * 8;
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
