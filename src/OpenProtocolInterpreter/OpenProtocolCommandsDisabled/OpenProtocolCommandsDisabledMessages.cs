using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    internal class OpenProtocolCommandsDisabledMessages :  IMessagesTemplate
    {
        private readonly IMid templates;

        public OpenProtocolCommandsDisabledMessages()
        {
            templates = new MID_0420(new MID_0421(new MID_0422(new MID_0423(null))));
        }

        public OpenProtocolCommandsDisabledMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.ProcessPackage(package);
        }
    }
}
