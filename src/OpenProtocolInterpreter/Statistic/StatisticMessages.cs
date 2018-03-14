using OpenProtocolInterpreter.Messages;


namespace OpenProtocolInterpreter.Statistic
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
            this.templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public MID ProcessPackage(string package)
        {
            return this.templates.ProcessPackage(package);
        }
    }
}
