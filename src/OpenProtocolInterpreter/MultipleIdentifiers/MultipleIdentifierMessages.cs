using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    internal class MultipleIdentifierMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public MultipleIdentifierMessages()
        {
            templates = new Mid0150(new Mid0151(new Mid0152(new Mid0153(
                new Mid0154(new Mid0155(new Mid0156(new Mid0157(null))))))));
        }

        public MultipleIdentifierMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
