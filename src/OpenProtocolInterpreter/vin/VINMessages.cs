using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Vin
{
    internal class VinMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public VinMessages()
        {
            templates = new MID_0050(new MID_0051(new MID_0052(new MID_0053(new MID_0054(null)))));
        }

        public VinMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.ProcessPackage(package);
        }
    }
}
