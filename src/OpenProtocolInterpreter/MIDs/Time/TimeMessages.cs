using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MIDs.Time
{
    internal class TimeMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public TimeMessages()
        {
            this.templates = new MID_0080(new MID_0081(new MID_0082(null)));
        }

        public TimeMessages(System.Collections.Generic.IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.buildChainOfMids(selectedMids);
        }

        public MID processPackage(string package)
        {
            return this.templates.processPackage(package);
        }
    }
}
