namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Strategies. Used in <see cref="Tightening.Mid0061"/> and <see cref="Tightening.Mid0065"/>.
    /// </summary>
    public enum Strategy
    {
        TORQUE_CONTROL = 1,
        TORQUE_CONTROL_AND_ANGLE_MONITORING = 2,
        TORQUE_CONTROL_AND_ANGLE_CONTROL = 3,
        ANGLE_CONTROL_AND_TORQUE_MONITORING = 4,
        DS_CONTROL = 5,
        DS_CONTROL_TORQUE_MONITORING = 6,
        REVERSE_ANGLE = 7,
        REVERSE_TORQUE = 8,
        CLICK_WRENCH = 9,
        ROTATE_SPINDLE_FORWARD = 10,
        TORQUE_CONTROL_OR_ANGLE_CONTROL = 11,
        ROTATE_SPINDLE_REVERSE = 12,
        HOME_POSITION_FORWARD = 13,
        EP_MONITORING = 14,
        YIELD = 15,
        EP_FIXED = 16,
        EP_CONTROL = 17,
        EP_ANGLE_SHUTOFF = 18,
        YIELD_OR_TORQUE_CONTROL = 19,
        SNUG_GRADIENT = 20,
        RESIDUAL_TORQUE_AND_TIME = 21,
        RESIDUAL_ANGLE_AND_TIME = 22,
        BREAKAWAY_PEAK = 23,
        LOOSE_AND_TIGHTENING= 24,
        HOME_POSITION_REVERSE = 25,
        PVT_COMP_WITH_SNUG = 26,
        NO_STRATEGY = 99
    }
}
