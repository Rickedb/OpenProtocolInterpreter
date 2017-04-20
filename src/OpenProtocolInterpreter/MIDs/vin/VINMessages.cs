using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MIDs.VIN
{
    internal class VINMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public VINMessages()
        {
            this.templates = new MID_0050(new MID_0051(new MID_0052(new MID_0053(new MID_0054(null)))));
        }

        public VINMessages(System.Collections.Generic.IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.buildChainOfMids(selectedMids);
        }

        public MID processPackage(string package)
        {
            return this.templates.processPackage(package);
        }
    }
}
