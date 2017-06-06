using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MIDs.AutomaticManualMode
{
    internal class AutomaticManualModeMessages :  IMessagesTemplate
    {
        private readonly IMID templates;

        public AutomaticManualModeMessages()
        {
            this.templates = new MID_0400(new MID_0401(new MID_0402(new MID_0403(new MID_0410(new MID_0411(null))))));
        }

        public AutomaticManualModeMessages(System.Collections.Generic.IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.buildChainOfMids(selectedMids);
        }

        public MID processPackage(string package)
        {
            return this.templates.processPackage(package);
        }
    }
}
