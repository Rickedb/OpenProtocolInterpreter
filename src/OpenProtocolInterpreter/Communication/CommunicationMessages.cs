using System.Collections.Generic;
using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.Communication
{
    internal class CommunicationMessages : IMessagesTemplate
    {
        private readonly IMid _templates;

        public CommunicationMessages()
        {
            _templates = new Mid0005(new Mid0004(new Mid0001(new Mid0002(new Mid0003(new Mid0006(new Mid0008(null)))))));
        }

        public CommunicationMessages(IEnumerable<Mid> selectedMids)
        {
            _templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package) => _templates.Parse(package);

        public Mid ProcessPackage(byte[] package) => _templates.Parse(package);
    }
}
