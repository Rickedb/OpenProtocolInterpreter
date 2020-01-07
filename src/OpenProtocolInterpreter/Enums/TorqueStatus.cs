namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Torque status. Used in <see cref="PowerMACS.BoltData"/>.
    /// </summary>
    public enum TorqueStatus
    {
        UNDEFINED = -1,
        BOLT_TORQUE_LOW = 0,
        BOLT_TORQUE_OK = 1,
        BOLT_TORQUE_HIGH = 2
    }
}
