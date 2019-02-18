using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Vin
{
    internal class VinMessages : IMessagesTemplate
    {
        private readonly IMid _templates;

        public VinMessages()
        {
            _templates = new Mid0050(new Mid0051(new Mid0052(new Mid0053(new Mid0054(null)))));
        }

        public VinMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            _templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package) => _templates.Parse(package);

        public Mid ProcessPackage(byte[] package) => _templates.Parse(package);
    }
}
