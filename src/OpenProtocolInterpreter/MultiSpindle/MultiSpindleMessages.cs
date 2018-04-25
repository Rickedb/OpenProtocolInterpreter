using OpenProtocolInterpreter.Messages;
using OpenProtocolInterpreter.MultiSpindle.Status;

namespace OpenProtocolInterpreter.MultiSpindle
{
    internal class MultiSpindleMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public MultiSpindleMessages()
        {
            templates = new MID_0090(new MID_0091(new MID_0092(null)));
        }

        public MultiSpindleMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.ProcessPackage(package);
        }
    }
}
