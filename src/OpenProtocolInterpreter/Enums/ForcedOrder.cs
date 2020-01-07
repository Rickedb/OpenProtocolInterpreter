namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Forced Orders. Used in <see cref="Job.Mid0033"/> and <see cref="Job.Advanced.Mid0140"/>.
    /// </summary>
    public enum ForcedOrder
    {
        FREE_ORDER = 0,
        FORCED_ORDER = 1,
        FREE_AND_FORCED_ORDER = 2
    }
}
