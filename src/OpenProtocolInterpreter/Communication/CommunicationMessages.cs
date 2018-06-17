using System.Collections.Generic;
using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Communication
{
    internal class CommunicationMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public CommunicationMessages()
        {
            templates = new Mid0005(new Mid0004(new Mid0001(new Mid0002(new Mid0003(null)))));
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
