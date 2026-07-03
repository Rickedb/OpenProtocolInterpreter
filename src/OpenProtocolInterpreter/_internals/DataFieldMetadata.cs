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

        public DataField CreateAndBind(Mid mid)
        {
            return Attribute.CreateAndBind(mid, Property, Index);
        }
    }
}
