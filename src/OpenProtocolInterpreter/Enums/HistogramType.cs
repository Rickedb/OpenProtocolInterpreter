namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Histogram Types. Used in <see cref="Statistic.Mid0300"/> and <see cref="Statistic.Mid0301"/>.
    /// </summary>
    public enum HistogramType
    {
        Torque = 0,
        Angle = 1,
        Current = 2,
        PrevailTorque = 3,
        SelfTap = 4,
        RundownAngle = 5
    }
}
