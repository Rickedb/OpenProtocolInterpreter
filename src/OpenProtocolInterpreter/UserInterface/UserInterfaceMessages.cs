using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.UserInterface
{
    internal class UserInterfaceMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public UserInterfaceMessages()
        {
            templates = new MID_0110(new MID_0111(new MID_0113(null)));
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
