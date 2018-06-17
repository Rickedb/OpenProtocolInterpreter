using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.PLCUserData
{
    internal class PLCUserDataMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public PLCUserDataMessages()
        {
            templates = new Mid0240(new Mid0241( new Mid0242( new Mid0243(new Mid0244(new Mid0245(null))))));
        }

        public PLCUserDataMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
