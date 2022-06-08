namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Contract of every <see cref="Mid"/> message that can be answered by another mid which is not classified as an acknowledge. It's mid usually has more properties to be filled.
    /// </summary>
    public interface IAnswerableBy<TMid> where TMid : Mid
    {

    }
}
