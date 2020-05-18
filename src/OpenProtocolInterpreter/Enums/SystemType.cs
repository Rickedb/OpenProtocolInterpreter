namespace OpenProtocolInterpreter
{
    /// <summary>
    /// The system type of the controller.
    /// <para>Possible values are:</para>
    /// <list type="bullet">
    ///     <item>000 = System type not set </item>
    ///     <item>001 = Power Focus 4000 </item>
    ///     <item>002 = Power MACS 4000 </item>
    ///     <item>003 = Power Focus 6000</item>
    /// </list>
    /// </summary>
    public enum SystemType
    {
        SYSTEM_TYPE_NOT_SET = 0,
        POWER_FOCUS_4000 = 1,
        POWER_MACS_4000 = 2,
        POWER_FOCUS_6000 = 3
    }
}
