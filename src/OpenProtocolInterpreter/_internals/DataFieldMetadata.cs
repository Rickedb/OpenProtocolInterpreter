using System.Reflection;

namespace OpenProtocolInterpreter
{
    internal struct DataFieldMetadata
    {
        public int Index { get; set; }
        public DataFieldDefinitionAttribute Attribute { get; set; }
        public PropertyInfo Property { get; set; }

        public DataFieldMetadata(DataFieldDefinition definition)
        {

        }

        public DataFieldMetadata(int index, DataFieldDefinitionAttribute attribute, PropertyInfo property)
        {
            Index = index;
            Attribute = attribute;
            Property = property;
        }

        /// <summary>
        /// Creates the data field bound to <paramref name="owner"/>, which is either a <see cref="Mid"/> or an <see cref="ExtraData"/>.
        /// </summary>
        public DataField CreateAndBind(object owner)
        {
            return Attribute.CreateAndBind(owner, Property, Index);
        }
    }
}
