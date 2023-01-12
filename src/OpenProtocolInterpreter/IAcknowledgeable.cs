namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Contract which every <see cref="Mid"/> that might needs an acknowledge response implements.
    /// </summary>
    public interface IAcknowledgeable<TAckMid> where TAckMid : Mid, IAcknowledge, new()
    {
        
    }
}
