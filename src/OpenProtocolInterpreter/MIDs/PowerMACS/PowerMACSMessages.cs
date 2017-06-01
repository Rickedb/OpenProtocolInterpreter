using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MIDs.PowerMACS
{
    internal class PowerMACSMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public PowerMACSMessages()
        {
            this.templates = new MID_0105(new MID_0106(new MID_0107(new MID_0108(new MID_0109(null)))));
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
