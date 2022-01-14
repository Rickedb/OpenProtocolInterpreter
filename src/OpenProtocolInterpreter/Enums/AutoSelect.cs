namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Auto Select. Used in <see cref="Job.Advanced.Mid0140"/> in <see cref="Job.Advanced.AdvancedJob"/> .
    /// </summary>
    public enum AutoSelect
    {
        NONE = 0,
        AUTO_NEXT_CHANGE = 1,
        IO = 2,
        FIELDBUS = 6,
        SOCKET_TRAY = 8
    }
}
