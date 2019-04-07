using OpenProtocolInterpreter.Messages;


namespace OpenProtocolInterpreter.Statistic
{
    internal class StatisticMessages : IMessagesTemplate
    {
        private readonly IMid _templates;

        public StatisticMessages()
        {
            _templates = new Mid0300(new Mid0301(null));
        }

        public StatisticMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            _templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package) => _templates.Parse(package);

        public Mid ProcessPackage(byte[] package) => _templates.Parse(package);
    }
}
