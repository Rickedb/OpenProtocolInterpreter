using System.Text;

namespace OpenProtocolInterpreter.Converters
{
    internal class ByteArrayConverter : ValueConverter, IValueConverter<byte[]>
    {
        public byte[] Convert(string value) => Encoding.ASCII.GetBytes(value);

        public string Convert(byte[] value) => Encoding.ASCII.GetString(value);

        public string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, byte[] value)
        {
            return GetPadded(paddingChar, size, orientation, Convert(value));
        }
    }
}
