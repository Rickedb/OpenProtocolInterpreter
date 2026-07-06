using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Defines a data field specification in a MID.
    /// <para>
    /// This attribute is used to decorate properties in a MID class to define how they should be parsed and formatted in the MID message.
    /// </para>
    /// </summary>
    public class DataFieldDefinitionAttribute : Attribute
    {
        public int Field { get; set; }
        public int Revision { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public char PaddingChar { get; set; } = ' ';
        public PaddingOrientation PaddingOrientation { get; set; } = PaddingOrientation.RightPadded;
        public bool HasPrefix { get; set; } = true;

        public DataFieldDefinitionAttribute(int revision)
        {
            Revision = revision;
        }
        public DataFieldDefinitionAttribute(int field, int revision) : this(revision)
        {
            if (field > 99 || field < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(field), "Data field id must be between 0 and 99");
            }
            Field = field;
        }

        internal DataField CreateAndBind(Mid mid, PropertyInfo propertyInfo)
            => CreateAndBind(mid, propertyInfo, Index);
        internal DataField CreateAndBind(Mid mid, PropertyInfo propertyInfo, int index)
        {
            return Build(mid, propertyInfo, index);
        }

        internal virtual DataField Build(Mid mid, PropertyInfo propertyInfo, int index)
        {
            return new DataField(Field, index, Size, PaddingChar, PaddingOrientation, HasPrefix);
        }
    }
    public class BooleanDataFieldDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public BooleanDataFieldDefinitionAttribute(int revision) : base(revision)
        {
            Size = 1;
        }
        public BooleanDataFieldDefinitionAttribute(int field, int revision) : base(field, revision)
        {
            Size = 1;
        }
        internal override DataField Build(Mid mid, PropertyInfo propertyInfo, int index)
        {
            return DataField.Boolean(Field, index, HasPrefix)
                            .Bind(mid, propertyInfo);
        }
    }
    public class StringDataFieldDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public StringDataFieldDefinitionAttribute(int revision) : base(revision)
        {
        }
        public StringDataFieldDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }
        internal override DataField Build(Mid mid, PropertyInfo propertyInfo, int index)
        {
            return DataField.String(Field, index, Size, PaddingOrientation, HasPrefix)
                            .Bind(mid, propertyInfo);
        }
    }
    public class Int32DataFieldDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public Int32DataFieldDefinitionAttribute(int revision) : base(revision)
        {
            PaddingChar = '0';
            PaddingOrientation = PaddingOrientation.LeftPadded;
        }
        public Int32DataFieldDefinitionAttribute(int field, int revision) : base(field, revision)
        {
            PaddingChar = '0';
            PaddingOrientation = PaddingOrientation.LeftPadded;
        }
        internal override DataField Build(Mid mid, PropertyInfo propertyInfo, int index)
        {
            return DataField.Int32(Field, index, Size, HasPrefix)
                            .Bind(mid, propertyInfo);
        }
    }
    public class Int64DataFieldDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public Int64DataFieldDefinitionAttribute(int revision) : base(revision)
        {
            PaddingChar = '0';
            PaddingOrientation = PaddingOrientation.LeftPadded;
        }
        public Int64DataFieldDefinitionAttribute(int field, int revision) : base(field, revision)
        {
            PaddingChar = '0';
            PaddingOrientation = PaddingOrientation.LeftPadded;
        }
        internal override DataField Build(Mid mid, PropertyInfo propertyInfo, int index)
        {
            return DataField.Int64(Field, index, Size, HasPrefix)
                            .Bind(mid, propertyInfo);
        }
    }
    public class DecimalDataFieldDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public DecimalDataFieldDefinitionAttribute(int revision) : base(revision)
        {
            PaddingChar = '0';
            PaddingOrientation = PaddingOrientation.LeftPadded;
        }
        public DecimalDataFieldDefinitionAttribute(int field, int revision) : base(field, revision)
        {
            PaddingChar = '0';
            PaddingOrientation = PaddingOrientation.LeftPadded;
        }
        internal override DataField Build(Mid mid, PropertyInfo propertyInfo, int index)
        {
            return DataField.Decimal(Field, index, Size, HasPrefix)
                            .Bind(mid, propertyInfo);
        }
    }

    public class TimestampDataFieldDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public TimestampDataFieldDefinitionAttribute(int revision) : base(revision)
        {
            Size = 19;
        }
        public TimestampDataFieldDefinitionAttribute(int field, int revision) : base(field, revision)
        {
            Size = 19;
        }
        internal override DataField Build(Mid mid, PropertyInfo propertyInfo, int index)
        {
            return DataField.Timestamp(Field, index, HasPrefix)
                            .Bind(mid, propertyInfo);
        }
    }

    public class VariableDataFieldCollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public VariableDataFieldCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public VariableDataFieldCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(Mid mid, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<VariableDataField>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = OpenProtocolConvert.ToString,
                DefaultParser = VariableDataField.ParseAll
            }.Bind(mid, propertyInfo);
        }
    }

    public class EnumCollectionDefinitionAttribute<T> : DataFieldDefinitionAttribute where T : Enum
    {
        public EnumCollectionDefinitionAttribute(int revision) : base(revision)
        {

        }
        public EnumCollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {

        }

        internal override DataField Build(Mid mid, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<T>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = PackEnums,
                DefaultParser = ParseEnums
            }.Bind(mid, propertyInfo);
        }

        private static string PackEnums(char paddingChar, int size, PaddingOrientation orientation, List<T> greenLights)
        {
            var builder = new StringBuilder(greenLights.Count);
            foreach (var e in greenLights)
                builder.Append(OpenProtocolConvert.ToString((int)(object)e));

            return builder.ToString();
        }

        private static List<T> ParseEnums(string value)
        {
            var list = new List<T>();
            foreach (var c in value)
                list.Add((T)(object)OpenProtocolConvert.ToInt32(c.ToString()));

            return list;
        }
    }
}
