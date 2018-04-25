using OpenProtocolInterpreter.Messages;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Alarm
{
    internal class AlarmMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public AlarmMessages()
        {
            templates = new MID_0070(new MID_0071(new MID_0072(new MID_0073(new MID_0074(new MID_0075(
                             new MID_0076(new MID_0077(new MID_0078(null)))))))));
        }

        public AlarmMessages(IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.ProcessPackage(package);
        }
    }
}
