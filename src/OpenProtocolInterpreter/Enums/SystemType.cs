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
    ///     <item>004 = Micro Torque Focus 6000</item>
    /// </list>
    /// </summary>
    public enum SystemType
    {
        SystemTypeNotSet = 0,
        PowerFocus4000 = 1,
        PowerMacs4000 = 2,
        PowerFocus6000 = 3,
        MicroTorqueFocus6000 = 4
    }
}
