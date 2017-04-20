using OpenProtocolInterpreter.Messages;


namespace OpenProtocolInterpreter.MIDs.ParameterSet
{
    internal class ParameterSetMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public ParameterSetMessages()
        {
            this.templates = new MID_0010(new MID_0011(new MID_0012(new MID_0013(new MID_0014(new MID_0015(new MID_0016(
                             new MID_0017(new MID_0018(new MID_0019(new MID_0020(new MID_0021(new MID_0022(new MID_0023(
                             new MID_0024(new MID_2504(null))))))))))))))));
        }

        public ParameterSetMessages(System.Collections.Generic.IEnumerable<MID> selectedMids)
        {
            this.templates = MessageTemplateFactory.buildChainOfMids(selectedMids);
        }

        public MID processPackage(string package)
        {
            return this.templates.processPackage(package);
        }
    }
}
