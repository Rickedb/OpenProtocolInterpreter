namespace OpenProtocolInterpreter
{
    public enum NodeType
    {
        ParameterSet = 1,
        Multistage = 2,
        Job = 3,

        TighteningProgram = 100,
        TighteningStep = 101,
        Restriction = 102,
        Check = 103,
        SpeedRamp = 104,
        Monitoring = 105,

        MultistepTighteningProgram = 201
    }
}
