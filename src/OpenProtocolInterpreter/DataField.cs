using System;

namespace OpenProtocolInterpreter
{
    public class DataField
    {
        private object CachedValue;
        private char PaddingChar;
        private PaddingOrientations PaddingOrientation;

        public bool HasPrefix { get; set; }
        public int Field { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public string Value { get; set; }

        public DataField(int field, int index, int size, bool hasPrefix = true)
        {
            HasPrefix = hasPrefix;
            Field = field;
            Index = index;
            Size = size;
        }

        public DataField(int field, int index, int size, char paddingChar, PaddingOrientations paddingOrientation = PaddingOrientations.RIGHT_PADDED, bool hasPrefix = true)
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

        public virtual void SetValue<T>(Func<char, int, PaddingOrientations, T, string> converter, T value)
        {
            CachedValue = null;
            Value = converter(PaddingChar, Size, PaddingOrientation, value);
        }

        public virtual void SetValue(string value)
        {
            CachedValue = null;
            Value = new Converters.ValueConverter().GetPadded(PaddingChar, Size, PaddingOrientation, value);
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
