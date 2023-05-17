namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Batch Status. Used in <see cref="Tightening.Mid0061"/> and <see cref="Tightening.Mid0065"/>.
    /// </summary>
    public enum BatchStatus
    {
        Nok = 0,
        Ok = 1,
        NotUsed = 2,
        Running = 3
    }
}
