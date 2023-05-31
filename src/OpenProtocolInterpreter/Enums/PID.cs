namespace OpenProtocolInterpreter
{
    public enum StatusPID
    {
        /// <summary>
        /// The overall status of all the tools in the tightening.
        /// </summary>
        TighteningStatus = 00001,
        /// <summary>
        /// The station id is a unique id for each station. 
        /// </summary>
        StationId = 00002,
        /// <summary>
        /// The station name. 
        /// </summary>
        StationName = 00003,
        /// <summary>
        /// Additional information related to the Tightening Status
        /// </summary>
        OverallTighteningStatusAdditionalInformation = 00005
    }

    public enum IdentifiersPID
    {
        /// <summary>
        /// The VIN number for the tightening
        /// </summary>
        VinNumber = 00010,
        /// <summary>
        /// Identifier 1 used for the tightening. 
        /// <para>Could for example be a pallet number, identity of the operator, identification for the part, etc…</para>
        /// </summary>
        Identifier1 = 00011,
        /// <summary>
        /// Identifier 2 used for the tightening. 
        /// <para>Could for example be a pallet number, identity of the operator, identification for the part, etc…</para>
        /// </summary>
        Identifier2 = 00012,
        /// <summary>
        /// Identifier 3 used for the tightening. 
        /// <para>Could for example be a pallet number, identity of the operator, identification for the part, etc…</para>
        /// </summary>
        Identifier3 = 00013,
        /// <summary>
        /// Identifier 4 used for the tightening. 
        /// <para>Could for example be a pallet number, identity of the operator, identification for the part, etc…</para>
        /// </summary>
        Identifier4 = 00014,
        /// <summary>
        /// Identifier 5 used for the tightening. 
        /// <para>Could for example be a pallet number, identity of the operator, identification for the part, etc…</para>
        /// </summary>
        Identifier5 = 00015,
        /// <summary>
        /// Identifier 6 used for the tightening. 
        /// <para>Could for example be a pallet number, identity of the operator, identification for the part, etc…</para>
        /// </summary>
        Identifier6 = 00016,
        /// <summary>
        /// Identifier 7 used for the tightening. 
        /// <para>Could for example be a pallet number, identity of the operator, identification for the part, etc…</para>
        /// </summary>
        Identifier7 = 00017,
        /// <summary>
        /// Identifier 8 used for the tightening. 
        /// <para>Could for example be a pallet number, identity of the operator, identification for the part, etc…</para>
        /// </summary>
        Identifier8 = 00018,
        /// <summary>
        /// Identifier 9 used for the tightening. 
        /// <para>Could for example be a pallet number, identity of the operator, identification for the part, etc…</para>
        /// </summary>
        Identifier9 = 00019,
        /// <summary>
        /// Identifier 10 used for the tightening. 
        /// <para>Could for example be a pallet number, identity of the operator, identification for the part, etc…</para>
        /// </summary>
        Identifier10 = 00020,

        /// <summary>
        /// Identifier for tightening 10 figures long.
        /// </summary>
        TighteningIdentifier = 00030,
        IdentifierHandling = 00031,

        /// <summary>
        /// Oldest result Id in a controller result database. 32 bit
        /// </summary>
        OldestResultId = 00050,
        /// <summary>
        /// Latest result Id in a controller result database. 32 bit
        /// </summary>
        LatestResultId = 00051,
        /// <summary>
        /// Oldest result Time in a controller result database. Unix time
        /// </summary>
        OldestResultTime = 00052,
        /// <summary>
        /// Latest result Time in a controller result database. Unix time
        /// </summary>
        LatestResultTime = 00053
    }

    public enum EventParameterPID
    {
        /// <summary>
        /// System common. But content unique for each system.
        /// </summary>
        Events = 00040
    }

    public enum BatchParametersPID
    {
        /// <summary>
        /// This parameter gives the total number of tightenings in the batch. 
        /// <para><em>Only used if this tightening was a part of a batch.</em></para>
        /// </summary>
        BatchSize = 00100,
        /// <summary>
        /// The number for this tightening in the batch. 
        /// <para><em>Only used if this tightening was a part of a batch.</em></para>
        /// </summary>
        BatchCounter = 00101,
        /// <summary>
        /// The current status of the batch. Only used if this tightening was a part of a batch.
        /// </summary>
        BatchCompleteStatus = 00102,
        BatchCount = 00103,
        BatchIncrementWhenNok = 00104,
        /// <summary>
        /// The current status of the batch.
        /// <para><em>Only used if this tightening was a part of a batch.</em></para>
        /// </summary>
        BatchStatus = 00105,
    }

    public enum TighteningProgramInformationPID
    {
        /// <summary>
        /// The number or index of the tightening program or Pset that made the tightening
        /// </summary>
        TighteningProgramNumber = 01000,
        /// <summary>
        /// The name of the tightening program or Pset that made the tightening
        /// </summary>
        TighteningProgramName = 01001,
        /// <summary>
        /// The overall strategy used in the tightening program.
        /// </summary>
        ControlTighteningProgramStrategy = 01002,
        /// <summary>
        /// Date and time of last change in tightening program settings
        /// </summary>
        TimeOfLastChangeInTighteningProgramSettings = 01003,
        /// <summary>
        /// The number of steps in the tightening program
        /// </summary>
        NumberOfSteps = 01004,
        TighteningStrategy = 01005,
        TraceToolStart = 01006,
        /// <summary>
        /// Torque value from where the tightening cycle is considered as started.
        /// </summary>
        CycleToolStrat = 01007,
        /// <summary>
        /// Torque value for the limit at which the fastener shall be removed.
        /// </summary>
        RemoveFastenerLimit = 01008,
        MeasureTorqueAt = 01009,
        /// <summary>
        /// High limit for monitor Angle High Limit
        /// </summary>
        MonitorAngleHighLimit = 01010,
        MeasureAngleTo = 01011,
        /// <summary>
        /// Degree value for re-hit detection
        /// </summary>
        RehitAngle = 01012,
        ZoomStepSpeed = 01013,
        ErgoRamp = 01014,

        /// <summary>
        /// Time after rundown done until result is sent, especially used when Multistage tightening is used
        /// </summary>
        ToolIdleTime = 01016,
        /// <summary>
        /// Time for slip off detection
        /// </summary>
        EndTime = 01017,
        /// <summary>
        /// When starting detection of End time.
        /// </summary>
        MonitorEndTimeFrom = 01018,
        /// <summary>
        /// Time out value in second before not finished Job is aborted.
        /// </summary>
        TighteningTimeOutInSeconds = 01019,
        /// <summary>
        /// Max number of coherent NOK results allowed
        /// </summary>
        MaxCoherentNok = 01020,
        HighSpeedRundownUsed = 01021,
        /// <summary>
        /// Speed in percent of tool max
        /// </summary>
        HighSpeedRundownSpeed = 01022,
        /// <summary>
        /// Value in degrees for the interval of the first part of the rundown before snag
        /// </summary>
        HighSpeedRundownInterval = 01023,
        /// <summary>
        /// Acceleration factor in percent
        /// </summary>
        HighSpeedRundownRampAtHighSpeed = 01024,
        HighSpeedRundownDisableHighSpeedAtNok = 01025,
        OptionsUsed = 01026,
        OptionsSoftStop = 01027,
        OptionsRehitDetect = 01028,
        OptionsTorqueLessThanTargetDetect = 01029,
        OptionsLostTriggerDetect = 01030,
        OptionsSocketReleaseDetect = 01031,
        SelftapMonitoringSpeedRpm = 01032,
        MeasuredDelayTime = 01033,
        DsTuningValue = 01034,
        OptionsTimeoutDetect = 01035,
        /// <summary>
        /// Used strategies as a bit field. Measured value
        /// </summary>
        UsedStrategies = 01036,
        TighteningErrorBits1 = 01037,
        TighteningErrorBits2 = 01038,
        ResultType = 01039,
        /// <summary>
        /// The Id of a dynamic Pset
        /// </summary>
        DynamicParameterSetId = 01040,
        /// <summary>
        /// The name of a dynamic Pset
        /// </summary>
        DynamicParameterSetName = 01041,
        /// <summary>
        /// Device dependent tightening information. 
        /// <para><em>See specific device specification and/or appendix</em></para>
        /// </summary>
        TighteningInformationBits = 01042,
        DisableLoosening = 01043,
    }

    public enum TorqueControllerInformationPID
    {
        /// <summary>
        /// The name of the torque controller that made the tightening
        /// </summary>
        TorqueControllerName = 01100,
        /// <summary>
        /// The number of the torque controller that made the tightening.
        /// </summary>
        TorqueControllerNumber = 01101,
        /// <summary>
        /// The type name of the controller that made the tightening.
        /// </summary>
        TorqueControllerTypeName = 01102,
        /// <summary>
        /// The article number of the torque controller that made the tightening.
        /// </summary>
        TorqueControllerArticleNumber = 01103,
        /// <summary>
        /// The serial number of the torque controller that made the tightening.
        /// </summary>
        TorqueControllerSerialNumber = 01104
    }

    public enum BoltInformationPID
    {
        /// <summary>
        /// The name of the bolt that was tightened
        /// </summary>
        BoltName = 01300,
        /// <summary>
        /// The number of the bolt that was tightened
        /// </summary>
        BoltNumber = 01301,
        /// <summary>
        /// The status of the bolt that was tightened
        /// </summary>
        BoltStatus = 01302,
    }

    public enum ErrorAndStatusCodesPID
    {
        /// <summary>
        /// The total status of the tightening
        /// </summary>
        TighteningStatus = 01400,
        /// <summary>
        /// Error codes from the tightening. Is defined by a bit field and sent as a hexadecimal value
        /// <para><em>i.e. Data Type will be set to H in the telegram.</em></para>
        /// <para><em>The number of bits and their definition vary between the different systems.</em></para>
        /// </summary>
        TighteningErrorCodes = 01401,
        /// <summary>
        /// The status of the Torque in the tightening 
        /// <para><em>Based on the parameter 02001</em></para>
        /// </summary>
        TorqueStatus = 01402,
        /// <summary>
        /// The status of the Angle in the tightening 
        /// <para><em>Based on the parameter 02011</em></para>
        /// </summary>
        AngleStatus = 01403,
        /// <summary>
        /// The status of the Rundown monitoring in the tightening
        /// <para><em>Based on the parameter 02016-2018</em></para>
        /// </summary>
        RundownMonitorStatus = 01404,
        /// <summary>
        /// The status of the Current monitoring in the tightening 
        /// <para><em>Based on the parameter 02020-02023</em></para>
        /// </summary>
        CurrentMonitorStatus = 01405,
        /// <summary>
        /// The status of the Self tap monitoring in the tightening 
        /// <para><em>Based on the parameter 02070-02071</em></para>
        /// </summary>
        SelftapStatus = 01406,
        /// <summary>
        /// The status of the PVT monitoring in the tightening 
        /// <para><em>Based on the parameter 02078</em></para>
        /// </summary>
        PVTMonitorStatus = 01407,
        /// <summary>
        /// The status of the PVT Comp monitoring in the tightening 
        /// <para><em>Based on the parameter 02072-02073</em></para>
        /// </summary>
        PVTCompStatus = 01408,

        /// <summary>
        /// Additional information related to the Tightening Status
        /// </summary>
        TighteningStatusAdditionalInformation = 01420,
        /// <summary>
        /// The primary error from the tightening.
        /// <para><em>The definition vary between the different systems</em></para>
        /// </summary>
        PrimaryError = 01421,
        /// <summary>
        /// The number of the step that made the tightening NOK
        /// </summary>
        FailingStep = 01422
    }

    public enum JobSyncParametersPID
    {
        /// <summary>
        /// ID of a Job
        /// </summary>
        JobId = 01500,
        /// <summary>
        /// Job result sequence
        /// </summary>
        JobSequenceNumber = 01501,
        /// <summary>
        /// Stage within an Job
        /// </summary>
        JobStageNumber = 01502,
        /// <summary>
        /// The last time the Job configuration was changed
        /// </summary>
        JobTimestamp = 01503,
        /// <summary>
        /// Id of a sync group or station.
        /// </summary>
        SyncGroupId = 01504,
        /// <summary>
        /// Name of a sync group or station.
        /// </summary>
        SyncGroupName = 01505,
        /// <summary>
        /// Status of a sync group or station
        /// </summary>
        SyncGroupStatus = 01506,
        /// <summary>
        /// The Id of a result from an sync tightening
        /// </summary>
        SyncTighteningId = 01507,
        /// <summary>
        /// The time stamp of Job started
        /// </summary>
        JobStartTime = 01508,
        /// <summary>
        /// The Reference Mac address for Job result when cell is used
        /// </summary>
        JobReferenceMacAddress = 01509,
        /// <summary>
        /// Identifier number of Job
        /// </summary>
        JobResultId = 01510,
        AutoParameterSetChange = 01511,
        ParameterSetOrMultistageSetType = 01512,
        /// <summary>
        /// Channel Id of Pset/Mset when cell is used
        /// </summary>
        ParameterSetOrMultistageChannelId = 01513,
        /// <summary>
        /// Time when the Job was ended or stopped
        /// </summary>
        StopTime = 01514,
        /// <summary>
        /// First NOK stage in Job
        /// </summary>
        FirstNokEvent = 01515,
        JobDoneStatus = 01516
    }

    public enum AlarmInformationPID
    {
        AlarmText = 01700,
        AlarmSeverity = 01701,
        MaintenanceAlert = 01702
    }

    public enum TighteningValuesPID
    {
        /// <summary>
        /// The target torque for the whole tightening program
        /// </summary>
        TorqueFinalTarget = 02000,
        /// <summary>
        /// The measured torque for the whole tightening.
        /// </summary>
        TorqueMeasuredValue = 02001,
        /// <summary>
        /// The upper limit for the measured torque of the whole program.
        /// </summary>
        TorqueFinalUpperLimit = 02002,
        /// <summary>
        /// The lower limit for the measured torque of the whole program.
        /// </summary>
        TorqueFinalLowerLimit = 02003,
        /// <summary>
        /// The first target in a two step
        /// </summary>
        TorqueFirstTarget = 02004,
        /// <summary>
        /// Torque value where the tightening measurement starts after tightening start
        /// </summary>
        TorqueCycleStart = 02005,
        /// <summary>
        /// Torque value where the tightening measurement starts before complete
        /// </summary>
        TorqueCycleComplete = 02006,

        /// <summary>
        /// The target angle for the whole tightening program
        /// </summary>
        AngleTarget = 02010,
        /// <summary>
        /// The measured angle for the whole tightening.
        /// </summary>
        AngleMeasuredValue = 02011,
        /// <summary>
        /// The upper limit for the measured angle, for the whole tightening
        /// </summary>
        AngleUpperLimit = 02012,
        /// <summary>
        /// The lower limit for the measured angle, for the whole tightening
        /// </summary>
        AngleLowerLimit = 02013,
        /// <summary>
        /// The torque value at which the angle measurement start at the cycle start
        /// </summary>
        AngleTargetThresholdTorqueCycleStart = 02014,
        /// <summary>
        /// The torque value at which the angle measurement start at the cycle end
        /// </summary>
        AngleTargetThresholdTorqueCycleEnd = 02015,
        /// <summary>
        /// The max allowed angle value target measured according to parameter 2043 (<see cref="RundownAngle"/>)
        /// </summary>
        AngleMaxRundown = 02016,
        /// <summary>
        /// The min allowed angle value target measured according to parameter 2043 (<see cref="RundownAngle"/>)
        /// </summary>
        AngleMinRundown = 02017,
        /// <summary>
        /// The max value of the angle to measure
        /// </summary>
        AngleMaxToMonitor = 02018,
        TorqueRundownCompleteTorque = 02019,
        /// <summary>
        /// The target current for the whole tightening program
        /// </summary>
        CurrentTarget = 02020,
        /// <summary>
        /// The measured current for the whole tightening.
        /// </summary>
        CurrentMeasuredValue = 02021,
        /// <summary>
        /// The upper limit for the measured current
        /// </summary>
        CurrentUpperLimit = 02022,
        /// <summary>
        /// The lower limit for the measured current
        /// </summary>
        CurrentLowerLimit = 02023,

        /// <summary>
        /// The measured torque for the whole tightening. Measured with a secondary torque transducer.
        /// </summary>
        TorqueSecondMeasuredValue = 02030,
        /// <summary>
        /// The upper limit for the measured torque 2nd.
        /// </summary>
        TorqueSecondUpperLimit = 02031,
        /// <summary>
        /// The lower limit for the measured torque 2nd.
        /// </summary>
        TorqueSecondLowerLimit = 02032,

        /// <summary>
        /// The measured angle for the whole tightening. Measured with a secondary angle transducer.
        /// </summary>
        AngleSecondMeasuredValue = 02040,
        /// <summary>
        /// The upper limit for the measured angle 2nd
        /// </summary>
        AngleSecondUpperLimit = 02041,
        /// <summary>
        /// The lower limit for the measured angle 2nd
        /// </summary>
        AngleSecondLowerLimit = 02042,
        RundownAngle = 02043,
        RundownAngleMeasuredValue = 02044,

        /// <summary>
        /// The target speed for the whole tightening program
        /// </summary>
        SpeedTarget = 02050,
        /// <summary>
        /// The measured speed for the whole tightening program
        /// </summary>
        SpeedMeasured = 02051,
        /// <summary>
        /// The target speed for the each step
        /// </summary>
        StepSpeed = 02052,

        /// <summary>
        /// The time duration for the soft start in a tightening
        /// </summary>
        SoftStartTime = 02054,
        /// <summary>
        /// The tightening speed during the soft start time duration either in ratio or percent of the tool max speed.
        /// </summary>
        SoftStartSpeed = 02055,
        /// <summary>
        /// The tightening speed increase per time unit during the step.
        /// </summary>
        StepRamp = 02056,

        LockAtBatchDone = 02058,
        /// <summary>
        /// Antinecking detection for angle control strategies.
        /// </summary>
        NeckingShutOff = 02059,
        RotateDirection = 02060,
        Selftap = 02061,
        /// <summary>
        /// At least 1
        /// </summary>
        NumberOfSelftapWindows = 02062,

        NeckingDropTorqueFromPeak = 02064,

        /// <summary>
        /// The max tightening torque value for the self-tap measurement validation.
        /// </summary>
        SelftapMaxTorque = 02070,
        /// <summary>
        /// The min tightening torque value for the self-tap measurement validation.
        /// </summary>
        SelftapMinTorque = 02071,
        /// <summary>
        /// The max tightening torque value for the prevail measurement validation.
        /// </summary>
        PrevailTorqueMax = 02072,
        /// <summary>
        /// The min tightening torque value for the prevail measurement validation.
        /// </summary>
        PrevailTorqueMin = 02073,
        YieldMax = 02074,
        YieldMin = 02075,
        /// <summary>
        /// Prevail on or off
        /// </summary>
        Prevail = 02076,
        /// <summary>
        /// Prevail Comp on or off
        /// </summary>
        PrevailComp = 02077,
        /// <summary>
        /// Angle value
        /// </summary>
        PrvailCompPointAngle = 02078,
        /// <summary>
        /// At least 1 is required
        /// </summary>
        NumberOfPrevailWindows = 02079,
        /// <summary>
        /// Torque float value for the low limit in Torque trace
        /// </summary>
        PostViewTorqueMinLimit = 02080,
        /// <summary>
        /// Torque float value for the high limit in Torque trace
        /// </summary>
        PostViewTorqueMaxLimit = 02081,
        PrevailCompMeasuredTorque = 02082,

        /// <summary>
        /// The interval duration in degrees for self-tap measurements according to parameters 02070 (<see cref="SelftapMaxTorque"/>) and 02071 (<see cref="SelftapMinTorque"/>)
        /// </summary>
        SelftapMonitorInterval = 02084,
        /// <summary>
        /// Delay from cycle start to the start of Prevail Torque Monitor Interval
        /// </summary>
        PrevailTorqueDelayInterval = 02085,
        /// <summary>
        /// The interval duration in degrees for prevail measurements according to parameters 02072 (<see cref="PrevailTorqueMax"/>) and 02073 (<see cref="PrevailTorqueMin"/>)
        /// </summary>
        PrevailTorqueMonitorInterval = 02086,
        /// <summary>
        /// Post View Torque in Angle trace
        /// </summary>
        PostViewTorqueMonitorMinStart = 02087,
        /// <summary>
        /// Post View Torque in Angle trace
        /// </summary>
        PostViewTorqueMonitorMinInterval = 02088,
        /// <summary>
        /// Post View Torque in Angle trace
        /// </summary>
        PostViewTorqueMonitorMaxStart = 02089,
        /// <summary>
        /// Post View Torque in Angle trace
        /// </summary>
        PostViewTorqueMonitorMaxInterval = 02090,
        PostViewTorque = 02091,
        SelftapTorqueMeasuredValue = 02092,
        PrevailTorqueMeasuredValue = 02093,
        AttachmentGearRatio = 02094,
        AttachmentTuningEfficiencyTuning = 02095,

        /// <summary>
        /// Torque threshold for loosening detection
        /// </summary>
        LooseningLimitTorque = 02100,
        /// <summary>
        /// Speed according to parameter 02103 (<see cref="SpeedUnit"/>)
        /// </summary>
        LooseningSpeed = 02101,
        /// <summary>
        /// Ramp according to parameter 02103 (<see cref="SpeedUnit"/>)
        /// </summary>
        LooseningRamp = 02102,
        SpeedUnit = 02103,

        /// <summary>
        /// The target force for the whole program
        /// </summary>
        ForceFinalTarget = 02110,
        /// <summary>
        /// The measured force for the whole press.
        /// </summary>
        ForceMeasuredValue = 02111,
        /// <summary>
        /// The upper limit for the measured force, for the whole program
        /// </summary>
        ForceFinalUpperLimit = 02112,
        /// <summary>
        /// The lower limit for the measured force, for the whole program
        /// </summary>
        ForceFinalLowerLimit = 02113,

        /// <summary>
        /// The target stroke for the whole program
        /// </summary>
        StrokeTarget = 02120,
        /// <summary>
        /// The measured stroke for the whole program.
        /// </summary>
        StrokeMeasuredValue = 02121,
        /// <summary>
        /// The upper limit for the measured stroke, for the whole program
        /// </summary>
        StrokeUpperLimit = 02122,
        /// <summary>
        /// The lower limit for the measured stroke, for the whole program
        /// </summary>
        StrokeLowerLimit = 02123,
        /// <summary>
        /// User defined event text
        /// </summary>
        FreeEventText = 02124,

        /// <summary>
        /// The status for one stage torque of a four stage tightening.
        /// </summary>
        FourStageStatusTorqueMeasuredValue = 02129,
        /// <summary>
        /// Starting value in degrees for an four stage tightening
        /// </summary>
        FourStageSoftStartAngle = 02130,
        /// <summary>
        /// Max value for soft start torque in Nm during soft start
        /// </summary>
        FourStageSoftStartAngleTorqueMax = 02131,
        /// <summary>
        /// Min value in degrees for first target in an four stage tightening
        /// </summary>
        FourStageSoftStartAngleAngleMin = 02132,
        /// <summary>
        /// Max value in degrees for first target in an four stage tightening
        /// </summary>
        FourStageSoftStartAngleAngleMax = 02133,
        /// <summary>
        /// The measured torque for one stage of a four stage tightening
        /// </summary>
        FourStageTorqueMeasuredValue = 02134,
        /// <summary>
        /// The measured angle for one stage of a four stage tightening
        /// </summary>
        FourStageAngleMeasuredValue = 02135,
        /// <summary>
        /// The status for one stage angle of a four stage tightening.
        /// </summary>
        FourStageStatusAngleMeasuredValue = 02136,
        /// <summary>
        /// Gradient monitoring on or off
        /// </summary>
        GradientMonitoring = 02137,
        /// <summary>
        /// Torque Value in Nm
        /// </summary>
        GradientTorqueMin = 02138,
        /// <summary>
        /// Torque Value in Nm
        /// </summary>
        GradientTorqueMax = 02139,
        /// <summary>
        /// Angle value in degrees
        /// </summary>
        GradientJointHardness = 02140,
        /// <summary>
        /// Torque Value in Nm
        /// </summary>
        GradientStartTorque = 02141,
        /// <summary>
        /// Angle value in degrees
        /// </summary>
        GradientAngleOffset = 02142,
        /// <summary>
        /// Torque Value in Nm
        /// </summary>
        YieldControlStartTorque = 02143,
        /// <summary>
        /// Angle value in degrees for one step
        /// </summary>
        YieldControlStepAngle = 02144,
        /// <summary>
        /// Angle value in degrees
        /// </summary>
        YieldControlWindowAngle = 02145,
        /// <summary>
        /// In percent
        /// </summary>
        YieldSlopeRatio = 02146,
        /// <summary>
        /// Angle extra value for one step
        /// </summary>
        YieldControlExtraAngleStep = 02147,

        /// <summary>
        /// Adjustable limit on or off
        /// </summary>
        PositioningAdjustableLimit = 02150,
        /// <summary>
        /// Value in Nm
        /// </summary>
        PositioningLimit = 02151,
        /// <summary>
        /// Value in degrees
        /// </summary>
        SnugGradientDeltaAngle = 02152,
        /// <summary>
        /// Value in torque Nm
        /// </summary>
        SnugGradientDeltaTorque = 02153,
        /// <summary>
        /// Value in torque Nm
        /// </summary>
        SnugGradientTorqueLimit = 02154,
        /// <summary>
        /// Value in degrees
        /// </summary>
        SnugGradientPVTDistance = 02155,
        /// <summary>
        /// Value in degrees
        /// </summary>
        SnugGradientPVTInterval = 02156,
        /// <summary>
        /// Value in degrees
        /// </summary>
        SnugGradientCompensate = 02157,
        /// <summary>
        /// Value in torque Nm
        /// </summary>
        SnugPVTMonitoringMin = 02158,
        /// <summary>
        /// Value in torque Nm
        /// </summary>
        SnugPVTMonitoringMax = 02159,
        /// <summary>
        /// Value in degrees
        /// </summary>
        DelayMonitoringAfterCycleStart = 02160,
        /// <summary>
        /// Min value in degrees for soft start angle in a four stage tightening
        /// </summary>
        FourStageSoftStartAngleLowLimit = 02161,
        /// <summary>
        /// Max value in degrees for soft start angle in a four stage tightening
        /// </summary>
        FourStageSoftStartAngleHighLimit = 02162,
        /// <summary>
        /// Min value in Nm for rundown torque in a four stage tightening
        /// </summary>
        FourStageRundownTorqueLowLimit = 02163,
        /// <summary>
        /// Max value in Nm for rundown torque in a four stage tightening
        /// </summary>
        FourStageRundownTorqueHighLimit = 02164,
        /// <summary>
        /// Min value in Nm for first torque in a four stage tightening
        /// </summary>
        FourStageFirstTorqueLowLimit = 02165,
        /// <summary>
        /// Max value in Nm for first torque in a four stage tightening
        /// </summary>
        FourStageFirstTorqueHighLimit = 02166,
        /// <summary>
        /// Min value for soft start torque in Nm during soft start
        /// </summary>
        FourStageSoftStartAngleTorqueMin = 02167,

        /// <summary>
        /// Total time to make the tightening [s]
        /// </summary>
        ElapsedTime = 02170,
        /// <summary>
        /// Number of turns for rundown
        /// </summary>
        TurnsForRundown = 02171
    }

    public enum TighteningValuesForTracePID
    {
        /// <summary>
        /// Type of the trace curve
        /// </summary>
        TraceType = 02201,
        /// <summary>
        /// Coefficient to convert 2 byte binary data to real physical values. 
        /// <para><em>Physical value = Binary value / Coefficient</em></para>
        /// </summary>
        DivisionCoefficient = 02213,
        /// <summary>
        /// Coefficient to convert 2 byte binary data to real physical values. 
        /// <para><em>Physical value = Binary value * Coefficient</em></para>
        /// </summary>
        MultiplicationCoefficient = 02214,
        /// <summary>
        /// Number of samples for stage one at four stage tightening
        /// </summary>
        StageOneNumberOfSamples = 02215,
        /// <summary>
        /// Number of samples for stage two at four stage tightening
        /// </summary>
        StageTwoNumberOfSamples = 02216,
        /// <summary>
        /// Number of samples for stage three at four stage tightening
        /// </summary>
        StageThreeNumberOfSamples = 02217,
        /// <summary>
        /// Number of samples for stage four at four stage tightening
        /// </summary>
        StageFourNumberOfSamples = 02218
    }

    public enum GeneralDownloadDataStatusForRadioConnectedToolsPID
    {
        ToolLatestParameterSetStatus = 04000,
        ToolLatestIdentifierStatus = 04001,
        ToolLockUnlockStatus = 04002
    }

    public enum StepInformationPID
    {
        /// <summary>
        /// The target torque for the tightening program step
        /// </summary>
        StepTorqueTarget = 05100,
        /// <summary>
        /// The measured torque for the tightening program step
        /// </summary>
        StepTorqueMeasuredValue = 05101,
        /// <summary>
        /// The upper limit for the measured step torque.
        /// </summary>
        StepTorqueUpperLimit = 05102,
        /// <summary>
        /// The lower limit for the measured step torque.
        /// </summary>
        StepTorqueLowerLimit = 05103,

        /// <summary>
        /// The target angle for the tightening program step
        /// </summary>
        StepAngleTarget = 05110,
        /// <summary>
        /// The torque value there the angle measurement start
        /// </summary>
        StepAngleTargetThresholdTorque = 05111,
        /// <summary>
        /// The measured angle for tightening program step
        /// </summary>
        StepAngleMeasuredValue = 05112,
        /// <summary>
        /// The upper limit for the measured step angle
        /// </summary>
        StepAngleUpperLimit = 05113,
        /// <summary>
        /// The lower limit for the measured step angle
        /// </summary>
        StepAngleLowerLimit = 05114,

        /// <summary>
        /// The target current for the tightening program step
        /// </summary>
        StepCurrentTarget = 05120,
        /// <summary>
        /// The measured current for tightening program step
        /// </summary>
        StepCurrentMeasuredValue = 05121,
        /// <summary>
        /// The upper limit for the measured step current
        /// </summary>
        StepCurrentUpperLimit = 05122,
        /// <summary>
        /// The lower limit for the measured step current
        /// </summary>
        StepCurrentLowerLimit = 05123,

        /// <summary>
        /// The target force for the tightening program step
        /// </summary>
        StepForceTarget = 05130,
        /// <summary>
        /// The measured force for the tightening program step
        /// </summary>
        StepForceMeasuredValue = 05131,
        /// <summary>
        /// The upper limit for the measured step force.
        /// </summary>
        StepForceUpperLimit = 05132,
        /// <summary>
        /// The lower limit for the measured step force.
        /// </summary>
        StepForceLowerLimit = 05133,

        /// <summary>
        /// The target stroke for the tightening program step
        /// </summary>
        StepStrokeTarget = 05140,
        /// <summary>
        /// The force value there the stroke measurement start
        /// </summary>
        StepStrokeTargetThresholdForce = 05141,
        /// <summary>
        /// The measured stroke for tightening program step
        /// </summary>
        StepStrokeMeasuredValue = 05142,
        /// <summary>
        /// The upper limit for the measured step stroke
        /// </summary>
        StepStrokeUpperLimit = 05143,
        /// <summary>
        /// The lower limit for the measured step stroke
        /// </summary>
        StepStrokeLowerLimit = 05144,

        /// <summary>
        /// Calculated from the Time Stamp
        /// </summary>
        StepStart = 05150,
        /// <summary>
        /// Calculated from the Time Stamp
        /// </summary>
        StepStop = 05151,

        /// <summary>
        /// The measured shut off torque for the step
        /// </summary>
        StepShutOffTorqueMeasured = 05160,
        /// <summary>
        /// The measured torque rate for the step
        /// </summary>
        StepTorqueRateMeasured = 05161,
        /// <summary>
        /// The measured torque rate deviation for the step
        /// </summary>
        StepTorqueRateDeviationMeasured = 05162,
        /// <summary>
        /// The measured peak torque in angle window for the step
        /// </summary>
        StepPeakTorqueInWindowMeasured = 05163,
        /// <summary>
        /// The measured low torque in angle window for the step
        /// </summary>
        StepLowTorqueInWindowMeasured = 05164,
        /// <summary>
        /// The measured post view torque high torque value for the step
        /// </summary>
        StepPostViewTorqueHighMeasured = 05165,
        /// <summary>
        /// The measured post view torque low torque value for the step
        /// </summary>
        StepPostViewTorqueLowMeasured = 05166,
        /// <summary>
        /// The measured yield point angle for the step
        /// </summary>
        StepYieldAngleMeasured = 05167,
        /// <summary>
        /// The measured prevailing torque for the step
        /// </summary>
        StepPrevailingTorqueMeasured = 05168,
        /// <summary>
        /// The measured time for the step
        /// </summary>
        StepTimeMeasured = 05169,
        /// <summary>
        /// Time needed to execute the step
        /// </summary>
        StepElapsedTime = 05170,
        /// <summary>
        /// The measured cross thread angle for the step
        /// </summary>
        CrossThreadAngleMeasured = 05171,
        /// <summary>
        /// The measured angle at post view torque high
        /// </summary>
        StepPostViewTorqueHighAngleMeasured = 05172,
        /// <summary>
        /// The measured angle at post view torque low
        /// </summary>
        StepPostViewTorqueLowAngleMeasured = 05173
    }

    public enum ToolInformationPID
    {
        /// <summary>
        /// The type name of the tool that made the tightening.
        /// </summary>
        ToolTypeName = 01200,
        /// <summary>
        /// The article number of the tool that made the tightening.
        /// </summary>
        ToolArticleNumber = 01201,
        /// <summary>
        /// The serial number of the tool that made the tightening.
        /// </summary>
        ToolSerialNumber = 01202,
        ToolType = 01203,
        SpeedFactor = 01204,
        /// <summary>
        /// The index or number of the tool
        /// </summary>
        ToolNumber = 01205,

        /// <summary>
        /// The total number of tightenings made with the tool
        /// </summary>
        ToolTotalNumberOfTightenings = 01210,
        /// <summary>
        /// The total number of tightenings made with the tool since last service
        /// </summary>
        ToolTotalNumberOfTighteningsSinceService = 01211,
        /// <summary>
        /// The total number of tightenings before the tool need to be serviced
        /// </summary>
        ToolTotalNumberOfTighteningsToService = 01212,
        /// <summary>
        /// To read out the different tool temperatures
        /// </summary>
        ToolTemperature = 01213,
        /// <summary>
        /// To get the service interval
        /// </summary>
        ServiceInterval = 01214
    }
}
