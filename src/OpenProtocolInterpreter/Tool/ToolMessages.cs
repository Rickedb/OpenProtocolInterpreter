using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Tool
{
    internal class ToolMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public ToolMessages()
        {
            templates = new Mid0040(new Mid0041(new Mid0042(new Mid0043(new Mid0044(new Mid0045(new Mid0046(
                             new Mid0047(new Mid0048(null)))))))));
        }

        public ToolMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
