using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.PowerMACS
{
    internal class PowerMACSMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public PowerMACSMessages()
        {
            templates = new MID_0105(new MID_0106(new MID_0107(new MID_0108(new MID_0109(null)))));
        }

        public PowerMACSMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
