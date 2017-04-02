namespace OpenProtocolInterpreter.MIDs.Reply
{
    internal class ReplyMessages : IMessagesTemplate
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
