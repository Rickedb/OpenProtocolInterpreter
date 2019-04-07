using System.Collections.Generic;
using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.ApplicationSelector
{
    internal class ApplicationSelectorMessages : IMessagesTemplate
    {
        private readonly IMid _templates;

        public ApplicationSelectorMessages()
        {
            _templates = new Mid0250(new Mid0251(new Mid0252(new Mid0253(new Mid0254(new Mid0255(null))))));
        }

        public ApplicationSelectorMessages(IEnumerable<Mid> selectedMids)
        {
            _templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package) => _templates.Parse(package);

        public Mid ProcessPackage(byte[] package) => _templates.Parse(package);
    }
}
