using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    internal class MultipleIdentifierMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public MultipleIdentifierMessages()
        {
            templates = new MID_0150(new MID_0151(new MID_0152(new MID_0153(
                new MID_0154(new MID_0155(new MID_0156(new MID_0157(null))))))));
        }

        public MultipleIdentifierMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.ProcessPackage(package);
        }
    }
}
