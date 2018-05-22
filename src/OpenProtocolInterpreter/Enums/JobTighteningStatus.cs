namespace OpenProtocolInterpreter
{
    public enum JobTighteningStatus
    {
        OFF = 0,
        NOK = 1,
        ABORTED = 3,
        INCREMENTED = 4,
        DECREMENTED = 5,
        BYPASSED = 6,
        RESET_BATCH = 7,
        LOOSENING = 8,
        FREE_BATCH = 9,
        JOB_ABORTED = 10
    }
}
