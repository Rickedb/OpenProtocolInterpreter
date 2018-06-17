using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Vin
{
    internal class VinMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public VinMessages()
        {
            templates = new Mid0050(new Mid0051(new Mid0052(new Mid0053(new Mid0054(null)))));
        }

        public VinMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
