using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.ParameterSet
{
    internal class ParameterSetMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public ParameterSetMessages()
        {
            templates = new MID_0010(new MID_0011(new MID_0012(new MID_0013(new MID_0014(new MID_0015(new MID_0016(
                             new MID_0017(new MID_0018(new MID_0019(new MID_0020(new MID_0021(new MID_0022(new MID_0023(
                             new MID_0024(new MID_2504(null))))))))))))))));
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
