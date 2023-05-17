namespace OpenProtocolInterpreter
{
    /// /// <summary>
    /// Decrement batch after loosening/OK tightening. Used in <see cref="Job.Advanced.Mid0140"/> in <see cref="Job.Advanced.AdvancedJob"/> .
    /// </summary>
    public enum DecrementBatchAfterLoosening
    {
        Never = 0,
        Always = 1,
        AfterOk = 2
    }
}
