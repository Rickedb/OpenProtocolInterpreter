using OpenProtocolInterpreter.Messages;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Alarm
{
    internal class AlarmMessages : IMessagesTemplate
    {
        private readonly IMid _templates;

        public AlarmMessages()
        {
            _templates = new Mid0070(new Mid0071(new Mid0072(new Mid0073(new Mid0074(new Mid0075(
                             new Mid0076(new Mid0077(new Mid0078(null)))))))));
        }

        public AlarmMessages(IEnumerable<Mid> selectedMids)
        {
            _templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package) => _templates.Parse(package);

        public Mid ProcessPackage(byte[] package) => _templates.Parse(package);
    }
}
