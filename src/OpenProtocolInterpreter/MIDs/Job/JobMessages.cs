using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenProtocolInterpreter.MIDs.Job
{
    internal class JobMessages : IMessagesTemplate
    {
        private readonly IMID templates;

        public JobMessages()
        {
            this.templates = new MID_0035(new MID_0036(new MID_0038(new MID_0034(new MID_0036(null)))));
        }

        public MID processPackage(string package)
        {
            return this.templates.processPackage(package);
        }
    }
}
