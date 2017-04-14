using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MIDs.Job.Advanced
{
    internal class AdvancedJobMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public AdvancedJobMessages()
        {
            this.templates = new MID_0127(null);
        }

        public AdvancedJobMessages(System.Collections.Generic.IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.buildChainOfMids(selectedMids);
        }

        public MID processPackage(string package)
        {
            return this.templates.processPackage(package);
        }
    }
}
