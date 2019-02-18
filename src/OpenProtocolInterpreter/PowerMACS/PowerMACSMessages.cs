using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.PowerMACS
{
    internal class PowerMACSMessages : IMessagesTemplate
    {
        private readonly IMid _templates;

        public PowerMACSMessages()
        {
            _templates = new Mid0105(new Mid0106(new Mid0107(new Mid0108(new Mid0109(null)))));
        }

        public PowerMACSMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            _templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package) => _templates.Parse(package);

        public Mid ProcessPackage(byte[] package) => _templates.Parse(package);
    }
}
