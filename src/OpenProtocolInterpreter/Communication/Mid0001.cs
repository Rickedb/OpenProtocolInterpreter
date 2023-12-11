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

        public bool OptionalKeepAlive
        {
            get => GetField(7, DataFields.UseKeepAlive).GetValue(OpenProtocolConvert.ToBoolean);
            set => GetField(7, DataFields.UseKeepAlive).SetValue(OpenProtocolConvert.ToString, value);
        }

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

        protected override Dictionary<int, List<DataField>> RegisterDatafields()
        {
            return new Dictionary<int, List<DataField>>()
            {
                {
                    7, new List<DataField>()
                            {
                                DataField.Boolean(DataFields.UseKeepAlive, 20)
                            }
                }
            };
        }

        protected enum DataFields
        {
            //Rev 7
            UseKeepAlive
        }
    }
}
