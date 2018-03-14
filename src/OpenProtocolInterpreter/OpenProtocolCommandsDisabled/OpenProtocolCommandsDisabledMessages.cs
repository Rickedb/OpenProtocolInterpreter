using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    internal class OpenProtocolCommandsDisabledMessages :  IMessagesTemplate
    {
        private readonly IMID templates;

        public OpenProtocolCommandsDisabledMessages()
        {
            this.templates = new MID_0420(new MID_0421(new MID_0422(new MID_0423(null))));
        }

        public OpenProtocolCommandsDisabledMessages(System.Collections.Generic.IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public MID ProcessPackage(string package)
        {
            return this.templates.ProcessPackage(package);
        }
    }
}
