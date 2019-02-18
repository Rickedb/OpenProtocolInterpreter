using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.UserInterface
{
    internal class UserInterfaceMessages : IMessagesTemplate
    {
        private readonly IMid _templates;

        public UserInterfaceMessages()
        {
            _templates = new Mid0110(new Mid0111(new Mid0113(null)));
        }

        public UserInterfaceMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            _templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package) => _templates.Parse(package);

        public Mid ProcessPackage(byte[] package) => _templates.Parse(package);
    }
}
