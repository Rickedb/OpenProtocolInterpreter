using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MultipleIdentifiers
{
    internal class MultipleIdentifierMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public MultipleIdentifierMessages()
        {
            this.templates = new MID_0150(new MID_0151(new MID_0152(new MID_0153(
                new MID_0154(new MID_0155(new MID_0156(new MID_0157(null))))))));
        }

        public MultipleIdentifierMessages(System.Collections.Generic.IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public MID ProcessPackage(string package)
        {
            return this.templates.ProcessPackage(package);
        }
    }
}
