using OpenProtocolInterpreter.Messages;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tightening
{
    internal class TighteningMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public TighteningMessages()
        {
            templates = new MID_0061(
                                    new MID_0065(
                                        new MID_0062(
                                            new MID_0064(
                                                new MID_0063(
                                                    new MID_0060(null))))));
        }

        public TighteningMessages(bool onlyController)
        {
            templates = (onlyController) ? InitControllerTemplates() : InitIntegratorTemplates();
        }

        public TighteningMessages(IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.ProcessPackage(package);
        }

        private IMid InitIntegratorTemplates()
        {
            return new MID_0062(new MID_0064(new MID_0063(new MID_0060(null))));
        }

        private IMid InitControllerTemplates()
        {
            return new MID_0061(new MID_0065(null));
        }
    }
}
