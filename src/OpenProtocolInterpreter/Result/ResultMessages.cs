using OpenProtocolInterpreter.Messages;
using System.Collections.Generic;

namespace OpenProtocolInterpreter.Result
{
    public class ResultMessages : IMessagesTemplate
    {
        private readonly IMid _templates;

        public ResultMessages()
        {
            _templates = new Mid1201(new Mid1202(new Mid1203()));
        }

        public ResultMessages(bool onlyController)
        {
            _templates = onlyController ? InitControllerTemplates() : InitIntegratorTemplates();
        }

        public ResultMessages(IEnumerable<Mid> selectedMids)
        {
            _templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return _templates.Parse(package);
        }

        private IMid InitIntegratorTemplates() => new Mid1203();
        

        private IMid InitControllerTemplates()
        {
            return new Mid1201(new Mid1202(null));
        }
    }
}
