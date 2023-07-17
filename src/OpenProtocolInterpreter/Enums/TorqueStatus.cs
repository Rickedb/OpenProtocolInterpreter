namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Torque status. Used in <see cref="PowerMACS.BoltData"/>.
    /// </summary>
    public enum TorqueStatus
    {
        Undefined = -1,
        BoltTorqueLow = 0,
        BoltTorqueOk = 1,
        BoltTorqueHigh = 2
    }
}
