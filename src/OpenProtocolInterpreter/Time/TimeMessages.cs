using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Time
{
    internal class TimeMessages : IMessagesTemplate
    {
        private readonly IMid _templates;

        public TimeMessages()
        {
            _templates = new Mid0080(new Mid0081(new Mid0082(null)));
        }

        public TimeMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            _templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package) => _templates.Parse(package);

        public Mid ProcessPackage(byte[] package) => _templates.Parse(package);
    }
}
