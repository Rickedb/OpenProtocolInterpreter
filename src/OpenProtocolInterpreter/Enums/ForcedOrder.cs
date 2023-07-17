namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Forced Orders. Used in <see cref="Job.Mid0033"/> and <see cref="Job.Advanced.Mid0140"/>.
    /// </summary>
    public enum ForcedOrder
    {
        FreeOrder = 0,
        ForcedOrder = 1,
        FreeAndForcedOrder = 2
    }
}
