using OpenProtocolInterpreter.Messages;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Tightening
{
    internal class TighteningMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public TighteningMessages()
        {
            templates = new Mid0061(
                                    new Mid0065(
                                        new Mid0062(
                                            new Mid0064(
                                                new Mid0063(
                                                    new Mid0060(null))))));
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
            return templates.Parse(package);
        }

        private IMid InitIntegratorTemplates()
        {
            return new Mid0062(new Mid0064(new Mid0063(new Mid0060(null))));
        }

        private IMid InitControllerTemplates()
        {
            return new Mid0061(new Mid0065(null));
        }
    }
}
