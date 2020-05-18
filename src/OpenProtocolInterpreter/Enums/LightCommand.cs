namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Light commands. Used in <see cref="ApplicationSelector.Mid0254"/> and <see cref="ApplicationSelector.Mid0255"/>.
    /// </summary>
    public enum LightCommand
    {
        OFF = 0,
        STEADY = 1,
        FLASHING = 2
    }
}
