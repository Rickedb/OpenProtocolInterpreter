using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.AutomaticManualMode
{
    internal class AutomaticManualModeMessages :  IMessagesTemplate
    {
        private readonly IMid templates;

        public AutomaticManualModeMessages()
        {
            templates = new Mid0400(new Mid0401(new Mid0402(new Mid0403(new Mid0410(new Mid0411(null))))));
        }

        public AutomaticManualModeMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
