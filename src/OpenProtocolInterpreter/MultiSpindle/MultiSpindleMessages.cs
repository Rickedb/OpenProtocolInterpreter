using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MultiSpindle
{
    internal class MultiSpindleMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public MultiSpindleMessages()
        {
            templates = new Mid0090(new Mid0091(new Mid0092(new Mid0093(null))));
        }

        public MultiSpindleMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
