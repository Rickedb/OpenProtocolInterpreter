namespace OpenProtocolInterpreter.Converters
{
    internal interface IValueConverter<T>
    {
        T Convert(string value);
        string Convert(T value);
        string Convert(char paddingChar, int size, DataField.PaddingOrientations orientation,T value);
    }
}
