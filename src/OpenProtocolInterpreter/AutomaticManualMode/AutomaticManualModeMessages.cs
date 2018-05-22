using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.AutomaticManualMode
{
    internal class AutomaticManualModeMessages :  IMessagesTemplate
    {
        private readonly IMid templates;

        public AutomaticManualModeMessages()
        {
            templates = new MID_0400(new MID_0401(new MID_0402(new MID_0403(new MID_0410(new MID_0411(null))))));
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
