using OpenProtocolInterpreter.Messages;
using OpenProtocolInterpreter.MultiSpindle.Status;

namespace OpenProtocolInterpreter.MultiSpindle
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
            this.templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public MID ProcessPackage(string package)
        {
            return this.templates.ProcessPackage(package);
        }
    }
}
