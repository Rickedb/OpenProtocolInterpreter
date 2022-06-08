namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Contract which every <see cref="Mid"/> that might needs an acknowledge response implements.
    /// </summary>
    public interface IAcknowledgeable
    {
        Mid GetAcknowledge();
    }
}
