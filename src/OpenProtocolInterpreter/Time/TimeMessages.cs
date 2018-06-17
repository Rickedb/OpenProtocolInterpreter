using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Time
{
    internal class TimeMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public TimeMessages()
        {
            templates = new Mid0080(new Mid0081(new Mid0082(null)));
        }

        public TimeMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
