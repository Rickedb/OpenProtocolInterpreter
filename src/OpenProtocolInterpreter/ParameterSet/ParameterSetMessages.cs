using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.ParameterSet
{
    internal class ParameterSetMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public ParameterSetMessages()
        {
            templates = new Mid0010(new Mid0011(new Mid0012(new Mid0013(new Mid0014(new Mid0015(new Mid0016(
                             new Mid0017(new Mid0018(new Mid0019(new Mid0020(new Mid0021(new Mid0022(new Mid0023(
                             new Mid0024(new Mid2504(null))))))))))))))));
        }

        public ParameterSetMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
