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
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
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

        /// <summary>
        /// Creates the data field and binds it to the decorated property of its owner (<see cref="Mid"/> or <see cref="ExtraData"/>).
        /// </summary>
        internal DataField CreateAndBind(object owner, PropertyInfo propertyInfo)
            => CreateAndBind(owner, propertyInfo, Index);
        internal DataField CreateAndBind(object owner, PropertyInfo propertyInfo, int index)
        {
            return Build(owner, propertyInfo, index);
        }

        internal virtual DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return new DataField(Field, index, Size, PaddingChar, PaddingOrientation, HasPrefix);
        }

        /// <summary>
        /// Tells whether the decorated property is an enum whose underlying type is <typeparamref name="T"/>,
        /// as happens when a <see cref="TighteningValueStatus"/> property is decorated with an
        /// <see cref="Int32DataFieldDefinitionAttribute"/>. Such a property reads back as a boxed enum rather
        /// than as a <typeparamref name="T"/>, so its data field needs a
        /// <see cref="DataField{T}.BackingPropertyConverter"/> to be packed.
        /// </summary>
        protected static bool IsEnumBackedBy<T>(PropertyInfo propertyInfo)
        {
            return propertyInfo != null
                && propertyInfo.PropertyType.IsEnum
                && Enum.GetUnderlyingType(propertyInfo.PropertyType) == typeof(T);
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
        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return DataField.Boolean(Field, Index, HasPrefix)
                            .Bind(owner, propertyInfo);
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
        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return DataField.String(Field, index, Size, PaddingOrientation, HasPrefix)
                            .Bind(owner, propertyInfo);
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
        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            var dataField = DataField.Int32(Field, index, Size, HasPrefix);
            if (IsEnumBackedBy<int>(propertyInfo))
            {
                dataField.BackingPropertyConverter = Convert.ToInt32;
            }

            return dataField.Bind(owner, propertyInfo);
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
        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            var dataField = DataField.Int64(Field, index, Size, HasPrefix);
            if (IsEnumBackedBy<long>(propertyInfo))
            {
                dataField.BackingPropertyConverter = Convert.ToInt64;
            }

            return dataField.Bind(owner, propertyInfo);
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
        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return DataField.Decimal(Field, index, Size, HasPrefix)
                            .Bind(owner, propertyInfo);
        }
    }

    public class TruncatedDecimalDataFieldDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public int DecimalPoints { get; set; }

        public TruncatedDecimalDataFieldDefinitionAttribute(int revision) : base(revision)
        {
            DecimalPoints = 2;
            PaddingChar = '0';
            PaddingOrientation = PaddingOrientation.LeftPadded;
        }
        public TruncatedDecimalDataFieldDefinitionAttribute(int field, int revision) : base(field, revision)
        {
            DecimalPoints = 2;
            PaddingChar = '0';
            PaddingOrientation = PaddingOrientation.LeftPadded;
        }

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return DataField.TruncatedDecimal(Field, index, Size, DecimalPoints, HasPrefix)
                            .Bind(owner, propertyInfo);
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
        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return DataField.Timestamp(Field, index, HasPrefix)
                            .Bind(owner, propertyInfo);
        }
    }

    public class UnixTimestampDataFieldDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public UnixTimestampDataFieldDefinitionAttribute(int revision) : base(revision)
        {
            Size = 10;
        }
        public UnixTimestampDataFieldDefinitionAttribute(int field, int revision) : base(field, revision)
        {
            Size = 10;
        }
        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return DataField.Timestamp(Field, index, HasPrefix)
                            .Bind(owner, propertyInfo);
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

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<VariableDataField>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = OpenProtocolConvert.ToString,
                DefaultParser = VariableDataField.ParseAll
            }.Bind(owner, propertyInfo);
        }
    }

    public class Int32CollectionDefinitionAttribute : DataFieldDefinitionAttribute
    {
        public int EachFieldSize { get; set; }

        public Int32CollectionDefinitionAttribute(int revision) : base(revision)
        {
            PaddingChar = '0';
            PaddingOrientation = PaddingOrientation.LeftPadded;
        }

        public Int32CollectionDefinitionAttribute(int field, int revision) : base(field, revision)
        {
            PaddingChar = '0';
            PaddingOrientation = PaddingOrientation.LeftPadded;
        }

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            if (EachFieldSize <= 0)
                throw new InvalidOperationException("EachFieldSize must be greater than 0 for Int32CollectionDefinitionAttribute.");

            return new DataField<List<int>>(Field, index, Size, PaddingChar, PaddingOrientation, HasPrefix)
            {
                DefaultConverter = PackList,
                DefaultParser = ParseList
            }.Bind(owner, propertyInfo);
        }

        private string PackList(char paddingChar, int size, PaddingOrientation orientation, List<int> list)
        {
            var builder = new StringBuilder(list.Count);
            foreach (var e in list)
                builder.Append(OpenProtocolConvert.ToString(paddingChar, EachFieldSize, orientation, e));

            return builder.ToString();
        }

        private List<int> ParseList(string value)
        {
            var span = value.AsSpan();
            var list = new List<int>();
            for (int i = 0; i < span.Length; i += EachFieldSize)
            {
                var slice = span.Slice(i, EachFieldSize);
                list.Add(OpenProtocolConvert.ToInt32(slice.ToString()));
            }

            return list;
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

        internal override DataField Build(object owner, PropertyInfo propertyInfo, int index)
        {
            return new DataField<List<T>>(Field, index, Size, HasPrefix)
            {
                DefaultConverter = PackEnums,
                DefaultParser = ParseEnums
            }.Bind(owner, propertyInfo);
        }

        private static string PackEnums(char paddingChar, int size, PaddingOrientation orientation, List<T> list)
        {
            var builder = new StringBuilder(list.Count);
            foreach (var e in list)
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
