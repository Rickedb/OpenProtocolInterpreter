using System.Collections.Generic;

namespace OpenProtocolInterpreter.Communication
{
    /// <summary>
    /// Application communication start
    /// <para>This message enables the communication. The controller does not respond to any other command before this</para>
    /// <para>Message sent by Integrator</para>
    /// <para>Answers: <see cref="Mid0002"/> Communication start acknowledge or <see cref="Mid0004"/> Command error, Client already connected or MID revision unsupported</para>
    /// </summary>
    public class Mid0001 : Mid, ICommunication, IIntegrator, IAnswerableBy<Mid0002>, IDeclinableCommand
    {
        public const int MID = 1;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.ClientAlreadyConnected, Error.MidRevisionUnsupported };

        [BooleanDataFieldDefinition(id: 0, revision: 7)]
        public bool OptionalKeepAlive { get; set; }

        [BooleanDataFieldDefinition(id: 1, revision: 8)]
        public bool OptionalToolLockAtDisconnection { get; set; }

        [DecimalDataFieldDefinition(id: 2, revision: 8, Size = 4)]
        public decimal OptionalEarlyLock { get; set; }

        public Mid0001() : this(DEFAULT_REVISION)
        {

        }

        public Mid0001(Header header) : base(header)
        {
        }

        public Mid0001(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        // protected override Dictionary<int, List<DataField>> RegisterDatafields()
        // {
        //     var fields = new Dictionary<int, List<DataField>>();
        //     if (Header.Revision >= 7)
        //     {
        //         fields.Add(7,
        //         [
        //             DataField.Boolean(DataFields.UseKeepAlive, 20).Bind(this, nameof(OptionalKeepAlive))
        //         ]);
        //     }

        //     if (Header.Revision >= 8)
        //     {
        //         fields.Add(8,
        //         [
        //             DataField.Boolean(DataFields.OptionalToolLockAtDisconnection, 24).Bind(this, nameof(OptionalToolLockAtDisconnection)),
        //             DataField.Decimal(DataFields.OptionalEarlyLock, 26, 4).Bind(this, nameof(OptionalEarlyLock))
        //         ]);
        //     }

        //     return fields;
        // }

        protected enum DataFields
        {
            //Rev 7
            UseKeepAlive,
            OptionalToolLockAtDisconnection,
            OptionalEarlyLock
        }
    }
}
