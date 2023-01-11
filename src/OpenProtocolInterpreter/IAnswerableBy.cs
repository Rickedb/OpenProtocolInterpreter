namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Contract of every <see cref="Mid"/> message that can be answered by another mid which is not classified as an acknowledge.
    /// </summary>
    public interface IAnswerableBy<TMid> where TMid : Mid
    {

    }
}
