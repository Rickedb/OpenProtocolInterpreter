using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    internal class OpenProtocolCommandsDisabledMessages :  IMessagesTemplate
    {
        private readonly IMid templates;

        public OpenProtocolCommandsDisabledMessages()
        {
            templates = new Mid0420(new Mid0421(new Mid0422(new Mid0423(null))));
        }

        public OpenProtocolCommandsDisabledMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
