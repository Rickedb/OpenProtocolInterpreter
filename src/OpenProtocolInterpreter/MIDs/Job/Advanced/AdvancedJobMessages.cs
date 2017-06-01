using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MIDs.Job.Advanced
{
    internal class AdvancedJobMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public AdvancedJobMessages()
        {
            this.templates = new MID_0121(new MID_0122( new MID_0123(new MID_0124( new MID_0125(new MID_0126(new MID_0127(new MID_0128(new MID_0129(
                             new MID_0130( new MID_0131(new MID_0132(new MID_0133(new MID_0140(null))))))))))))));
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
