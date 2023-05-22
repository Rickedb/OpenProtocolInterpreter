namespace OpenProtocolInterpreter
{
    /// <summary>
    /// Relay Numbers. Used in <see cref="IOInterface.Mid0216"/>, <see cref="IOInterface.Mid0217"/>, <see cref="IOInterface.Mid0219"/> and <see cref="IOInterface.Relay"/>
    /// </summary>
    public enum RelayNumber
    {
        Off = 0,
        Ok = 1,
        Nok = 2,
        Low = 3,
        High = 4,
        LowTorque = 5,
        HighTorque = 6,
        LowAngle = 7,
        HighAngle = 8,
        CycleComplete = 9,
        Alarm = 10,
        BatchNxOk = 11,
        JobOk = 12,
        JobNok = 13,
        JobRunning = 14,

        ToolHealthOk = 17,
        PowerFocusReady = 18,
        ToolReady = 19,
        ToolStartSwitch = 20,
        DirectionSwitchClockwise = 21,
        DirectionSwitchCounterclockwise = 22,
        TighteningDirectionCounterclockwise = 23,
        ToolTightening = 24,
        ToolLoosening = 25,
        ToolRunning = 26,
        ToolRunningClockwise = 27,
        ToolRunningCounterclockwise = 28,
        StatisticAlarm = 29,
        ToolLocked = 30,
        ReceivedIdentifier = 31,
        RunningPSetBit0 = 32,
        RunningPSetBit1 = 33,
        RunningPSetBit2 = 34,
        RunningPSetBit3 = 35,
        RunningJobBit0 = 36,
        RunningJobBit1 = 37,
        RunningJobBit2 = 38,
        RunningJobBit3 = 39,

        LineOk = 44,
        LineControlAlert1 = 45,
        LineControlAlert2 = 46,
        ServiceIndicator = 47,
        FieldbusRelay1 = 48,
        FieldbusRelay2 = 49,
        FieldbusRelay3= 50,
        FieldbusRelay4 = 51,
        ToolRedLight = 52,
        ToolGreenLight = 53,
        ToolYellowLight = 54,

        RunningPSetBit4 = 59,
        RunningPSetBit5 = 60,
        RunningPSetBit6 = 61,
        RunningPSetBit7 = 62,
        RunningJobBit4 = 63,
        RunningJobBit5 = 64,
        RunningJobBit6 = 65,
        RunningJobBit7 = 66,
        SyncOk = 67,
        SyncNok = 68,
        SyncSpindle1Ok = 69,
        SyncSpindle1Nok = 70,
        SyncSpindle2Ok = 71,
        SyncSpindle2Nok = 72,
        SyncSpindle3Ok = 73,
        SyncSpindle3Nok = 74,
        SyncSpindle4Ok = 75,
        SyncSpindle4Nok = 76,
        SyncSpindle5Ok = 77,
        SyncSpindle5Nok = 78,
        SyncSpindle6Ok = 79,
        SyncSpindle6Nok = 80,
        SyncSpindle7Ok = 81,
        SyncSpindle7Nok = 82,
        SyncSpindle8Ok = 83,
        SyncSpindle8Nok = 84,
        SyncSpindle9Ok = 85,
        SyncSpindle9Nok = 86,
        SyncSpindle10Ok = 87,
        SyncSpindle10Nok = 88,

        LineControlStart = 91,
        JobAborted = 92,
        ExternalControlled1 = 93,
        ExternalControlled2 = 94,
        ExternalControlled3 = 95,
        ExternalControlled4 = 96,
        ExternalControlled5 = 97,
        ExternalControlled6 = 98,
        ExternalControlled7 = 99,
        ExternalControlled8 = 100,
        ExternalControlled9 = 101,
        ExternalControlled10 = 102,
        ToolsNetConnectionLost = 103,
        OpenProtocolConnectionLost = 104,
        FieldbusOffline = 105,
        HomePosition = 106,
        BatchNok = 107,
        SelectedChannelInJob = 108,
        SafeToDisconnectTool = 109,
        RunningJobBit8 = 110,
        RunningPSetBit8 = 111,
        CalibrationAlarm = 112,
        CycleStart = 113,
        LowCurrent = 114,
        HighCurrent = 115,
        LowPVTMonitoring = 116,
        HighPVTMonitoring = 117,
        LowPVTSelfTap = 118,
        HighPVTSelfTap = 119,
        LowTighteningAngle = 120,
        HighTighteningAngle = 121,
        IdentifierIdentified = 122,
        IdentifierType1Received = 123,
        IdentifierType2Received = 124,
        IdentifierType3Received = 125,
        IdentifierType4Received = 126,

        RingButtonAck = 129,
        DigInControlled1 = 130,
        DigInControlled2 = 131,
        DigInControlled3 = 132,
        DigInControlled4 = 133,
        FieldbusCarriedSignalsDisabled = 134,
        Illuminator = 135,
        NewParameterSetSelected = 136,
        NewJobSelected = 137,
        JobOffRelay = 138,
        LogicRelay1 = 139,
        LogicRelay2 = 140,
        LogicRelay3 = 141,
        LogicRelay4 = 142,
        MaxCoherentNokReached = 143,
        BatchDone = 144,
        StartTriggerActive = 145,

        CompletedBatchBit0 = 251,
        CompletedBatchBit1 = 252,
        CompletedBatchBit2 = 253,
        CompletedBatchBit3 = 254,
        CompletedBatchBit4 = 255,
        CompletedBatchBit5 = 256,
        CompletedBatchBit6 = 257,

        RemainingBatchBit0 = 259,
        RemainingBatchBit1 = 260,
        RemainingBatchBit2 = 261,
        RemainingBatchBit3 = 262,
        RemainingBatchBit4 = 263,
        RemainingBatchBit5 = 264,
        RemainingBatchBit6 = 265,

        OpenProtocolCommandsDisabled = 275,
        CycleAbort = 276,
        EffectiveLoosening = 277,
        LogicRelay5 = 278,
        LogicRelay6 = 279,
        LogicRelay7 = 280,
        LogicRelay8 = 281,
        LogicRelay9 = 282,
        LogicRelay10 = 283,
        LockAtBatchDone = 284,

        BatteryLow = 287,
        BatteryEmpty = 288,
        ToolConnected = 289,
        NoToolConnected = 290,

        FunctionButton = 293,
        Rehit = 294,
        TighteningDisabled = 295,
        LooseningDisabled = 296,
        PositioningDisabled = 297,
        MotorTuningDisabled = 298,
        OpenEndTuningDisabled = 299,
        TrackingDisabled = 300,

        AutomaticMode = 302,
        PlusEmergencyMode = 303,
        WearIndicator = 304,
        DirectionAlert = 305,
        PlusBoltReworked = 306,
        LineStop = 307,
        RunningPSetBit9 = 308,
        ActiveXmlResultAck = 309,
        ToolInWorkSpace = 310,
        ToolInProductSpace = 311,
        XmlProtocolActive = 312,
        ToolEnabledByXml = 313,
        NeckingFailure = 314,
        PlusProtocolNotActive = 315,
        PlusNoTightening = 316,
        TagIdError = 317,
        JobAbortionInProgress = 318,
        StopTightening = 319,
        SlowDownTightening = 320,

        MiddleCourseTriggerActive = 351,
        FrontTriggerActive = 352,
        ReverseTriggerActive = 353,
        RunningJobBit9 = 354,
        ToolUnlocked = 355,
        /// <summary>
        /// Indicates that the connection to the Atlas Copco license server has been lost or the synchronization has failed. 
        /// The signal is cleared when the License manager synchronization has been done successfully
        /// </summary>
        LicenseServerConnectionLost = 356,
        /// <summary>
        /// Tightening not disabled by external source
        /// </summary>
        TighteningExternallyEnabled = 357,
        /// <summary>
        /// Tightening disabled by external source
        /// </summary>
        TighteningExternallyDisabled = 358,
        /// <summary>
        /// Loosening not disabled by external source
        /// </summary>
        LooseningExternallyEnabled = 359,
        /// <summary>
        /// Loosening disabled by external source
        /// </summary>
        LooseningExternallyDisabled = 360,
        /// <summary>
        /// Multistep tightening program has ended, torque has fallen below Program end torque configured.
        /// </summary>
        ProgramEnd = 361,
        /// <summary>
        /// Oil level supervision configured in the tool maintenance to remind the users when it is time to fill up oil in a pulse tool.
        /// </summary>
        PulseToolAlarmOilLevelEmpty = 362,
        /// <summary>
        /// Indicates high tightening time resulting in NOK tightening
        /// </summary>
        TighteningTimeHigh = 363,
        /// <summary>
        /// Indicates low tightening time resulting in NOK tightening
        /// </summary>
        TighteningTimeLow = 364,
        /// <summary>
        /// Output signal tracking the function button state. The signal is set when the function button is pressed and is cleared when the function button is released.
        /// </summary>
        ToolFunctionButtonPressed = 365
    }
}
