using OpenProtocolInterpreter.Messages;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.MIDs.Alarm
{
    internal class AlarmMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public AlarmMessages()
        {
            this.templates = new MID_0070(new MID_0071(new MID_0072(new MID_0073(new MID_0074(new MID_0075(
                             new MID_0076(new MID_0077(new MID_0078(null)))))))));
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
