using System.Text;

namespace OpenProtocolInterpreter.Converters
{
    public abstract class AsciiConverter<T> : ValueConverter, IValueConverter<T>
    {
        public abstract T Convert(string value);

        public abstract string Convert(T value);

        public abstract string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, T value);

        public virtual T ConvertFromBytes(byte[] value)
        {
            var asciiValue = Encoding.ASCII.GetString(value);
            return Convert(asciiValue);
        }

        public virtual byte[] ConvertToBytes(T value)
        {
            var asciiValue = Convert(value);
            return Encoding.ASCII.GetBytes(asciiValue);
        }

        public virtual byte[] ConvertToBytes(char paddingChar, int size, DataField.PaddingOrientations orientation, T value)
        {
            var asciiValue = Convert(paddingChar, size, orientation, value);
            return Encoding.ASCII.GetBytes(asciiValue);
        }
    }
}
