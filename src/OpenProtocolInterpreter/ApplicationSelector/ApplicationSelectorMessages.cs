using System.Collections.Generic;
using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.ApplicationSelector
{
    internal class ApplicationSelectorMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public ApplicationSelectorMessages()
        {
            this.templates = new MID_0250(new MID_0251(new MID_0252(new MID_0253(new MID_0254(new MID_0255(null))))));
        }

        public ApplicationSelectorMessages(IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public MID ProcessPackage(string package)
        {
            return this.templates.ProcessPackage(package);
        }
    }
}
