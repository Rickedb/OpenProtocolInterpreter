using OpenProtocolInterpreter.Messages;


namespace OpenProtocolInterpreter.MIDs.Statistic
{
    internal class StatisticMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public StatisticMessages()
        {
            this.templates = new MID_0300(new MID_0301(null));
        }

        public StatisticMessages(System.Collections.Generic.IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.buildChainOfMids(selectedMids);
        }

        public MID processPackage(string package)
        {
            return this.templates.processPackage(package);
        }
    }
}
