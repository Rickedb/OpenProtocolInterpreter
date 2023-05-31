using System;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Torque values unit. Used in <see cref="Tightening.Mid0061"/> and <see cref="Tightening.Mid0065"/>.
    /// </summary>
    public enum TorqueValuesUnit
    {
        Nm = 1,
        LbfFt = 2,
        LbfIn = 3,
        Kpm = 4,
        KgfCm = 5,
        OzfIn = 6,
        [Obsolete("Percentage of torque was marked as obsolete since Specification 2.10.0")]
        Percentage = 7,
        Ncm = 8
    }
}
