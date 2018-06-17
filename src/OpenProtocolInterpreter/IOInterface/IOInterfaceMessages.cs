using System.Collections.Generic;
using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.IOInterface
{
    internal class IOInterfaceMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public IOInterfaceMessages()
        {
            templates = new Mid0200(new Mid0210(new Mid0211(new Mid0212(new Mid0213( new Mid0214(
                             new Mid0215(new Mid0216(new Mid0217(new Mid0218( new Mid0219(new Mid0220(
                             new Mid0221(new Mid0222(new Mid0223(new Mid0224(new Mid0225(null)))))))))))))))));
        }

        public IOInterfaceMessages(IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
