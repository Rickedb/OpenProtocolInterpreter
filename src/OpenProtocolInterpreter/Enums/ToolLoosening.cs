namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Tool loosenings. Used in <see cref="Job.Mid0033"/> and <see cref="Job.Advanced.Mid0140"/>.
    /// </summary>
    public enum ToolLoosening
    {
        ENABLED = 0,
        DISABLED = 1,
        ENABLE_ONLY_ON_NOK_TIGHTENINGS = 2
    }
}
