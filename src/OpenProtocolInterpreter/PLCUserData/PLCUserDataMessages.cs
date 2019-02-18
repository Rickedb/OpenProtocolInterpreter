using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.PLCUserData
{
    internal class PLCUserDataMessages : IMessagesTemplate
    {
        private readonly IMid _templates;

        public PLCUserDataMessages()
        {
            _templates = new Mid0240(new Mid0241( new Mid0242( new Mid0243(new Mid0244(new Mid0245(null))))));
        }

        public PLCUserDataMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            _templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package) => _templates.Parse(package);

        public Mid ProcessPackage(byte[] package) => _templates.Parse(package);
    }
}
