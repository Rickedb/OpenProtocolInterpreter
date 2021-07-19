using System;

namespace OpenProtocolInterpreter.Job
{
    /// <summary>
    /// Parameter set entity.
    /// </summary>
    public class ParameterSet
    {
        public int ChannelId { get; set; }
        public int TypeId { get; set; }
        public bool AutoValue { get; set; }
        public int BatchSize { get; set; }
        public int IdentifierNumber { get; set; }
        [Obsolete("Socket is replaced by IdentifierNumber when revision 4 or later")]
        public int Socket { get; set; }
        public string JobStepName { get; set; }
        public int JobStepType { get; set; }
        public int MaxCoherentNok { get; set; }
    }
}
