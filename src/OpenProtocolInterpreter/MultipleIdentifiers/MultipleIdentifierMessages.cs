using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    internal class MultipleIdentifierMessages : IMessagesTemplate
    {
        private readonly IMid _templates;

        public MultipleIdentifierMessages()
        {
            _templates = new Mid0150(new Mid0151(new Mid0152(new Mid0153(
                new Mid0154(new Mid0155(new Mid0156(new Mid0157(null))))))));
        }

        public MultipleIdentifierMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            _templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package) => _templates.Parse(package);

        public Mid ProcessPackage(byte[] package) => _templates.Parse(package);
    }
}
