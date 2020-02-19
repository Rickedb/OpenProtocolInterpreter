namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Job batch modes. Used in <see cref="Job.Mid0033"/> and <see cref="Job.Mid0035"/>.
    /// </summary>
    public enum JobBatchMode
    {
        ONLY_OK_TIGHTENINGS = 0,
        OK_AND_NOK_TIGHTENINGS = 1
    }
}
