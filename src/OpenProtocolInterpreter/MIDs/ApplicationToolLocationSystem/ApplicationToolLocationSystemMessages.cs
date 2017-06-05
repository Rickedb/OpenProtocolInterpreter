using System.Collections.Generic;
using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MIDs.ApplicationToolLocationSystem
{
    internal class ApplicationToolLocationSystemMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public ApplicationToolLocationSystemMessages()
        {
            this.templates = new MID_0260(new MID_0261(new MID_0262(new MID_0263(new MID_0264(new MID_0265(null))))));
        }

        public ApplicationToolLocationSystemMessages(IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.buildChainOfMids(selectedMids);
        }

        public MID processPackage(string package)
        {
            return this.templates.processPackage(package);
        }
    }
}
