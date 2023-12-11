using System;
using System.Drawing;
using System.Linq;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Represents a single and raw Data Field in <see cref="Mid"/> before being abstracted 
    /// to a typed field inside a mid entity
    /// </summary>
    public class DataField
    {
        private readonly char _paddingChar;
        private readonly PaddingOrientation _paddingOrientation;
        private object CachedValue;

        internal static DataField Default = new(-1, -1, -1);

        public bool HasPrefix { get; set; }
        public int Field { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public string Value { get; set; }
        public byte[] RawValue { get; set; }
        public int TotalSize => HasPrefix ? 2 + Size : Size;

        public DataField(int field, int index, int size, bool hasPrefix = true)
        {
            HasPrefix = hasPrefix;
            Field = field;
            Index = index;
            Size = size;
            _paddingChar = ' ';
        }

        public DataField(Enum field, int index, int size, bool hasPrefix = true)
            : this(field.GetHashCode(), index, size, hasPrefix)
        {

        }

        public DataField(int field, int index, int size, char paddingChar, PaddingOrientation paddingOrientation = PaddingOrientation.RightPadded, bool hasPrefix = true)
        {
            _paddingChar = paddingChar;
            _paddingOrientation = paddingOrientation;
            HasPrefix = hasPrefix;
            Field = field;
            Index = index;
            Size = size;
        }

        public DataField(Enum field, int index, int size, char paddingChar, PaddingOrientation paddingOrientation = PaddingOrientation.RightPadded, bool hasPrefix = true)
            : this(field.GetHashCode(), index, size, paddingChar, paddingOrientation, hasPrefix)
        {

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
            if (RawValue == default || !RawValue.Any())
                CachedValue = default(T);
            else if (IsValueNotCached<T>())
                CachedValue = converter(RawValue);

            return (T)CachedValue;
        }

        public virtual void SetValue<T>(Func<char, int, PaddingOrientation, T, string> converter, T value)
        {
            CachedValue = null;
            Value = converter(_paddingChar, Size, _paddingOrientation, value);
            Size = Value.Length;
        }

        public virtual void SetRawValue<T>(Func<char, int, PaddingOrientation, T, byte[]> converter, T value)
        {
            CachedValue = null;
            RawValue = converter(_paddingChar, Size, _paddingOrientation, value);
            Size = RawValue.Length;
        }

        public virtual void SetValue(string value)
        {
            CachedValue = null;
            SetValue(OpenProtocolConvert.TruncatePadded, value);
        }

        public static DataField String(int field, int index, int size, bool hasPrefix = true)
            => new(field, index, size, ' ', PaddingOrientation.RightPadded, hasPrefix);
        public static DataField String(int field, int index, int size, PaddingOrientation paddingOrientation, bool hasPrefix = true)
           => new(field, index, size, ' ', paddingOrientation, hasPrefix);
        public static DataField String(Enum field, int index, int size, bool hasPrefix = true)
           => new(field, index, size, ' ', PaddingOrientation.RightPadded, hasPrefix);
        public static DataField String(Enum field, int index, int size, PaddingOrientation paddingOrientation, bool hasPrefix = true)
           => new(field, index, size, ' ', paddingOrientation, hasPrefix);

        public static DataField Boolean(int field, int index, bool hasPrefix = true)
           => new(field, index, 1, hasPrefix);
        public static DataField Boolean(Enum field, int index, bool hasPrefix = true)
           => new(field, index, 1, hasPrefix);

        public static DataField Timestamp(int field, int index, bool hasPrefix = true)
           => new(field, index, 19, hasPrefix);
        public static DataField Timestamp(Enum field, int index, bool hasPrefix = true)
           => new(field, index, 19, hasPrefix);

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
}
