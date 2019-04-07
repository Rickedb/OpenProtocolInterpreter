using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.OpenProtocolCommandsDisabled
{
    internal class OpenProtocolCommandsDisabledMessages :  IMessagesTemplate
    {
        private readonly IMid _templates;

        public OpenProtocolCommandsDisabledMessages()
        {
            _templates = new Mid0420(new Mid0421(new Mid0422(new Mid0423(null))));
        }

        public OpenProtocolCommandsDisabledMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            _templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package) => _templates.Parse(package);

        public Mid ProcessPackage(byte[] package) => _templates.Parse(package);
    }
}
