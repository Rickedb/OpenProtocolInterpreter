using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MIDs.PowerMACS
{
    internal class PowerMACSMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public PowerMACSMessages()
        {
            this.templates = new MID_0105(new MID_0106(null));
        }

        public PowerMACSMessages(System.Collections.Generic.IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.buildChainOfMids(selectedMids);
        }

        public MID processPackage(string package)
        {
            return this.templates.processPackage(package);
        }
    }
}
