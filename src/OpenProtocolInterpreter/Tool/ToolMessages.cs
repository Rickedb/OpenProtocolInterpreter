using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Tool
{
    internal class ToolMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public ToolMessages()
        {
            templates = new MID_0040(new MID_0041(new MID_0042(new MID_0043(new MID_0044(new MID_0045(new MID_0046(
                             new MID_0047(new MID_0048(null)))))))));
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
