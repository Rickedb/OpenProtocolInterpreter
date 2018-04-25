using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Job.Advanced
{
    internal class AdvancedJobMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public AdvancedJobMessages()
        {
            templates = new MID_0121(new MID_0122( new MID_0123(new MID_0124( new MID_0125(new MID_0126(new MID_0127(new MID_0128(new MID_0129(
                             new MID_0130( new MID_0131(new MID_0132(new MID_0133(new MID_0140(null))))))))))))));
        }

        public AdvancedJobMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.ProcessPackage(package);
        }
    }
}
