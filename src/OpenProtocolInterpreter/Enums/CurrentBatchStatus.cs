namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Current Batch Status. Used in <see cref="Job.Advanced.Mid0140"/> in <see cref="Job.Advanced.AdvancedJob"/>.
    /// </summary>
    public enum CurrentBatchStatus
    {
        NotStarted = 0,
        Ok = 1,
        Nok = 2
    }
}
