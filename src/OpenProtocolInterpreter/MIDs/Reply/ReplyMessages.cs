using OpenProtocolInterpreter.MIDs.Interfaces;

namespace OpenProtocolInterpreter.MIDs.Reply
{
    public class ReplyMessages
    {
        private readonly IMID templates;

        public ReplyMessages()
        {
            this.templates = new MID_0005(new MID_0004(null));
        }

        public MID processPackage(string package)
        {
            return this.templates.processPackage(package);
        }
    }
}
