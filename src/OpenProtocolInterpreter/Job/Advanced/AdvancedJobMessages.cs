using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Job.Advanced
{
    internal class AdvancedJobMessages : IMessagesTemplate
    {
        private readonly IMid _templates;

        public AdvancedJobMessages()
        {
            _templates = new Mid0121(new Mid0122(new Mid0123(new Mid0124(new Mid0125(new Mid0126(new Mid0127(new Mid0128(new Mid0129(
                             new Mid0130(new Mid0131(new Mid0132(new Mid0133(new Mid0120(new Mid0140(null)))))))))))))));
        }

        public AdvancedJobMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            _templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package) => _templates.Parse(package);

        public Mid ProcessPackage(byte[] package) => _templates.Parse(package);
    }
}
