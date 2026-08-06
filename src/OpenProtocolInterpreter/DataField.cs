using System;
using System.Reflection;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Represents a single and raw Data Field in <see cref="Mid"/> before being abstracted
    /// to a typed field inside a mid entity
    /// </summary>
    public class DataField
    {
        protected readonly char PaddingChar;
        protected readonly PaddingOrientation PaddingOrientation;
        private object CachedValue;

        internal static DataField Default = new(-1, -1, -1);

        public bool HasPrefix { get; set; }
        public int Field { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public string Value { get; set; }
        public byte[] RawValue { get; set; }
        public ReadOnlySpan<char> Span => Value.AsSpan();
        public int TotalSize => HasPrefix ? 2 + Size : Size;

        public DataField(int field, int index, int size, bool hasPrefix = true)
            : this(field, index, size, ' ', PaddingOrientation.RightPadded, hasPrefix)
        {

        }

        public DataField(Enum field, int index, int size, bool hasPrefix = true)
            : this(field.GetHashCode(), index, size, hasPrefix)
        {

        }

        public DataField(Enum field, int index, int size, char paddingChar, PaddingOrientation paddingOrientation = PaddingOrientation.RightPadded, bool hasPrefix = true)
            : this(field.GetHashCode(), index, size, paddingChar, paddingOrientation, hasPrefix)
        {

        }

        public DataField(int field, int index, int size, char paddingChar, PaddingOrientation paddingOrientation = PaddingOrientation.RightPadded, bool hasPrefix = true)
        {
            PaddingChar = paddingChar;
            PaddingOrientation = paddingOrientation;
            HasPrefix = hasPrefix;
            Field = field;
            Index = index;
            Size = size;
        }

        public virtual T GetValue<T>(Func<string, T> converter)
        {
            if (string.IsNullOrWhiteSpace(Value))
                CachedValue = default(T);
            else if (IsValueNotCached<T>())
                CachedValue = converter(Value);

            return (T)CachedValue;
        }

        public virtual T GetValue<T>(Func<byte[], T> converter)
        {
            if (RawValue == default || RawValue.Length == 0)
                CachedValue = default(T);
            else if (IsValueNotCached<T>())
                CachedValue = converter(RawValue);

            return (T)CachedValue;
        }

        public virtual void SetValue<T>(Func<char, int, PaddingOrientation, T, string> converter, T value)
        {
            CachedValue = null;
            Value = converter(PaddingChar, Size, PaddingOrientation, value);
            Size = Value.Length;
        }

        public virtual void SetRawValue<T>(Func<char, int, PaddingOrientation, T, byte[]> converter, T value)
        {
            CachedValue = null;
            RawValue = converter(PaddingChar, Size, PaddingOrientation, value);
            Size = RawValue.Length;
        }

        public virtual void SetValue(string value)
        {
            SetValue(OpenProtocolConvert.TruncatePadded, value);
        }

        public virtual void SetValue(ReadOnlySpan<char> value)
            => SetValue(value.ToString());

        public static DataField<string> String(int field, int index, int size, bool hasPrefix = true)
            => String(field, index, size, PaddingOrientation.RightPadded, hasPrefix);
        public static DataField<string> String(int field, int index, int size, PaddingOrientation paddingOrientation, bool hasPrefix = true)
        {
            return new DataField<string>(field, index, size, ' ', paddingOrientation, hasPrefix)
            {
                DefaultConverter = (paddingChar, s, o, v) => OpenProtocolConvert.TruncatePadded(paddingChar, s, o, v?.ToString()),
                DefaultParser = s => s
            };
        }

        public static DataField<string> String(Enum field, int index, int size, bool hasPrefix = true)
           => String(field, index, size, PaddingOrientation.RightPadded, hasPrefix);
        public static DataField<string> String(Enum field, int index, int size, PaddingOrientation paddingOrientation, bool hasPrefix = true)
           => String(field.GetHashCode(), index, size, paddingOrientation, hasPrefix);

        public static DataField<bool> Boolean(int field, int index, bool hasPrefix = true)
        {
            return new DataField<bool>(field, index, 1, hasPrefix)
            {
                DefaultConverter = OpenProtocolConvert.ToString,
                DefaultParser = OpenProtocolConvert.ToBoolean
            };
        }

        public static DataField<bool> Boolean(Enum field, int index, bool hasPrefix = true)
           => Boolean(field.GetHashCode(), index, hasPrefix);

        public static DataField<DateTime> Timestamp(int field, int index, bool hasPrefix = true)
        {
            return new DataField<DateTime>(field, index, 19, hasPrefix)
            {
                DefaultConverter = OpenProtocolConvert.ToString,
                DefaultParser = OpenProtocolConvert.ToDateTime
            };
        }
        public static DataField<DateTime> Timestamp(Enum field, int index, bool hasPrefix = true)
           => Timestamp(field.GetHashCode(), index, hasPrefix);

        public static DataField<decimal> Decimal(int field, int index, int size, bool hasPrefix = true)
        {
            return new DataField<decimal>(field, index, size, '0', PaddingOrientation.LeftPadded, hasPrefix)
            {
                DefaultConverter = OpenProtocolConvert.ToString,
                DefaultParser = OpenProtocolConvert.ToDecimal
            };
        }
        public static DataField<decimal> Decimal(Enum field, int index, int size, bool hasPrefix = true)
            => Decimal(field.GetHashCode(), index, size, hasPrefix);

        public static DataField<decimal> TruncatedDecimal(int field, int index, int size, int decimalPoints, bool hasPrefix = true)
        {
            return new DataField<decimal>(field, index, size, '0', PaddingOrientation.LeftPadded, hasPrefix)
            {
                DefaultConverter = OpenProtocolConvert.TruncatedDecimalToString,
                DefaultParser = (str) => OpenProtocolConvert.ToTruncatedDecimal(str, decimalPoints)
            };
        }
        public static DataField<decimal> TruncatedDecimal(Enum field, int index, int size, int decimalPoints, bool hasPrefix = true)
            => TruncatedDecimal(field.GetHashCode(), index, size, decimalPoints, hasPrefix);

        public static DataField<int> Int32(int field, int index, int size, bool hasPrefix = true)
        {
            return new DataField<int>(field, index, size, '0', PaddingOrientation.LeftPadded, hasPrefix)
            {
                DefaultConverter = OpenProtocolConvert.ToString,
                DefaultParser = OpenProtocolConvert.ToInt32
            };
        }

        public static DataField<int> Int32(Enum field, int index, int size, bool hasPrefix = true)
            => Int32(field.GetHashCode(), index, size, hasPrefix);

        public static DataField<long> Int64(int field, int index, int size, bool hasPrefix = true)
        {
            return new DataField<long>(field, index, size, '0', PaddingOrientation.LeftPadded, hasPrefix)
            {
                DefaultConverter = OpenProtocolConvert.ToString,
                DefaultParser = OpenProtocolConvert.ToInt64
            };
        }

        public static DataField<long> Int64(Enum field, int index, int size, bool hasPrefix = true)
            => Int64(field.GetHashCode(), index, size, hasPrefix);

        public static DataField Number(int field, int index, int size, bool hasPrefix = true)
            => new(field, index, size, '0', PaddingOrientation.LeftPadded, hasPrefix);
        public static DataField Number(Enum field, int index, int size, bool hasPrefix = true)
            => new(field, index, size, '0', PaddingOrientation.LeftPadded, hasPrefix);

        public static DataField Volatile(int field, int index, bool hasPrefix = true)
            => new(field, index, 0, hasPrefix);
        public static DataField Volatile(Enum field, int index, bool hasPrefix = true)
            => new(field, index, 0, hasPrefix);

        public static DataField Volatile(int field, bool hasPrefix = true)
           => new(field, 0, 0, hasPrefix);
        public static DataField Volatile(Enum field, bool hasPrefix = true)
            => new(field, 0, 0, hasPrefix);

        private bool IsValueNotCached<T>() => CachedValue == null || IsNotTypeOf<T>();

        private bool IsNotTypeOf<T>() => !CachedValue.GetType().Equals(typeof(T));
    }

    public class DataField<T> : DataField, IBackedPropertyDataField
    {
        private object _owner;
        private PropertyInfo _backingProperty;
        protected internal Func<char, int, PaddingOrientation, T, string> DefaultConverter;
        protected internal Func<string, T> DefaultParser;

        public DataField(int field, int index, int size, bool hasPrefix = true) : base(field, index, size, hasPrefix)
        {
        }

        public DataField(Enum field, int index, int size, bool hasPrefix = true) : base(field, index, size, hasPrefix)
        {
        }

        public DataField(Enum field, int index, int size, char paddingChar, PaddingOrientation paddingOrientation = PaddingOrientation.RightPadded, bool hasPrefix = true) : base(field, index, size, paddingChar, paddingOrientation, hasPrefix)
        {
        }

        public DataField(int field, int index, int size, char paddingChar, PaddingOrientation paddingOrientation = PaddingOrientation.RightPadded, bool hasPrefix = true) : base(field, index, size, paddingChar, paddingOrientation, hasPrefix)
        {
        }

        public void SyncWithBackingPropertyIfBound()
        {
            if (_backingProperty?.GetValue(_owner) is T propValue)
            {
                var value = DefaultConverter(PaddingChar, Size, PaddingOrientation, propValue);
                base.SetValue(value);
            }
        }

        public override void SetValue(string value)
        {
            base.SetValue(value);
            var parsedValue = DefaultParser(value);
            SetBackingPropertyValueIfBound(parsedValue);
        }

        private void SetBackingPropertyValueIfBound(object value)
        {
            if (_backingProperty != null && _owner != null)
                _backingProperty.SetValue(_owner, value);
        }

        protected internal DataField<T> Bind(object owner, string propertyName)
            => Bind(owner, owner.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance));

        protected internal DataField<T> Bind(object owner, PropertyInfo propertyInfo)
        {
            _owner = owner;
            _backingProperty = propertyInfo;

            return this;
        }
    }

    public interface IBackedPropertyDataField
    {
        void SyncWithBackingPropertyIfBound();
    }

    public struct DataFieldDefinition
    {
        public int Field { get; set; }
        public int Revision { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public char PaddingChar { get; set; } = ' ';
        public PaddingOrientation PaddingOrientation { get; set; } = PaddingOrientation.RightPadded;
        public bool HasPrefix { get; set; } = true;
        public PropertyInfo BoundedPropertyInfo { get; private set; }

        public DataFieldDefinition()
        {
        }

        public DataFieldDefinition Bind(PropertyInfo propertyInfo)
        {
            BoundedPropertyInfo = propertyInfo;
            return this;
        }

#if NET6_0_OR_GREATER
        public override readonly int GetHashCode()
        {
            return HashCode.Combine(Field, Revision, Index, Size, PaddingChar, PaddingOrientation, HasPrefix);
        }
#endif
    }
}
