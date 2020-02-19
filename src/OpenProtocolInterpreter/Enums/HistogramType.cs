namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Histogram Types. Used in <see cref="Statistic.Mid0300"/> and <see cref="Statistic.Mid0301"/>.
    /// </summary>
    public enum HistogramType
    {
        TORQUE = 0,
        ANGLE = 1,
        CURRENT = 2,
        PREVAIL_TORQUE = 3,
        SELF_TAP = 4,
        RUNDOWN_ANGLE = 5
    }
}
