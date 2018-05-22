using System.Collections.Generic;
using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.ApplicationToolLocationSystem
{
    internal class ApplicationToolLocationSystemMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public ApplicationToolLocationSystemMessages()
        {
            templates = new MID_0260(new MID_0261(new MID_0262(new MID_0263(new MID_0264(new MID_0265(null))))));
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
