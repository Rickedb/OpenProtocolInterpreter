using OpenProtocolInterpreter.Messages;

namespace OpenProtocolInterpreter.MotorTuning
{
    internal class MotorTuningMessages : IMessagesTemplate
    {
        private readonly IMid templates;

        public MotorTuningMessages()
        {
            templates = new MID_0500(new MID_0501(new MID_0502(new MID_0503(new MID_0504(null)))));
        }

        public MotorTuningMessages(System.Collections.Generic.IEnumerable<Mid> selectedMids)
        {
            templates = MessageTemplateFactory.BuildChainOfMids(selectedMids);
        }

        public Mid ProcessPackage(string package)
        {
            return templates.Parse(package);
        }
    }
}
