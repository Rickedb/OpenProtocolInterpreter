using System.Collections.Generic;
using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Communication
{
    internal class CommunicationMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public CommunicationMessages()
        {
            templates = new MID_0005(new MID_0004(new MID_0001(new MID_0002(new MID_0006(null)))));
        }

        public CommunicationMessages(IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
