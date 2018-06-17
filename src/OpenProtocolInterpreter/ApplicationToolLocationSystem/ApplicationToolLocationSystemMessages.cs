using System.Collections.Generic;
using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    internal class ApplicationToolLocationSystemMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public ApplicationToolLocationSystemMessages()
        {
            templates = new Mid0260(new Mid0261(new Mid0262(new Mid0263(new Mid0264(new Mid0265(null))))));
        }

        public ApplicationToolLocationSystemMessages(IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
