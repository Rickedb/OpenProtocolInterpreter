using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Time
{
    internal class TimeMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public TimeMessages()
        {
            templates = new MID_0080(new MID_0081(new MID_0082(null)));
        }

        public TimeMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
