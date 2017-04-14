using OpenProtocolInterpreter.Messages;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MIDs.Alarm
{
    internal class AlarmMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public AlarmMessages()
        {
            this.templates = new MID_0070(new MID_0071(new MID_0072(null)));
        }

        public AlarmMessages(IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.buildChainOfMids(selectedMids);
        }

        public MID processPackage(string package)
        {
            return this.templates.processPackage(package);
        }
    }
}
