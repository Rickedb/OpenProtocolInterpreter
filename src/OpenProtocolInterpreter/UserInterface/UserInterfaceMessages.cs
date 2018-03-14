using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.UserInterface
{
    internal class UserInterfaceMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public UserInterfaceMessages()
        {
            this.templates = new MID_0110(new MID_0111(new MID_0113(null)));
        }

        public UserInterfaceMessages(System.Collections.Generic.IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public MID ProcessPackage(string package)
        {
            return this.templates.ProcessPackage(package);
        }
    }
}
