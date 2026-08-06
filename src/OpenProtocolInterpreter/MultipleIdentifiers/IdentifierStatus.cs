using System;
using System.Reflection;

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    /// <summary>
    /// Represents an Identifier Status entity
    /// </summary>
    public class IdentifierStatus
    {
        public int IdentifierTypeNumber { get; set; }
        public bool IncludedInWorkOrder { get; set; }
        public StatusInWorkOrder StatusInWorkOrder { get; set; }
        public string ResultPart { get; set; }

        public string Pack()
        {
            return OpenProtocolConvert.ToString('0', 1, PaddingOrientation.LeftPadded, IdentifierTypeNumber) +
                   OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, Convert.ToInt32(IncludedInWorkOrder)) +
                   OpenProtocolConvert.ToString('0', 2, PaddingOrientation.LeftPadded, (int)StatusInWorkOrder) +
                   ResultPart.SafePadRight(25);
        }

        public static IdentifierStatus Parse(string section)
            => Parse(section.AsSpan());

        public static IdentifierStatus Parse(ReadOnlySpan<char> section)
        {
            if (section.IsEmpty)
                return default;

            return new IdentifierStatus()
            {
                IdentifierTypeNumber = OpenProtocolConvert.ToInt32(section.Slice(0, 1)),
                IncludedInWorkOrder = OpenProtocolConvert.ToBoolean(section.Slice(1, 2)),
                StatusInWorkOrder = (StatusInWorkOrder)OpenProtocolConvert.ToInt32(section.Slice(3, 2)),
                ResultPart = section.SafeSubstring(5, 25)
            };
        }
    }

    public class IdentifierStatusDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public IdentifierStatusDefinitionAttribute(int revision) : base(revision)
        {

        }
        public IdentifierStatusDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return new DataField<IdentifierStatus>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = Pack,
                DefaultParser = IdentifierStatus.Parse
            }.Bind(owner, propertyInfo);
        }

        private static string Pack(char paddingChar, int size, PaddingOrientation orientation, IdentifierStatus identifierStatus)
            => identifierStatus.Pack();
    }
}
