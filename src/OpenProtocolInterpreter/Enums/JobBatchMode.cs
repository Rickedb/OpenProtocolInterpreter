namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Job batch modes. Used in <see cref="Job.Mid0033"/> and <see cref="Job.Mid0035"/>.
    /// </summary>
    public enum JobBatchMode
    {
        OnlyOkTightenings = 0,
        OkAndNokTightenings = 1
    }
}
