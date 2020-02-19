using System;
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
        private readonly PaddingOrientations _paddingOrientation;
        private object CachedValue;

        public bool HasPrefix { get; set; }
        public int Field { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public string Value { get; set; }
        public byte[] RawValue { get; set; }

        public DataField(int field, int index, int size, bool hasPrefix = true)
        {
            HasPrefix = hasPrefix;
            Field = field;
            Index = index;
            Size = size;
            _paddingChar = ' ';
        }

        public DataField(int field, int index, int size, char paddingChar, PaddingOrientations paddingOrientation = PaddingOrientations.RIGHT_PADDED, bool hasPrefix = true)
        {
            _paddingChar = paddingChar;
            _paddingOrientation = paddingOrientation;
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
            if (!RawValue.Any())
                CachedValue = default(T);
            else if (IsValueNotCached<T>())
                CachedValue = converter(RawValue);

            return (T)CachedValue;
        }

        public virtual void SetValue<T>(Func<char, int, PaddingOrientations, T, string> converter, T value)
        {
            CachedValue = null;
            Value = converter(_paddingChar, Size, _paddingOrientation, value);
            Size = Value.Length;
        }

        public virtual void SetRawValue<T>(Func<char, int, PaddingOrientations, T, byte[]> converter, T value)
        {
            CachedValue = null;
            RawValue = converter(_paddingChar, Size, _paddingOrientation, value);
            Size = Value.Length;
        }

        public virtual void SetValue(string value)
        {
            CachedValue = null;
            SetValue(new Converters.ValueConverter().GetPadded, value);
        }

        private bool IsValueNotCached<T>() => CachedValue == null || IsNotTypeOf<T>();

        private bool IsNotTypeOf<T>() => !CachedValue.GetType().Equals(typeof(T));

        public enum PaddingOrientations
        {
            RIGHT_PADDED,
            LEFT_PADDED
        }
    }
}
