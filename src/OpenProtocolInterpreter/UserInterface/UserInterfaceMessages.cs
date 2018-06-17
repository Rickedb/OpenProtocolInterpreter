using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.UserInterface
{
    internal class UserInterfaceMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public UserInterfaceMessages()
        {
            templates = new Mid0110(new Mid0111(new Mid0113(null)));
        }

        public UserInterfaceMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
