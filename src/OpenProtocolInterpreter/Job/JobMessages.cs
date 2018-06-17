using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Job
{
    internal class JobMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public JobMessages()
        {
            templates = new Mid0035(new Mid0036(new Mid0038(new Mid0034(new Mid0037(new Mid0039(new Mid0030(
                             new Mid0031(new Mid0032(new Mid0033(null))))))))));
        }

        public JobMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
