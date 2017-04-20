using System.Collections.Generic;
using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MIDs.Communication
{
    internal class CommunicationMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public CommunicationMessages()
        {
            this.templates = new MID_0005(new MID_0004(new MID_0001(new MID_0002(new MID_0006(null)))));
        }

        public CommunicationMessages(IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.buildChainOfMids(selectedMids);
        }

        public MID processPackage(string package)
        {
            return this.templates.processPackage(package);
        }
    }
}
