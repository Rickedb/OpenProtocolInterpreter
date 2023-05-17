namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Auto Select. Used in <see cref="Job.Advanced.Mid0140"/> in <see cref="Job.Advanced.AdvancedJob"/> .
    /// </summary>
    public enum AutoSelect
    {
        None = 0,
        AutoNextChange = 1,
        IO = 2,
        Fieldbus = 6,
        SocketTray = 8
    }
}
