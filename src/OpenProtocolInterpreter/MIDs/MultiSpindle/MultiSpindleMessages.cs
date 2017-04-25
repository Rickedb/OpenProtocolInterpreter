using OpenProtocolInterpreter.Messages;
using OpenProtocolInterpreter.MIDs.MultiSpindle.Status;

namespace OpenProtocolInterpreter.MIDs.MultiSpindle
{
    internal class MultiSpindleMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public MultiSpindleMessages()
        {
            this.templates = new MID_0090(new MID_0091(new MID_0092(null)));
        }

        public MultiSpindleMessages(System.Collections.Generic.IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.buildChainOfMids(selectedMids);
        }

        public MID processPackage(string package)
        {
            return this.templates.processPackage(package);
        }
    }
}
