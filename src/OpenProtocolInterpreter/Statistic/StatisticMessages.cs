using OpenProtocolInterpreter.Messages;


namespace OpenProtocolInterpreter.Statistic
{
    internal class StatisticMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public StatisticMessages()
        {
            templates = new MID_0300(new MID_0301(null));
        }

        public StatisticMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
