using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Job
{
    internal class JobMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public JobMessages()
        {
            templates = new MID_0035(new MID_0036(new MID_0038(new MID_0034(new MID_0037(new MID_0030(
                             new MID_0031(new MID_0032(new MID_0033(null)))))))));
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
