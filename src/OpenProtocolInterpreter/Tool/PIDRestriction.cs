using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace OpenProtocolInterpreter.Tool
{
    public class PIDRestriction
    {
        /// <summary>
        /// Size in bytes of a packed <see cref="PIDRestriction"/>: <see cref="PID"/> (6) plus <see cref="Restriction"/> (3).
        /// </summary>
        internal const int PackedSize = 9;

        public int PID { get; set; }
        public int Restriction { get; set; }

        public PIDRestriction()
        {

        }

        public PIDRestriction(int pid, int restriction)
        {
            PID = pid;
            Restriction = restriction;
        }

        public string Pack()
        {
            return OpenProtocolConvert.ToString('0', 6, PaddingOrientation.LeftPadded, PID) +
                   OpenProtocolConvert.ToString('0', 3, PaddingOrientation.LeftPadded, Restriction);
        }

        public static PIDRestriction Parse(string value)
            => Parse(value.AsSpan());

        public static PIDRestriction Parse(ReadOnlySpan<char> value)
        {
            return new PIDRestriction()
            {
                PID = OpenProtocolConvert.ToInt32(value.Slice(0, 6)),
                Restriction = OpenProtocolConvert.ToInt32(value.Slice(6, 3)),
            };
        }
    }

    public class PIDRestrictionCollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public PIDRestrictionCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public PIDRestrictionCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<PIDRestriction>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = PackPIDRestriction,
                DefaultParser = ParsePIDRestriction
            }.Bind(owner, propertyInfo);
        }

        private string PackPIDRestriction(char paddingChar, int size, PaddingOrientation orientation, List<PIDRestriction> pidRestrictions)
            => string.Join("", pidRestrictions.Select(p => p.Pack()));

        private List<PIDRestriction> ParsePIDRestriction(string value)
        {
            var span = value.AsSpan();
            var pidRestrictions = new List<PIDRestriction>(span.Length / PIDRestriction.PackedSize);
            for (int i = 0; i + PIDRestriction.PackedSize <= span.Length; i += PIDRestriction.PackedSize)
            {
                pidRestrictions.Add(PIDRestriction.Parse(span.Slice(i, PIDRestriction.PackedSize)));
            }

            return pidRestrictions;
        }
    }
}
