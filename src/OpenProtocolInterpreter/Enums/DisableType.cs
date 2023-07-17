namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Disable types. Used in <see cref="Tool.Mid0042"/>.
    /// </summary>
    public enum DisableType
    {
        /// <summary>
        /// This is the same function as the revision 1 functionality. The tool is locked and cannot be started.
        /// </summary>
        Disable = 0,
        /// <summary>
        /// Will not run in the next tightening but will be included in the final result with status NOK
        /// </summary>
        InhibitNok = 1,
        /// <summary>
        /// Will not run in the next tightening but will be included in the final result with status OK
        /// </summary>
        InhibitOk = 2,
        /// <summary>
        /// Will not run in the next tightening and will not be included in the final result
        /// </summary>
        InhibitNoResult = 3
    }
}
