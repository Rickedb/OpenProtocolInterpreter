namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Angle status. Used in <see cref="PowerMACS.BoltData"/>.
    /// </summary>
    public enum AngleStatus
    {
        Undefined = -1,
        BoltAngleLow = 0,
        BoltAngleOk = 1,
        BoltAngleHigh = 2
    }
}
