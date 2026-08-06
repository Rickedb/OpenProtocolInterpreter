using System;

namespace OpenProtocolInterpreter.ParameterSet
{
    public class Mid2503 : Mid, IIntegrator, IParameterSet
    {
        public const int MID = 2503;

        [StringDataFieldDefinition(revision: 1, field: 1, Index = 20, Size = 0, HasPrefix = false)]
        public string Password { get; set; }

        public Mid2503() : this(DEFAULT_REVISION)
        {
        }

        public Mid2503(Header header) : base(header)
        {
        }

        public Mid2503(int revision) : this(new Header()
        {
            Mid = MID,
            Revision = revision
        })
        {
        }

        public override string Pack()
        {
            GetField(nameof(Password)).Size = Password?.Length ?? 0;
            return base.Pack();
        }

        public override Mid Parse(ReadOnlySpan<char> package)
        {
            GetField(nameof(Password)).Size = Header.Length - Header.DefaultSize;
            return base.Parse(package);
        }
    }
}
