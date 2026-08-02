using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace OpenProtocolInterpreter.ApplicationSelector
{
    /// <summary>
    /// Selector socket info
    /// <para>
    ///     This message is sent each time a socket is lifted or put back in position.
    ///     This MID contains the device ID of the selector the information is coming from,
    ///     the number of sockets of the selector device, and the current status of each socket
    ///     (lifted or not lifted).
    /// </para>
    /// <para>Message sent by: Controller</para>
    /// <para>Answer: <see cref="Mid0252"/>, Selector socket info acknowledge</para>
    /// </summary>
    public class Mid0251 : Mid, IApplicationSelector, IController, IAcknowledgeable<Mid0252>
    {
        public const int MID = 251;

        [Int32DataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 2)]
        public int DeviceId { get; set; }

        [Int32DataFieldDefinition(revision: 1, field: 2, Index = 24, Size = 2)]
        public int NumberOfSockets { get; set; }

        [SocketStatusListDefinition(revision: 1, field: 3, Index = 28)]
        public List<bool> SocketStatus { get; set; }

        public Mid0251() : this(new Header()
        {
            Mid = MID,
            Revision = DEFAULT_REVISION
        })
        {

        }

        public Mid0251(Header header) : base(header)
        {
            SocketStatus ??= [];
        }

        public override string Pack()
        {
            NumberOfSockets = SocketStatus.Count;
            GetField(nameof(SocketStatus)).Size = NumberOfSockets;
            return base.Pack();
        }

        protected override void ProcessDataField(DataField dataField, ReadOnlySpan<char> package)
        {
            if (dataField.Field == 3)
            {
                dataField.Size = NumberOfSockets;
            }
            base.ProcessDataField(dataField, package);
        }

        private class SocketStatusListDefinitionAttribute : DataFieldDefinitionAttribute
        {
            public SocketStatusListDefinitionAttribute(int revision) : base(revision)
            {

            }
            public SocketStatusListDefinitionAttribute(int field, int revision) : base(field, revision)
            {

            }

            internal override DataField Build(Mid mid, PropertyInfo propertyInfo, int index)
            {
                return new DataField<List<bool>>(Field, index, Size, HasPrefix)
                {
                    DefaultConverter = PackSocketStatus,
                    DefaultParser = ParseSocketStatus
                }.Bind(mid, propertyInfo);
            }

            protected static string PackSocketStatus(char paddingChar, int size, PaddingOrientation orientation, List<bool> socketStatus)
            {
                var builder = new StringBuilder(socketStatus.Count);
                foreach (var v in socketStatus)
                    builder.Append(OpenProtocolConvert.ToString(v));

                return builder.ToString();
            }

            protected static List<bool> ParseSocketStatus(string section)
            {
                var span = section.AsSpan();
                var list = new List<bool>(span.Length);
                for (int i = 0; i < span.Length; i++)
                    list.Add(OpenProtocolConvert.ToBoolean(span.Slice(i, 1)));

                return list;
            }
        }
    }
}
