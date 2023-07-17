﻿namespace OpenProtocolInterpreter
{
    /// <summary>
    /// If no subtype exists it will be set to 000
    /// <para>For a Power Focus 4000 and PF 6000 system the valid subtypes are: </para>
    /// <para>001 = a normal tightening system</para>
    /// For a Power MACS 4000 system the valid subtypes are: 
    /// <list type="bullet">
    ///     <item>001 = a normal tightening system</item>
    ///     <item>002 = a system running presses instead of spindles.</item>
    /// </list>
    /// </summary>
    public enum SystemSubType
    {
        NoSubtypeExists = 0,
        NormalTighteningSystem = 1,
        SystemRunningPresses = 2
    }
}
