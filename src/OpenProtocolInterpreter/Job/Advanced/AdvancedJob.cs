namespace OpenProtocolInterpreter.Job.Advanced
{
    public class AdvancedJob
    {
        public int ChannelId { get; set; }
        public int ProgramId { get; set; }
        public bool AutoSelect { get; set; }
        public int BatchSize { get; set; }
        public int MaxCoherentNok { get; set; }
        public int BatchCounter { get; set; }
    }
}
