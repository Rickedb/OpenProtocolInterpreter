namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Angle status. Used in <see cref="PowerMACS.BoltData"/>.
    /// </summary>
    public enum AngleStatus
    {
        UNDEFINED = -1,
        BOLT_ANGLE_LOW = 0,
        BOLT_ANGLE_OK = 1,
        BOLT_ANGLE_HIGH = 2
    }
}
