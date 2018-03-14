using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Job
{
    internal class JobMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public JobMessages()
        {
            this.templates = new MID_0035(new MID_0036(new MID_0038(new MID_0034(new MID_0037(new MID_0030(
                             new MID_0031(new MID_0032(new MID_0033(null)))))))));
        }

        public JobMessages(System.Collections.Generic.IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public MID ProcessPackage(string package)
        {
            return this.templates.ProcessPackage(package);
        }
    }
}
