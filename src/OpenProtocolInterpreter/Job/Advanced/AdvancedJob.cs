namespace OpenProtocolInterpreter.Job.Advanced
{
    /// <summary>
    /// Represents a advanced job entity
    /// </summary>
    public class AdvancedJob
    {
        public int ChannelId { get; set; }
        public int ProgramId { get; set; }
        public AutoSelect AutoSelect { get; set; }
        public int BatchSize { get; set; }
        public int MaxCoherentNok { get; set; }
        //Rev 2 and Rev 999 for BatchCounter only
        public int BatchCounter { get; set; }
        public int IdentifierNumber { get; set; }
        public string JobStepName { get; set; }
        public int JobStepType { get; set; }
        //Rev 3
        public ToolLoosening ToolLoosening { get; set; }
        public BatchMode JobBatchMode { get; set; }
        public BatchStatusAtIncrement BatchStatusAtIncrement { get; set; }
        public DecrementBatchAfterLoosening DecrementBatchAfterLoosening { get; set; }
        public CurrentBatchStatus CurrentBatchStatus { get; set; }

        /// <summary>
        /// Represents a advanced job entity
        /// </summary>
        public AdvancedJob()
        {

        }

        /// <summary>
        /// Revision 1 constructor
        /// </summary>
        /// <param name="channelId">two ASCII characters, range 00-99</param>
        /// <param name="programId">parameter set ID or Multistage ID, three ASCII characters, range 000-999</param>
        /// <param name="autoSelect">One ASCII character,
        ///     <para>0=None</para>
        ///     <para>1=Auto Next Change</para> 
        ///     <para>2=I/O</para> 
        ///     <para>6=Fieldbus</para> 
        ///     <para>8=Socket tray</para>
        /// </param>
        /// <param name="batchSize">Two ASCII characters, range 00-99</param>
        /// <param name="maxCoherentNok">Two ASCII characters, range 00-99</param>
        public AdvancedJob(int channelId, int programId, AutoSelect autoSelect, int batchSize, int maxCoherentNok)
        {
            ChannelId = channelId;
            ProgramId = programId;
            AutoSelect = autoSelect;
            BatchSize = batchSize;
            MaxCoherentNok = maxCoherentNok;
        }

        /// <summary>
        /// Revision 2 constructor
        /// </summary>
        /// <param name="channelId">two ASCII characters, range 00-99</param>
        /// <param name="programId">parameter set ID or Multistage ID, three ASCII characters, range 000-999</param>
        /// <param name="autoSelect">One ASCII character,
        ///     <para>0=None</para>
        ///     <para>1=Auto Next Change</para> 
        ///     <para>2=I/O</para> 
        ///     <para>6=Fieldbus</para> 
        ///     <para>8=Socket tray</para>
        /// </param>
        /// <param name="batchSize">Two ASCII characters, range 00-99</param>
        /// <param name="maxCoherentNok">Two ASCII characters, range 00-99</param>
        /// <param name="batchCounter">Two ASCII characters, range 00-99</param>
        /// <param name="identifierNumber">Four ASCII characters, range 0000-9999 (Socket(s), EndFitting(s)…)</param>
        /// <param name="jobStepName">25 ASCII characters</param>
        /// <param name="jobStepType">Two ASCII characters, range 00-99</param>
        public AdvancedJob(int channelId, int programId, AutoSelect autoSelect, int batchSize, int maxCoherentNok, int batchCounter, 
            int identifierNumber, string jobStepName, int jobStepType) : this(channelId, programId, autoSelect, batchSize, maxCoherentNok, batchCounter)
        {
            IdentifierNumber = identifierNumber;
            JobStepName = jobStepName;
            JobStepType = jobStepType;
        }

        /// <summary>
        /// Revision 3 constructor
        /// </summary>
        /// <param name="channelId">two ASCII characters, range 00-99</param>
        /// <param name="programId">parameter set ID or Multistage ID, three ASCII characters, range 000-999</param>
        /// <param name="autoSelect">One ASCII character,
        ///     <para>0=None</para>
        ///     <para>1=Auto Next Change</para> 
        ///     <para>2=I/O</para> 
        ///     <para>6=Fieldbus</para> 
        ///     <para>8=Socket tray</para>
        /// </param>
        /// <param name="batchSize">Two ASCII characters, range 00-99</param>
        /// <param name="maxCoherentNok">Two ASCII characters, range 00-99</param>
        /// <param name="batchCounter">Two ASCII characters, range 00-99</param>
        /// <param name="identifierNumber">Four ASCII characters, range 0000-9999 (Socket(s), EndFitting(s)…)</param>
        /// <param name="jobStepName">25 ASCII characters</param>
        /// <param name="jobStepType">Two ASCII characters, range 00-99</param>
        /// <param name="toolLoosening">1 ASCII character.
        ///     <para>0=Enable</para> 
        ///     <para>1=Disable</para>
        ///     <para>2=Enable only on NOK tightening</para>
        /// </param>
        /// <param name="jobBatchMode">1 ASCII character. 
        ///     <para>0=only the OK tightenings are counted</para>
        ///     <para>1=both the OK and NOK tightenings are counted</para>
        /// </param>
        /// <param name="batchStatusAtIncrement">1 ASCII character. Batch status after performing an increment or a bypass parameter set: 
        ///     <para>0=OK</para>
        ///     <para>1=NOK</para>
        /// </param>
        /// <param name="decrementBatchAfterLoosening">1 ASCII character.
        ///     <para>0=Never</para>
        ///     <para>1=Always</para>
        ///     <para>2=After OK</para>
        /// </param>
        /// <param name="currentBatchStatus">1 ASCII character: 
        ///     <para>0=Not started</para>
        ///     <para>1=OK</para>
        ///     <para>2=NOK</para>
        /// </param>
        public AdvancedJob(int channelId, int programId, AutoSelect autoSelect, int batchSize, int maxCoherentNok, int batchCounter,
            int identifierNumber, string jobStepName, int jobStepType, ToolLoosening toolLoosening, BatchMode jobBatchMode, 
            BatchStatusAtIncrement batchStatusAtIncrement, DecrementBatchAfterLoosening decrementBatchAfterLoosening, CurrentBatchStatus currentBatchStatus) 
            : this(channelId, programId, autoSelect, batchSize, maxCoherentNok, batchCounter, identifierNumber, jobStepName, jobStepType)
        {
            ToolLoosening = toolLoosening;
            JobBatchMode = jobBatchMode;
            BatchStatusAtIncrement = batchStatusAtIncrement;
            DecrementBatchAfterLoosening = decrementBatchAfterLoosening;
            CurrentBatchStatus = currentBatchStatus;
        }

        /// <summary>
        /// Revision 999 constructor
        /// </summary>
        /// <param name="channelId">two ASCII characters, range 00-99</param>
        /// <param name="programId">parameter set ID or Multistage ID, three ASCII characters, range 000-999</param>
        /// <param name="autoSelect">One ASCII character,
        ///     <para>0=None</para>
        ///     <para>1=Auto Next Change</para> 
        ///     <para>2=I/O</para> 
        ///     <para>6=Fieldbus</para> 
        ///     <para>8=Socket tray</para>
        /// </param>
        /// <param name="batchSize">Two ASCII characters, range 00-99</param>
        /// <param name="maxCoherentNok">Two ASCII characters, range 00-99</param>
        /// <param name="batchCounter">Two ASCII characters, range 00-99</param>
        public AdvancedJob(int channelId, int programId, AutoSelect autoSelect, int batchSize, int maxCoherentNok, int batchCounter) 
            : this(channelId, programId, autoSelect, batchSize, maxCoherentNok)
        {
            BatchCounter = batchCounter;
        }
    }
}
