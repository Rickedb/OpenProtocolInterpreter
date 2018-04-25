using System.Collections.Generic;
using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.ApplicationSelector
{
    internal class ApplicationSelectorMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public ApplicationSelectorMessages()
        {
            templates = new MID_0250(new MID_0251(new MID_0252(new MID_0253(new MID_0254(new MID_0255(null))))));
        }

        public ApplicationSelectorMessages(IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.ProcessPackage(package);
        }
    }
}
