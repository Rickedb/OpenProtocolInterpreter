using System;

namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Torque values unit. Used in <see cref="Tightening.Mid0061"/> and <see cref="Tightening.Mid0065"/>.
    /// </summary>
    public enum TorqueValuesUnit
    {
        NM = 1,
        LBF_FT = 2,
        LBF_IN = 3,
        KPM = 4,
        KGF_CM = 5,
        OZF_IN = 6,
        [Obsolete("Percentage of torque was marked as obsolete since Specification 2.10.0")]
        PERCENTAGE = 7,
        NCM = 8
    }
}
