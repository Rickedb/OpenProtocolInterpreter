using System;

namespace OpenProtocolInterpreter.MIDs.Job.Advanced
{
    internal class AdvancedJobMessages : IMessagesTemplate
    {
        private readonly IMID nextTemplate;

        public AdvancedJobMessages()
        {
            this.nextTemplate = new MID_0127(null);
        }

        public MID processPackage(string package)
        {
            return this.nextTemplate.processPackage(package);
        }
    }
}
