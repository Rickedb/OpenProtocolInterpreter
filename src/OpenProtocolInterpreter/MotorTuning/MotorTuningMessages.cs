using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MotorTuning
{
    internal class MotorTuningMessages : IMessagesTemplate
    {
        private readonly IMid _templates;

        public MotorTuningMessages()
        {
            _templates = new Mid0500(new Mid0501(new Mid0502(new Mid0503(new Mid0504(null)))));
        }

        public MotorTuningMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            _templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package) => _templates.Parse(package);

        public Mid ProcessPackage(byte[] package) => _templates.Parse(package);
    }
}
