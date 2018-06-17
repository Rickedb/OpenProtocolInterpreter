using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.PowerMACS
{
    internal class PowerMACSMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public PowerMACSMessages()
        {
            templates = new Mid0105(new Mid0106(new Mid0107(new Mid0108(new Mid0109(null)))));
        }

        public PowerMACSMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
