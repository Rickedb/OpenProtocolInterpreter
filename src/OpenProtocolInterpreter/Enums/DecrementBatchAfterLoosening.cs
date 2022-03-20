namespace OpenProtocolInterpreter
{
    /// /// <summary>
    /// Decrement batch after loosening/OK tightening. Used in <see cref="Job.Advanced.Mid0140"/> in <see cref="Job.Advanced.AdvancedJob"/> .
    /// </summary>
    public enum DecrementBatchAfterLoosening
    {
        NEVER = 0,
        ALWAYS = 1,
        AFTER_OK = 2
    }
}
