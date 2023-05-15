using OpenProtocolInterpreter.Converters;
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
        private readonly IValueConverter<bool> _boolConverter;
        public const int MID = 1;

        public IEnumerable<Error> DocumentedPossibleErrors => new Error[] { Error.CLIENT_ALREADY_CONNECTED, Error.MID_REVISION_UNSUPPORTED };

        public bool OptionalKeepAlive
        {
            get => GetField(7, (int)DataFields.USE_KEEPALIVE).GetValue(_boolConverter.Convert);
            set => GetField(7, (int)DataFields.USE_KEEPALIVE).SetValue(_boolConverter.Convert, value);
        }

        public Mid0001() : this(DEFAULT_REVISION)
        {

        }

        public Mid0001(Header header) : base(header)
        {
            _boolConverter = new BoolConverter();
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
                                new DataField((int)DataFields.USE_KEEPALIVE, 20, 1)
                            }
                }
            };
        }

        public enum DataFields
        {
            //Rev 7
            USE_KEEPALIVE
        }
    }
}
