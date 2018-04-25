using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.PLCUserData
{
    internal class PLCUserDataMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public PLCUserDataMessages()
        {
            templates = new MID_0240(new MID_0241( new MID_0242( new MID_0243(new MID_0244(new MID_0245(null))))));
        }

        public PLCUserDataMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.ProcessPackage(package);
        }
    }
}
