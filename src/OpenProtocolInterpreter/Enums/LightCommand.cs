namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Light commands. Used in <see cref="ApplicationSelector.Mid0254"/> and <see cref="ApplicationSelector.Mid0255"/>.
    /// </summary>
    public enum LightCommand
    {
        Off = 0,
        Steady = 1,
        Flashing = 2
    }
}
