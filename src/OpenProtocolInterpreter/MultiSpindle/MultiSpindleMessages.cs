using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MultiSpindle
{
    internal class MultiSpindleMessages : IMessagesTemplate
    {
        private readonly IMid _templates;

        public MultiSpindleMessages()
        {
            _templates = new Mid0090(new Mid0091(new Mid0092(new Mid0093(null))));
        }

        public MultiSpindleMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            _templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package) => _templates.Parse(package);

        public Mid ProcessPackage(byte[] package) => _templates.Parse(package);
    }
}
