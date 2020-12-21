namespace OpenProtocolInterpreter.Converters
{
    public interface IValueConverter<T>
    {
        T Convert(string value);
        string Convert(T value);
        string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation, T value);

        T ConvertFromBytes(byte[] value);
        byte[] ConvertToBytes(T value);
        byte[] ConvertToBytes(char paddingChar, int size, DataField.PaddingOrientations orientation, T value);
    }
}
